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
        Point position;
        int speed;
        int width, height;
        Direction direction;
        bool walkable;

        // Properties
        public Point Position
        {
            get { return position; }
            protected set { position = value; }
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

        public int Speed
        {
            get { return speed; }
        }

        public bool Walkable
        {
            get { return walkable; }
            protected set { walkable = value; }
        }

        public Direction ObjDirection
        {
            get { return direction; }
            protected set { direction = value; }
        }

        protected Image Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        // Konstruktor
        public MovingObject(Image ImgTex, Direction direct, int pX = 0, int pY = 0, int oSpeed = 1, int oWidth = 16, int oHeight = 16, bool wAble = true)
        {
            texture = ImgTex;
            direction = direct;
            position = new Point(pX, pY);
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
                    position.X -= speed;
                    break;
                case Direction.Right:
                    position.X += speed;
                    break;
            }
        }

        public override void Draw(Graphics gfx)
        {
            gfx.DrawImage(texture, position.X, position.Y, width, height);
        }
    }
}
