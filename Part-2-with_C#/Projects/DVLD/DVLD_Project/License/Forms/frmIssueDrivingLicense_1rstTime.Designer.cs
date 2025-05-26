namespace DVLD_Project.License
{
    partial class frmIssueDrivingLicense_1rstTime
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlDisplayApplicationLicenseInfo1
            // 
            this.ctrlDisplayApplicationLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlDisplayApplicationLicenseInfo1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDisplayApplicationLicenseInfo1.ForeColor = System.Drawing.SystemColors.Info;
            this.ctrlDisplayApplicationLicenseInfo1.Location = new System.Drawing.Point(8, 131);
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
            this.ctrlDisplayApplicationInfo1.Location = new System.Drawing.Point(8, 276);
            this.ctrlDisplayApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDisplayApplicationInfo1.Name = "ctrlDisplayApplicationInfo1";
            this.ctrlDisplayApplicationInfo1.Size = new System.Drawing.Size(1081, 230);
            this.ctrlDisplayApplicationInfo1.TabIndex = 1;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtNotes.Location = new System.Drawing.Point(8, 543);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(615, 137);
            this.txtNotes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Notes:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(756, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 37);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.ForeColor = System.Drawing.Color.Cyan;
            this.btnIssue.Location = new System.Drawing.Point(900, 593);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(86, 37);
            this.btnIssue.TabIndex = 2;
            this.btnIssue.Text = "Isssue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 25.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(261, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 43);
            this.label2.TabIndex = 4;
            this.label2.Text = "Issue Driving License The First Time";
            // 
            // frmIssueDrivingLicense_1rstTime
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1102, 692);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrlDisplayApplicationInfo1);
            this.Controls.Add(this.ctrlDisplayApplicationLicenseInfo1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmIssueDrivingLicense_1rstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driving License First Time";
            this.Load += new System.EventHandler(this.frmIssueDrivingLicense_1rstTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.User_Controls.ctrlDisplayApplicationLicenseInfo ctrlDisplayApplicationLicenseInfo1;
        private Applications.User_Controls.ctrlDisplayApplicationInfo ctrlDisplayApplicationInfo1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label label2;
    }
}