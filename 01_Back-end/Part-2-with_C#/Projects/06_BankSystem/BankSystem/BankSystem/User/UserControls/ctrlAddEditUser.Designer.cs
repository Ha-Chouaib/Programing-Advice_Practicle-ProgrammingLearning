namespace BankSystem.User.UserControls
{
    partial class ctrlAddEditUser
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
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonalInf = new System.Windows.Forms.TabPage();
            this.pnlPersonalDetails = new System.Windows.Forms.Panel();
            this.lblPickRecord = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabUserData = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlUserDataContainer = new System.Windows.Forms.Panel();
            this.lblConfermUpdatedPass = new System.Windows.Forms.Label();
            this.txtConfirmUpdatedPass = new System.Windows.Forms.TextBox();
            this.lnkCustomPermissions = new System.Windows.Forms.LinkLabel();
            this.rbIsActive = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblOriginalPassword = new System.Windows.Forms.Label();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.txtOriginalPassword = new System.Windows.Forms.TextBox();
            this.txtCreatedByUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlDisplayPersonDetails1 = new BankSystem.Person.UserControls.ctrlDisplayPersonDetails();
            this.ctrlFind1 = new BankSystem.ctrlFind();
            this.tabControl1.SuspendLayout();
            this.tabPersonalInf.SuspendLayout();
            this.pnlPersonalDetails.SuspendLayout();
            this.tabUserData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlUserDataContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Black", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.SystemColors.Info;
            this.lblHeaderTitle.Location = new System.Drawing.Point(466, 11);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(328, 59);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Add New User";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersonalInf);
            this.tabControl1.Controls.Add(this.tabUserData);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(35, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1131, 622);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPersonalInf
            // 
            this.tabPersonalInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tabPersonalInf.Controls.Add(this.pnlPersonalDetails);
            this.tabPersonalInf.Location = new System.Drawing.Point(4, 32);
            this.tabPersonalInf.Name = "tabPersonalInf";
            this.tabPersonalInf.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInf.Size = new System.Drawing.Size(1123, 586);
            this.tabPersonalInf.TabIndex = 0;
            this.tabPersonalInf.Text = "Personal Details";
            // 
            // pnlPersonalDetails
            // 
            this.pnlPersonalDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnlPersonalDetails.Controls.Add(this.lblPickRecord);
            this.pnlPersonalDetails.Controls.Add(this.ctrlDisplayPersonDetails1);
            this.pnlPersonalDetails.Controls.Add(this.btnNext);
            this.pnlPersonalDetails.Controls.Add(this.ctrlFind1);
            this.pnlPersonalDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPersonalDetails.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.2F);
            this.pnlPersonalDetails.Location = new System.Drawing.Point(3, 3);
            this.pnlPersonalDetails.Name = "pnlPersonalDetails";
            this.pnlPersonalDetails.Size = new System.Drawing.Size(1117, 580);
            this.pnlPersonalDetails.TabIndex = 0;
            // 
            // lblPickRecord
            // 
            this.lblPickRecord.AutoSize = true;
            this.lblPickRecord.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPickRecord.ForeColor = System.Drawing.Color.White;
            this.lblPickRecord.Location = new System.Drawing.Point(263, 12);
            this.lblPickRecord.Name = "lblPickRecord";
            this.lblPickRecord.Size = new System.Drawing.Size(107, 20);
            this.lblPickRecord.TabIndex = 42;
            this.lblPickRecord.Text = "Pick a Person";
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNext.Location = new System.Drawing.Point(997, 537);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(97, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next ->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabUserData
            // 
            this.tabUserData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tabUserData.Controls.Add(this.panel1);
            this.tabUserData.Location = new System.Drawing.Point(4, 32);
            this.tabUserData.Name = "tabUserData";
            this.tabUserData.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserData.Size = new System.Drawing.Size(1123, 586);
            this.tabUserData.TabIndex = 1;
            this.tabUserData.Text = "User Data";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.pnlUserDataContainer);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1117, 580);
            this.panel1.TabIndex = 3;
            // 
            // pnlUserDataContainer
            // 
            this.pnlUserDataContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlUserDataContainer.Controls.Add(this.lblConfermUpdatedPass);
            this.pnlUserDataContainer.Controls.Add(this.txtConfirmUpdatedPass);
            this.pnlUserDataContainer.Controls.Add(this.lnkCustomPermissions);
            this.pnlUserDataContainer.Controls.Add(this.rbIsActive);
            this.pnlUserDataContainer.Controls.Add(this.label8);
            this.pnlUserDataContainer.Controls.Add(this.cmbRoles);
            this.pnlUserDataContainer.Controls.Add(this.lblConfirmPass);
            this.pnlUserDataContainer.Controls.Add(this.txtConfirmPassword);
            this.pnlUserDataContainer.Controls.Add(this.label7);
            this.pnlUserDataContainer.Controls.Add(this.label6);
            this.pnlUserDataContainer.Controls.Add(this.label5);
            this.pnlUserDataContainer.Controls.Add(this.lblOriginalPassword);
            this.pnlUserDataContainer.Controls.Add(this.txtCreatedDate);
            this.pnlUserDataContainer.Controls.Add(this.txtOriginalPassword);
            this.pnlUserDataContainer.Controls.Add(this.txtCreatedByUser);
            this.pnlUserDataContainer.Controls.Add(this.label3);
            this.pnlUserDataContainer.Controls.Add(this.txtUserName);
            this.pnlUserDataContainer.Controls.Add(this.txtUserID);
            this.pnlUserDataContainer.Location = new System.Drawing.Point(145, 109);
            this.pnlUserDataContainer.Name = "pnlUserDataContainer";
            this.pnlUserDataContainer.Size = new System.Drawing.Size(842, 351);
            this.pnlUserDataContainer.TabIndex = 27;
            // 
            // lblConfermUpdatedPass
            // 
            this.lblConfermUpdatedPass.AutoSize = true;
            this.lblConfermUpdatedPass.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfermUpdatedPass.ForeColor = System.Drawing.Color.White;
            this.lblConfermUpdatedPass.Location = new System.Drawing.Point(18, 280);
            this.lblConfermUpdatedPass.Name = "lblConfermUpdatedPass";
            this.lblConfermUpdatedPass.Size = new System.Drawing.Size(145, 20);
            this.lblConfermUpdatedPass.TabIndex = 43;
            this.lblConfermUpdatedPass.Text = "Confirm Password";
            // 
            // txtConfirmUpdatedPass
            // 
            this.txtConfirmUpdatedPass.BackColor = System.Drawing.Color.Black;
            this.txtConfirmUpdatedPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmUpdatedPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtConfirmUpdatedPass.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmUpdatedPass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtConfirmUpdatedPass.Location = new System.Drawing.Point(22, 303);
            this.txtConfirmUpdatedPass.MaxLength = 4;
            this.txtConfirmUpdatedPass.Multiline = true;
            this.txtConfirmUpdatedPass.Name = "txtConfirmUpdatedPass";
            this.txtConfirmUpdatedPass.PasswordChar = '*';
            this.txtConfirmUpdatedPass.Size = new System.Drawing.Size(309, 40);
            this.txtConfirmUpdatedPass.TabIndex = 42;
            this.txtConfirmUpdatedPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalPassword_KeyPress);
            this.txtConfirmUpdatedPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmUpdatedPass_Validating);
            // 
            // lnkCustomPermissions
            // 
            this.lnkCustomPermissions.AutoSize = true;
            this.lnkCustomPermissions.LinkColor = System.Drawing.Color.DarkCyan;
            this.lnkCustomPermissions.Location = new System.Drawing.Point(553, 292);
            this.lnkCustomPermissions.Name = "lnkCustomPermissions";
            this.lnkCustomPermissions.Size = new System.Drawing.Size(207, 23);
            this.lnkCustomPermissions.TabIndex = 41;
            this.lnkCustomPermissions.TabStop = true;
            this.lnkCustomPermissions.Text = "Set Custom Permissions";
            this.lnkCustomPermissions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomPermissions_LinkClicked);
            // 
            // rbIsActive
            // 
            this.rbIsActive.AutoSize = true;
            this.rbIsActive.Checked = true;
            this.rbIsActive.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIsActive.ForeColor = System.Drawing.Color.Cyan;
            this.rbIsActive.Location = new System.Drawing.Point(375, 169);
            this.rbIsActive.Name = "rbIsActive";
            this.rbIsActive.Size = new System.Drawing.Size(84, 27);
            this.rbIsActive.TabIndex = 40;
            this.rbIsActive.TabStop = true;
            this.rbIsActive.Text = "Active";
            this.rbIsActive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(506, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Roles";
            // 
            // cmbRoles
            // 
            this.cmbRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRoles.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(505, 226);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(309, 31);
            this.cmbRoles.TabIndex = 38;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPass.ForeColor = System.Drawing.Color.White;
            this.lblConfirmPass.Location = new System.Drawing.Point(18, 203);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(145, 20);
            this.lblConfirmPass.TabIndex = 37;
            this.lblConfirmPass.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Black;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtConfirmPassword.Location = new System.Drawing.Point(22, 226);
            this.txtConfirmPassword.MaxLength = 4;
            this.txtConfirmPassword.Multiline = true;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(309, 40);
            this.txtConfirmPassword.TabIndex = 36;
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalPassword_KeyPress);
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(18, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(506, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Created Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(506, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Created By User";
            // 
            // lblOriginalPassword
            // 
            this.lblOriginalPassword.AutoSize = true;
            this.lblOriginalPassword.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginalPassword.ForeColor = System.Drawing.Color.White;
            this.lblOriginalPassword.Location = new System.Drawing.Point(18, 128);
            this.lblOriginalPassword.Name = "lblOriginalPassword";
            this.lblOriginalPassword.Size = new System.Drawing.Size(81, 20);
            this.lblOriginalPassword.TabIndex = 32;
            this.lblOriginalPassword.Text = "Password";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.BackColor = System.Drawing.Color.Black;
            this.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreatedDate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCreatedDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedDate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtCreatedDate.Location = new System.Drawing.Point(505, 79);
            this.txtCreatedDate.Multiline = true;
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.ReadOnly = true;
            this.txtCreatedDate.Size = new System.Drawing.Size(309, 40);
            this.txtCreatedDate.TabIndex = 31;
            // 
            // txtOriginalPassword
            // 
            this.txtOriginalPassword.BackColor = System.Drawing.Color.Black;
            this.txtOriginalPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOriginalPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtOriginalPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalPassword.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtOriginalPassword.Location = new System.Drawing.Point(22, 151);
            this.txtOriginalPassword.MaxLength = 4;
            this.txtOriginalPassword.Multiline = true;
            this.txtOriginalPassword.Name = "txtOriginalPassword";
            this.txtOriginalPassword.PasswordChar = '*';
            this.txtOriginalPassword.Size = new System.Drawing.Size(309, 40);
            this.txtOriginalPassword.TabIndex = 30;
            this.txtOriginalPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalPassword_KeyPress);
            this.txtOriginalPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtOriginalPassword_Validating);
            // 
            // txtCreatedByUser
            // 
            this.txtCreatedByUser.BackColor = System.Drawing.Color.Black;
            this.txtCreatedByUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreatedByUser.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCreatedByUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreatedByUser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtCreatedByUser.Location = new System.Drawing.Point(505, 151);
            this.txtCreatedByUser.Multiline = true;
            this.txtCreatedByUser.Name = "txtCreatedByUser";
            this.txtCreatedByUser.ReadOnly = true;
            this.txtCreatedByUser.Size = new System.Drawing.Size(309, 40);
            this.txtCreatedByUser.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(388, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "User ID";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Black;
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtUserName.Location = new System.Drawing.Point(22, 79);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(309, 40);
            this.txtUserName.TabIndex = 27;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.Black;
            this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.ForeColor = System.Drawing.Color.Cyan;
            this.txtUserID.Location = new System.Drawing.Point(338, 46);
            this.txtUserID.Multiline = true;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(161, 30);
            this.txtUserID.TabIndex = 26;
            this.txtUserID.Text = "[ N/A ]";
            this.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.Info;
            this.btnPrevious.Location = new System.Drawing.Point(25, 496);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(111, 40);
            this.btnPrevious.TabIndex = 26;
            this.btnPrevious.Text = "<-Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCancel.Location = new System.Drawing.Point(476, 745);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 40);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Cyan;
            this.btnSave.Location = new System.Drawing.Point(608, 745);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlDisplayPersonDetails1
            // 
            this.ctrlDisplayPersonDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlDisplayPersonDetails1.Location = new System.Drawing.Point(12, 91);
            this.ctrlDisplayPersonDetails1.Name = "ctrlDisplayPersonDetails1";
            this.ctrlDisplayPersonDetails1.Size = new System.Drawing.Size(1082, 440);
            this.ctrlDisplayPersonDetails1.TabIndex = 2;
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(267, 43);
            this.ctrlFind1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 57);
            this.ctrlFind1.TabIndex = 2;
            // 
            // ctrlAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblHeaderTitle);
            this.Name = "ctrlAddEditUser";
            this.Size = new System.Drawing.Size(1197, 801);
            this.tabControl1.ResumeLayout(false);
            this.tabPersonalInf.ResumeLayout(false);
            this.pnlPersonalDetails.ResumeLayout(false);
            this.pnlPersonalDetails.PerformLayout();
            this.tabUserData.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlUserDataContainer.ResumeLayout(false);
            this.pnlUserDataContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderTitle;
        private ctrlFind ctrlFind1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersonalInf;
        private System.Windows.Forms.Panel pnlPersonalDetails;
        private System.Windows.Forms.TabPage tabUserData;
        private System.Windows.Forms.Button btnNext;
        private Person.UserControls.ctrlDisplayPersonDetails ctrlDisplayPersonDetails1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPickRecord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlUserDataContainer;
        private System.Windows.Forms.Label lblConfermUpdatedPass;
        private System.Windows.Forms.TextBox txtConfirmUpdatedPass;
        private System.Windows.Forms.LinkLabel lnkCustomPermissions;
        private System.Windows.Forms.RadioButton rbIsActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblOriginalPassword;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.TextBox txtOriginalPassword;
        private System.Windows.Forms.TextBox txtCreatedByUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnPrevious;
    }
}
