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
        public Car(Image ImgTex, Direction direct, int pX = 0, int pY = 0, int oSpeed = 1, int oWidth = 16, int oHeight = 16, bool wAble = true, bool flipedImage = false)
            : base(ImgTex, direct, pX, pY, oSpeed, oWidth, oHeight, wAble)
        {
            if (flipedImage) base.Texture.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
