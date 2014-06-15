using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    class Finish : Drawable
    {
        // Variabeln
        Image texture;
        bool used;
        Point pos;
        const int size = 32;

        // Properties
        public bool Used
        {
            get { return used; }
            set { used = value; }
        }

        public Point Position
        {
            get { return pos; }
        }

        public int Size
        {
            get { return size; }
        }

        // Konstruktor
        public Finish(Image imgTex, int pX, int pY, bool isUsed = false)
        {
            texture = imgTex;
            pos.X = pX;
            pos.Y = pY;
            used = isUsed;
        }

        public override void Draw(Graphics gfx)
        {
            if (used) gfx.DrawImage(texture, pos.X, pos.Y, size, size);
        }
    }
}
