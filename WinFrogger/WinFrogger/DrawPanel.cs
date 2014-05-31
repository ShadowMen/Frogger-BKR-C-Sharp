using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrogger
{
    class DrawPanel : Panel
    {
        public DrawPanel()
        {
            // Setze Styles für DoubleBuffering
            this.DoubleBuffered = true;
            UpdateStyles();
        }
    }
}
