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

    enum FrogStatus
    {
        Alive,
        Jump,
        Death
    };

    class Frog : Drawable
    {
        // Variabeln
        Image texture;
        Point position;
        Rectangle textRect;
        FrogDirection direction = FrogDirection.Down;
        FrogStatus status;

        // Properties
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public FrogStatus Status
        {
            get { return status; }
            set
            {
                if(value == status) return;
                status = value;

                switch (status)
                {
                    case FrogStatus.Alive:
                        textRect.Y = 0;
                        break;
                    case FrogStatus.Jump:
                        textRect.Y = 32;
                        break;
                    case FrogStatus.Death:
                        textRect.Y = 64;
                        break;
                }
            }
        }

        public FrogDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        // Konstruktor
        public Frog(Image imgTexture, int pX, int pY, FrogDirection fDirection = FrogDirection.Up)
        {
            texture = imgTexture;
            position = new Point(pX, pY);
            textRect = new Rectangle(0, 0, 32, 32);

            TurnFrog(fDirection);
        }

        public void Move(FrogDirection direct, int width)
        {
            TurnFrog(direct);

            switch (direct)
            {
                case FrogDirection.Down:
                    position.Y += width;
                    break;
                case FrogDirection.Up:
                    position.Y -= width;
                    break;
                case FrogDirection.Right:
                    position.X += width;
                    break;
                case FrogDirection.Left:
                    position.X -= width;
                    break;
            }
        }

        public void TurnFrog(FrogDirection direct)
        {
            if (direction != direct) direction = direct;
            else return;

            switch (direct)
            {
                case FrogDirection.Up:
                    textRect.X = 64;
                    break;
                case FrogDirection.Down:
                    textRect.X = 0;
                    break;
                case FrogDirection.Left:
                    textRect.X = 32;
                    break;
                case FrogDirection.Right:
                    textRect.X = 96;
                    break;
            }
        }

        public void Die()
        {
            textRect.Y = 64;
            status = FrogStatus.Death;
        }

        public override void Draw(Graphics gfx)
        {
            gfx.DrawImage(texture, new Rectangle(position.X, position.Y, 32, 32), textRect, GraphicsUnit.Pixel);
        }
    }
}
