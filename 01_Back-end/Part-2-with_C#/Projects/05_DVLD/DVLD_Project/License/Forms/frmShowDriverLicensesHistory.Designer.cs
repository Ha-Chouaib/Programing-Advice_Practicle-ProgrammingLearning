namespace DVLD_Project.License
{
    partial class frmShowDriverLicensesHistory
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPersonDetails1 = new DVLD_Project.ctrlPersonDetails();
            this.ctrlDriverLicensesHistory1 = new DVLD_Project.License.UserControls.ctrlDriverLicensesHistory();
            this.pbHistory = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(576, 854);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 31);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(437, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Driver Licenses History";
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.@__PersonID = 0;
            this.ctrlPersonDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(416, 97);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(801, 347);
            this.ctrlPersonDetails1.TabIndex = 1;
            // 
            // ctrlDriverLicensesHistory1
            // 
            this.ctrlDriverLicensesHistory1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlDriverLicensesHistory1.Location = new System.Drawing.Point(26, 450);
            this.ctrlDriverLicensesHistory1.Name = "ctrlDriverLicensesHistory1";
            this.ctrlDriverLicensesHistory1.Size = new System.Drawing.Size(1191, 386);
            this.ctrlDriverLicensesHistory1.TabIndex = 0;
            // 
            // pbHistory
            // 
            this.pbHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pbHistory.Image = global::DVLD_Project.Properties.Resources.PersonLicenseHistory_512;
            this.pbHistory.Location = new System.Drawing.Point(72, 97);
            this.pbHistory.Name = "pbHistory";
            this.pbHistory.Size = new System.Drawing.Size(297, 309);
            this.pbHistory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHistory.TabIndex = 4;
            this.pbHistory.TabStop = false;
            // 
            // frmShowDriverLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1242, 897);
            this.Controls.Add(this.pbHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.ctrlDriverLicensesHistory1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowDriverLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowDriverLicensesHistory";
            this.Load += new System.EventHandler(this.frmShowDriverLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlDriverLicensesHistory ctrlDriverLicensesHistory1;
        private ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbHistory;
    }
}