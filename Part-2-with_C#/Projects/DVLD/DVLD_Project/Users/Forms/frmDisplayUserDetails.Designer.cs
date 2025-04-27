namespace DVLD_Project.Users.Forms
{
    partial class frmDisplayUserDetails
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
            this.ctrlShowLoginInfo1 = new DVLD_Project.Users.UserControls.ctrlShowLoginInfo();
            this.ctrlPersonDetails1 = new DVLD_Project.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClose.Location = new System.Drawing.Point(790, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 34);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlShowLoginInfo1
            // 
            this.ctrlShowLoginInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ctrlShowLoginInfo1.Location = new System.Drawing.Point(29, 379);
            this.ctrlShowLoginInfo1.Name = "ctrlShowLoginInfo1";
            this.ctrlShowLoginInfo1.Size = new System.Drawing.Size(855, 85);
            this.ctrlShowLoginInfo1.TabIndex = 1;
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1._PersonID = 0;
            this.ctrlPersonDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(56, 12);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(801, 347);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // frmDisplayUserDetails
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(916, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowLoginInfo1);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "frmDisplayUserDetails";
            this.Text = "User Details";
            this.Load += new System.EventHandler(this.frmDisplayUserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonDetails ctrlPersonDetails1;
        private UserControls.ctrlShowLoginInfo ctrlShowLoginInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}