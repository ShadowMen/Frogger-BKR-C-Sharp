using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WinFrogger
{
    public partial class MainForm : Form
    {
        // Variabeln
        Game game;
        Thread drawThread;
        bool keyPressed;
        volatile bool stopThread;

        public MainForm()
        {
            InitializeComponent();

            game = new Game();

            keyPressed = false;
            stopThread = false;
        }

        private void Draw()
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer = context.Allocate(drawPanel.CreateGraphics(), new Rectangle(0, 0, drawPanel.Size.Width, drawPanel.Size.Height));
            
            while (!stopThread)
            {
                game.Draw(myBuffer.Graphics);
                myBuffer.Render();
            }
        }

        private void menuDropdownStart_Click(object sender, EventArgs e)
        {
            if (game.State == GameState.Stopped)
            {
                // Game
                game.Start();

                // Update Timer
                updateTimer.Start();

                // Hintergrund Musik
                game.PlayMusic();

                // Draw Thread
                if (drawThread == null) drawThread = new Thread(new ThreadStart(this.Draw));
                stopThread = false;
                drawThread.Start();

                // Menu
                menuPauseResume.Text = "Pause";
                menuPauseResume.Enabled = true;
                menuDropdownStart.Text = "Stop";
            }
            else if (game.State == GameState.Paused)
            {
                // Game
                game.Stop();

                // Update Timer
                updateTimer.Stop();

                // Hintergrund Musik
                game.StopMusic();

                // Thread
                stopThread = true;
                drawThread.Abort();
                drawThread = null;

                // Menu
                menuPauseResume.Enabled = false;
                menuDropdownStart.Text = "Start";

                // Ausgabe leeren
                drawPanel.Invalidate();
            }
        }

        private void menuPauseResume_Click(object sender, EventArgs e)
        {
            if (game.State == GameState.Running)
            {
                game.Pause();
                updateTimer.Stop();
                menuPauseResume.Text = "Weiter";
            }
            else
            {
                game.Resume();
                updateTimer.Start();
                menuPauseResume.Text = "Pause";
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!keyPressed)
            {
                game.HandleInput(e.KeyData);
                keyPressed = true;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopThread = true;
            if(drawThread != null) drawThread.Abort();
        }

        private void menuShowInfoBox_Click(object sender, EventArgs e)
        {
            InfoBox infobox = new InfoBox();
            
            // Spiel pausieren, wenn es läuft
            if(game.State == GameState.Running) game.Pause();
            
            // Infobox anzeigen
            infobox.ShowDialog();
            
            // Weiterspielen, wenn das Spiel pausiert ist
            if(game.State == GameState.Paused) game.Resume();
        }
    }
}
