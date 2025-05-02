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
            this.dgvLDL_AppsList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterTerm = new System.Windows.Forms.TextBox();
            this.btnAddNewLocalApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.pbLDLApp = new System.Windows.Forms.PictureBox();
            this.cmbAppStatusFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDL_AppsList)).BeginInit();
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
            this.dgvLDL_AppsList.Location = new System.Drawing.Point(12, 242);
            this.dgvLDL_AppsList.Name = "dgvLDL_AppsList";
            this.dgvLDL_AppsList.ReadOnly = true;
            this.dgvLDL_AppsList.Size = new System.Drawing.Size(1263, 407);
            this.dgvLDL_AppsList.TabIndex = 0;
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
    }
}