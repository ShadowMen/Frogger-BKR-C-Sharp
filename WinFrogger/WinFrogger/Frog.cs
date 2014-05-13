using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum FrogDirection
    {
        Up,
        Down,
        Left,
        Right
    };

    class Frog : Drawable
    {
        // Variabeln
        Image texture;
        float posX, posY;
        FrogDirection direction;

        // Konstruktor
        public Frog(Image imgTexture, float pX, float pY, FrogDirection fDirection = FrogDirection.Up)
        {
            texture = imgTexture;
            posX = pX;
            posY = pY;
            direction = fDirection;
        }

        public void Move(FrogDirection direct)
        {
        }

        public override void Draw(Graphics gfx)
        {
            base.Draw(gfx);
        }
    }
}
