﻿namespace DVLD_Project.Applications
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
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.schedualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cmsLDL_Apps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cmsLDL_Apps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.scheduleTestsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem7,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLDL_Apps.Name = "cmsLDL_Apps";
            this.cmsLDL_Apps.Size = new System.Drawing.Size(286, 294);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.showApplicationDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showApplicationDetailsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showApplicationDetailsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(282, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.editApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editApplicationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.editApplicationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.deleteApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteApplicationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.deleteApplicationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(282, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.cancelApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelApplicationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cancelApplicationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(282, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(282, 6);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedualToolStripMenuItem,
            this.schedualWrittenTestToolStripMenuItem,
            this.schedualStreetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleTestsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.scheduleTestsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(282, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(282, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showLicenseToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.toolStripMenuItem7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(282, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.showPersonLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonLicenseHistoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.showPersonLicenseHistoryToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
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
            // schedualToolStripMenuItem
            // 
            this.schedualToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.schedualToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.schedualToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.schedualToolStripMenuItem.Name = "schedualToolStripMenuItem";
            this.schedualToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.schedualToolStripMenuItem.Text = "Schedual Vision Test";
            this.schedualToolStripMenuItem.Click += new System.EventHandler(this.schedualToolStripMenuItem_Click);
            // 
            // schedualWrittenTestToolStripMenuItem
            // 
            this.schedualWrittenTestToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.schedualWrittenTestToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.schedualWrittenTestToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.schedualWrittenTestToolStripMenuItem.Name = "schedualWrittenTestToolStripMenuItem";
            this.schedualWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.schedualWrittenTestToolStripMenuItem.Text = "Schedual Written Test";
            // 
            // schedualStreetTestToolStripMenuItem
            // 
            this.schedualStreetTestToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.schedualStreetTestToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.schedualStreetTestToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.schedualStreetTestToolStripMenuItem.Name = "schedualStreetTestToolStripMenuItem";
            this.schedualStreetTestToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.schedualStreetTestToolStripMenuItem.Text = "Schedual Street Test";
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
            this.Text = "frmManageLocalDrivingLicenseApps";
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
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualStreetTestToolStripMenuItem;
    }
}