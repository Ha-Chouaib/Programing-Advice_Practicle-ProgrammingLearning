namespace DVLD_Project.Applications
{
    partial class frmManageLocalDrivingLicenseApps
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
            this.dgvLDL_AppsList = new System.Windows.Forms.DataGridView();
            this.cmsLDL_Apps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSchedualeTests = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSchedualeVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSchedualWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSchedualStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterTerm = new System.Windows.Forms.TextBox();
            this.btnAddNewLocalApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.cmbAppStatusFilter = new System.Windows.Forms.ComboBox();
            this.pbLDLApp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDL_AppsList)).BeginInit();
            this.cmsLDL_Apps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLDLApp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLDL_AppsList
            // 
            this.dgvLDL_AppsList.AllowUserToAddRows = false;
            this.dgvLDL_AppsList.AllowUserToDeleteRows = false;
            this.dgvLDL_AppsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLDL_AppsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvLDL_AppsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDL_AppsList.ContextMenuStrip = this.cmsLDL_Apps;
            this.dgvLDL_AppsList.Location = new System.Drawing.Point(12, 242);
            this.dgvLDL_AppsList.Name = "dgvLDL_AppsList";
            this.dgvLDL_AppsList.ReadOnly = true;
            this.dgvLDL_AppsList.Size = new System.Drawing.Size(1263, 407);
            this.dgvLDL_AppsList.TabIndex = 0;
            // 
            // cmsLDL_Apps
            // 
            this.cmsLDL_Apps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmsLDL_Apps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsmEditApplication,
            this.tsmDeleteApplication,
            this.toolStripMenuItem2,
            this.tsmCancelApplication,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.tsmSchedualeTests,
            this.toolStripMenuItem5,
            this.tsmIssueDrivingLicenseFirstTime,
            this.toolStripMenuItem6,
            this.tsmShowLicense,
            this.toolStripMenuItem7,
            this.tsmShowPersonLicenseHistory});
            this.cmsLDL_Apps.Name = "cmsLDL_Apps";
            this.cmsLDL_Apps.Size = new System.Drawing.Size(281, 316);
            this.cmsLDL_Apps.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLDL_Apps_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.showApplicationDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showApplicationDetailsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Info;
            this.showApplicationDetailsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmEditApplication
            // 
            this.tsmEditApplication.BackColor = System.Drawing.Color.Transparent;
            this.tsmEditApplication.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmEditApplication.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmEditApplication.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmEditApplication.Name = "tsmEditApplication";
            this.tsmEditApplication.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmEditApplication.Size = new System.Drawing.Size(280, 26);
            this.tsmEditApplication.Text = "Edit Application";
            this.tsmEditApplication.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // tsmDeleteApplication
            // 
            this.tsmDeleteApplication.BackColor = System.Drawing.Color.Transparent;
            this.tsmDeleteApplication.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmDeleteApplication.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmDeleteApplication.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmDeleteApplication.Name = "tsmDeleteApplication";
            this.tsmDeleteApplication.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmDeleteApplication.Size = new System.Drawing.Size(280, 26);
            this.tsmDeleteApplication.Text = "Delete Application";
            this.tsmDeleteApplication.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmCancelApplication
            // 
            this.tsmCancelApplication.BackColor = System.Drawing.Color.Transparent;
            this.tsmCancelApplication.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmCancelApplication.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmCancelApplication.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmCancelApplication.Name = "tsmCancelApplication";
            this.tsmCancelApplication.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmCancelApplication.Size = new System.Drawing.Size(280, 26);
            this.tsmCancelApplication.Text = "Cancel Application";
            this.tsmCancelApplication.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(277, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem4.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmSchedualeTests
            // 
            this.tsmSchedualeTests.BackColor = System.Drawing.Color.Transparent;
            this.tsmSchedualeTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSchedualeVisionTest,
            this.tsmiSchedualWrittenTest,
            this.tsmiSchedualStreetTest});
            this.tsmSchedualeTests.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmSchedualeTests.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmSchedualeTests.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmSchedualeTests.Name = "tsmSchedualeTests";
            this.tsmSchedualeTests.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmSchedualeTests.Size = new System.Drawing.Size(280, 26);
            this.tsmSchedualeTests.Text = "Scheduale Tests";
            // 
            // tsmiSchedualeVisionTest
            // 
            this.tsmiSchedualeVisionTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tsmiSchedualeVisionTest.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tsmiSchedualeVisionTest.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmiSchedualeVisionTest.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.tsmiSchedualeVisionTest.Name = "tsmiSchedualeVisionTest";
            this.tsmiSchedualeVisionTest.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tsmiSchedualeVisionTest.Size = new System.Drawing.Size(220, 40);
            this.tsmiSchedualeVisionTest.Text = "Scheduale Vision Test";
            this.tsmiSchedualeVisionTest.Click += new System.EventHandler(this.schedualToolStripMenuItem_Click);
            // 
            // tsmiSchedualWrittenTest
            // 
            this.tsmiSchedualWrittenTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tsmiSchedualWrittenTest.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tsmiSchedualWrittenTest.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmiSchedualWrittenTest.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.tsmiSchedualWrittenTest.Name = "tsmiSchedualWrittenTest";
            this.tsmiSchedualWrittenTest.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tsmiSchedualWrittenTest.Size = new System.Drawing.Size(220, 40);
            this.tsmiSchedualWrittenTest.Text = "Scheduale Written Test";
            this.tsmiSchedualWrittenTest.Click += new System.EventHandler(this.schedualWrittenTestToolStripMenuItem_Click);
            // 
            // tsmiSchedualStreetTest
            // 
            this.tsmiSchedualStreetTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tsmiSchedualStreetTest.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tsmiSchedualStreetTest.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmiSchedualStreetTest.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.tsmiSchedualStreetTest.Name = "tsmiSchedualStreetTest";
            this.tsmiSchedualStreetTest.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.tsmiSchedualStreetTest.Size = new System.Drawing.Size(220, 40);
            this.tsmiSchedualStreetTest.Text = "Scheduale Street Test";
            this.tsmiSchedualStreetTest.Click += new System.EventHandler(this.schedualStreetTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem5.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmIssueDrivingLicenseFirstTime
            // 
            this.tsmIssueDrivingLicenseFirstTime.BackColor = System.Drawing.Color.Transparent;
            this.tsmIssueDrivingLicenseFirstTime.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmIssueDrivingLicenseFirstTime.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmIssueDrivingLicenseFirstTime.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmIssueDrivingLicenseFirstTime.Name = "tsmIssueDrivingLicenseFirstTime";
            this.tsmIssueDrivingLicenseFirstTime.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(280, 26);
            this.tsmIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            this.tsmIssueDrivingLicenseFirstTime.Click += new System.EventHandler(this.cmsiIssueDrivingLicenseFirstTime_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem6.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmShowLicense
            // 
            this.tsmShowLicense.BackColor = System.Drawing.Color.Transparent;
            this.tsmShowLicense.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowLicense.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmShowLicense.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmShowLicense.Name = "tsmShowLicense";
            this.tsmShowLicense.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmShowLicense.Size = new System.Drawing.Size(280, 26);
            this.tsmShowLicense.Text = "Show License";
            this.tsmShowLicense.Click += new System.EventHandler(this.tsmShowLicense_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem7.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(277, 6);
            // 
            // tsmShowPersonLicenseHistory
            // 
            this.tsmShowPersonLicenseHistory.BackColor = System.Drawing.Color.Transparent;
            this.tsmShowPersonLicenseHistory.Font = new System.Drawing.Font("Segoe UI Historic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowPersonLicenseHistory.ForeColor = System.Drawing.SystemColors.Info;
            this.tsmShowPersonLicenseHistory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tsmShowPersonLicenseHistory.Name = "tsmShowPersonLicenseHistory";
            this.tsmShowPersonLicenseHistory.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tsmShowPersonLicenseHistory.Size = new System.Drawing.Size(280, 26);
            this.tsmShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmShowPersonLicenseHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(330, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving License Applications";
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbFilterOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterOptions.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(133, 205);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(257, 28);
            this.cmbFilterOptions.TabIndex = 2;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(12, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By->";
            // 
            // txtFilterTerm
            // 
            this.txtFilterTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.txtFilterTerm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilterTerm.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterTerm.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.txtFilterTerm.Location = new System.Drawing.Point(424, 205);
            this.txtFilterTerm.Multiline = true;
            this.txtFilterTerm.Name = "txtFilterTerm";
            this.txtFilterTerm.Size = new System.Drawing.Size(257, 28);
            this.txtFilterTerm.TabIndex = 4;
            this.txtFilterTerm.Visible = false;
            this.txtFilterTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterTerm_KeyPress);
            this.txtFilterTerm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilterTerm_KeyUp);
            // 
            // btnAddNewLocalApp
            // 
            this.btnAddNewLocalApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNewLocalApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewLocalApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLocalApp.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLocalApp.ForeColor = System.Drawing.Color.Cyan;
            this.btnAddNewLocalApp.Location = new System.Drawing.Point(1134, 199);
            this.btnAddNewLocalApp.Name = "btnAddNewLocalApp";
            this.btnAddNewLocalApp.Size = new System.Drawing.Size(141, 31);
            this.btnAddNewLocalApp.TabIndex = 1;
            this.btnAddNewLocalApp.Text = "Add New App +";
            this.btnAddNewLocalApp.UseVisualStyleBackColor = true;
            this.btnAddNewLocalApp.Click += new System.EventHandler(this.btnAddNewLocalApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(1172, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 42);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(12, 684);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.BackColor = System.Drawing.Color.Black;
            this.lblRecords.Font = new System.Drawing.Font("Trebuchet MS", 10.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblRecords.ForeColor = System.Drawing.Color.Cyan;
            this.lblRecords.Location = new System.Drawing.Point(88, 684);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(27, 20);
            this.lblRecords.TabIndex = 8;
            this.lblRecords.Text = "???";
            // 
            // cmbAppStatusFilter
            // 
            this.cmbAppStatusFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cmbAppStatusFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAppStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppStatusFilter.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAppStatusFilter.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.cmbAppStatusFilter.FormattingEnabled = true;
            this.cmbAppStatusFilter.Location = new System.Drawing.Point(424, 205);
            this.cmbAppStatusFilter.Name = "cmbAppStatusFilter";
            this.cmbAppStatusFilter.Size = new System.Drawing.Size(186, 28);
            this.cmbAppStatusFilter.TabIndex = 10;
            this.cmbAppStatusFilter.Visible = false;
            this.cmbAppStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbAppStatusFilter_SelectedIndexChanged);
            // 
            // pbLDLApp
            // 
            this.pbLDLApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.pbLDLApp.Location = new System.Drawing.Point(551, 12);
            this.pbLDLApp.Name = "pbLDLApp";
            this.pbLDLApp.Size = new System.Drawing.Size(175, 127);
            this.pbLDLApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLDLApp.TabIndex = 9;
            this.pbLDLApp.TabStop = false;
            // 
            // frmManageLocalDrivingLicenseApps
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(1287, 731);
            this.Controls.Add(this.cmbAppStatusFilter);
            this.Controls.Add(this.pbLDLApp);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewLocalApp);
            this.Controls.Add(this.txtFilterTerm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLDL_AppsList);
            this.Name = "frmManageLocalDrivingLicenseApps";
            this.Text = "Manage Local Driving License Apps";
            this.Load += new System.EventHandler(this.frmManageMainApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDL_AppsList)).EndInit();
            this.cmsLDL_Apps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLDLApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLDL_AppsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterTerm;
        private System.Windows.Forms.Button btnAddNewLocalApp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.PictureBox pbLDLApp;
        private System.Windows.Forms.ComboBox cmbAppStatusFilter;
        private System.Windows.Forms.ContextMenuStrip cmsLDL_Apps;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmSchedualeTests;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem tsmShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiSchedualeVisionTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiSchedualWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiSchedualStreetTest;
    }
}