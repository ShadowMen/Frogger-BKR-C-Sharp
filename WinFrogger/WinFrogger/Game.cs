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

        List<Drawable> drawlist = new List<Drawable>();
        Field field;

        // Konstruktor
        public Game()
        {
            isGameRunning = false;

            field = new Field();
            drawlist.Add(field);
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
        }

        public void Update()
        {
        }

        // Grafik Funktionen
        public void Resize(int width, int height)
        {
        }

        public void Draw(Graphics gfx)
        {
            for (int i = 0; i < drawlist.Count; i++)
            {
                drawlist[i].Draw(gfx);
            }
        }
    }
}
