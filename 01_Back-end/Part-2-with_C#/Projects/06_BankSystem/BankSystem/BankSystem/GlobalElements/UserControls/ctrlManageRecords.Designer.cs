namespace BankSystem
{
    partial class ctrlManageRecords
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvListRecords = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.cmbFilterByGroups = new System.Windows.Forms.ComboBox();
            this.pbRecordsProfile = new System.Windows.Forms.PictureBox();
            this.pbSearchClick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecordsProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchClick)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.BackColor = System.Drawing.Color.Black;
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterOptions.ForeColor = System.Drawing.Color.White;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(153, 260);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(274, 33);
            this.cmbFilterOptions.TabIndex = 0;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.BackColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Cyan;
            this.lblRecordsCount.Location = new System.Drawing.Point(32, 715);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(79, 25);
            this.lblRecordsCount.TabIndex = 15;
            this.lblRecordsCount.Text = "Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By ->";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(1474, 708);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Black;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(166)))), ((int)(((byte)(86)))));
            this.btnUpdate.Location = new System.Drawing.Point(1261, 255);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 42);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Edit ";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Black;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.Cyan;
            this.btnAddNew.Location = new System.Drawing.Point(1390, 255);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(175, 42);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "Add New ";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Info;
            this.lblTitle.Location = new System.Drawing.Point(549, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(527, 81);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Manage Records";
            // 
            // dgvListRecords
            // 
            this.dgvListRecords.AllowUserToAddRows = false;
            this.dgvListRecords.AllowUserToDeleteRows = false;
            this.dgvListRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListRecords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.dgvListRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRecords.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListRecords.Location = new System.Drawing.Point(37, 309);
            this.dgvListRecords.MultiSelect = false;
            this.dgvListRecords.Name = "dgvListRecords";
            this.dgvListRecords.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListRecords.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvListRecords.RowTemplate.Height = 24;
            this.dgvListRecords.Size = new System.Drawing.Size(1528, 396);
            this.dgvListRecords.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.BackColor = System.Drawing.Color.Black;
            this.txtSearchTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchTerm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTerm.ForeColor = System.Drawing.Color.White;
            this.txtSearchTerm.Location = new System.Drawing.Point(539, 255);
            this.txtSearchTerm.Multiline = true;
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(574, 38);
            this.txtSearchTerm.TabIndex = 1;
            // 
            // cmbFilterByGroups
            // 
            this.cmbFilterByGroups.BackColor = System.Drawing.Color.Black;
            this.cmbFilterByGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterByGroups.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterByGroups.ForeColor = System.Drawing.Color.White;
            this.cmbFilterByGroups.FormattingEnabled = true;
            this.cmbFilterByGroups.Location = new System.Drawing.Point(577, 260);
            this.cmbFilterByGroups.Name = "cmbFilterByGroups";
            this.cmbFilterByGroups.Size = new System.Drawing.Size(389, 33);
            this.cmbFilterByGroups.TabIndex = 20;
            this.cmbFilterByGroups.Visible = false;
            this.cmbFilterByGroups.SelectedIndexChanged += new System.EventHandler(this.cmbFilterByGroups_SelectedIndexChanged);
            // 
            // pbRecordsProfile
            // 
            this.pbRecordsProfile.Image = global::BankSystem.Properties.Resources.social_responsibility_18024872;
            this.pbRecordsProfile.Location = new System.Drawing.Point(666, 84);
            this.pbRecordsProfile.Name = "pbRecordsProfile";
            this.pbRecordsProfile.Size = new System.Drawing.Size(251, 153);
            this.pbRecordsProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRecordsProfile.TabIndex = 19;
            this.pbRecordsProfile.TabStop = false;
            // 
            // pbSearchClick
            // 
            this.pbSearchClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearchClick.Image = global::BankSystem.Properties.Resources.search_11349253;
            this.pbSearchClick.Location = new System.Drawing.Point(1119, 255);
            this.pbSearchClick.Name = "pbSearchClick";
            this.pbSearchClick.Size = new System.Drawing.Size(45, 38);
            this.pbSearchClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearchClick.TabIndex = 18;
            this.pbSearchClick.TabStop = false;
            this.pbSearchClick.Click += new System.EventHandler(this.pbSearchClick_Click);
            // 
            // ctrlManageRecords
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.cmbFilterByGroups);
            this.Controls.Add(this.pbRecordsProfile);
            this.Controls.Add(this.pbSearchClick);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvListRecords);
            this.Name = "ctrlManageRecords";
            this.Size = new System.Drawing.Size(1574, 756);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecordsProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchClick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvListRecords;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.PictureBox pbSearchClick;
        private System.Windows.Forms.PictureBox pbRecordsProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cmbFilterByGroups;
    }
}
