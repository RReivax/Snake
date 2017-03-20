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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gameLoop(int lvl) {
            level = lvl;

        }
    }
}
