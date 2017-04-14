using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using ExcelExtensions;
using Application = Microsoft.Office.Interop.Excel.Application;
using Window = Microsoft.Office.Interop.Excel.Windows;
using SHDocVw;

namespace WindowSaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region methods
         
        //displays processes in testbox1
        public static string[] getProcesses()
        {
            Process[] procs;
            procs = Process.GetProcesses();
            string[] procArray = new string[procs.Length];
            for (int i = 0; i < procs.Length; i++)
            {
                    procArray[i] = procs[i].ProcessName;
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

        //launches URLs written to file internet explorer
        public static void runIE(int rCounter)
        {
            string[] lines = File.ReadAllLines(@"C:\\Users\\Kyle\\Documents\\WindowSaver\\TestFiles0.txt", Encoding.UTF8);
            int counter = 0;
            int urlCounter = 0;
            foreach (string line in lines)
            {
                if (isUrlValid(line))
                {
                    urlCounter++;
                }
            }
            string[] url = new string[urlCounter];
            foreach (string line in lines)
            {
                if (isUrlValid(line))
                {
                    url[counter] = line;
                    counter++;
                }
            }
            Process browser = new Process();
            ProcessStartInfo psiObject = new ProcessStartInfo(url[0]);
            browser.StartInfo = psiObject;
            browser.Start();
            Thread.Sleep(1500);
            for (int i =1; i< url.Length; i++)
            {
                Process.Start(url[i]);
            }
        }

        //runs filepaths written in explorer.exe
        public static void runExplorer()
        {
            string[] lines = File.ReadAllLines(@"C:\\Users\\Kyle\\Documents\\WindowSaver\\TestFiles0.txt", Encoding.UTF8);
            foreach (String line in lines)
            {
                if (!isUrlValid(line))
                {
                    Process.Start("explorer.exe", line);
                }
            }
        }

        //checks string for valid URL
        public static bool isUrlValid(string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        //grabs file handle of open excel instances
        public static void excelHandle()
        {
            var myApps = new ExcelAppCollection();
            string[] xlInst;
            IEnumerable<Process> procs = myApps.GetProcesses();
            foreach (Process p in procs)
            {
                int i = 0;
                try
                {

                }
                catch (Exception ex) { Console.WriteLine(ex); }
                
            }
        }

        public static void iEInstances()
        {            
            ShellWindows iEInstances = new ShellWindows();
            string[] arr = new string[1000];
            int i = 0;
            foreach ( InternetExplorer ie in iEInstances )
            {
                arr[i++] = ie.Name;
                MessageBox.Show(ie.LocationName);
            }
        }

        #endregion

        #region ClickMethods
        private void writeButton_Click(object sender, EventArgs e)
        {
            procsWrite();
        }

        private void runButton_Click(object sender, EventArgs e)
        {

            runIE(0);
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
            bool url = isUrlValid(textBox1.Text);
            MessageBox.Show(url.ToString());
        }

        private void excelTestB_Click(object sender, EventArgs e)
        {
            HandleHandler.getDirectories();   
        }

        private void txtFileButton_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Kyle\Documents\WindowSaver\TestFiles" + 0 + ".txt");
        }

        private void iEInstB_Click(object sender, EventArgs e)
        {
            iEInstances();
        }

        #endregion
    }
}
