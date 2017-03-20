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
                case Keys.Left:
                case Keys.Q:
                case Keys.Up:
                case Keys.Z:
                case Keys.Down:
                case Keys.S:
                    MessageBox.Show(keyData.ToString());
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
            state = gameState.STOP;
            gamePanel.BackColor = Color.Black;
            //temporary game init
            currentGame = new Game();
            currentGame.initGame();
            dir = currentGame.currentOrientation;
            gameLoop(1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void gameLoop(int lvl) {
            level = lvl;
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e) {
            currentGame.update(dir);
            gamePanel.SuspendLayout();
            gamePanel.Controls.Clear();
            for (int i = 0; i < Space.W; i++) {
                for(int j = 0; j < Space.H; j++) {
                    if(currentGame.Map[j, i].type != CellType.EMPTY) {
                        Console.WriteLine("Map : ( " + j + " ; " + i + " )");
                        Console.WriteLine("Type = " + currentGame.Map[j, i].type);
                        Cell tmp = new Cell(currentGame.Map[j, i].type);
                        tmp.Location = new Point(i * 20, j * 20);
                        gamePanel.Controls.Add(tmp);
                    }
                }
            }
            gamePanel.ResumeLayout();
        }
    }
}
