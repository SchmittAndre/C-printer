using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace Filobserverwindow
{
    public partial class TabLayoutUC : UserControl
    {
        string observerdirstr;
        FileSystemWatcher watcher1;
        Dictionary<string, FileandTimer> createdfiles;
        private static System.Timers.Timer timer1;
        private Font printFont;
        private SolidBrush printColor;
        Printer Printer;

        public TabLayoutUC()
        {
            InitializeComponent();
            printFont = new Font("Arial", 12);
            printColor = new SolidBrush(Color.Black);
            Printer = new Printer();
            createdfiles = new Dictionary<string, FileandTimer>();
            observerdir.Text = observerdirstr;
            TextPeview.Text = "abcABC123";
            TextPeview.Font = printFont;
            TextPeview.ForeColor = printColor.Color;
        }

        private void observerdialog_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            observerdirstr = folderBrowserDialog1.SelectedPath;
            observerdir.Text = observerdirstr;
        }

        private void startobserver_Click(object sender, EventArgs e)
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
                startobserver.Enabled = false;
            }
        }

        static void watcher1_Changed(object source, FileSystemEventArgs e)
        {
            Debug.Print("File " + e.Name + " was " + e.ChangeType);
        }

        void watcher1_Created(object sender, FileSystemEventArgs e)
        {
            Debug.Print("File " + e.Name + " was" + e.ChangeType + " Timer started");
            timer1 = new System.Timers.Timer((int)(delaytime1.Value * 1000));
            FileandTimer temp = new FileandTimer(timer1, e, Printer, printColor, printFont, printDocument1, ShallDelete.Checked);
            // Hook up the Elapsed event for the timer. 
            temp.TimerOfFile.Elapsed += temp.Timer1Tick;
            temp.TimerOfFile.AutoReset = false;
            temp.TimerOfFile.Enabled = true;
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

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Debug.Print("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            FileandTimer temp = createdfiles[e.OldName];
            createdfiles.Remove(e.OldName);
            temp.Datei = e;
            createdfiles.Add(e.Name, temp);

        }

        private void B_Fonts_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = printFont;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                printFont = fontDialog1.Font;
                TextPeview.Font = printFont;
            }
        }

        private void B_Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            printColor = new SolidBrush(colorDialog1.Color);
            TextPeview.ForeColor = printColor.Color;
        }

        private void B_pageSettup_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            this.pageSetupDialog1.Document = this.printDocument1;
            this.pageSetupDialog1.ShowDialog();
        }

        private void chosePrinter_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog2 = new PrintDialog();
            printDialog2.Document = printDocument1;
            DialogResult result = printDialog2.ShowDialog();
        }
    }
}
