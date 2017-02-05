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
            this.t_observerdir = new System.Windows.Forms.TextBox();
            this.observerpath = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.t_movetodir = new System.Windows.Forms.TextBox();
            this.movetopath = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.b_print = new System.Windows.Forms.Button();
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
            this.settingsgroupbox.Controls.Add(this.b_print);
            this.settingsgroupbox.Controls.Add(this.label1);
            this.settingsgroupbox.Controls.Add(this.button1);
            this.settingsgroupbox.Controls.Add(this.t_movetodir);
            this.settingsgroupbox.Controls.Add(this.movetopath);
            this.settingsgroupbox.Controls.Add(this.startobserver);
            this.settingsgroupbox.Controls.Add(this.label3);
            this.settingsgroupbox.Controls.Add(this.observerdialog);
            this.settingsgroupbox.Controls.Add(this.t_observerdir);
            this.settingsgroupbox.Controls.Add(this.observerpath);
            this.settingsgroupbox.Location = new System.Drawing.Point(4, 7);
            this.settingsgroupbox.Name = "settingsgroupbox";
            this.settingsgroupbox.Size = new System.Drawing.Size(248, 312);
            this.settingsgroupbox.TabIndex = 0;
            this.settingsgroupbox.TabStop = false;
            this.settingsgroupbox.Text = "Settings";
            // 
            // startobserver
            // 
            this.startobserver.Location = new System.Drawing.Point(47, 126);
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
            // t_observerdir
            // 
            this.t_observerdir.AllowDrop = true;
            this.t_observerdir.Location = new System.Drawing.Point(47, 46);
            this.t_observerdir.MaxLength = 256;
            this.t_observerdir.Name = "t_observerdir";
            this.t_observerdir.Size = new System.Drawing.Size(100, 20);
            this.t_observerdir.TabIndex = 7;
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "verschieben nach:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Datei...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // t_movetodir
            // 
            this.t_movetodir.AllowDrop = true;
            this.t_movetodir.Location = new System.Drawing.Point(47, 100);
            this.t_movetodir.MaxLength = 256;
            this.t_movetodir.Name = "t_movetodir";
            this.t_movetodir.Size = new System.Drawing.Size(100, 20);
            this.t_movetodir.TabIndex = 12;
            // 
            // movetopath
            // 
            this.movetopath.Location = new System.Drawing.Point(8, 103);
            this.movetopath.Name = "movetopath";
            this.movetopath.Size = new System.Drawing.Size(33, 19);
            this.movetopath.TabIndex = 11;
            this.movetopath.Text = "Pfad: ";
            // 
            // b_print
            // 
            this.b_print.Location = new System.Drawing.Point(85, 251);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(75, 23);
            this.b_print.TabIndex = 15;
            this.b_print.Text = "Print";
            this.b_print.UseVisualStyleBackColor = true;
            this.b_print.Click += new System.EventHandler(this.b_print_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 373);
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
    private System.Windows.Forms.TextBox t_observerdir;
    private System.Windows.Forms.Button observerdialog;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.GroupBox settingsgroupbox;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox t_movetodir;
        private System.Windows.Forms.Label movetopath;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button b_print;
    }
}
