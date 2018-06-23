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
            TabPage newPage = new TabPage((tabControl1.TabPages.Count).ToString());
            newPage.Controls.Add(new TabLayoutUC());
            this.tabControl1.TabPages.Add(newPage);
        }
        
        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Printer.PrintThreadstop = true;
            Printer.PrintThread.Join();
        }
    }

}
