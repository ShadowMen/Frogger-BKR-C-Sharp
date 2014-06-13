using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    class Trunk : MovingObject
    {
        // Variabeln


        // Konstruktor
        public Trunk(Image ImgTex, Direction direct, int pX = 0, int pY = 0, int oSpeed = 1, bool wAble = true, bool flipedImage = false)
            : base(ImgTex, direct, pX, pY, oSpeed, 64, 32, wAble)
        {
            if (flipedImage) base.Texture.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
