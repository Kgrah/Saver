using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
namespace WindowSaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //displays processes in testbox1
        public static string[] getProcesses()
        {
            Process[] procs;
            procs = Process.GetProcesses();
            string[] procArray = new string[procs.Length];
            for (int i = 0; i < procs.Length; i++)
            {
                if (procArray[i].Contains("excel"))
                {
                    procArray[i] = procs[i].ProcessName;
                }
            }
            for (int i = 0; i < procArray.Length; i++)
            {
                string[] trueProcesses = procArray;
                trueProcesses[i] = Path.GetFullPath(procArray[i]);
            }
            return procArray;
        }

        public static string getFileLocation()
        {
            return @"C:\\Users\\Kyle\\Documents\\WindowSaver\\TestFiles0.txt";
        }

        //kills programs written to file
        public static void kill()
        {
            /*getFileLocation();
            for (int i = 0; i < sa.Length; i++)
            {
                
            }*/

            //Write class for this stuff?
            string[] lines = File.ReadAllLines(@"C:\\Users\\Kyle\\Documents\\WindowSaver\\TestFiles0.txt", Encoding.UTF8);
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    Process[] proc = Process.GetProcessesByName(lines[i]);
                    proc[i].Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("try again");
            }
         
          }

        //writes processes to a text file
        public static string[] procsWrite()
        {
            int i = 0;
            string[] procsTest = new string[100];
            int fileCounter = 0;
            LinkedList<string> urls = new LinkedList<string>();
            foreach (SHDocVw.InternetExplorer ieInst in new SHDocVw.ShellWindows())
            {
                string url = ieInst.LocationURL.ToString();
                Console.WriteLine(url);
                urls.AddFirst(url);
            }
            System.IO.File.WriteAllLines(@"C:\Users\Kyle\Documents\WindowSaver\TestFiles" + fileCounter + ".txt", urls);
            Process.Start(@"C:\Users\Kyle\Documents\WindowSaver\TestFiles" + fileCounter + ".txt");

            return procsTest;
        }

        //runs programs written to file
        public static void runIE()
        {
            string[] lines = File.ReadAllLines(@"C:\\Users\\Kyle\\Documents\\WindowSaver\\TestFiles0.txt", Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++)
            {
                Process process = new Process();
                Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe", lines[i]);
            }
        }

        //checks string for valid URL
        private bool IsUrlValid(string url)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            procsWrite();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            runIE();
        }

        private void getProcsButton_Click(object sender, EventArgs e)
        {
            string[] toPrint = getProcesses();
            for (int i = 0; i < toPrint.Length; i++)
            {
                testBox1.Text = testBox1.Text + "\n" + toPrint[i];
            }
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            kill();
        }

        private void urlTest_Click(object sender, EventArgs e)
        {
            //testBox1.Text.Equals(IsUrlValid(textBox1.Text));
            string test = textBox1.Text;
            MessageBox.Show("you typed " + test);
        }

        private void excelTestB_Click(object sender, EventArgs e)
        {
            try
            {
                //Excel Application Object
                Microsoft.Office.Interop.Excel.Application oExcelApp;

                this.Activate();

                //Get reference to Excel.Application from the ROT.
                oExcelApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("excel.application");

                //Display the name of the object.
                MessageBox.Show(oExcelApp.ActiveWorkbook.FullName);

                //Release the reference
                oExcelApp = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
