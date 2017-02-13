/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schmitta
 * Datum: 19.01.2017
 * Zeit: 08:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Configuration;

namespace Filobserverwindow
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        string observerdirstr;
        FileSystemWatcher watcher1;
        Dictionary<string, FileandTimer> createdfiles;
        private static System.Timers.Timer timer1;
        private Font printFont;
        private SolidBrush printColor;
        printer Printer = new printer();
        PrintDialog printDialog1 = new PrintDialog();

        public MainForm()
        {
            InitializeComponent();
            createdfiles = new Dictionary<string, FileandTimer>();
            observerdir.Text = observerdirstr;
        }


        void ObserverdialogClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            observerdirstr = folderBrowserDialog1.SelectedPath;
            observerdir.Text = observerdirstr;
        }

        void StartobserverClick(object sender, EventArgs e)
        {
            if (Directory.Exists(observerdirstr))
            {
                watcher1 = new FileSystemWatcher(observerdirstr);
                Debug.Print("Start twatcher1");
                watcher1.Changed += new FileSystemEventHandler(watcher1_Changed);
                watcher1.Created += new FileSystemEventHandler(watcher1_Created);
                watcher1.Deleted += new FileSystemEventHandler(watcher1_Deleted);
                watcher1.Renamed += new RenamedEventHandler(OnRenamed);
                watcher1.EnableRaisingEvents = true;
            }
        }

        static void watcher1_Changed(object source, FileSystemEventArgs e)
        {
            Debug.Print("File " + e.Name + " was " + e.ChangeType);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Debug.Print("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            FileandTimer temp = createdfiles[e.OldName];
            createdfiles.Remove(e.OldName);
            temp.Datei = e;
            createdfiles.Add(e.Name, temp);

        }

        void watcher1_Deleted(object source, FileSystemEventArgs e)
        {
            Debug.Print("File " + e.Name + " was " + e.ChangeType);
            try
            {
                FileandTimer temp = createdfiles[e.Name];
                temp.TimerOfFile.Stop();
                createdfiles.Remove(e.Name);
            }
            catch
            {
                Debug.Print("deleted file ignored");
            }
        }

        void watcher1_Created(object sender, FileSystemEventArgs e)
        {
            Debug.Print("File " + e.Name + " was" + e.ChangeType + " Timer started");
            timer1 = new System.Timers.Timer((int)(delaytime1.Value * 1000));
            FileandTimer temp = new FileandTimer(timer1, e , Printer, printColor, printFont, printDocument1);
            // Hook up the Elapsed event for the timer. 
            temp.TimerOfFile.Elapsed += temp.Timer1Tick;
            temp.TimerOfFile.AutoReset = false;
            temp.TimerOfFile.Enabled = true;
            createdfiles.Add(e.Name, temp);
        }

        private void B_Fonts_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            printFont = fontDialog1.Font;
        }

        private void B_Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            printColor = new SolidBrush(colorDialog1.Color);
        }

        private void B_pageSettup_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.Document = printDocument1;
            this.pageSetupDialog1.ShowDialog();
        }

        private void chosePrinter_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
          
        }
    }

}
