namespace Snake
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonScores = new System.Windows.Forms.Button();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.scoresPanel = new System.Windows.Forms.Panel();
            this.scoreList = new System.Windows.Forms.Label();
            this.scoreTitle = new System.Windows.Forms.Label();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.scoresPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(17, 100);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(800, 500);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.buttonStop);
            this.menuPanel.Controls.Add(this.buttonScores);
            this.menuPanel.Controls.Add(this.buttonPlayPause);
            this.menuPanel.Location = new System.Drawing.Point(17, 13);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 81);
            this.menuPanel.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(100, 10);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(80, 60);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonScores
            // 
            this.buttonScores.Location = new System.Drawing.Point(710, 10);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(80, 60);
            this.buttonScores.TabIndex = 1;
            this.buttonScores.Text = "Scores";
            this.buttonScores.UseVisualStyleBackColor = true;
            this.buttonScores.Click += new System.EventHandler(this.buttonScores_Click);
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.Location = new System.Drawing.Point(10, 10);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(80, 60);
            this.buttonPlayPause.TabIndex = 0;
            this.buttonPlayPause.Text = "Play";
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // scoresPanel
            // 
            this.scoresPanel.Controls.Add(this.scoreList);
            this.scoresPanel.Controls.Add(this.scoreTitle);
            this.scoresPanel.Controls.Add(this.buttonPrev);
            this.scoresPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scoresPanel.Location = new System.Drawing.Point(0, 0);
            this.scoresPanel.Name = "scoresPanel";
            this.scoresPanel.Size = new System.Drawing.Size(834, 611);
            this.scoresPanel.TabIndex = 2;
            this.scoresPanel.Visible = false;
            // 
            // scoreList
            // 
            this.scoreList.Location = new System.Drawing.Point(117, 100);
            this.scoreList.Name = "scoreList";
            this.scoreList.Size = new System.Drawing.Size(600, 500);
            this.scoreList.TabIndex = 2;
            this.scoreList.Text = "blabal";
            // 
            // scoreTitle
            // 
            this.scoreTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F);
            this.scoreTitle.Location = new System.Drawing.Point(0, 0);
            this.scoreTitle.Name = "scoreTitle";
            this.scoreTitle.Size = new System.Drawing.Size(834, 107);
            this.scoreTitle.TabIndex = 1;
            this.scoreTitle.Text = "Scores";
            this.scoreTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(12, 561);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(95, 39);
            this.buttonPrev.TabIndex = 0;
            this.buttonPrev.Text = "Previous";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 611);
            this.Controls.Add(this.scoresPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.gamePanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuPanel.ResumeLayout(false);
            this.scoresPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonScores;
        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Panel scoresPanel;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Label scoreTitle;
        private System.Windows.Forms.Label scoreList;
    }
}