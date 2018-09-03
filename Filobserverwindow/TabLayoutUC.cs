﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Filobserverwindow
{
    public partial class TabLayoutUC : UserControl
    {
        private static string observerdirstr;
        private FileSystemWatcher watcher1;
        private Dictionary<string, FileandTimer> createdfiles;
        private System.Timers.Timer timer1;
        private Font printFont;
        public SolidBrush printColor;
        private bool started;
        Printer Printer;
        private PageSettings pagesettings;
        public decimal Delaytime
        {
            get { return delaytime1.Value; }
        }
        public string Getpathstring
        {
            get { return observerdirstr; }
        }
        public Font GetFont
        {
            get { return printFont; }
        }
        public Color GetColor
        {
            get { return printColor.Color; }
        }
        public bool Watcherstarted
        {
            get { return started; }
        }
        public System.Drawing.Printing.PrintDocument GetPrintDokument
        {
            get { return this.printDocument1; }
        }

        public PageSettings Pagesettings { get => pagesettings; set => pagesettings = value; }

        public TabLayoutUC(Printer printer)
        {
            InitializeComponent();
            printFont = new Font("Arial", 12);
            printColor = new SolidBrush(Color.Black);
            Printer = printer;
            createdfiles = new Dictionary<string, FileandTimer>();
            observerdir.Text = observerdirstr;
            delaytime1.Value = 1;
            TextPeview.Text = "abcABC123";
            TextPeview.Font = printFont;
            TextPeview.ForeColor = printColor.Color;
            started = false;

            
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 55;
            Pagesettings = new PageSettings();
            this.Pagesettings.PrinterSettings.Duplex = Duplex.Default;
            Pagesettings.PrinterSettings.PrintFileName = "does not matter, unused if PrintToFile == false";
        }

        public TabLayoutUC(Printer printer, Font font, Color color,String path, bool started, decimal whaitTimer)
        {
            InitializeComponent();
            printFont = font;
            printColor = new SolidBrush(color);
            Printer = printer;
            createdfiles = new Dictionary<string, FileandTimer>();
            observerdir.Text = observerdirstr = path;
            delaytime1.Value = whaitTimer;
            TextPeview.Text = "abcABC123";
            TextPeview.Font = printFont;
            this.started = started;
            TextPeview.ForeColor = printColor.Color;
            printDocument1.DefaultPageSettings.Margins.Bottom = 0;
            printDocument1.DefaultPageSettings.Margins.Left = 0;
            printDocument1.DefaultPageSettings.Margins.Right = 0;
            printDocument1.DefaultPageSettings.Margins.Top = 55;
            Pagesettings = new PageSettings();
            Pagesettings.PrinterSettings.Duplex = Duplex.Default;
            Pagesettings.PrinterSettings.PrintFileName = "does not matter, unused if PrintToFile == false";
        }

        private void Observerdialog_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            observerdirstr = folderBrowserDialog1.SelectedPath;
            observerdir.Text = observerdirstr;
        }

        private void Observerdir_TextChanged(object sender, EventArgs e)
        {
            observerdirstr = observerdir.Text;
        }

        private void Startobserver_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(observerdirstr))
            {
                foreach (string file in Directory.EnumerateFiles(observerdirstr))
                {
                    Debug.Print("File " + Path.GetFileName(file) + " Timer started");
                    Printer.AddTooQueue(file, printColor, printFont, printDocument1, ShallDelete.Checked);
                }
                watcher1 = new FileSystemWatcher(observerdirstr);
                Debug.Print("Start twatcher at: " + observerdirstr);
                watcher1.Changed += new FileSystemEventHandler(Watcher1_Changed);
                watcher1.Created += new FileSystemEventHandler(Watcher1_Created);
                watcher1.Deleted += new FileSystemEventHandler(Watcher1_Deleted);
                watcher1.Renamed += new RenamedEventHandler(OnRenamed);
                watcher1.EnableRaisingEvents = true;
                startobserver.Enabled = false;
                started = true;
                BtStop.Enabled = true;
            }
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            watcher1.EnableRaisingEvents = false;
            watcher1.Dispose();
            Debug.Print("stop watcher");
            startobserver.Enabled = true;
            BtStop.Enabled = false;
            started = false;
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
            this.pageSetupDialog1.PageSettings = Pagesettings;
            this.pageSetupDialog1.Document = this.printDocument1;
            this.pageSetupDialog1.EnableMetric = true;
            this.pageSetupDialog1.ShowDialog();
        }

        private void ChosePrinter_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog2 = new PrintDialog
            {
                Document = printDocument1
            };
            DialogResult result = printDialog2.ShowDialog();
        }

        private void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void DelTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelTab();
        }

        private void DelTab()
        {
            TabControl tabcontrol = (TabControl)Parent.Parent;
            if(tabcontrol.TabPages.Count > 1)
            {
                if (watcher1 != null)
                    {
                        watcher1.EnableRaisingEvents = false;
                        watcher1 = null;
                    }
                tabcontrol.TabPages.Remove((TabPage)this.Parent);
            }
        }

        private void AddTab()
        {
            TabControl tabcontrol = (TabControl) this.Parent.Parent;
            TabPage newPage = new TabPage((tabcontrol.TabPages.Count).ToString());
            newPage.Controls.Add(new TabLayoutUC(Printer));
            tabcontrol.TabPages.Add(newPage);

        }
    }
}
