namespace DVLD_Project.Applications
{
    partial class frmDisplayApplicationDetails
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
            this.ctrlDisplayApplicationLicenseInfo1 = new DVLD_Project.Applications.User_Controls.ctrlDisplayApplicationLicenseInfo();
            this.ctrlDisplayApplicationInfo1 = new DVLD_Project.Applications.User_Controls.ctrlDisplayApplicationInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlDisplayApplicationLicenseInfo1
            // 
            this.ctrlDisplayApplicationLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlDisplayApplicationLicenseInfo1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDisplayApplicationLicenseInfo1.ForeColor = System.Drawing.SystemColors.Info;
            this.ctrlDisplayApplicationLicenseInfo1.Location = new System.Drawing.Point(15, 109);
            this.ctrlDisplayApplicationLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDisplayApplicationLicenseInfo1.Name = "ctrlDisplayApplicationLicenseInfo1";
            this.ctrlDisplayApplicationLicenseInfo1.Size = new System.Drawing.Size(1080, 135);
            this.ctrlDisplayApplicationLicenseInfo1.TabIndex = 0;
            // 
            // ctrlDisplayApplicationInfo1
            // 
            this.ctrlDisplayApplicationInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlDisplayApplicationInfo1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDisplayApplicationInfo1.ForeColor = System.Drawing.SystemColors.Info;
            this.ctrlDisplayApplicationInfo1.Location = new System.Drawing.Point(15, 254);
            this.ctrlDisplayApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDisplayApplicationInfo1.Name = "ctrlDisplayApplicationInfo1";
            this.ctrlDisplayApplicationInfo1.Size = new System.Drawing.Size(1081, 230);
            this.ctrlDisplayApplicationInfo1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(508, 509);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 32.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(349, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "Application Details";
            // 
            // frmDisplayApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1108, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDisplayApplicationInfo1);
            this.Controls.Add(this.ctrlDisplayApplicationLicenseInfo1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDisplayApplicationDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDisplayApplicationDetails";
            this.Load += new System.EventHandler(this.frmDisplayApplicationDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Controls.ctrlDisplayApplicationLicenseInfo ctrlDisplayApplicationLicenseInfo1;
        private User_Controls.ctrlDisplayApplicationInfo ctrlDisplayApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}