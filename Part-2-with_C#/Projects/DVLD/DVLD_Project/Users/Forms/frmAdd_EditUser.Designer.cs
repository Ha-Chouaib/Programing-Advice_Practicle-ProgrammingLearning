namespace DVLD_Project.Users.Forms
{
    partial class frmAdd_EditUser
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
            this.lblAddEdit_Header = new System.Windows.Forms.Label();
            this.ctrlAdd_EditUser1 = new DVLD_Project.Users.UserControls.ctrlAdd_EditUser();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddEdit_Header
            // 
            this.lblAddEdit_Header.AutoSize = true;
            this.lblAddEdit_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lblAddEdit_Header.Font = new System.Drawing.Font("Tahoma", 40.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAddEdit_Header.ForeColor = System.Drawing.Color.Cyan;
            this.lblAddEdit_Header.Location = new System.Drawing.Point(344, 20);
            this.lblAddEdit_Header.Name = "lblAddEdit_Header";
            this.lblAddEdit_Header.Size = new System.Drawing.Size(418, 66);
            this.lblAddEdit_Header.TabIndex = 0;
            this.lblAddEdit_Header.Text = "Add New User";
            // 
            // ctrlAdd_EditUser1
            // 
            this.ctrlAdd_EditUser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ctrlAdd_EditUser1.Location = new System.Drawing.Point(12, 120);
            this.ctrlAdd_EditUser1.Name = "ctrlAdd_EditUser1";
            this.ctrlAdd_EditUser1.Size = new System.Drawing.Size(1083, 565);
            this.ctrlAdd_EditUser1.TabIndex = 1;
            this.ctrlAdd_EditUser1.UserID = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSave.ForeColor = System.Drawing.Color.Cyan;
            this.btnSave.Location = new System.Drawing.Point(989, 708);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(877, 708);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAdd_EditUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1105, 752);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlAdd_EditUser1);
            this.Controls.Add(this.lblAddEdit_Header);
            this.Name = "frmAdd_EditUser";
            this.Text = "Add/Edit User";
            this.Load += new System.EventHandler(this.frmAddNewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddEdit_Header;
        private UserControls.ctrlAdd_EditUser ctrlAdd_EditUser1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}