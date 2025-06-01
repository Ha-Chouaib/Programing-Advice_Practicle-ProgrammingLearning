namespace DVLD_Project.License.Forms
{
    partial class frmManageInternationalLicenses
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
            this.dgvListInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewInternationalLicens = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterTerm = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListInternationalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListInternationalLicenses
            // 
            this.dgvListInternationalLicenses.AllowUserToAddRows = false;
            this.dgvListInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvListInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListInternationalLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgvListInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListInternationalLicenses.Location = new System.Drawing.Point(9, 319);
            this.dgvListInternationalLicenses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvListInternationalLicenses.Name = "dgvListInternationalLicenses";
            this.dgvListInternationalLicenses.ReadOnly = true;
            this.dgvListInternationalLicenses.Size = new System.Drawing.Size(1080, 401);
            this.dgvListInternationalLicenses.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClose.Location = new System.Drawing.Point(989, 724);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewInternationalLicens
            // 
            this.btnAddNewInternationalLicens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewInternationalLicens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewInternationalLicens.ForeColor = System.Drawing.SystemColors.Info;
            this.btnAddNewInternationalLicens.Location = new System.Drawing.Point(869, 268);
            this.btnAddNewInternationalLicens.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddNewInternationalLicens.Name = "btnAddNewInternationalLicens";
            this.btnAddNewInternationalLicens.Size = new System.Drawing.Size(220, 41);
            this.btnAddNewInternationalLicens.TabIndex = 1;
            this.btnAddNewInternationalLicens.Text = "Add New International License";
            this.btnAddNewInternationalLicens.UseVisualStyleBackColor = true;
            this.btnAddNewInternationalLicens.Click += new System.EventHandler(this.btnAddNewInternationalLicens_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 38.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(283, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(599, 62);
            this.label1.TabIndex = 3;
            this.label1.Text = "International Licenses";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.ForeColor = System.Drawing.Color.Cyan;
            this.lblRecords.Location = new System.Drawing.Point(84, 731);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(48, 18);
            this.lblRecords.TabIndex = 4;
            this.lblRecords.Text = "[ ??? ]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(5, 731);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Records:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(8, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filter By ->";
            // 
            // txtFilterTerm
            // 
            this.txtFilterTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtFilterTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterTerm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtFilterTerm.Location = new System.Drawing.Point(292, 278);
            this.txtFilterTerm.Name = "txtFilterTerm";
            this.txtFilterTerm.Size = new System.Drawing.Size(210, 23);
            this.txtFilterTerm.TabIndex = 7;
            this.txtFilterTerm.TextChanged += new System.EventHandler(this.txtFilterTerm_TextChanged);
            this.txtFilterTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterTerm_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.InternationalLicenseImg;
            this.pictureBox1.Location = new System.Drawing.Point(434, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.ForeColor = System.Drawing.Color.Black;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(104, 277);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(177, 26);
            this.cmbFilterOptions.TabIndex = 9;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.ForeColor = System.Drawing.Color.Black;
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(292, 277);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(177, 26);
            this.cmbIsActive.TabIndex = 10;
            this.cmbIsActive.SelectedIndexChanged += new System.EventHandler(this.cmbIsActive_SelectedIndexChanged);
            // 
            // frmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1100, 774);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFilterTerm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewInternationalLicens);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvListInternationalLicenses);
            this.Font = new System.Drawing.Font("Trebuchet MS", 10.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmManageInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage International Licenses";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListInternationalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListInternationalLicenses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewInternationalLicens;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilterTerm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.ComboBox cmbIsActive;
    }
}