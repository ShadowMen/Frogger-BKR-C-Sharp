namespace WinFrogger
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuDropdownStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartHard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPauseResume = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlayerName = new System.Windows.Forms.ToolStripTextBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.drawPanel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDropdownStart,
            this.menuPauseResume,
            this.menuPlayerName});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(608, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuDropdownStart
            // 
            this.menuDropdownStart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStartEasy,
            this.menuStartNormal,
            this.menuStartHard});
            this.menuDropdownStart.Name = "menuDropdownStart";
            this.menuDropdownStart.Size = new System.Drawing.Size(43, 21);
            this.menuDropdownStart.Text = "Start";
            // 
            // menuStartEasy
            // 
            this.menuStartEasy.Name = "menuStartEasy";
            this.menuStartEasy.Size = new System.Drawing.Size(120, 22);
            this.menuStartEasy.Text = "Leicht";
            this.menuStartEasy.Click += new System.EventHandler(this.menuStartEasy_Click);
            // 
            // menuStartNormal
            // 
            this.menuStartNormal.Name = "menuStartNormal";
            this.menuStartNormal.Size = new System.Drawing.Size(120, 22);
            this.menuStartNormal.Text = "Normal";
            this.menuStartNormal.Click += new System.EventHandler(this.menuStartNormal_Click);
            // 
            // menuStartHard
            // 
            this.menuStartHard.Name = "menuStartHard";
            this.menuStartHard.Size = new System.Drawing.Size(120, 22);
            this.menuStartHard.Text = "Schwer";
            this.menuStartHard.Click += new System.EventHandler(this.menuStartHard_Click);
            // 
            // menuPauseResume
            // 
            this.menuPauseResume.Enabled = false;
            this.menuPauseResume.Name = "menuPauseResume";
            this.menuPauseResume.Size = new System.Drawing.Size(48, 21);
            this.menuPauseResume.Text = "Pause";
            this.menuPauseResume.Click += new System.EventHandler(this.menuPauseResume_Click);
            // 
            // menuPlayerName
            // 
            this.menuPlayerName.Name = "menuPlayerName";
            this.menuPlayerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuPlayerName.Size = new System.Drawing.Size(100, 21);
            this.menuPlayerName.Text = "Player";
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 33;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 50;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // drawPanel
            // 
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(0, 25);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(608, 450);
            this.drawPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 475);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(614, 500);
            this.Name = "MainForm";
            this.Text = "Frogger - von Nils";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuDropdownStart;
        private System.Windows.Forms.ToolStripMenuItem menuStartEasy;
        private System.Windows.Forms.ToolStripMenuItem menuStartNormal;
        private System.Windows.Forms.ToolStripMenuItem menuStartHard;
        private System.Windows.Forms.ToolStripMenuItem menuPauseResume;
        private System.Windows.Forms.ToolStripTextBox menuPlayerName;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer drawTimer;
        private System.Windows.Forms.Panel drawPanel;
    }
}

