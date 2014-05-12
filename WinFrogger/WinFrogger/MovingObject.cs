using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum Direction
    {
        Left,
        Right
    };

    class MovingObject : Drawable
    {
        // Variabeln
        Image texture;
        float posX, posY, speed;
        int width, height;
        Direction direction;
        bool walkable;


        // Konstruktor
        public MovingObject(Image ImgTex, Direction direct, float pX = 0, float pY = 0, float oSpeed = 1.0f, int oWidth = 16, int oHeight = 16, bool wAble = true)
        {
            texture = ImgTex;
            direction = direct;
            posX = pX;
            posY = pY;
            speed = oSpeed;
            width = oWidth;
            height = oHeight;
            walkable = wAble;
        }

        public void Update()
        {
            switch (direction)
            {
                case Direction.Left:
                    posX -= speed;
                    break;
                case Direction.Right:
                    posX += speed;
                    break;
            }
        }

        public override void Draw(Graphics gfx)
        {
            gfx.DrawImage(texture, posX, posY, width, height);
        }
    }
}
