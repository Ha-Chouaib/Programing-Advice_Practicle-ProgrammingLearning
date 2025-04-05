namespace ContactsManagmentSystem
{
    partial class frmManagmentSystem
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDisplayConctactInf = new System.Windows.Forms.Panel();
            this.btnBackToAddNewMode = new System.Windows.Forms.Button();
            this.btnRestAll = new System.Windows.Forms.Button();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCountries = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnPerformActions = new System.Windows.Forms.Button();
            this.pnlListContainer = new System.Windows.Forms.Panel();
            this.btnListAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchBy1rsName = new System.Windows.Forms.Button();
            this.btnSearchByLastName = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDisplayConctactInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Bisque;
            this.label1.Location = new System.Drawing.Point(471, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contacts Managment System";
            // 
            // pnlDisplayConctactInf
            // 
            this.pnlDisplayConctactInf.BackColor = System.Drawing.Color.Black;
            this.pnlDisplayConctactInf.Controls.Add(this.btnBackToAddNewMode);
            this.pnlDisplayConctactInf.Controls.Add(this.btnRestAll);
            this.pnlDisplayConctactInf.Controls.Add(this.dtDateOfBirth);
            this.pnlDisplayConctactInf.Controls.Add(this.label8);
            this.pnlDisplayConctactInf.Controls.Add(this.cmbCountries);
            this.pnlDisplayConctactInf.Controls.Add(this.label7);
            this.pnlDisplayConctactInf.Controls.Add(this.label6);
            this.pnlDisplayConctactInf.Controls.Add(this.label5);
            this.pnlDisplayConctactInf.Controls.Add(this.label4);
            this.pnlDisplayConctactInf.Controls.Add(this.label3);
            this.pnlDisplayConctactInf.Controls.Add(this.label2);
            this.pnlDisplayConctactInf.Controls.Add(this.txtAddress);
            this.pnlDisplayConctactInf.Controls.Add(this.txtLastName);
            this.pnlDisplayConctactInf.Controls.Add(this.txtPhone);
            this.pnlDisplayConctactInf.Controls.Add(this.txtEmail);
            this.pnlDisplayConctactInf.Controls.Add(this.txtFirstName);
            this.pnlDisplayConctactInf.Location = new System.Drawing.Point(145, 49);
            this.pnlDisplayConctactInf.Name = "pnlDisplayConctactInf";
            this.pnlDisplayConctactInf.Size = new System.Drawing.Size(1008, 285);
            this.pnlDisplayConctactInf.TabIndex = 1;
            // 
            // btnBackToAddNewMode
            // 
            this.btnBackToAddNewMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(26)))), ((int)(((byte)(166)))));
            this.btnBackToAddNewMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackToAddNewMode.Font = new System.Drawing.Font("MV Boli", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToAddNewMode.ForeColor = System.Drawing.Color.OldLace;
            this.btnBackToAddNewMode.Location = new System.Drawing.Point(3, 243);
            this.btnBackToAddNewMode.Name = "btnBackToAddNewMode";
            this.btnBackToAddNewMode.Size = new System.Drawing.Size(201, 39);
            this.btnBackToAddNewMode.TabIndex = 21;
            this.btnBackToAddNewMode.Text = "Return To Add New Mode";
            this.btnBackToAddNewMode.UseVisualStyleBackColor = false;
            this.btnBackToAddNewMode.Click += new System.EventHandler(this.btnBackToAddNewMode_Click);
            // 
            // btnRestAll
            // 
            this.btnRestAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(26)))), ((int)(((byte)(166)))));
            this.btnRestAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestAll.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestAll.ForeColor = System.Drawing.Color.OldLace;
            this.btnRestAll.Location = new System.Drawing.Point(889, 243);
            this.btnRestAll.Name = "btnRestAll";
            this.btnRestAll.Size = new System.Drawing.Size(116, 39);
            this.btnRestAll.TabIndex = 20;
            this.btnRestAll.Text = "Reste All";
            this.btnRestAll.UseVisualStyleBackColor = false;
            this.btnRestAll.Click += new System.EventHandler(this.btnRestAll_Click);
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.CalendarForeColor = System.Drawing.SystemColors.ControlLight;
            this.dtDateOfBirth.CalendarMonthBackground = System.Drawing.SystemColors.ControlDark;
            this.dtDateOfBirth.Font = new System.Drawing.Font("Microsoft New Tai Lue", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateOfBirth.Location = new System.Drawing.Point(563, 166);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(380, 25);
            this.dtDateOfBirth.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(473, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Country";
            // 
            // cmbCountries
            // 
            this.cmbCountries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.cmbCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCountries.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountries.ForeColor = System.Drawing.SystemColors.Info;
            this.cmbCountries.FormattingEnabled = true;
            this.cmbCountries.Location = new System.Drawing.Point(363, 236);
            this.cmbCountries.MaxDropDownItems = 10;
            this.cmbCountries.Name = "cmbCountries";
            this.cmbCountries.Size = new System.Drawing.Size(279, 30);
            this.cmbCountries.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(560, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Date Of Birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(560, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(65, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(560, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(65, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(65, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "First Name";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtAddress.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtAddress.Location = new System.Drawing.Point(68, 162);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(380, 28);
            this.txtAddress.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtLastName.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtLastName.Location = new System.Drawing.Point(563, 29);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(380, 28);
            this.txtLastName.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtPhone.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtPhone.Location = new System.Drawing.Point(563, 93);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(380, 28);
            this.txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtEmail.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtEmail.Location = new System.Drawing.Point(68, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(380, 28);
            this.txtEmail.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtFirstName.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtFirstName.Location = new System.Drawing.Point(68, 29);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(380, 28);
            this.txtFirstName.TabIndex = 0;
            // 
            // btnPerformActions
            // 
            this.btnPerformActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(26)))), ((int)(((byte)(166)))));
            this.btnPerformActions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPerformActions.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerformActions.ForeColor = System.Drawing.Color.OldLace;
            this.btnPerformActions.Location = new System.Drawing.Point(145, 350);
            this.btnPerformActions.Name = "btnPerformActions";
            this.btnPerformActions.Size = new System.Drawing.Size(1008, 46);
            this.btnPerformActions.TabIndex = 2;
            this.btnPerformActions.Text = "Add New Contact";
            this.btnPerformActions.UseVisualStyleBackColor = false;
            this.btnPerformActions.Click += new System.EventHandler(this.btnPerformActions_Click);
            // 
            // pnlListContainer
            // 
            this.pnlListContainer.BackColor = System.Drawing.Color.Black;
            this.pnlListContainer.Location = new System.Drawing.Point(145, 547);
            this.pnlListContainer.Name = "pnlListContainer";
            this.pnlListContainer.Size = new System.Drawing.Size(1008, 370);
            this.pnlListContainer.TabIndex = 17;
            // 
            // btnListAll
            // 
            this.btnListAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(26)))), ((int)(((byte)(166)))));
            this.btnListAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListAll.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListAll.ForeColor = System.Drawing.Color.OldLace;
            this.btnListAll.Location = new System.Drawing.Point(900, 501);
            this.btnListAll.Name = "btnListAll";
            this.btnListAll.Size = new System.Drawing.Size(253, 39);
            this.btnListAll.TabIndex = 18;
            this.btnListAll.Text = "List All Contacts";
            this.btnListAll.UseVisualStyleBackColor = false;
            this.btnListAll.Click += new System.EventHandler(this.btnListAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtSearch.Location = new System.Drawing.Point(148, 501);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(606, 39);
            this.txtSearch.TabIndex = 22;
            // 
            // btnSearchBy1rsName
            // 
            this.btnSearchBy1rsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(10)))), ((int)(((byte)(107)))));
            this.btnSearchBy1rsName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchBy1rsName.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBy1rsName.ForeColor = System.Drawing.Color.White;
            this.btnSearchBy1rsName.Location = new System.Drawing.Point(708, 415);
            this.btnSearchBy1rsName.Name = "btnSearchBy1rsName";
            this.btnSearchBy1rsName.Size = new System.Drawing.Size(445, 39);
            this.btnSearchBy1rsName.TabIndex = 23;
            this.btnSearchBy1rsName.Text = "Search By First Name";
            this.btnSearchBy1rsName.UseVisualStyleBackColor = false;
            this.btnSearchBy1rsName.Click += new System.EventHandler(this.btnSearchByCountryName_Click);
            // 
            // btnSearchByLastName
            // 
            this.btnSearchByLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(10)))), ((int)(((byte)(107)))));
            this.btnSearchByLastName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchByLastName.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchByLastName.ForeColor = System.Drawing.Color.White;
            this.btnSearchByLastName.Location = new System.Drawing.Point(145, 415);
            this.btnSearchByLastName.Name = "btnSearchByLastName";
            this.btnSearchByLastName.Size = new System.Drawing.Size(445, 39);
            this.btnSearchByLastName.TabIndex = 24;
            this.btnSearchByLastName.Text = "Search By Last Name";
            this.btnSearchByLastName.UseVisualStyleBackColor = false;
            this.btnSearchByLastName.Click += new System.EventHandler(this.btnSearchByLastName_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(10)))), ((int)(((byte)(107)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("MV Boli", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(751, 501);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 39);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Sitka Small", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Info;
            this.label9.Location = new System.Drawing.Point(145, 481);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(350, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "You Can Enter Just a Part Of The First/Last Name";
            // 
            // frmManagmentSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1292, 938);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSearchByLastName);
            this.Controls.Add(this.btnSearchBy1rsName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnListAll);
            this.Controls.Add(this.pnlListContainer);
            this.Controls.Add(this.btnPerformActions);
            this.Controls.Add(this.pnlDisplayConctactInf);
            this.Controls.Add(this.label1);
            this.Name = "frmManagmentSystem";
            this.Text = "Contacts Managment System";
            this.Load += new System.EventHandler(this.frmManagmentSystem_Load);
            this.pnlDisplayConctactInf.ResumeLayout(false);
            this.pnlDisplayConctactInf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDisplayConctactInf;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCountries;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPerformActions;
        private System.Windows.Forms.Panel pnlListContainer;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.Button btnListAll;
        private System.Windows.Forms.Button btnRestAll;
        private System.Windows.Forms.Button btnBackToAddNewMode;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchBy1rsName;
        private System.Windows.Forms.Button btnSearchByLastName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
    }
}

