namespace BankSystem.SystemSettings.Controls
{
    partial class ctrlCustomBtn
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
            this.pnlBtnContainer = new System.Windows.Forms.Panel();
            this.lblBtnTitle = new System.Windows.Forms.Label();
            this.pbBtnImg = new System.Windows.Forms.PictureBox();
            this.pnlBtnContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBtnContainer
            // 
            this.pnlBtnContainer.Controls.Add(this.lblBtnTitle);
            this.pnlBtnContainer.Controls.Add(this.pbBtnImg);
            this.pnlBtnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBtnContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlBtnContainer.Name = "pnlBtnContainer";
            this.pnlBtnContainer.Size = new System.Drawing.Size(289, 53);
            this.pnlBtnContainer.TabIndex = 0;
            this.pnlBtnContainer.Click += new System.EventHandler(this.pnlBtnContainer_Click);
            this.pnlBtnContainer.MouseEnter += new System.EventHandler(this.pnlBtnContainer_MouseEnter);
            this.pnlBtnContainer.MouseLeave += new System.EventHandler(this.pnlBtnContainer_MouseLeave);
            // 
            // lblBtnTitle
            // 
            this.lblBtnTitle.AutoSize = true;
            this.lblBtnTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBtnTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblBtnTitle.Location = new System.Drawing.Point(93, 17);
            this.lblBtnTitle.Name = "lblBtnTitle";
            this.lblBtnTitle.Size = new System.Drawing.Size(160, 23);
            this.lblBtnTitle.TabIndex = 5;
            this.lblBtnTitle.Text = "App && Branch Info";
            this.lblBtnTitle.Click += new System.EventHandler(this.pnlBtnContainer_Click);
            this.lblBtnTitle.MouseEnter += new System.EventHandler(this.pnlBtnContainer_MouseEnter);
            this.lblBtnTitle.MouseLeave += new System.EventHandler(this.pnlBtnContainer_MouseLeave);
            // 
            // pbBtnImg
            // 
            this.pbBtnImg.Location = new System.Drawing.Point(35, 13);
            this.pbBtnImg.Name = "pbBtnImg";
            this.pbBtnImg.Size = new System.Drawing.Size(34, 27);
            this.pbBtnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBtnImg.TabIndex = 4;
            this.pbBtnImg.TabStop = false;
            this.pbBtnImg.Click += new System.EventHandler(this.pnlBtnContainer_Click);
            this.pbBtnImg.MouseEnter += new System.EventHandler(this.pnlBtnContainer_MouseEnter);
            this.pbBtnImg.MouseLeave += new System.EventHandler(this.pnlBtnContainer_MouseLeave);
            // 
            // ctrlCustomBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.Controls.Add(this.pnlBtnContainer);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ctrlCustomBtn";
            this.Size = new System.Drawing.Size(289, 53);
            this.pnlBtnContainer.ResumeLayout(false);
            this.pnlBtnContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBtnImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBtnContainer;
        private System.Windows.Forms.Label lblBtnTitle;
        private System.Windows.Forms.PictureBox pbBtnImg;
    }
}
