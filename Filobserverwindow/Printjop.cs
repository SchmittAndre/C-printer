using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace Filobserverwindow
{
    class Printjop
    {
        public string PathToPrint;
        public SolidBrush Color;
        public Font Font;
        public PrintDocument dokument;

        public Printjop(string pathToPrint, SolidBrush color, Font font, PrintDocument dokument)
        {
            PathToPrint = pathToPrint;
            Color = color;
            Font = font;
            this.dokument = dokument;
        }
    }
}
