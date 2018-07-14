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
        public string str;
        public SolidBrush Color;
        public Font Font;
        public PrintDocument dokument;
        public bool shallDelete;
        public bool ispath;

        public Printjop(string pathToPrint, bool ispath, SolidBrush color, Font font, PrintDocument dokument, bool shallDelete)
        {
            this.ispath = ispath;
            str = pathToPrint;
            Color = color;
            Font = font;
            this.dokument = dokument;
            this.shallDelete = shallDelete;
        }
    }
}
