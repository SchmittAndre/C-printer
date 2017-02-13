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
            this.groupFonts = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextPeview = new System.Windows.Forms.Label();
            this.B_pageSettup = new System.Windows.Forms.Button();
            this.B_Color = new System.Windows.Forms.Button();
            this.B_Fonts = new System.Windows.Forms.Button();
            this.settingsgroupbox = new System.Windows.Forms.GroupBox();
            this.delaytime1 = new System.Windows.Forms.NumericUpDown();
            this.startobserver = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.observerdialog = new System.Windows.Forms.Button();
            this.observerdir = new System.Windows.Forms.TextBox();
            this.observerpath = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chosePrinter = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupFonts.SuspendLayout();
            this.settingsgroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delaytime1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupFonts);
            this.tabPage1.Controls.Add(this.settingsgroupbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupFonts
            // 
            this.groupFonts.Controls.Add(this.chosePrinter);
            this.groupFonts.Controls.Add(this.label2);
            this.groupFonts.Controls.Add(this.TextPeview);
            this.groupFonts.Controls.Add(this.B_pageSettup);
            this.groupFonts.Controls.Add(this.B_Color);
            this.groupFonts.Controls.Add(this.B_Fonts);
            this.groupFonts.Location = new System.Drawing.Point(287, 7);
            this.groupFonts.Name = "groupFonts";
            this.groupFonts.Size = new System.Drawing.Size(239, 281);
            this.groupFonts.TabIndex = 1;
            this.groupFonts.TabStop = false;
            this.groupFonts.Text = "Fonts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vorschau:";
            // 
            // TextPeview
            // 
            this.TextPeview.AutoSize = true;
            this.TextPeview.Location = new System.Drawing.Point(68, 130);
            this.TextPeview.Name = "TextPeview";
            this.TextPeview.Size = new System.Drawing.Size(55, 13);
            this.TextPeview.TabIndex = 3;
            this.TextPeview.Text = "platzhalter";
            // 
            // B_pageSettup
            // 
            this.B_pageSettup.Location = new System.Drawing.Point(7, 69);
            this.B_pageSettup.Name = "B_pageSettup";
            this.B_pageSettup.Size = new System.Drawing.Size(112, 23);
            this.B_pageSettup.TabIndex = 2;
            this.B_pageSettup.Text = "Seite Einrichten";
            this.B_pageSettup.UseVisualStyleBackColor = true;
            this.B_pageSettup.Click += new System.EventHandler(this.B_pageSettup_Click);
            // 
            // B_Color
            // 
            this.B_Color.Location = new System.Drawing.Point(7, 44);
            this.B_Color.Name = "B_Color";
            this.B_Color.Size = new System.Drawing.Size(112, 23);
            this.B_Color.TabIndex = 1;
            this.B_Color.Text = "Farbe";
            this.B_Color.UseVisualStyleBackColor = true;
            this.B_Color.Click += new System.EventHandler(this.B_Color_Click);
            // 
            // B_Fonts
            // 
            this.B_Fonts.Location = new System.Drawing.Point(7, 19);
            this.B_Fonts.Name = "B_Fonts";
            this.B_Fonts.Size = new System.Drawing.Size(112, 23);
            this.B_Fonts.TabIndex = 0;
            this.B_Fonts.Text = "Schrift";
            this.B_Fonts.UseVisualStyleBackColor = true;
            this.B_Fonts.Click += new System.EventHandler(this.B_Fonts_Click);
            // 
            // settingsgroupbox
            // 
            this.settingsgroupbox.Controls.Add(this.delaytime1);
            this.settingsgroupbox.Controls.Add(this.startobserver);
            this.settingsgroupbox.Controls.Add(this.label3);
            this.settingsgroupbox.Controls.Add(this.observerdialog);
            this.settingsgroupbox.Controls.Add(this.observerdir);
            this.settingsgroupbox.Controls.Add(this.observerpath);
            this.settingsgroupbox.Location = new System.Drawing.Point(4, 7);
            this.settingsgroupbox.Name = "settingsgroupbox";
            this.settingsgroupbox.Size = new System.Drawing.Size(265, 281);
            this.settingsgroupbox.TabIndex = 0;
            this.settingsgroupbox.TabStop = false;
            this.settingsgroupbox.Text = "Settings";
            // 
            // delaytime1
            // 
            this.delaytime1.Location = new System.Drawing.Point(47, 73);
            this.delaytime1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.delaytime1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.delaytime1.Name = "delaytime1";
            this.delaytime1.Size = new System.Drawing.Size(100, 20);
            this.delaytime1.TabIndex = 11;
            this.delaytime1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // startobserver
            // 
            this.startobserver.Location = new System.Drawing.Point(47, 99);
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
            this.tabPage2.Size = new System.Drawing.Size(546, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chosePrinter
            // 
            this.chosePrinter.Location = new System.Drawing.Point(10, 99);
            this.chosePrinter.Name = "chosePrinter";
            this.chosePrinter.Size = new System.Drawing.Size(109, 23);
            this.chosePrinter.TabIndex = 5;
            this.chosePrinter.Text = "Drucker wählen";
            this.chosePrinter.UseVisualStyleBackColor = true;
            this.chosePrinter.Click += new System.EventHandler(this.chosePrinter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 353);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Adeprn";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupFonts.ResumeLayout(false);
            this.groupFonts.PerformLayout();
            this.settingsgroupbox.ResumeLayout(false);
            this.settingsgroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delaytime1)).EndInit();
            this.ResumeLayout(false);

    }
    private System.Windows.Forms.NumericUpDown delaytime1;
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
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupFonts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TextPeview;
        private System.Windows.Forms.Button B_pageSettup;
        private System.Windows.Forms.Button B_Color;
        private System.Windows.Forms.Button B_Fonts;
        private System.Windows.Forms.Button chosePrinter;
    }
}
