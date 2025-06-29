namespace _02_Pool_Club
{
    partial class ctrlPoolClub
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbTable = new System.Windows.Forms.GroupBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.TableTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gbTable
            // 
            this.gbTable.Controls.Add(this.lblPlayerName);
            this.gbTable.Controls.Add(this.lblTimer);
            this.gbTable.Controls.Add(this.btnEnd);
            this.gbTable.Controls.Add(this.btnStartStop);
            this.gbTable.Controls.Add(this.pictureBox1);
            this.gbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTable.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTable.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gbTable.Location = new System.Drawing.Point(0, 0);
            this.gbTable.Name = "gbTable";
            this.gbTable.Size = new System.Drawing.Size(299, 281);
            this.gbTable.TabIndex = 5;
            this.gbTable.TabStop = false;
            this.gbTable.Text = "Table 1";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.SystemColors.Info;
            this.lblPlayerName.Location = new System.Drawing.Point(108, 48);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(84, 24);
            this.lblPlayerName.TabIndex = 8;
            this.lblPlayerName.Text = "Player 1";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTimer.Location = new System.Drawing.Point(105, 107);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(90, 24);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "00:00:00";
            // 
            // btnEnd
            // 
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.ForeColor = System.Drawing.Color.Red;
            this.btnEnd.Location = new System.Drawing.Point(26, 173);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(104, 30);
            this.btnEnd.TabIndex = 6;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.ForeColor = System.Drawing.Color.Lime;
            this.btnStartStop.Location = new System.Drawing.Point(169, 173);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(104, 30);
            this.btnStartStop.TabIndex = 5;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // TableTimer
            // 
            this.TableTimer.Interval = 1000;
            this.TableTimer.Tick += new System.EventHandler(this.TableTimer_Tick);
            // 
            // ctrlPoolClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.gbTable);
            this.Name = "ctrlPoolClub";
            this.Size = new System.Drawing.Size(299, 281);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbTable.ResumeLayout(false);
            this.gbTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbTable;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Timer TableTimer;
    }
}
