﻿/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schmitta
 * Datum: 19.01.2017
 * Zeit: 08:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing.Printing;

namespace Filobserverwindow
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        Dictionary<string, FileandTimer> createdfiles;
        private Font printFont;
        private SolidBrush printColor;
        Printer Printer;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DirPrint", "Save.txt");

        public MainForm()
        {
            InitializeComponent();
            printFont = new Font("courier new", 11);
            printColor = new SolidBrush(Color.Black);
            Printer = new Printer();
            createdfiles = new Dictionary<string, FileandTimer>();
            if (File.Exists(path))
            {
                if (new FileInfo(path).Length == 0)
                {
                    AddStandardtab();
                }
                else
                {
                    LoadIni(path);
                }
            }
            else
            {
                AddStandardtab();
            }
        }



        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            //saveIni(path);
            Printer.PrintThreadstop = true;
            Printer.PrintThread.Join();
            Debug.Print("Test");
        }

        private void LoadIni(string filename)
        {
            if (File.Exists(path))
            {
                XmlSerializer serializer = new
                XmlSerializer(typeof(MyRootClass));

                // A FileStream is needed to read the XML document.
                FileStream fs = new FileStream(filename, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                // Declare an object variable of the type to be deserialized.
                MyRootClass i;

                // Use the Deserialize method to restore the object's state.
                try
                {
                    i = (MyRootClass)serializer.Deserialize(reader);
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                    AddStandardtab();
                    return;
                }
                finally
                {
                    fs.Close();
                }
                this.tabControl1.TabPages.Clear();
                foreach (Tabsave tab in i.Tabs)
                {
                    TabPage newPage = new TabPage((tabControl1.TabPages.Count).ToString());
                    newPage.Controls.Add(new TabLayoutUC(Printer, tab.Font, tab.Color, tab.Path, tab.started, tab.waitTime));
                    this.tabControl1.TabPages.Add(newPage);
                }
            }

        }

        private void SavePagesettings()
        {
            System.Drawing.Printing.PageSettings page_settings = new PageSettings();
            StringBuilder xml_str = new StringBuilder();
            StringWriter sw = new StringWriter(xml_str);

            XmlSerializer xs = new XmlSerializer(typeof(PageSettings));
            xs.Serialize(sw, page_settings);

            sw.Close();
        }

        private void SaveIni(string filename)
        {
            if (!System.IO.Directory.Exists(path))
            {
                
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            XmlSerializer serializer =
            new XmlSerializer(typeof(MyRootClass));


            TextWriter myWriter = new StreamWriter(filename);

            MyRootClass myRootClass = new MyRootClass();

            Tabsave[] Tabsaves = new Tabsave[tabControl1.TabCount];
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                TabPage tab = tabControl1.TabPages[i];
                TabLayoutUC tablayout = (TabLayoutUC)tab.Controls[0];
                Tabsave item1 = new Tabsave
                {
                    waitTime = tablayout.Delaytime,
                    Path = tablayout.Getpathstring,
                    Color = tablayout.GetColor,
                    Font = tablayout.GetFont,
                    started = tablayout.Watcherstarted,
                    pagesettings = tablayout.Pagesettings,
                };
                if (item1.pagesettings.PrinterSettings.Duplex == 0)
                {
                    item1.pagesettings.PrinterSettings.Duplex = Duplex.Simplex;
                }
                Tabsaves[i] = item1;
            }
            myRootClass.anz = Tabsaves.Length;

            myRootClass.Tabs = Tabsaves;
            try
            {
                serializer.Serialize(myWriter, myRootClass);
            }
            catch
            {
                Debug.Print("Printer not Serializable");
            }
            myWriter.Close();
        }

        private void AddStandardtab()
        {
            TabPage newPage = new TabPage((tabControl1.TabPages.Count).ToString());
            newPage.Controls.Add(new TabLayoutUC(Printer));
            this.tabControl1.TabPages.Add(newPage);
        }

        private void TabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = sender as TabControl;
            TabPage tabPageCurrent = null;

            if (e.Button == MouseButtons.Middle)
            {
                for (var i = 0; i < tabControl.TabCount; i++)
                {
                    if (!tabControl.GetTabRect(i).Contains(e.Location))
                        continue;
                    tabPageCurrent = tabControl.TabPages[i];
                    break;
                }
                if (tabPageCurrent != null && tabControl.TabCount > 1)
                    tabControl.TabPages.Remove(tabPageCurrent);
            }
        }
    }

    public class MyRootClass
    {
        private Tabsave[] tabs;
        public int anz;

        [XmlArrayItem(ElementName = "tab",
        IsNullable = true,
        Type = typeof(Tabsave))]
        [XmlArray]
        public Tabsave[] Tabs
        {
            get { return tabs; }
            set { tabs = value; }
        }

    }

    [Serializable()]
    public class Tabsave
    {
        [XmlIgnore()]
        public Font Font { get; set; }
        public string Path;
        public decimal waitTime;
        public bool started;
        [XmlIgnore]
        public Color Color { get; set; }

        [XmlElement("PrintColor")]
        public int ColorAsArgb
        {
            get { return Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }
        //public PrintDialog printDialog2;

        [Browsable(false)]
        public string FontSerialize
        {
            get { return FontSerializationHelper.ToString(Font); }
            set { Font = FontSerializationHelper.FromString(value); }
        }

        public PageSettings pagesettings;
    }
}
