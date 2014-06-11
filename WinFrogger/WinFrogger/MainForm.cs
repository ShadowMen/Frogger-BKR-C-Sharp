﻿using System;
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
        volatile bool stopThread = false;

        public MainForm()
        {
            InitializeComponent();

            game = new Game();

            // Threaded Drawing
            drawThread = new Thread(new ThreadStart(this.Draw));
        }

        private void Draw()
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            BufferedGraphics myBuffer =  context.Allocate(drawPanel.CreateGraphics(), drawPanel.Bounds);
            
            while (!stopThread)
            {
                game.Draw(myBuffer.Graphics);
                myBuffer.Render();
            }
        }

        private void menuDropdownStart_Click(object sender, EventArgs e)
        {
            if (game.IsGameRunning) return;
            updateTimer.Start();
            drawThread.Start();
            menuPauseResume.Enabled = true;
        }

        private void menuPauseResume_Click(object sender, EventArgs e)
        {
            if (game.IsGameRunning)
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
            game.HandleInput(e.KeyData);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopThread = true;
            drawThread.Abort();
        }
    }
}
