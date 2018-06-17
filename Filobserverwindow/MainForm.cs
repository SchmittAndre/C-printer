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

namespace Filobserverwindow
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        string observerdirstr;
        FileSystemWatcher watcher;
        Dictionary<string, FileandTimer> createdfiles;
        private static System.Timers.Timer timer1;
        private Font printFont;
        private SolidBrush printColor;
        Printer Printer;

        public MainForm()
        {
            InitializeComponent();
            printFont = new Font("courier new", 11);
            printColor = new SolidBrush(Color.Black);
            Printer = new Printer();
            createdfiles = new Dictionary<string, FileandTimer>();
            observerdir.Text = observerdirstr;
            TextPeview.Text = "abcABC123";
            TextPeview.Font = printFont;
            TextPeview.ForeColor = printColor.Color;
            BtStop.Enabled = false;
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
                watcher = new FileSystemWatcher(observerdirstr);
                Debug.Print("Start twatcher1");
                watcher.Changed += new FileSystemEventHandler(Watcher1_Changed);
                watcher.Created += new FileSystemEventHandler(Watcher1_Created);
                watcher.Deleted += new FileSystemEventHandler(Watcher1_Deleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.EnableRaisingEvents = true;
                startobserver.Enabled=false;
                BtStop.Enabled = true;
            }
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            Debug.Print("stop watcher");
            startobserver.Enabled = true;
            BtStop.Enabled = false;
        }

        static void Watcher1_Changed(object source, FileSystemEventArgs e)
        {
            Debug.Print("File " + e.Name + " was " + e.ChangeType);
        }

        void Watcher1_Created(object sender, FileSystemEventArgs e)
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

        void Watcher1_Deleted(object source, FileSystemEventArgs e)
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
            this.pageSetupDialog1.Document= this.printDocument1;
            this.pageSetupDialog1.ShowDialog();
                
        }
        
        private void ChosePrinterClick(object sender, EventArgs e)
        {
            PrintDialog printDialog2 = new PrintDialog();
            printDialog2.Document = printDocument1;
            DialogResult result = printDialog2.ShowDialog();
        }
        
        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Printer.PrintThreadstop = true;
            Printer.PrintThread.Join();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage((tabControl1.Controls.Count + 1).ToString());
            test.Controls.Add(new TabLayoutUC());
            tabControl1.Controls.Add(test);

        }
    }

}
