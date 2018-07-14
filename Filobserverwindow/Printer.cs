using System;
using System.IO;
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
    public class Printer
    {
        string strtoprint;
        SolidBrush ColorToPrint;
        Font FontToPrint;
        Queue<Printjop> jobs = new Queue<Printjop>();
        public Thread PrintThread;
        public bool PrintThreadstop = false;
        
        public Printer()
        {
        	PrintThread = new Thread(new ThreadStart(PrintFile));
        	PrintThread.Priority = ThreadPriority.AboveNormal;
        	PrintThread.Start();
        }

        private void PrintFile()
        {
        	Printjop actualpritjob;
        	Thread.Sleep(400);

            while (!PrintThreadstop && jobs.Count >= 0)
        	{
        		if (jobs.Count !=0)
        		{
        		actualpritjob = jobs.Dequeue();
        		}
        		else
        		{
        			actualpritjob = null;
        		}
        		
        		if(actualpritjob != null)
        		{
                    string[] printstring;

                    if (actualpritjob.ispath)
                    {
                        printstring = File.ReadAllLines(actualpritjob.str, Encoding.GetEncoding(437));
                        if (actualpritjob.shallDelete)
                        {
                            File.Delete(actualpritjob.str);
                        }
                    }
                    else
                    {
                        printstring = new string[] { actualpritjob.str };
                    }
                    strtoprint = string.Join("\r\n", printstring);
                    printstring = strtoprint.Split(new Char[] { '\f'});
                    strtoprint = printstring[0];

                    ColorToPrint = actualpritjob.Color;
                    FontToPrint = actualpritjob.Font;
                    for(int i = 1; i<printstring.Length; i++)
                    {
                        string item = printstring[i];
                        if (item.Equals(""))
                        {
                            continue;
                        }
                        AddTooQueue(item, ColorToPrint, FontToPrint, actualpritjob.dokument);
                    }

                    actualpritjob.dokument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDocument1_PrintPage);
		        	actualpritjob.dokument.Print();
        		}
        		Thread.Sleep(100);
        	}
        }

        public void AddTooQueue(string PathToPrint, SolidBrush Color, Font Font, System.Drawing.Printing.PrintDocument dokument, bool shallDelete)
        {
            lock("Quelock")
            {
                jobs.Enqueue(new Printjop(PathToPrint, true, Color, Font, dokument, shallDelete));
            }
            
        }

        public void AddTooQueue(string StrtoPrint, SolidBrush Color, Font Font, System.Drawing.Printing.PrintDocument dokument)
        {
            lock ("Quelock")
            {
                jobs.Enqueue(new Printjop(StrtoPrint, false, Color, Font, dokument, false));
            }

        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.MeasureString(strtoprint, FontToPrint, e.MarginBounds.Size, StringFormat.GenericTypographic, out int charactersOnPage, out int linesPerPage);

            e.Graphics.DrawString(strtoprint, FontToPrint, ColorToPrint, e.MarginBounds, StringFormat.GenericTypographic);
            strtoprint = strtoprint.Substring(charactersOnPage);
            e.HasMorePages = (strtoprint.Length > 0);
        }
    }


}
