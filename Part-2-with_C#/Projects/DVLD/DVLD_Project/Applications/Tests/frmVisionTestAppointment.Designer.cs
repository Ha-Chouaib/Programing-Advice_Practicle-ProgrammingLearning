namespace DVLD_Project.Applications.Tests
{
    partial class frmVisionTestAppointment
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListVisionTests = new System.Windows.Forms.DataGridView();
            this.btnAddAppointmrnt = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.ctrlDisplayApplicationLicenseInfo1 = new DVLD_Project.Applications.User_Controls.ctrlDisplayApplicationLicenseInfo();
            this.ctrlDisplayApplicationInfo1 = new DVLD_Project.Applications.User_Controls.ctrlDisplayApplicationInfo();
            this.pbVisionTest = new System.Windows.Forms.PictureBox();
            this.cmsSheduale = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVisionTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisionTest)).BeginInit();
            this.cmsSheduale.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 30.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(334, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Visoin Test Appointment";
            // 
            // dgvListVisionTests
            // 
            this.dgvListVisionTests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListVisionTests.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.dgvListVisionTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListVisionTests.Location = new System.Drawing.Point(36, 658);
            this.dgvListVisionTests.Name = "dgvListVisionTests";
            this.dgvListVisionTests.Size = new System.Drawing.Size(1081, 309);
            this.dgvListVisionTests.TabIndex = 6;
            // 
            // btnAddAppointmrnt
            // 
            this.btnAddAppointmrnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnAddAppointmrnt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAppointmrnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointmrnt.Location = new System.Drawing.Point(970, 612);
            this.btnAddAppointmrnt.Name = "btnAddAppointmrnt";
            this.btnAddAppointmrnt.Size = new System.Drawing.Size(147, 31);
            this.btnAddAppointmrnt.TabIndex = 7;
            this.btnAddAppointmrnt.Text = "Add Appointment +";
            this.btnAddAppointmrnt.UseVisualStyleBackColor = false;
            this.btnAddAppointmrnt.Click += new System.EventHandler(this.btnAddAppointmrnt_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClose.Location = new System.Drawing.Point(1020, 983);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(43, 625);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Appointments:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(43, 990);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Records ->";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Trebuchet MS", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblRecords.ForeColor = System.Drawing.Color.Cyan;
            this.lblRecords.Location = new System.Drawing.Point(150, 990);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(54, 22);
            this.lblRecords.TabIndex = 11;
            this.lblRecords.Text = "[ ??? ]";
            // 
            // ctrlDisplayApplicationLicenseInfo1
            // 
            this.ctrlDisplayApplicationLicenseInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlDisplayApplicationLicenseInfo1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDisplayApplicationLicenseInfo1.ForeColor = System.Drawing.SystemColors.Info;
            this.ctrlDisplayApplicationLicenseInfo1.Location = new System.Drawing.Point(68, 214);
            this.ctrlDisplayApplicationLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDisplayApplicationLicenseInfo1.Name = "ctrlDisplayApplicationLicenseInfo1";
            this.ctrlDisplayApplicationLicenseInfo1.Size = new System.Drawing.Size(1026, 134);
            this.ctrlDisplayApplicationLicenseInfo1.TabIndex = 5;
            // 
            // ctrlDisplayApplicationInfo1
            // 
            this.ctrlDisplayApplicationInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ctrlDisplayApplicationInfo1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDisplayApplicationInfo1.ForeColor = System.Drawing.SystemColors.Info;
            this.ctrlDisplayApplicationInfo1.Location = new System.Drawing.Point(36, 358);
            this.ctrlDisplayApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDisplayApplicationInfo1.Name = "ctrlDisplayApplicationInfo1";
            this.ctrlDisplayApplicationInfo1.Size = new System.Drawing.Size(1081, 230);
            this.ctrlDisplayApplicationInfo1.TabIndex = 4;
            // 
            // pbVisionTest
            // 
            this.pbVisionTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.pbVisionTest.Location = new System.Drawing.Point(498, 12);
            this.pbVisionTest.Name = "pbVisionTest";
            this.pbVisionTest.Size = new System.Drawing.Size(166, 129);
            this.pbVisionTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVisionTest.TabIndex = 3;
            this.pbVisionTest.TabStop = false;
            // 
            // cmsSheduale
            // 
            this.cmsSheduale.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsSheduale.Name = "cmsSheduale";
            this.cmsSheduale.Size = new System.Drawing.Size(181, 84);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuText;
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.editToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuText;
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeTestToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.takeTestToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // frmVisionTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1156, 1031);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddAppointmrnt);
            this.Controls.Add(this.dgvListVisionTests);
            this.Controls.Add(this.ctrlDisplayApplicationLicenseInfo1);
            this.Controls.Add(this.ctrlDisplayApplicationInfo1);
            this.Controls.Add(this.pbVisionTest);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVisionTestAppointment";
            this.Text = "Vision Test Appointment";
            this.Load += new System.EventHandler(this.frmVisionTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListVisionTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisionTest)).EndInit();
            this.cmsSheduale.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbVisionTest;
        private User_Controls.ctrlDisplayApplicationInfo ctrlDisplayApplicationInfo1;
        private User_Controls.ctrlDisplayApplicationLicenseInfo ctrlDisplayApplicationLicenseInfo1;
        private System.Windows.Forms.DataGridView dgvListVisionTests;
        private System.Windows.Forms.Button btnAddAppointmrnt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ContextMenuStrip cmsSheduale;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}