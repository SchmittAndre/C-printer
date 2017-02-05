namespace msdnprintbsp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.B_Fontdialog = new System.Windows.Forms.Button();
            this.B_Coloredialog = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.B_Pagesetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printButton
            // 
            this.printButton.Location = new System.Drawing.Point(96, 203);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 0;
            this.printButton.Text = "print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // B_Fontdialog
            // 
            this.B_Fontdialog.Location = new System.Drawing.Point(13, 13);
            this.B_Fontdialog.Name = "B_Fontdialog";
            this.B_Fontdialog.Size = new System.Drawing.Size(75, 23);
            this.B_Fontdialog.TabIndex = 1;
            this.B_Fontdialog.Text = "Font";
            this.B_Fontdialog.UseVisualStyleBackColor = true;
            this.B_Fontdialog.Click += new System.EventHandler(this.B_File_Click);
            // 
            // B_Coloredialog
            // 
            this.B_Coloredialog.Location = new System.Drawing.Point(95, 13);
            this.B_Coloredialog.Name = "B_Coloredialog";
            this.B_Coloredialog.Size = new System.Drawing.Size(75, 23);
            this.B_Coloredialog.TabIndex = 2;
            this.B_Coloredialog.Text = "Color";
            this.B_Coloredialog.UseVisualStyleBackColor = true;
            this.B_Coloredialog.Click += new System.EventHandler(this.B_Color_Click);
            // 
            // B_Pagesetting
            // 
            this.B_Pagesetting.Location = new System.Drawing.Point(176, 13);
            this.B_Pagesetting.Name = "B_Pagesetting";
            this.B_Pagesetting.Size = new System.Drawing.Size(96, 23);
            this.B_Pagesetting.TabIndex = 3;
            this.B_Pagesetting.Text = "Pagesettings";
            this.B_Pagesetting.UseVisualStyleBackColor = true;
            this.B_Pagesetting.Click += new System.EventHandler(this.B_Pagesetting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.B_Pagesetting);
            this.Controls.Add(this.B_Coloredialog);
            this.Controls.Add(this.B_Fontdialog);
            this.Controls.Add(this.printButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button B_Fontdialog;
        private System.Windows.Forms.Button B_Coloredialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button B_Pagesetting;
    }
}

