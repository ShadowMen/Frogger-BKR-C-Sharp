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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            UpdateStyles();
        }
    }
}
