using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelExtensions;
using Application = Microsoft.Office.Interop.Excel.Application;
using Window = Microsoft.Office.Interop.Excel.Window;
using System.Diagnostics;

namespace WindowSaver.Items
{
    class Test
    {
        public static void excelHandle()
        {
            var myApps = new ExcelAppCollection();

            IEnumerable<Process> procs = myApps.GetProcesses();
            foreach (Process p in procs)
            {
                try
                {
                    Application a = myApps.FromProcess(p);
                    string fullPath = a.ActiveWorkbook.FullName;
                    Console.WriteLine(a);
                }
                catch (Exception ex) { Console.WriteLine(ex); }
            }
            Console.ReadLine();
        }
    }
}
