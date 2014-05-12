using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    class Car : MovingObject
    {
        // Variabeln


        // Konstruktor
        public Car(Image ImgTex, Direction direct, float pX = 0, float pY = 0, float oSpeed = 1.0f, int oWidth = 16, int oHeight = 16, bool wAble = true)
            : base(ImgTex, direct, pX, pY, oSpeed, oWidth, oHeight, wAble)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
