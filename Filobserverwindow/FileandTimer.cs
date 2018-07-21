using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace Filobserverwindow
{
    public class FileandTimer
    {
        public FileSystemEventArgs Datei;
        public System.Timers.Timer TimerOfFile { get; private set; }
        public Printer Printer;
        private readonly Font jobsFont;
        private readonly SolidBrush jobsColor;
        private readonly bool shallDelete;
        readonly System.Drawing.Printing.PrintDocument jobsdokument;


        public FileandTimer(System.Timers.Timer timer, FileSystemEventArgs Dateiinfos , Printer Printer, 
            SolidBrush Color, Font Font, System.Drawing.Printing.PrintDocument dokument, bool shalldelete)
        {
            Datei = Dateiinfos;
            TimerOfFile = timer;
            this.Printer = Printer;
            this.jobsColor = Color;
            this.jobsFont = Font;
            this.jobsdokument = dokument;
            this.shallDelete = shalldelete;
        }

        public void Timer1Tick(object sender, System.EventArgs e)
        {
            Debug.Print("Datei: " + Datei.Name + " wurde erzeugt und wird nun ausgedruckt");
            TimerOfFile.Stop();
            Printer.AddTooQueue(Datei.FullPath, jobsColor, jobsFont, jobsdokument, shallDelete);
        }
    }
}
