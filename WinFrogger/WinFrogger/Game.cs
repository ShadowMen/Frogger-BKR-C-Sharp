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

        // Konstruktor
        public Game()
        {
        }

        // Game Funktionen
        public void Start(DifficultyLevel difficulty)
        {
        }

        public void Pause()
        {
        }

        public void Resume()
        {
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
        }
    }
}
