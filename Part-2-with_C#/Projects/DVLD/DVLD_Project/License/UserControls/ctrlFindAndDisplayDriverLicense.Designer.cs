namespace DVLD_Project.License.UserControls
{
    partial class ctrlFindAndDisplayDriverLicense
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
            this.ctrlDisplayDriverLicenseInfo1 = new DVLD_Project.License.UserControls.ctrlDisplayDriverLocalLicenseInfo();
            this.ctrlFindLicense1 = new DVLD_Project.License.UserControls.ctrlFindLicense();
            this.SuspendLayout();
            // 
            // ctrlDisplayDriverLicenseInfo1
            // 
            this.ctrlDisplayDriverLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlDisplayDriverLicenseInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlDisplayDriverLicenseInfo1.Location = new System.Drawing.Point(0, 108);
            this.ctrlDisplayDriverLicenseInfo1.Name = "ctrlDisplayDriverLicenseInfo1";
            this.ctrlDisplayDriverLicenseInfo1.Size = new System.Drawing.Size(1020, 402);
            this.ctrlDisplayDriverLicenseInfo1.TabIndex = 0;
            // 
            // ctrlFindLicense1
            // 
            this.ctrlFindLicense1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlFindLicense1.Location = new System.Drawing.Point(153, 12);
            this.ctrlFindLicense1.Name = "ctrlFindLicense1";
            this.ctrlFindLicense1.Size = new System.Drawing.Size(709, 73);
            this.ctrlFindLicense1.TabIndex = 1;
            // 
            // ctrlFindAndDisplayDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.ctrlFindLicense1);
            this.Controls.Add(this.ctrlDisplayDriverLicenseInfo1);
            this.Name = "ctrlFindAndDisplayDriverLicense";
            this.Size = new System.Drawing.Size(1020, 510);
            this.Load += new System.EventHandler(this.ctrlFindAndDisplayDriverLicense_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDisplayDriverLocalLicenseInfo ctrlDisplayDriverLicenseInfo1;
        private ctrlFindLicense ctrlFindLicense1;
    }
}
