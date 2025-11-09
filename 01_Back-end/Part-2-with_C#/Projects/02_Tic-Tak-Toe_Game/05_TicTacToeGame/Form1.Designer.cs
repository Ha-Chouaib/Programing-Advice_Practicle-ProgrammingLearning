namespace _05_TicTacToeGame
{
    partial class Form1
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
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb6 = new System.Windows.Forms.PictureBox();
            this.pb7 = new System.Windows.Forms.PictureBox();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.pb5 = new System.Windows.Forms.PictureBox();
            this.pb8 = new System.Windows.Forms.PictureBox();
            this.pb9 = new System.Windows.Forms.PictureBox();
            this.btnRestartGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb9)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTurn.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTurn.Location = new System.Drawing.Point(41, 119);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(105, 45);
            this.lblTurn.TabIndex = 0;
            this.lblTurn.Text = "Turn:";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlayer.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblPlayer.Location = new System.Drawing.Point(42, 169);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(120, 40);
            this.lblPlayer.TabIndex = 1;
            this.lblPlayer.Text = "Player1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(481, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(473, 68);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tic-Tac-Toe Game";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblWinner.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Yellow;
            this.lblWinner.Location = new System.Drawing.Point(74, 302);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(62, 45);
            this.lblWinner.TabIndex = 4;
            this.lblWinner.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(41, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Winner";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightYellow;
            this.label1.Location = new System.Drawing.Point(41, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "Game State";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblState.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblState.Location = new System.Drawing.Point(41, 453);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(241, 45);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "In Progress...";
            // 
            // pb1
            // 
            this.pb1.BackColor = System.Drawing.Color.Black;
            this.pb1.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb1.Location = new System.Drawing.Point(425, 169);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(125, 96);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb1.TabIndex = 8;
            this.pb1.TabStop = false;
            this.pb1.Tag = "?";
            this.pb1.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb3
            // 
            this.pb3.BackColor = System.Drawing.Color.Black;
            this.pb3.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb3.Location = new System.Drawing.Point(874, 169);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(125, 96);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb3.TabIndex = 10;
            this.pb3.TabStop = false;
            this.pb3.Tag = "?";
            this.pb3.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb2
            // 
            this.pb2.BackColor = System.Drawing.Color.Black;
            this.pb2.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb2.Location = new System.Drawing.Point(652, 169);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(125, 96);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb2.TabIndex = 11;
            this.pb2.TabStop = false;
            this.pb2.Tag = "?";
            this.pb2.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb6
            // 
            this.pb6.BackColor = System.Drawing.Color.Black;
            this.pb6.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb6.Location = new System.Drawing.Point(874, 340);
            this.pb6.Name = "pb6";
            this.pb6.Size = new System.Drawing.Size(125, 96);
            this.pb6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb6.TabIndex = 17;
            this.pb6.TabStop = false;
            this.pb6.Tag = "?";
            this.pb6.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb7
            // 
            this.pb7.BackColor = System.Drawing.Color.Black;
            this.pb7.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb7.Location = new System.Drawing.Point(430, 532);
            this.pb7.Name = "pb7";
            this.pb7.Size = new System.Drawing.Size(125, 96);
            this.pb7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb7.TabIndex = 18;
            this.pb7.TabStop = false;
            this.pb7.Tag = "?";
            this.pb7.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb4
            // 
            this.pb4.BackColor = System.Drawing.Color.Black;
            this.pb4.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb4.Location = new System.Drawing.Point(425, 340);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(125, 96);
            this.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb4.TabIndex = 19;
            this.pb4.TabStop = false;
            this.pb4.Tag = "?";
            this.pb4.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb5
            // 
            this.pb5.BackColor = System.Drawing.Color.Black;
            this.pb5.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb5.Location = new System.Drawing.Point(652, 340);
            this.pb5.Name = "pb5";
            this.pb5.Size = new System.Drawing.Size(125, 96);
            this.pb5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb5.TabIndex = 20;
            this.pb5.TabStop = false;
            this.pb5.Tag = "?";
            this.pb5.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb8
            // 
            this.pb8.BackColor = System.Drawing.Color.Black;
            this.pb8.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb8.Location = new System.Drawing.Point(652, 532);
            this.pb8.Name = "pb8";
            this.pb8.Size = new System.Drawing.Size(125, 96);
            this.pb8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb8.TabIndex = 21;
            this.pb8.TabStop = false;
            this.pb8.Tag = "?";
            this.pb8.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // pb9
            // 
            this.pb9.BackColor = System.Drawing.Color.Black;
            this.pb9.Image = global::_05_TicTacToeGame.Properties.Resources.Qst_Image;
            this.pb9.Location = new System.Drawing.Point(874, 532);
            this.pb9.Name = "pb9";
            this.pb9.Size = new System.Drawing.Size(125, 96);
            this.pb9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb9.TabIndex = 22;
            this.pb9.TabStop = false;
            this.pb9.Tag = "?";
            this.pb9.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // btnRestartGame
            // 
            this.btnRestartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRestartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestartGame.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnRestartGame.FlatAppearance.BorderSize = 0;
            this.btnRestartGame.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestartGame.Location = new System.Drawing.Point(49, 532);
            this.btnRestartGame.Name = "btnRestartGame";
            this.btnRestartGame.Size = new System.Drawing.Size(211, 72);
            this.btnRestartGame.TabIndex = 23;
            this.btnRestartGame.Text = "Restart Game";
            this.btnRestartGame.UseVisualStyleBackColor = false;
            this.btnRestartGame.Click += new System.EventHandler(this.btnRestartGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1283, 726);
            this.Controls.Add(this.btnRestartGame);
            this.Controls.Add(this.pb9);
            this.Controls.Add(this.pb8);
            this.Controls.Add(this.pb5);
            this.Controls.Add(this.pb4);
            this.Controls.Add(this.pb7);
            this.Controls.Add(this.pb6);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblTurn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb6;
        private System.Windows.Forms.PictureBox pb7;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.PictureBox pb5;
        private System.Windows.Forms.PictureBox pb8;
        private System.Windows.Forms.PictureBox pb9;
        private System.Windows.Forms.Button btnRestartGame;
    }
}

