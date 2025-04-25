namespace DVLD_Project.Users
{
    partial class frmManageUsers
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
            this.dgvListUsers = new System.Windows.Forms.DataGridView();
            this.btnAddNewUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbManageUser = new System.Windows.Forms.PictureBox();
            this.cmbFilterUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFilterTerm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIsActiveOptions = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmsAddEditUserMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showUserDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.callUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageUser)).BeginInit();
            this.cmsAddEditUserMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListUsers
            // 
            this.dgvListUsers.AllowUserToAddRows = false;
            this.dgvListUsers.AllowUserToDeleteRows = false;
            this.dgvListUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvListUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListUsers.ContextMenuStrip = this.cmsAddEditUserMenu;
            this.dgvListUsers.Location = new System.Drawing.Point(26, 226);
            this.dgvListUsers.Name = "dgvListUsers";
            this.dgvListUsers.ReadOnly = true;
            this.dgvListUsers.Size = new System.Drawing.Size(1083, 371);
            this.dgvListUsers.TabIndex = 0;
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(35)))), ((int)(((byte)(205)))));
            this.btnAddNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewUser.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddNewUser.Location = new System.Drawing.Point(1023, 175);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(86, 30);
            this.btnAddNewUser.TabIndex = 2;
            this.btnAddNewUser.Text = "Add New +";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(34)))), ((int)(((byte)(206)))));
            this.label1.Location = new System.Drawing.Point(353, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manage";
            // 
            // pbManageUser
            // 
            this.pbManageUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pbManageUser.Location = new System.Drawing.Point(513, 12);
            this.pbManageUser.Name = "pbManageUser";
            this.pbManageUser.Size = new System.Drawing.Size(175, 97);
            this.pbManageUser.TabIndex = 3;
            this.pbManageUser.TabStop = false;
            // 
            // cmbFilterUsers
            // 
            this.cmbFilterUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbFilterUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterUsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbFilterUsers.Font = new System.Drawing.Font("Trebuchet MS", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cmbFilterUsers.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFilterUsers.FormattingEnabled = true;
            this.cmbFilterUsers.Location = new System.Drawing.Point(124, 180);
            this.cmbFilterUsers.Name = "cmbFilterUsers";
            this.cmbFilterUsers.Size = new System.Drawing.Size(192, 26);
            this.cmbFilterUsers.TabIndex = 1;
            this.cmbFilterUsers.SelectedIndexChanged += new System.EventHandler(this.cmbFilterUsers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(23, 633);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Record->";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblRecord.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.ForeColor = System.Drawing.Color.Cyan;
            this.lblRecord.Location = new System.Drawing.Point(120, 633);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(19, 22);
            this.lblRecord.TabIndex = 5;
            this.lblRecord.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(1034, 627);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFilterTerm
            // 
            this.txtFilterTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtFilterTerm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtFilterTerm.Location = new System.Drawing.Point(349, 180);
            this.txtFilterTerm.Multiline = true;
            this.txtFilterTerm.Name = "txtFilterTerm";
            this.txtFilterTerm.Size = new System.Drawing.Size(192, 26);
            this.txtFilterTerm.TabIndex = 7;
            this.txtFilterTerm.Visible = false;
            this.txtFilterTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilterTerm_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(23, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filter By->";
            // 
            // cmbIsActiveOptions
            // 
            this.cmbIsActiveOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmbIsActiveOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActiveOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbIsActiveOptions.Font = new System.Drawing.Font("Trebuchet MS", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cmbIsActiveOptions.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmbIsActiveOptions.FormattingEnabled = true;
            this.cmbIsActiveOptions.Location = new System.Drawing.Point(349, 180);
            this.cmbIsActiveOptions.Name = "cmbIsActiveOptions";
            this.cmbIsActiveOptions.Size = new System.Drawing.Size(192, 26);
            this.cmbIsActiveOptions.TabIndex = 9;
            this.cmbIsActiveOptions.Visible = false;
            this.cmbIsActiveOptions.SelectedIndexChanged += new System.EventHandler(this.cmbIsActiveOptions_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(34)))), ((int)(((byte)(206)))));
            this.label4.Location = new System.Drawing.Point(694, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 46);
            this.label4.TabIndex = 10;
            this.label4.Text = "Users";
            // 
            // cmsAddEditUserMenu
            // 
            this.cmsAddEditUserMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cmsAddEditUserMenu.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsAddEditUserMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showUserDetailsToolStripMenuItem,
            this.addNewUserToolStripMenuItem,
            this.updateUserToolStripMenuItem,
            this.deleteUserToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.callUserToolStripMenuItem,
            this.sendSMSToolStripMenuItem,
            this.sendEmailToolStripMenuItem});
            this.cmsAddEditUserMenu.Name = "cmsAddEditUserMenu";
            this.cmsAddEditUserMenu.Size = new System.Drawing.Size(187, 170);
            // 
            // showUserDetailsToolStripMenuItem
            // 
            this.showUserDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.showUserDetailsToolStripMenuItem.Name = "showUserDetailsToolStripMenuItem";
            this.showUserDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showUserDetailsToolStripMenuItem.Text = "Show User Details";
            this.showUserDetailsToolStripMenuItem.Click += new System.EventHandler(this.showUserDetailsToolStripMenuItem_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // updateUserToolStripMenuItem
            // 
            this.updateUserToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.updateUserToolStripMenuItem.Name = "updateUserToolStripMenuItem";
            this.updateUserToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.updateUserToolStripMenuItem.Text = "Update User";
            this.updateUserToolStripMenuItem.Click += new System.EventHandler(this.updateUserToolStripMenuItem_Click);
            // 
            // deleteUserToolStripMenuItem
            // 
            this.deleteUserToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.deleteUserToolStripMenuItem.Name = "deleteUserToolStripMenuItem";
            this.deleteUserToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteUserToolStripMenuItem.Text = "Delete User";
            this.deleteUserToolStripMenuItem.Click += new System.EventHandler(this.deleteUserToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // callUserToolStripMenuItem
            // 
            this.callUserToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.callUserToolStripMenuItem.Name = "callUserToolStripMenuItem";
            this.callUserToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.callUserToolStripMenuItem.Text = "Call User";
            this.callUserToolStripMenuItem.Click += new System.EventHandler(this.callUserToolStripMenuItem_Click);
            // 
            // sendSMSToolStripMenuItem
            // 
            this.sendSMSToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.sendSMSToolStripMenuItem.Name = "sendSMSToolStripMenuItem";
            this.sendSMSToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sendSMSToolStripMenuItem.Text = "Send SMS";
            this.sendSMSToolStripMenuItem.Click += new System.EventHandler(this.sendSMSToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1135, 669);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilterUsers);
            this.Controls.Add(this.pbManageUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.dgvListUsers);
            this.Controls.Add(this.cmbIsActiveOptions);
            this.Controls.Add(this.txtFilterTerm);
            this.Name = "frmManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageUser)).EndInit();
            this.cmsAddEditUserMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListUsers;
        private System.Windows.Forms.Button btnAddNewUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbManageUser;
        private System.Windows.Forms.ComboBox cmbFilterUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilterTerm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIsActiveOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmsAddEditUserMenu;
        private System.Windows.Forms.ToolStripMenuItem showUserDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem callUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendSMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
    }
}