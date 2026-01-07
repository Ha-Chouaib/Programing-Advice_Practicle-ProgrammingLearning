namespace BankSystem
{
    partial class frmBaseForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbBankIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblClok = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBankIcon)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlTopLeft.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(113)))));
            this.pnlHeader.Controls.Add(this.pnlTopRight);
            this.pnlHeader.Controls.Add(this.pnlTopLeft);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1292, 89);
            this.pnlHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankSystem.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(490, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(198, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = " Welcome, [ User Name ]";
            // 
            // pbBankIcon
            // 
            this.pbBankIcon.Image = global::BankSystem.Properties.Resources.bank;
            this.pbBankIcon.Location = new System.Drawing.Point(4, 4);
            this.pbBankIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pbBankIcon.Name = "pbBankIcon";
            this.pbBankIcon.Size = new System.Drawing.Size(109, 62);
            this.pbBankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBankIcon.TabIndex = 2;
            this.pbBankIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(121, 4);
            this.lblHeaderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(505, 54);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Bank Managment System";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.pnlFooter.Controls.Add(this.lblClok);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 566);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1292, 42);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblClok
            // 
            this.lblClok.AutoSize = true;
            this.lblClok.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClok.Location = new System.Drawing.Point(12, 15);
            this.lblClok.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClok.Name = "lblClok";
            this.lblClok.Size = new System.Drawing.Size(172, 23);
            this.lblClok.TabIndex = 0;
            this.lblClok.Text = "30/010/2025 12:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.pbBankIcon);
            this.pnlTopLeft.Controls.Add(this.lblHeaderTitle);
            this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(691, 89);
            this.pnlTopLeft.TabIndex = 2;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.label2);
            this.pnlTopRight.Controls.Add(this.pictureBox1);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTopRight.Location = new System.Drawing.Point(650, 0);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(642, 89);
            this.pnlTopRight.TabIndex = 2;
            // 
            // frmBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 608);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaseForm";
            this.Text = "frmBaseForm";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBankIcon)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            this.pnlTopRight.ResumeLayout(false);
            this.pnlTopRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbBankIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblClok;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlTopLeft;
        private System.Windows.Forms.Panel pnlTopRight;
    }
}