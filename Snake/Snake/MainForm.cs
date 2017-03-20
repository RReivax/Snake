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
    public enum gameState { PLAY, PAUSE, STOP }

    public partial class MainForm : Form
    {
        public gameState state;

        public MainForm()
        {
            InitializeComponent();
            state = gameState.STOP;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            Cell pic = new Cell(CellType.HEAD);           
            gamePanel.Controls.Add(pic);
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (this.buttonPlayPause.Text == "Play")
            {
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
        }

        private void buttonScores_Click(object sender, EventArgs e)
        {
            if (state == gameState.PLAY) state = gameState.PAUSE;
            scoresPanel.Visible = true;
            
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            scoresPanel.Visible = false;
        }

    }
}
