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
        string Name;
        public FileSystemEventArgs Datei;
        public System.Timers.Timer TimerOfFile { get; private set; }
        public printer Printer;
        private Font jobsFont;
        private SolidBrush jobsColor;
        System.Drawing.Printing.PrintDocument jobsdokument;

        public FileandTimer(System.Timers.Timer timer, FileSystemEventArgs Dateiinfos , printer Printer,SolidBrush Color, Font Font, System.Drawing.Printing.PrintDocument dokument)
        {
            Datei = Dateiinfos;
            TimerOfFile = timer;
            this.Printer = Printer;
            this.jobsColor = Color;
            this.jobsFont = Font;
            this.jobsdokument = dokument;
        }

        public void Timer1Tick(object sender, System.EventArgs e)
        {
            Debug.Print("Datei: " + Datei.Name + " wurde erzeugt und wird nun ausgedruckt");
            TimerOfFile.Stop();
            Printer.addTooQueue(Datei.FullPath, jobsColor, jobsFont, jobsdokument);
        }
    }
}
