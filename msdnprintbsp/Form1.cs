using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace msdnprintbsp
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.IO.StreamReader fileToPrint;
        System.Drawing.Font printFont;
        System.Drawing.SolidBrush printColor;

        private void printButton_Click(object sender, EventArgs e)
        {
            string printPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileToPrint = new System.IO.StreamReader(printPath + @"\myFile.txt");
            printDocument1.Print();
            fileToPrint.Close();
        }
        private void B_File_Click(object sender, EventArgs e)
        {

            fontDialog1.ShowDialog();
            printFont = fontDialog1.Font;
        }

        private void B_Color_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            printColor = new SolidBrush(colorDialog1.Color);
        }
  

    private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float FontHeight = printFont.GetHeight(e.Graphics);
            float linesPerPage = e.MarginBounds.Height / FontHeight;
            while (count < linesPerPage)
            {
                line = fileToPrint.ReadLine();
                if (line == null)
                {
                    break;
                }
                yPos = topMargin + count * printFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, printFont, printColor, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
        }

        private void B_Pagesetting_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            this.pageSetupDialog1.PrinterSettings = this.printDocument1.PrinterSettings;
            this.pageSetupDialog1.ShowDialog();
            if (this.pageSetupDialog1.PageSettings != null)
            {
                this.printDocument1.DefaultPageSettings = this.pageSetupDialog1.PageSettings;
            }
        }
    }
}
