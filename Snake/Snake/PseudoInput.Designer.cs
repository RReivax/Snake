namespace Snake {
    partial class PseudoInput {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pseudo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pseudo
            // 
            this.pseudo.Location = new System.Drawing.Point(12, 28);
            this.pseudo.Name = "pseudo";
            this.pseudo.Size = new System.Drawing.Size(112, 20);
            this.pseudo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your pseudo bellow ;)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(151, 28);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(59, 20);
            this.ok.TabIndex = 2;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // PseudoInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 60);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pseudo);
            this.Name = "PseudoInput";
            this.Text = "Congratulations!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pseudo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok;
    }
}