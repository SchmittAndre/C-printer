﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Filobserverwindow
{
    public class printer
    {
        string strtoprint;
        SolidBrush ColorToPrint;
        Font FontToPrint;
        Queue<Printjop> jobs = new Queue<Printjop>();
        

        private void printFile()
        {
            Printjop actualjob = jobs.Dequeue();

            string printstring;
            using (System.IO.StreamReader fileToPrint = new System.IO.StreamReader(actualjob.PathToPrint))
            {
                printstring = fileToPrint.ReadToEnd();
                fileToPrint.Close();
            }

            ColorToPrint = actualjob.Color;
            FontToPrint = actualjob.Font;

            Encoding unicode = Encoding.GetEncoding(852);
            Encoding ascii = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(printstring);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string.
            char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            strtoprint = new string(asciiChars);

            // Display the strings created before and after the conversion.
            Console.WriteLine("Original string: {0}", printstring);
            Console.WriteLine("Ascii converted string: {0}", strtoprint);

            actualjob.dokument.Print();
        }

        public void addTooQueue(string PathToPrint, SolidBrush Color, Font Font, System.Drawing.Printing.PrintDocument dokument)
        {
            lock("Quelock")
            {
                jobs.Enqueue(new Printjop(PathToPrint, Color, Font, dokument));
            }
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            e.Graphics.MeasureString(strtoprint, FontToPrint, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(strtoprint, FontToPrint, ColorToPrint, e.MarginBounds, StringFormat.GenericTypographic);
            strtoprint = strtoprint.Substring(charactersOnPage);
            e.HasMorePages = (strtoprint.Length > 0);
        }
    }


}