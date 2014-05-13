using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFrogger
{
    class HUD : Drawable
    {
        // Variabeln
        int time, score, lifes;
        string highScore;


        // Properties
        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int Lifes
        {
            get { return lifes; }
            set { lifes = value; }
        }

        public string HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }


        public override void Draw(System.Drawing.Graphics gfx)
        {
            base.Draw(gfx);
        }
    }
}
