namespace XOGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStartGame = new Button();
            lblXScore = new Label();
            lblOScore = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(38, 18);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(94, 29);
            btnStartGame.TabIndex = 0;
            btnStartGame.Text = "Start game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            btnStartGame.KeyDown += btnStartGame_KeyDown;
            // 
            // lblXScore
            // 
            lblXScore.AutoSize = true;
            lblXScore.BackColor = Color.IndianRed;
            lblXScore.ForeColor = SystemColors.Control;
            lblXScore.Location = new Point(42, 59);
            lblXScore.Name = "lblXScore";
            lblXScore.Size = new Size(21, 20);
            lblXScore.TabIndex = 1;
            lblXScore.Text = "X:";
            // 
            // lblOScore
            // 
            lblOScore.AutoSize = true;
            lblOScore.BackColor = Color.Blue;
            lblOScore.ForeColor = SystemColors.Control;
            lblOScore.Location = new Point(42, 95);
            lblOScore.Name = "lblOScore";
            lblOScore.Size = new Size(23, 20);
            lblOScore.TabIndex = 2;
            lblOScore.Text = "O:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(582, 553);
            Controls.Add(lblOScore);
            Controls.Add(lblXScore);
            Controls.Add(btnStartGame);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartGame;
        private Label lblXScore;
        private Label lblOScore;
        private System.Windows.Forms.Timer timer1;
    }
}
