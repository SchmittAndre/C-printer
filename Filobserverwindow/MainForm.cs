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
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;

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
        string path = @"D:\myXml.xml";

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
                    TabPage newPage = new TabPage((tabControl1.TabPages.Count).ToString());
                    newPage.Controls.Add(new TabLayoutUC(Printer));
                    this.tabControl1.TabPages.Add(newPage);
                }
                else
                {
                    LoadIni(path);
                }
            }
            else
            {
                TabPage newPage = new TabPage((tabControl1.TabPages.Count).ToString());
                newPage.Controls.Add(new TabLayoutUC(Printer));
                this.tabControl1.TabPages.Add(newPage);
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
                i = (MyRootClass)serializer.Deserialize(reader);
                fs.Close();

                foreach(Tabsave tab in i.Tabs)
                {
                    TabPage newPage = new TabPage((tabControl1.TabPages.Count).ToString());
                    newPage.Controls.Add(new TabLayoutUC(Printer, tab.FontToSave,  tab.PrintColor,  tab.observerdirstr, tab.waitTime));
                    this.tabControl1.TabPages.Add(newPage);
                }
            }
            
        }

        private void SaveIni(string filename)
        {
            // Creates a new XmlSerializer.
            XmlSerializer s =
            new XmlSerializer(typeof(MyRootClass));

            // Writing the file requires a StreamWriter.
            TextWriter myWriter = new StreamWriter(filename);

            // Creates an instance of the class to serialize. 
            MyRootClass myRootClass = new MyRootClass();

            Tabsave[] myItems = new Tabsave[tabControl1.TabCount];
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                TabPage tab = tabControl1.TabPages[i];
                TabLayoutUC test = (TabLayoutUC)tab.Controls[0];
                Tabsave item1 = new Tabsave
                {
                    // Sets the objects' properties.
                    waitTime = test.Delaytime,
                    observerdirstr = test.Getpathstring,
                    PrintColor = test.GetColor,
                    FontToSave = test.GetFont
                };
                myItems[i] = item1;
            }
            myRootClass.anz = myItems.Length;
            
            myRootClass.Tabs = myItems;
            
            s.Serialize(myWriter, myRootClass);
            myWriter.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveIni(path);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            LoadIni(path);
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
        public Font FontToSave { get; set; }
        public string observerdirstr;
        public decimal waitTime;
        [XmlIgnore]
        public Color PrintColor { get; set; } 

        [XmlElement("PrintColor")]
        public int BackColorAsArgb
        {
            get { return PrintColor.ToArgb(); }
            set { PrintColor = Color.FromArgb(value); }
        }
        //public PrintDialog printDialog2;

        [Browsable(false)]
        public string FontSerialize
        {
            get { return FontSerializationHelper.ToString(FontToSave); }
            set { FontToSave = FontSerializationHelper.FromString(value); }
        }
    }


}
