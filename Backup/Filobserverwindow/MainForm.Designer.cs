/*
 * Erstellt mit SharpDevelop.
 * Benutzer: schmitta
 * Datum: 19.01.2017
 * Zeit: 08:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace Filobserverwindow
{
  partial class MainForm
  {
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    
    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }
    
    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    private void InitializeComponent()
    {
    	this.tabControl1 = new System.Windows.Forms.TabControl();
    	this.tabPage1 = new System.Windows.Forms.TabPage();
    	this.settingsgroupbox = new System.Windows.Forms.GroupBox();
    	this.startobserver = new System.Windows.Forms.Button();
    	this.label3 = new System.Windows.Forms.Label();
    	this.observerdialog = new System.Windows.Forms.Button();
    	this.observerdir = new System.Windows.Forms.TextBox();
    	this.observerpath = new System.Windows.Forms.Label();
    	this.tabPage2 = new System.Windows.Forms.TabPage();
    	this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
    	this.fontDialog1 = new System.Windows.Forms.FontDialog();
    	this.tabControl1.SuspendLayout();
    	this.tabPage1.SuspendLayout();
    	this.settingsgroupbox.SuspendLayout();
    	this.SuspendLayout();
    	// 
    	// tabControl1
    	// 
    	this.tabControl1.Controls.Add(this.tabPage1);
    	this.tabControl1.Controls.Add(this.tabPage2);
    	this.tabControl1.Location = new System.Drawing.Point(12, 21);
    	this.tabControl1.Name = "tabControl1";
    	this.tabControl1.SelectedIndex = 0;
    	this.tabControl1.Size = new System.Drawing.Size(759, 351);
    	this.tabControl1.TabIndex = 0;
    	// 
    	// tabPage1
    	// 
    	this.tabPage1.Controls.Add(this.settingsgroupbox);
    	this.tabPage1.Location = new System.Drawing.Point(4, 22);
    	this.tabPage1.Name = "tabPage1";
    	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
    	this.tabPage1.Size = new System.Drawing.Size(751, 325);
    	this.tabPage1.TabIndex = 0;
    	this.tabPage1.Text = "tabPage1";
    	this.tabPage1.UseVisualStyleBackColor = true;
    	// 
    	// settingsgroupbox
    	// 
    	this.settingsgroupbox.Controls.Add(this.startobserver);
    	this.settingsgroupbox.Controls.Add(this.label3);
    	this.settingsgroupbox.Controls.Add(this.observerdialog);
    	this.settingsgroupbox.Controls.Add(this.observerdir);
    	this.settingsgroupbox.Controls.Add(this.observerpath);
    	this.settingsgroupbox.Location = new System.Drawing.Point(4, 7);
    	this.settingsgroupbox.Name = "settingsgroupbox";
    	this.settingsgroupbox.Size = new System.Drawing.Size(250, 312);
    	this.settingsgroupbox.TabIndex = 0;
    	this.settingsgroupbox.TabStop = false;
    	this.settingsgroupbox.Text = "Settings";
    	// 
    	// startobserver
    	// 
    	this.startobserver.Location = new System.Drawing.Point(47, 73);
    	this.startobserver.Name = "startobserver";
    	this.startobserver.Size = new System.Drawing.Size(100, 31);
    	this.startobserver.TabIndex = 10;
    	this.startobserver.Text = "Start";
    	this.startobserver.UseVisualStyleBackColor = true;
    	this.startobserver.Click += new System.EventHandler(this.StartobserverClick);
    	// 
    	// label3
    	// 
    	this.label3.Location = new System.Drawing.Point(6, 20);
    	this.label3.Name = "label3";
    	this.label3.Size = new System.Drawing.Size(150, 23);
    	this.label3.TabIndex = 9;
    	this.label3.Text = "zu überwachender Ordner: ";
    	// 
    	// observerdialog
    	// 
    	this.observerdialog.Location = new System.Drawing.Point(154, 44);
    	this.observerdialog.Name = "observerdialog";
    	this.observerdialog.Size = new System.Drawing.Size(75, 23);
    	this.observerdialog.TabIndex = 8;
    	this.observerdialog.Text = "Datei...";
    	this.observerdialog.UseVisualStyleBackColor = true;
    	this.observerdialog.Click += new System.EventHandler(this.ObserverdialogClick);
    	// 
    	// observerdir
    	// 
    	this.observerdir.AllowDrop = true;
    	this.observerdir.Location = new System.Drawing.Point(47, 46);
    	this.observerdir.MaxLength = 256;
    	this.observerdir.Name = "observerdir";
    	this.observerdir.Size = new System.Drawing.Size(100, 20);
    	this.observerdir.TabIndex = 7;
    	// 
    	// observerpath
    	// 
    	this.observerpath.Location = new System.Drawing.Point(8, 49);
    	this.observerpath.Name = "observerpath";
    	this.observerpath.Size = new System.Drawing.Size(33, 19);
    	this.observerpath.TabIndex = 6;
    	this.observerpath.Text = "Pfad: ";
    	// 
    	// tabPage2
    	// 
    	this.tabPage2.Location = new System.Drawing.Point(4, 22);
    	this.tabPage2.Name = "tabPage2";
    	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
    	this.tabPage2.Size = new System.Drawing.Size(751, 325);
    	this.tabPage2.TabIndex = 1;
    	this.tabPage2.Text = "tabPage2";
    	this.tabPage2.UseVisualStyleBackColor = true;
    	// 
    	// MainForm
    	// 
    	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    	this.ClientSize = new System.Drawing.Size(764, 353);
    	this.Controls.Add(this.tabControl1);
    	this.MaximizeBox = false;
    	this.Name = "MainForm";
    	this.Text = "Adeprn";
    	this.tabControl1.ResumeLayout(false);
    	this.tabPage1.ResumeLayout(false);
    	this.settingsgroupbox.ResumeLayout(false);
    	this.settingsgroupbox.PerformLayout();
    	this.ResumeLayout(false);
    }
    private System.Windows.Forms.FontDialog fontDialog1;
    private System.Windows.Forms.Button startobserver;
    private System.Windows.Forms.Label observerpath;
    private System.Windows.Forms.TextBox observerdir;
    private System.Windows.Forms.Button observerdialog;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.GroupBox settingsgroupbox;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabControl tabControl1;
  }
}
