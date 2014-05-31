using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinFrogger
{
    enum DifficultyLevel
    {
        Easy,
        Normal,
        Hard
    };

    class Game
    {
        // Variabeln
        DifficultyLevel difficultyLvl;
        bool isGameRunning;

            // Frog
        bool frogMoving = false;
        Point newFrogPos;

        List<Drawable> drawlist = new List<Drawable>();
        Field field;

        Frog frog;

        // Konstruktor
        public Game()
        {
            isGameRunning = false;

            field = new Field();
            drawlist.Add(field);

            frog = new Frog(Image.FromFile("data/textures/frog.png"), 288, 384, FrogDirection.Up);
            drawlist.Add(frog);
        }

        // Properties
        public bool IsGameRunning
        {
            get { return isGameRunning; }
        }

        public DifficultyLevel Difficulty
        {
            get { return difficultyLvl; }
        }

        // Game Funktionen
        public void Start(DifficultyLevel difficulty)
        {
            if (difficultyLvl == difficulty) return;

            this.Reset();
            difficultyLvl = difficulty;
            isGameRunning = true;
        }

        public void Pause()
        {
            isGameRunning = false;
        }

        public void Resume()
        {
            isGameRunning = true;
        }

        public void Reset()
        {
        }

        public void HandleInput(System.Windows.Forms.Keys key)
        {
            if (frogMoving) return;

            switch (key)
            {
                case System.Windows.Forms.Keys.W:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Up);
                    newFrogPos = frog.Position;
                    newFrogPos.Y -= 32;
                    break;
                case System.Windows.Forms.Keys.S:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Down);
                    newFrogPos = frog.Position;
                    newFrogPos.Y += 32;
                    break;
                case System.Windows.Forms.Keys.D:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Right);
                    newFrogPos = frog.Position;
                    newFrogPos.X += 32;
                    break;
                case System.Windows.Forms.Keys.A:
                    frogMoving = true;
                    frog.TurnFrog(FrogDirection.Left);
                    newFrogPos = frog.Position;
                    newFrogPos.X -= 32;
                    break;
            }
        }

        public void Update()
        {
            this.MoveFrog();
        }

        private void MoveFrog()
        {
            if(frogMoving)
            {
                if (!frog.Position.Equals(newFrogPos))
                {
                    frog.Move(frog.Direction, 2);
                    frog.Status = FrogStatus.Jump;
                }
                else
                {
                    frogMoving = false;
                    frog.Status = FrogStatus.Alive;
                }
            }
        }

        // Grafik Funktionen
        public void Draw(Graphics gfx)
        {
            gfx.Clear(Color.Black);

            for (int i = 0; i < drawlist.Count; i++)
            {
                drawlist[i].Draw(gfx);
            }
        }
    }
}
