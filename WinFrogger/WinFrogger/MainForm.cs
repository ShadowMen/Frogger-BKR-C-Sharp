using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFrogger
{
    public partial class MainForm : Form
    {
        // Variabeln
        Game game;

        public MainForm()
        {
            InitializeComponent();

            game = new Game();
        }

        private void menuStartEasy_Click(object sender, EventArgs e)
        {
            game.Start(DifficultyLevel.Easy);
            menuPauseResume.Enabled = true;
        }

        private void menuStartNormal_Click(object sender, EventArgs e)
        {
            game.Start(DifficultyLevel.Normal);
        }

        private void menuStartHard_Click(object sender, EventArgs e)
        {
            game.Start(DifficultyLevel.Hard);
        }

        private void menuPauseResume_Click(object sender, EventArgs e)
        {
            if (game.IsGameRunning)
            {
                game.Pause();
                menuPauseResume.Text = "Weiter";
            }
            else
            {
                game.Resume();
                menuPauseResume.Text = "Pause";
            }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            Graphics gfx = drawPanel.CreateGraphics();
            game.Draw(gfx);
        }
    }
}
