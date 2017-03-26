﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public enum gameState { PLAY, PAUSE, STOP};
    public partial class MainForm : Form
    {
        private int level;
        private Space.Orientation dir;
        private Space.Orientation imgDir;
        private Game currentGame;
        public gameState state;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Right:
                case Keys.D:
                    if (dir != Space.Orientation.WEST)
                        dir = Space.Orientation.EAST;
                    return true;
                case Keys.Left:
                case Keys.Q:
                    if (dir != Space.Orientation.EAST)
                        dir = Space.Orientation.WEST;
                    return true;
                case Keys.Up:
                case Keys.Z:
                    if (dir != Space.Orientation.SOUTH)
                        dir = Space.Orientation.NORTH;
                    return true;
                case Keys.Down:
                case Keys.S:
                    if (dir != Space.Orientation.NORTH)
                        dir = Space.Orientation.SOUTH;
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public MainForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
            state = gameState.STOP;
            gamePanel.BackColor = Color.Black;
            gamePanel.BorderStyle = BorderStyle.FixedSingle;
            imgDir = Space.Orientation.NORTH;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void gameLoop(int lvl = 1) {
            currentGame = new Game();
            currentGame.initGame();
            dir = currentGame.currentOrientation;
            timer.Interval = 200/(int)Math.Sqrt(lvl);
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) {
            if(state == gameState.PLAY) {
                if (currentGame.update(dir)) {
                    updateMap();
                } else {
                    if(state != gameState.PAUSE)
                        endOfGame();
                }
            }
        }

        private void updateMap() {
            gamePanel.SuspendLayout();
            gamePanel.Controls.Clear();
            for (int i = 0; i < Space.W; i++) {
                for(int j = 0; j < Space.H; j++) {
                    if(currentGame.Map[j, i].type != CellType.EMPTY) {
                        Console.WriteLine("Map : ( " + j + " ; " + i + " )");
                        Console.WriteLine("Type = " + currentGame.Map[j, i].type);
                        currentGame.Map[j, i].Location = new Point(i * 20, j * 20);
                        currentGame.Map[j, i].Size = new Size(20, 20);

                        if (currentGame.Map[j, i].type == CellType.HEAD)
                        {
                            while (imgDir != dir)
                            {
                                currentGame.Map[j, i].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                if (imgDir == Space.Orientation.EAST)
                                    imgDir = Space.Orientation.NORTH;
                                else
                                    imgDir++;
                            }
                        }
                        gamePanel.Controls.Add(currentGame.Map[j,i]);
                    }
                }
            }
            gamePanel.ResumeLayout();
        }

        private void endOfGame(Boolean wall = false) {
            timer.Stop();
            scoresPanel.Visible = true;
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (this.buttonPlayPause.Text == "Play")
            {
                if(state == gameState.STOP) {
                    gameLoop();
                }
                state = gameState.PLAY;
                this.buttonPlayPause.Text = "Pause";
            }
            else
            {
                state = gameState.PAUSE;
                this.buttonPlayPause.Text = "Play";
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            state = gameState.STOP;
            gamePanel.Controls.Clear();
            scoresPanel.Visible = true;
            this.buttonPlayPause.Text = "Play";
        }

        private void buttonScores_Click(object sender, EventArgs e)
        {
            if (state == gameState.PLAY)
            {
                state = gameState.PAUSE;
                this.buttonPlayPause.Text = "Play";
            }
            scoresPanel.Visible = true;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            scoresPanel.Visible = false;
        }

    }
}
