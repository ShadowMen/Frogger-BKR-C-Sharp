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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuDropdownStart = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPanel = new WinFrogger.DrawPanel();
            this.menuStartEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartHard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDropdownStart});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(292, 24);
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
            this.menuDropdownStart.Size = new System.Drawing.Size(43, 20);
            this.menuDropdownStart.Text = "Start";
            // 
            // drawPanel
            // 
            this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanel.Location = new System.Drawing.Point(0, 24);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(292, 249);
            this.drawPanel.TabIndex = 2;
            // 
            // menuStartEasy
            // 
            this.menuStartEasy.Name = "menuStartEasy";
            this.menuStartEasy.Size = new System.Drawing.Size(120, 22);
            this.menuStartEasy.Text = "Leicht";
            // 
            // menuStartNormal
            // 
            this.menuStartNormal.Name = "menuStartNormal";
            this.menuStartNormal.Size = new System.Drawing.Size(120, 22);
            this.menuStartNormal.Text = "Normal";
            // 
            // menuStartHard
            // 
            this.menuStartHard.Name = "menuStartHard";
            this.menuStartHard.Size = new System.Drawing.Size(120, 22);
            this.menuStartHard.Text = "Schwer";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Frogger - von Nils";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuDropdownStart;
        private DrawPanel drawPanel;
        private System.Windows.Forms.ToolStripMenuItem menuStartEasy;
        private System.Windows.Forms.ToolStripMenuItem menuStartNormal;
        private System.Windows.Forms.ToolStripMenuItem menuStartHard;
    }
}

