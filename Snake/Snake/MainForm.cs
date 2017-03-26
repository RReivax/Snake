using System;
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
        private Boolean dirRead;
        private Space.Orientation imgDir;
        private Game currentGame;
        public gameState state;
        List<Cell> buffer;
        int panelDisplay;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Right:
                case Keys.D:
                    if (dir != Space.Orientation.WEST && dirRead) {
                        dir = Space.Orientation.EAST;
                        dirRead = false;
                    }
                    return true;
                case Keys.Left:
                case Keys.Q:
                    if (dir != Space.Orientation.EAST && dirRead) {
                        dir = Space.Orientation.WEST;
                        dirRead = false;
                    }
                    return true;
                case Keys.Up:
                case Keys.Z:
                    if (dir != Space.Orientation.SOUTH && dirRead) {
                        dir = Space.Orientation.NORTH;
                        dirRead = false;
                    }
                    return true;
                case Keys.Down:
                case Keys.S:
                    if (dir != Space.Orientation.NORTH && dirRead) {
                        dir = Space.Orientation.SOUTH;
                        dirRead = false;
                    }
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public MainForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
            buffer = new List<Cell>();
            dirRead = false;
            state = gameState.STOP;
            gamePanel.BackColor = Color.Black;
            gamePanel.BorderStyle = BorderStyle.FixedSingle;
            gamePanel2.BackColor = Color.Black;
            gamePanel2.BorderStyle = BorderStyle.FixedSingle;
            imgDir = Space.Orientation.NORTH;
            panelDisplay = 1;
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
                    dirRead = true;
                    updateMap();
                } else {
                    if(state != gameState.PAUSE)
                        endOfGame();
                }
            }
        }

        private void updateMap() {
            int nb_img = 0;
            for (int i = 0; i < Space.W; i++) {
                for(int j = 0; j < Space.H; j++) {
                    if(currentGame.Map[j, i].type != CellType.EMPTY) {
                        nb_img++;
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
                        buffer.Add(currentGame.Map[j,i]);
                    }
                }
            }
            if(panelDisplay == 1) {
                gamePanel2.Controls.Clear();
                gamePanel2.Controls.AddRange(buffer.ToArray());
                gamePanel2.Visible = true;
                gamePanel.Visible = false;
                panelDisplay = 2;
            } else {
                gamePanel.Controls.Clear();
                gamePanel.Controls.AddRange(buffer.ToArray());
                gamePanel.Visible = true;
                gamePanel2.Visible = false;
                panelDisplay = 1;
            }
            buffer.Clear();
        }

        private void endOfGame(Boolean wall = false) {
            state = gameState.STOP;
            timer.Stop();
            this.buttonPlayPause.Text = "Play";
            gamePanel.Visible = false;
            gamePanel2.Visible = false;
            scoresPanel.Visible = true;
            gamePanel.Controls.Clear();
            gamePanel2.Controls.Clear();
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
            gamePanel.Visible = false;
            gamePanel2.Visible = false;
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
            gamePanel.Visible = false;
            gamePanel2.Visible = false;
            scoresPanel.Visible = true;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            gamePanel.Visible = true;
            gamePanel2.Visible = false;
            panelDisplay = 1;
            scoresPanel.Visible = false;
        }

        private void gamePanel2_Paint(object sender, PaintEventArgs e) {

        }
    }
}
