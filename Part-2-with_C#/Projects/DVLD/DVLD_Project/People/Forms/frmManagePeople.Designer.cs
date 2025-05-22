namespace DVLD_Project
{
    partial class frmManagePeople
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtFilterPeople = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLsitPeople = new System.Windows.Forms.DataGridView();
            this.cmsManagePeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLsitPeople)).BeginInit();
            this.cmsManagePeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Controls.Add(this.txtFilterPeople);
            this.panel1.Controls.Add(this.cmbFilter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvLsitPeople);
            this.panel1.Location = new System.Drawing.Point(12, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1394, 411);
            this.panel1.TabIndex = 0;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.Cyan;
            this.btnAddNew.Location = new System.Drawing.Point(1285, 12);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(96, 38);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "Add New +";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtFilterPeople
            // 
            this.txtFilterPeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtFilterPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFilterPeople.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterPeople.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtFilterPeople.Location = new System.Drawing.Point(430, 20);
            this.txtFilterPeople.MaxLength = 50;
            this.txtFilterPeople.Multiline = true;
            this.txtFilterPeople.Name = "txtFilterPeople";
            this.txtFilterPeople.Size = new System.Drawing.Size(238, 26);
            this.txtFilterPeople.TabIndex = 2;
            this.txtFilterPeople.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterPeople_KeyPress);
            this.txtFilterPeople.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilterPeople_KeyUp);
            // 
            // cmbFilter
            // 
            this.cmbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFilter.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilter.ForeColor = System.Drawing.SystemColors.Menu;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(117, 20);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(276, 26);
            this.cmbFilter.TabIndex = 1;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter By ->";
            // 
            // dgvLsitPeople
            // 
            this.dgvLsitPeople.AllowUserToAddRows = false;
            this.dgvLsitPeople.AllowUserToDeleteRows = false;
            this.dgvLsitPeople.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.dgvLsitPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLsitPeople.ContextMenuStrip = this.cmsManagePeople;
            this.dgvLsitPeople.Location = new System.Drawing.Point(13, 58);
            this.dgvLsitPeople.Name = "dgvLsitPeople";
            this.dgvLsitPeople.ReadOnly = true;
            this.dgvLsitPeople.Size = new System.Drawing.Size(1368, 334);
            this.dgvLsitPeople.TabIndex = 0;
            this.dgvLsitPeople.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLsitPeople_CellFormatting);
            // 
            // cmsManagePeople
            // 
            this.cmsManagePeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.cmsManagePeople.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsManagePeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDetails,
            this.tsmAddNew,
            this.tsmEdit,
            this.tsmDelete,
            this.tsmSendEmail,
            this.tsmPhoneCall});
            this.cmsManagePeople.Name = "cmsManagePeople";
            this.cmsManagePeople.Size = new System.Drawing.Size(179, 136);
            // 
            // tsmShowDetails
            // 
            this.tsmShowDetails.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmShowDetails.Name = "tsmShowDetails";
            this.tsmShowDetails.Size = new System.Drawing.Size(178, 22);
            this.tsmShowDetails.Text = "Show Details";
            this.tsmShowDetails.Click += new System.EventHandler(this.tsmShowDetails_Click);
            // 
            // tsmAddNew
            // 
            this.tsmAddNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmAddNew.Name = "tsmAddNew";
            this.tsmAddNew.Size = new System.Drawing.Size(178, 22);
            this.tsmAddNew.Text = "Add New Person";
            this.tsmAddNew.Click += new System.EventHandler(this.tsmAddNew_Click);
            // 
            // tsmEdit
            // 
            this.tsmEdit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(178, 22);
            this.tsmEdit.Text = "Edit";
            this.tsmEdit.Click += new System.EventHandler(this.tsmEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(178, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmSendEmail
            // 
            this.tsmSendEmail.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmSendEmail.Name = "tsmSendEmail";
            this.tsmSendEmail.Size = new System.Drawing.Size(178, 22);
            this.tsmSendEmail.Text = "Send Email";
            this.tsmSendEmail.Click += new System.EventHandler(this.tsmSendEmail_Click);
            // 
            // tsmPhoneCall
            // 
            this.tsmPhoneCall.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmPhoneCall.Name = "tsmPhoneCall";
            this.tsmPhoneCall.Size = new System.Drawing.Size(178, 22);
            this.tsmPhoneCall.Text = "Phone Call";
            this.tsmPhoneCall.Click += new System.EventHandler(this.tsmPhoneCall_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Menu;
            this.btnClose.Location = new System.Drawing.Point(1303, 760);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordNumber.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblRecordNumber.Location = new System.Drawing.Point(12, 769);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(70, 20);
            this.lblRecordNumber.TabIndex = 2;
            this.lblRecordNumber.Text = "Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRecordsCount.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Aqua;
            this.lblRecordsCount.Location = new System.Drawing.Point(114, 769);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(73, 20);
            this.lblRecordsCount.TabIndex = 3;
            this.lblRecordsCount.Text = "<< ??? >>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 39F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(496, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 63);
            this.label2.TabIndex = 4;
            this.label2.Text = "Manage People";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.ManagePeopleImg;
            this.pictureBox1.Location = new System.Drawing.Point(539, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmManagePeople
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1418, 810);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblRecordNumber);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "frmManagePeople";
            this.Text = "frmManagePeople";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLsitPeople)).EndInit();
            this.cmsManagePeople.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordNumber;
        private System.Windows.Forms.DataGridView dgvLsitPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtFilterPeople;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip cmsManagePeople;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNew;
        private System.Windows.Forms.ToolStripMenuItem tsmEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmSendEmail;
        private System.Windows.Forms.ToolStripMenuItem tsmPhoneCall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}