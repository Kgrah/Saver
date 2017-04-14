using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

//Don't import the entire namespace, this will cause name conflicts.
using xlApp = Microsoft.Office.Interop.Excel.Application;
using xlWin = Microsoft.Office.Interop.Excel.Window;

namespace ExcelExtensions
{

    public partial class ExcelAppCollection
    {

        #region My Methods
        #endregion

        #region Methods

        private static xlApp InnerFromProcess(Process p)
        {
            return InnerFromHandle(ChildHandleFromMainHandle(p.MainWindowHandle.ToInt32()));
        }

        private static Int32 ChildHandleFromMainHandle(Int32 mainHandle)
        {
            Int32 handle = 0;
            EnumChildWindows(mainHandle, EnumChildFunc, ref handle);
            return handle;
        }

        private static xlApp InnerFromHandle(Int32 handle)
        {
            //assign the handle to be that excel window
            //then grab application object
            xlWin win = null;
            Int32 hr = AccessibleObjectFromWindow(handle, DW_OBJECTID, rrid.ToByteArray(), ref win);
            return win.Application;
        }

        private static Int32 GetWindowZ(IntPtr handle)
        {
            var z = 0;
            for (IntPtr h = handle; h != IntPtr.Zero; h = GetWindow(h, GW_HWNDPREV))
                z++;
            return z;
        }

        private static Boolean EnumChildFunc(Int32 hwndChild, ref Int32 lParam)
        {
            var buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == ComClassName)
            {
                lParam = hwndChild;
                return false;
            }
            return true;
        }

        #endregion

        #region Extern Methods

        [DllImport("Oleacc.dll")]
        private static extern Int32 AccessibleObjectFromWindow(
            Int32 hwnd, UInt32 dwObjectID, Byte[] riid, ref xlWin ptr);

        [DllImport("User32.dll")]
        private static extern Boolean EnumChildWindows(
            Int32 hWndParent, EnumChildCallback lpEnumFunc, ref Int32 lParam);

        [DllImport("User32.dll")]
        private static extern Int32 GetClassName(
            Int32 hWnd, StringBuilder lpClassName, Int32 nMaxCount);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, UInt32 uCmd);

        [DllImport("Kernel32.dll", SetLastError =
            true, CharSet = CharSet.Auto)]
        static extern uint
        GetFinalPathNameByHandle(IntPtr hfile,
            [MarshalAs(UnmanagedType.LPTStr)]
            StringBuilder lpszFilePath, uint
            cchFilePath, uint dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        [PreserveSig]
        public static extern uint GetModuleFileName
        (
            [In]
            IntPtr hModule,

            [Out]
            StringBuilder lpFilename,

            [In]
            [MarshalAs(UnmanagedType.U4)]
            int nSize
        );

        [DllImport("kernel32.dll")]
            static extern uint GetFullPathName(string lpFileName, uint nBufferLength,
            [Out] StringBuilder lpBuffer, out StringBuilder lpFilePart);

        #endregion

        #region Constants & delegates

        private const String MarshalName = "Excel.Application";

        private const String ProcessName = "EXCEL";

        private const String ComClassName = "EXCEL7";

        private const UInt32 DW_OBJECTID = 0xFFFFFFF0;

        private const UInt32 GW_HWNDPREV = 3;
        //3 = GW_HWNDPREV
        //The retrieved handle identifies the window above the specified window in the Z order.
        //If the specified window is a topmost window, the handle identifies a topmost window.
        //If the specified window is a top-level window, the handle identifies a top-level window.
        //If the specified window is a child window, the handle identifies a sibling window.

        private static Guid rrid = new Guid("{00020400-0000-0000-C000-000000000046}");

        private delegate Boolean EnumChildCallback(Int32 hwnd, ref Int32 lParam);
        #endregion
    }
}
