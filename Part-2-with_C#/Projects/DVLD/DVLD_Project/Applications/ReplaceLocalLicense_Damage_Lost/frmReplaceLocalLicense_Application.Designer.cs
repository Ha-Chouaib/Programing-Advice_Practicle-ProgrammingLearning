namespace DVLD_Project.Applications.ReplaceLocalLicense_Damage_Lost
{
    partial class frmReplaceLocalLicense_Application
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
            this.ctrlFindAndDisplayDriverLicense1 = new DVLD_Project.License.UserControls.ctrlFindAndDisplayDriverLicense();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamageLicense = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblCurrentUserName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLR_ApplicationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIssueReplace = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lnkShowLicensesHist = new System.Windows.Forms.LinkLabel();
            this.lnkShowNewLicInfo = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlFindAndDisplayDriverLicense1
            // 
            this.ctrlFindAndDisplayDriverLicense1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlFindAndDisplayDriverLicense1.Location = new System.Drawing.Point(49, 104);
            this.ctrlFindAndDisplayDriverLicense1.Name = "ctrlFindAndDisplayDriverLicense1";
            this.ctrlFindAndDisplayDriverLicense1.Size = new System.Drawing.Size(1020, 510);
            this.ctrlFindAndDisplayDriverLicense1.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Tahoma", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblHeaderTitle.Location = new System.Drawing.Point(173, 26);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(745, 58);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Replacement For Lost License";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox1.Controls.Add(this.rbLostLicense);
            this.groupBox1.Controls.Add(this.rbDamageLicense);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Location = new System.Drawing.Point(831, 620);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement For";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rbLostLicense.Checked = true;
            this.rbLostLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbLostLicense.Font = new System.Drawing.Font("Trebuchet MS", 12.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.rbLostLicense.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbLostLicense.Location = new System.Drawing.Point(39, 51);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Padding = new System.Windows.Forms.Padding(5);
            this.rbLostLicense.Size = new System.Drawing.Size(136, 37);
            this.rbLostLicense.TabIndex = 2;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = false;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamageLicense
            // 
            this.rbDamageLicense.AutoSize = true;
            this.rbDamageLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rbDamageLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDamageLicense.Font = new System.Drawing.Font("Trebuchet MS", 12.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.rbDamageLicense.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbDamageLicense.Location = new System.Drawing.Point(39, 117);
            this.rbDamageLicense.Name = "rbDamageLicense";
            this.rbDamageLicense.Padding = new System.Windows.Forms.Padding(5);
            this.rbDamageLicense.Size = new System.Drawing.Size(165, 37);
            this.rbDamageLicense.TabIndex = 1;
            this.rbDamageLicense.Text = "Damage License";
            this.rbDamageLicense.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox2.Controls.Add(this.panel11);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox2.Location = new System.Drawing.Point(49, 620);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 184);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application New License Info";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel11.Controls.Add(this.lblCurrentUserName);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Location = new System.Drawing.Point(411, 122);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(318, 43);
            this.panel11.TabIndex = 4;
            // 
            // lblCurrentUserName
            // 
            this.lblCurrentUserName.AutoSize = true;
            this.lblCurrentUserName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblCurrentUserName.Location = new System.Drawing.Point(159, 12);
            this.lblCurrentUserName.Name = "lblCurrentUserName";
            this.lblCurrentUserName.Size = new System.Drawing.Size(27, 20);
            this.lblCurrentUserName.TabIndex = 1;
            this.lblCurrentUserName.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Created By :";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel7.Controls.Add(this.lblApplicationFees);
            this.panel7.Controls.Add(this.label14);
            this.panel7.Location = new System.Drawing.Point(19, 122);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(318, 43);
            this.panel7.TabIndex = 7;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblApplicationFees.Location = new System.Drawing.Point(159, 12);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(27, 20);
            this.lblApplicationFees.TabIndex = 1;
            this.lblApplicationFees.Text = "???";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.Info;
            this.label14.Location = new System.Drawing.Point(12, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Application Fees:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel6.Controls.Add(this.lblApplicationDate);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(19, 73);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(318, 43);
            this.panel6.TabIndex = 6;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblApplicationDate.Location = new System.Drawing.Point(159, 12);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(27, 20);
            this.lblApplicationDate.TabIndex = 1;
            this.lblApplicationDate.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.Info;
            this.label12.Location = new System.Drawing.Point(12, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Application Date:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel5.Controls.Add(this.lblReplacedLicenseID);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(411, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(318, 43);
            this.panel5.TabIndex = 5;
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.ForeColor = System.Drawing.Color.Cyan;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(178, 12);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(51, 20);
            this.lblReplacedLicenseID.TabIndex = 1;
            this.lblReplacedLicenseID.Text = "[ ??? ]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Info;
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Replaced License ID:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel4.Controls.Add(this.lblOldLicenseID);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(411, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 43);
            this.panel4.TabIndex = 4;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblOldLicenseID.Location = new System.Drawing.Point(139, 12);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(27, 20);
            this.lblOldLicenseID.TabIndex = 1;
            this.lblOldLicenseID.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(12, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Old License ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.lblLR_ApplicationID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(18, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 43);
            this.panel1.TabIndex = 1;
            // 
            // lblLR_ApplicationID
            // 
            this.lblLR_ApplicationID.AutoSize = true;
            this.lblLR_ApplicationID.ForeColor = System.Drawing.Color.Cyan;
            this.lblLR_ApplicationID.Location = new System.Drawing.Point(159, 12);
            this.lblLR_ApplicationID.Name = "lblLR_ApplicationID";
            this.lblLR_ApplicationID.Size = new System.Drawing.Size(27, 20);
            this.lblLR_ApplicationID.TabIndex = 1;
            this.lblLR_ApplicationID.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "L.R Application ID:";
            // 
            // btnIssueReplace
            // 
            this.btnIssueReplace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssueReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReplace.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplace.ForeColor = System.Drawing.Color.Cyan;
            this.btnIssueReplace.Location = new System.Drawing.Point(884, 826);
            this.btnIssueReplace.Name = "btnIssueReplace";
            this.btnIssueReplace.Size = new System.Drawing.Size(185, 35);
            this.btnIssueReplace.TabIndex = 3;
            this.btnIssueReplace.Text = "Issue Replacement";
            this.btnIssueReplace.UseVisualStyleBackColor = true;
            this.btnIssueReplace.Click += new System.EventHandler(this.btnIssueReplace_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClose.Location = new System.Drawing.Point(759, 826);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 35);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnkShowLicensesHist
            // 
            this.lnkShowLicensesHist.AutoSize = true;
            this.lnkShowLicensesHist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkShowLicensesHist.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLicensesHist.LinkColor = System.Drawing.Color.Cyan;
            this.lnkShowLicensesHist.Location = new System.Drawing.Point(45, 833);
            this.lnkShowLicensesHist.Name = "lnkShowLicensesHist";
            this.lnkShowLicensesHist.Size = new System.Drawing.Size(165, 20);
            this.lnkShowLicensesHist.TabIndex = 3;
            this.lnkShowLicensesHist.TabStop = true;
            this.lnkShowLicensesHist.Text = "Show Licenses History";
            this.lnkShowLicensesHist.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lnkShowLicensesHist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowLicensesHist_LinkClicked);
            // 
            // lnkShowNewLicInfo
            // 
            this.lnkShowNewLicInfo.AutoSize = true;
            this.lnkShowNewLicInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkShowNewLicInfo.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowNewLicInfo.LinkColor = System.Drawing.Color.Cyan;
            this.lnkShowNewLicInfo.Location = new System.Drawing.Point(242, 833);
            this.lnkShowNewLicInfo.Name = "lnkShowNewLicInfo";
            this.lnkShowNewLicInfo.Size = new System.Drawing.Size(174, 20);
            this.lnkShowNewLicInfo.TabIndex = 6;
            this.lnkShowNewLicInfo.TabStop = true;
            this.lnkShowNewLicInfo.Text = "Show New Licenses Info";
            this.lnkShowNewLicInfo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lnkShowNewLicInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkShowNewLicInfo_LinkClicked);
            // 
            // frmReplaceLocalLicense_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1121, 889);
            this.Controls.Add(this.lnkShowNewLicInfo);
            this.Controls.Add(this.lnkShowLicensesHist);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueReplace);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHeaderTitle);
            this.Controls.Add(this.ctrlFindAndDisplayDriverLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceLocalLicense_Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReplaceLocalLicense_Application";
            this.Load += new System.EventHandler(this.frmReplaceLocalLicense_Application_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private License.UserControls.ctrlFindAndDisplayDriverLicense ctrlFindAndDisplayDriverLicense1;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamageLicense;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblCurrentUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLR_ApplicationID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIssueReplace;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnkShowLicensesHist;
        private System.Windows.Forms.LinkLabel lnkShowNewLicInfo;
    }
}