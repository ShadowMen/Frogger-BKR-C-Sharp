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

        // Properties
        public float PosX
        {
            get { return posX; }
            protected set { posX = value; }
        }

        public float PosY
        {
            get { return posY; }
            protected set { PosY = value; }
        }

        public int Width
        {
            get { return width; }
            protected set { width = value; }
        }

        public int Height
        {
            get { return height; }
            protected set { height = value; }
        }

        public bool Walkable
        {
            get { return walkable; }
            protected set { walkable = value; }
        }


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

        public virtual void Update()
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
