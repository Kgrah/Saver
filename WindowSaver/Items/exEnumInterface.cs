using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

//Don't add the entire interop namespace, it will introduce some naming conflicts.
using xlApp = Microsoft.Office.Interop.Excel.Application;

namespace ExcelExtensions
{

    /// <summary>
    /// Collection of currently running Excel instances.
    /// </summary>
    public partial class ExcelAppCollection : IEnumerable<xlApp>
    {

        #region Constructors

        /// <summary>Initializes a new instance of the 
        /// <see cref="ExcelAppCollection"/> class.</summary>
        /// <param name="sessionID">Windows sessionID to filter instances by.
        /// If not assigned, uses current session.</param>
        public ExcelAppCollection(Int32? sessionID = null)
        {
            if (sessionID.HasValue && sessionID.Value < -1)
                throw new ArgumentOutOfRangeException("sessionID");

            this.SessionID = sessionID
                ?? Process.GetCurrentProcess().SessionId;
        }

        #endregion

        #region Properties

        /// <summary>Gets the Windows sessionID used to filter instances.
        /// If -1, uses instances from all sessions.</summary>
        /// <value>The sessionID.</value>
        public Int32 SessionID { get; private set; }

        #endregion

        #region Accessors

        /// <summary>Gets the Application associated with a given process.</summary>
        /// <param name="process">The process.</param>
        /// <returns>Application associated with process.</returns>
        /// <exception cref="System.ArgumentNullException">process</exception>
        public xlApp FromProcess(Process process)
        {
            if (process == null)
                throw new ArgumentNullException("process");
            return InnerFromProcess(process);
        }

        /// <summary>Gets the Application associated with a given processID.</summary>
        /// <param name="processID">The process identifier.</param>
        /// <returns>Application associated with processID.</returns>
        public xlApp FromProcessID(Int32 processID)
        {
            try
            {
                return FromProcess(Process.GetProcessById(processID));
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        /// <summary>Get the Application associated with a given window handle.</summary>
        /// <param name="mainHandle">The window handle.</param>
        /// <returns>Application associated with window handle.</returns>
        public xlApp FromMainWindowHandle(Int32 mainHandle)
        {
            return InnerFromHandle(ChildHandleFromMainHandle(mainHandle));
        }

        /// <summary>Gets the main instance. </summary>
        /// <remarks>This is the oldest running instance.
        /// It will be used if an Excel file is double-clicked in Explorer, etc.</remarks>
        public xlApp PrimaryInstance
        {
            get
            {
                try
                {
                    return Marshal.GetActiveObject(MarshalName) as xlApp;
                }
                catch (COMException)
                {
                    return null;
                }
            }
        }

        /// <summary>Gets the top most instance.</summary>
        /// <value>The top most instance.</value>
        public xlApp TopMostInstance
        {
            get
            {
                var topMost = GetProcesses() //All Excel processes
                    .Select(p => p.MainWindowHandle) //All Excel main window handles
                    .Select(h => new { h = h, z = GetWindowZ(h) }) //Get (handle, z) pair per instance
                    .Where(x => x.z > 0) //Filter hidden instances
                    .OrderBy(x => x.z) //Sort by z value
                    .First(); //Lowest z value

                return FromMainWindowHandle(topMost.h.ToInt32());
            }
        }

        #endregion

        #region My Methods
        public void getPaths(Process p)
        {
            /*Handle = FromProcess(p);
            GetFinalPathNameByHandle(FromProcess())*/
        }

        public void fromModule(Process p)
        {

            //GetModuleFileName();
        }
        
        #endregion      

        #region Methods

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> 
        /// that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<xlApp> GetEnumerator()
        {
            foreach (var p in GetProcesses())
                yield return FromProcess(p);
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        /// <summary>Gets all Excel processes in the current session.</summary>
        /// <returns>Collection of all Excel processing in the current session.</returns>
        public IEnumerable<Process> GetProcesses()
        {

            IEnumerable<Process> result = Process.GetProcessesByName(ProcessName);

            if (this.SessionID >= 0)
                result = result.Where(p => p.SessionId == SessionID);

            return result;
        }

        #endregion
    }
}