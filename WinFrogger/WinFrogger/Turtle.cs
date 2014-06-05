using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    class Turtle : MovingObject
    {
        // Variabeln


        // Konstruktor
        public Turtle(Image ImgTex, Direction direct, int pX = 0, int pY = 0, int oSpeed = 1, int oWidth = 16, int oHeight = 16, bool wAble = true)
            : base(ImgTex, direct, pX, pY, oSpeed, oWidth, oHeight, wAble)
        {
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Graphics gfx)
        {
            if(base.Walkable) base.Draw(gfx);
        }
    }
}
