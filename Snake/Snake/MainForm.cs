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
        private Game currentGame;

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


    public gameState state;
        public MainForm()
        {
            this.KeyPreview = true;
            InitializeComponent();
            state = gameState.PLAY;
            gamePanel.BackColor = Color.Black;
            gamePanel.BorderStyle = BorderStyle.FixedSingle;
            currentGame = new Game();
            currentGame.initGame();
            dir = currentGame.currentOrientation;
            //temporary game init
            gameLoop(1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void gameLoop(int lvl) {
            timer.Interval = 500/(int)Math.Sqrt(4);
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) {
            if(state == gameState.PLAY) {
                Boolean wall = currentGame.update(dir);
                if (wall) {
                    updateMap();
                } else {
                    endOfGame(wall);
                }
            }
        }

        private void updateMap() {
            //gamePanel.SuspendLayout();
            gamePanel.Controls.Clear();
            for (int i = 0; i < Space.W; i++) {
                for(int j = 0; j < Space.H; j++) {
                    if(currentGame.Map[j, i].type != CellType.EMPTY) {
                        Console.WriteLine("Map : ( " + j + " ; " + i + " )");
                        Console.WriteLine("Type = " + currentGame.Map[j, i].type);
                        currentGame.Map[j, i].Location = new Point(i * 20, j * 20);
                        currentGame.Map[j, i].Size = new Size(20, 20);                        
                        gamePanel.Controls.Add(currentGame.Map[j,i]);
                    }
                }
            }
            //gamePanel.ResumeLayout();
        }

        private void endOfGame(Boolean wall = false) {
            timer.Stop();
            if (wall) {

            } else {

            }

        }
    }
}
