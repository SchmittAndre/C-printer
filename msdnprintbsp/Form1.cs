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
        string strtoprint;
        System.Drawing.Font printFont = new Font("Areal0", 10);
        SolidBrush printColor = new SolidBrush(Color.Black);

        private void printButton_Click(object sender, EventArgs e)
        {
            string printPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (fileToPrint = new System.IO.StreamReader(printPath + @"\myFile.txt"))
            {
                strtoprint = fileToPrint.ReadToEnd();
            }

            Encoding unicode = Encoding.GetEncoding(852);
            Encoding ascii = Encoding.Unicode;
            
            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(strtoprint);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            string asciiString = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", strtoprint);
            Console.WriteLine("Ascii converted string: {0}", asciiString);

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
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
            int charactersOnPage = 0;
            int linesPerPage = 0;
            e.Graphics.MeasureString(strtoprint, printFont, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(strtoprint, printFont, printColor, e.MarginBounds, StringFormat.GenericTypographic);
            strtoprint = strtoprint.Substring(charactersOnPage);
            e.HasMorePages = (strtoprint.Length > 0);
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
