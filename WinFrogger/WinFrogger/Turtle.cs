using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum TurtleState
    {
        Up,
        GoDown,
        Down
    };

    class Turtle : MovingObject
    {
        // Variabeln
        Rectangle textRect;

        TurtleState state;
        int goDownTime;
        int goDownTimer;

        // Konstruktor
        public Turtle(Image ImgTex, Direction direct, int pX = 0, int pY = 0, int oSpeed = 8, bool wAble = true, int DownTime = 60, bool flipedImage = false)
            : base(ImgTex, direct, pX, pY, oSpeed, 96, 32, wAble)
        {
            textRect = new Rectangle(0, 0, 32, 32);
            goDownTime = DownTime;
            state = TurtleState.Up;
            if (flipedImage) base.Texture.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        public override void Update()
        {
            if (goDownTimer <= 0)
            {
                if (state == TurtleState.Up)
                {
                    state = TurtleState.GoDown;
                    textRect.X = 32;
                    goDownTimer = 10;
                }
                else if (state == TurtleState.GoDown)
                {
                    state = TurtleState.Down;
                    textRect.X = 64;
                    base.Walkable = false;
                    goDownTimer = 20;
                }
                else if (state == TurtleState.Down)
                {
                    state = TurtleState.Up;
                    textRect.X = 0;
                    base.Walkable = true;
                    goDownTimer = goDownTime;
                }
            }
            else goDownTimer--;

            base.Update();
        }

        public override void Draw(Graphics gfx)
        {
            for (int i = 0; i < 3; i++)
            {
                gfx.DrawImage(base.Texture, new Rectangle( base.Position.X + (base.ObjDirection == Direction.Right ? +(i * 32) : -(i*32)), base.Position.Y, 32, 32), textRect, GraphicsUnit.Pixel);
            }
        }
    }
}
