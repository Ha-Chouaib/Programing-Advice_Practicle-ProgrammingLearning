namespace DVLD_Project.License.UserControls
{
    partial class ctrlDriverLicensesHistory
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRecords_Loc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenseDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowLocalLicenseDetials = new System.Windows.Forms.ToolStripMenuItem();
            this.tabIntrenational = new System.Windows.Forms.TabPage();
            this.lblRecords_Inter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvIntreNationalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.cmsLocalLicenseDetails.SuspendLayout();
            this.tabIntrenational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntreNationalLicenses)).BeginInit();
            this.cmsInternationalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1192, 386);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLocal);
            this.tabControl1.Controls.Add(this.tabIntrenational);
            this.tabControl1.Location = new System.Drawing.Point(6, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1176, 343);
            this.tabControl1.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tabLocal.Controls.Add(this.label6);
            this.tabLocal.Controls.Add(this.lblRecords_Loc);
            this.tabLocal.Controls.Add(this.label1);
            this.tabLocal.Controls.Add(this.dgvLocalLicenses);
            this.tabLocal.Font = new System.Drawing.Font("Trebuchet MS", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabLocal.ForeColor = System.Drawing.Color.Black;
            this.tabLocal.Location = new System.Drawing.Point(4, 29);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(1168, 310);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local Licenses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(519, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Records:";
            // 
            // lblRecords_Loc
            // 
            this.lblRecords_Loc.AutoSize = true;
            this.lblRecords_Loc.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblRecords_Loc.Location = new System.Drawing.Point(595, 287);
            this.lblRecords_Loc.Name = "lblRecords_Loc";
            this.lblRecords_Loc.Size = new System.Drawing.Size(40, 18);
            this.lblRecords_Loc.TabIndex = 6;
            this.lblRecords_Loc.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local Licenses History:";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.cmsLocalLicenseDetails;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(20, 44);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1124, 222);
            this.dgvLocalLicenses.TabIndex = 1;
            // 
            // cmsLocalLicenseDetails
            // 
            this.cmsLocalLicenseDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmsLocalLicenseDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLocalLicenseDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowLocalLicenseDetials});
            this.cmsLocalLicenseDetails.Name = "cmsLocalLicenseDetails";
            this.cmsLocalLicenseDetails.Size = new System.Drawing.Size(206, 30);
            // 
            // tsmShowLocalLicenseDetials
            // 
            this.tsmShowLocalLicenseDetials.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tsmShowLocalLicenseDetials.Name = "tsmShowLocalLicenseDetials";
            this.tsmShowLocalLicenseDetials.Padding = new System.Windows.Forms.Padding(0, 5, 0, 1);
            this.tsmShowLocalLicenseDetials.Size = new System.Drawing.Size(205, 26);
            this.tsmShowLocalLicenseDetials.Text = "Show License Details";
            this.tsmShowLocalLicenseDetials.Click += new System.EventHandler(this.tsmShowLocalLicenseDetials_Click);
            // 
            // tabIntrenational
            // 
            this.tabIntrenational.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tabIntrenational.Controls.Add(this.lblRecords_Inter);
            this.tabIntrenational.Controls.Add(this.label3);
            this.tabIntrenational.Controls.Add(this.label2);
            this.tabIntrenational.Controls.Add(this.dgvIntreNationalLicenses);
            this.tabIntrenational.Font = new System.Drawing.Font("Trebuchet MS", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabIntrenational.ForeColor = System.Drawing.Color.Black;
            this.tabIntrenational.Location = new System.Drawing.Point(4, 29);
            this.tabIntrenational.Name = "tabIntrenational";
            this.tabIntrenational.Padding = new System.Windows.Forms.Padding(3);
            this.tabIntrenational.Size = new System.Drawing.Size(1168, 310);
            this.tabIntrenational.TabIndex = 1;
            this.tabIntrenational.Text = "International ";
            // 
            // lblRecords_Inter
            // 
            this.lblRecords_Inter.AutoSize = true;
            this.lblRecords_Inter.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblRecords_Inter.Location = new System.Drawing.Point(609, 287);
            this.lblRecords_Inter.Name = "lblRecords_Inter";
            this.lblRecords_Inter.Size = new System.Drawing.Size(40, 18);
            this.lblRecords_Inter.TabIndex = 5;
            this.lblRecords_Inter.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(533, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(16, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "International Licenses History:";
            // 
            // dgvIntreNationalLicenses
            // 
            this.dgvIntreNationalLicenses.AllowUserToAddRows = false;
            this.dgvIntreNationalLicenses.AllowUserToDeleteRows = false;
            this.dgvIntreNationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIntreNationalLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvIntreNationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntreNationalLicenses.Location = new System.Drawing.Point(20, 48);
            this.dgvIntreNationalLicenses.Name = "dgvIntreNationalLicenses";
            this.dgvIntreNationalLicenses.ReadOnly = true;
            this.dgvIntreNationalLicenses.Size = new System.Drawing.Size(1123, 222);
            this.dgvIntreNationalLicenses.TabIndex = 0;
            // 
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowInternationalLicense});
            this.cmsInternationalLicenses.Name = "cmsInternationalLicenses";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(205, 52);
            // 
            // tsmShowInternationalLicense
            // 
            this.tsmShowInternationalLicense.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmShowInternationalLicense.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tsmShowInternationalLicense.Name = "tsmShowInternationalLicense";
            this.tsmShowInternationalLicense.Padding = new System.Windows.Forms.Padding(0, 5, 0, 1);
            this.tsmShowInternationalLicense.Size = new System.Drawing.Size(204, 26);
            this.tsmShowInternationalLicense.Text = "Show License Details";
            this.tsmShowInternationalLicense.Click += new System.EventHandler(this.tsmShowInternationalLicense_Click);
            // 
            // ctrlDriverLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicensesHistory";
            this.Size = new System.Drawing.Size(1192, 386);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.cmsLocalLicenseDetails.ResumeLayout(false);
            this.tabIntrenational.ResumeLayout(false);
            this.tabIntrenational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntreNationalLicenses)).EndInit();
            this.cmsInternationalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabIntrenational;
        private System.Windows.Forms.DataGridView dgvIntreNationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.Label lblRecords_Inter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecords_Loc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLocalLicenseDetials;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmShowInternationalLicense;
    }
}
