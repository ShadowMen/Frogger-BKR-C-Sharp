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
        float posX, posY;
        int imgSize;

        // Properties
        public bool Used
        {
            get { return used; }
            set { used = value; }
        }

        public float PosX
        {
            get { return posX; }
        }

        public float PosY
        {
            get { return posY; }
        }

        public int ImageSize
        {
            get { return imgSize; }
            set { imgSize = value; }
        }

        // Konstruktor
        public Finish(Image imgTex, float pX, float pY, int imageSize, bool isUsed = false)
        {
            texture = imgTex;
            posX = pX;
            posY = pY;
            imgSize = imageSize;
            used = isUsed;
        }

        public override void Draw(Graphics gfx)
        {
            if (used) gfx.DrawImage(texture, posX, posY, imgSize, imgSize);
        }
    }
}
