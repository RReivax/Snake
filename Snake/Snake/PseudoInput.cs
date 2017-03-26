using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake {
    public partial class PseudoInput : Form {
        public String p;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Enter:
                    p = pseudo.Text;
                    pseudo.Clear();
                    this.Close();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        public PseudoInput() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void ok_Click(object sender, EventArgs e) {
            p = pseudo.Text;
            pseudo.Clear();

            this.Close();
        }
    }
}
