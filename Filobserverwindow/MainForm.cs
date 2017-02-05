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
    string movetodir;
    FileSystemWatcher watcher1;
    
    public MainForm()
    {
      //
      // The InitializeComponent() call is required for Windows Forms designer support.
      //
      InitializeComponent();
      //
      // TODO: Add constructor code after the InitializeComponent() call.
      //
    }
    
    
    
    
   
    
    void ObserverdialogClick(object sender, EventArgs e)
    {
    	folderBrowserDialog1.ShowDialog();
      observerdirstr = folderBrowserDialog1.SelectedPath;
      t_observerdir.Text = observerdirstr;
    }
    
    void StartobserverClick(object sender, EventArgs e)
    {
      if (Directory.Exists(observerdirstr))
      {
        watcher1 = new FileSystemWatcher(observerdirstr);
        Debug.Print("Startetwatcher1");
        watcher1.Changed += new FileSystemEventHandler(watcher1_Changed);
        watcher1.Created += new FileSystemEventHandler(watcher1_Created);
        watcher1.Deleted += new FileSystemEventHandler(watcher1_Changed);
        watcher1.Renamed += new RenamedEventHandler(watcher1_Changed);
        watcher1.EnableRaisingEvents = true;
      }
    }

    static void watcher1_Changed(object source, FileSystemEventArgs e)
    {
      Debug.Print("Datei " + e.Name + " wurde " + e.ChangeType);
    }
    
    
    void watcher1_Created(object sender, FileSystemEventArgs e)
    {
      Debug.Print("Datei: " + e.Name + " wurde erzeugt und wird nun ausgedruckt");
    }

    private void b_print_Click(object sender, EventArgs e)
    {

    }
  }
}
