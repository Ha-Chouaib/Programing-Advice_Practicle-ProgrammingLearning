namespace DVLD_Project.Drivers
{
    partial class frmManageDrivers
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
            this.dgvDriversList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilterDrivers = new System.Windows.Forms.ComboBox();
            this.txtFilterTerm = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDriversList
            // 
            this.dgvDriversList.AllowUserToAddRows = false;
            this.dgvDriversList.AllowUserToDeleteRows = false;
            this.dgvDriversList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDriversList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvDriversList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriversList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDriversList.Location = new System.Drawing.Point(31, 317);
            this.dgvDriversList.Name = "dgvDriversList";
            this.dgvDriversList.ReadOnly = true;
            this.dgvDriversList.Size = new System.Drawing.Size(1083, 355);
            this.dgvDriversList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicensesHistoryToolStripMenuItem,
            this.addNewLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 100);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.showPersonDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.showPersonDetailsToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicensesHistoryToolStripMenuItem
            // 
            this.showLicensesHistoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.showLicensesHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicensesHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.showLicensesHistoryToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.showLicensesHistoryToolStripMenuItem.Name = "showLicensesHistoryToolStripMenuItem";
            this.showLicensesHistoryToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.showLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.showLicensesHistoryToolStripMenuItem.Text = "Show Licenses History";
            this.showLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicensesHistoryToolStripMenuItem_Click);
            // 
            // addNewLicenseToolStripMenuItem
            // 
            this.addNewLicenseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.addNewLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewLicenseToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.addNewLicenseToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.addNewLicenseToolStripMenuItem.Name = "addNewLicenseToolStripMenuItem";
            this.addNewLicenseToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.addNewLicenseToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.addNewLicenseToolStripMenuItem.Text = "Add New License";
            this.addNewLicenseToolStripMenuItem.Click += new System.EventHandler(this.addNewLicenseToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(1021, 690);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(27, 699);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Records:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Trebuchet MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblRecords.ForeColor = System.Drawing.Color.Cyan;
            this.lblRecords.Location = new System.Drawing.Point(109, 701);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(40, 18);
            this.lblRecords.TabIndex = 3;
            this.lblRecords.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 32.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(391, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 52);
            this.label3.TabIndex = 4;
            this.label3.Text = "Manage Drivers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(27, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filter By->";
            // 
            // cmbFilterDrivers
            // 
            this.cmbFilterDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cmbFilterDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterDrivers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmbFilterDrivers.FormattingEnabled = true;
            this.cmbFilterDrivers.Location = new System.Drawing.Point(123, 286);
            this.cmbFilterDrivers.Name = "cmbFilterDrivers";
            this.cmbFilterDrivers.Size = new System.Drawing.Size(219, 25);
            this.cmbFilterDrivers.TabIndex = 7;
            this.cmbFilterDrivers.SelectedIndexChanged += new System.EventHandler(this.cmbFilterDrivers_SelectedIndexChanged);
            // 
            // txtFilterTerm
            // 
            this.txtFilterTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtFilterTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterTerm.Font = new System.Drawing.Font("Segoe UI Historic", 11.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txtFilterTerm.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtFilterTerm.Location = new System.Drawing.Point(372, 286);
            this.txtFilterTerm.Multiline = true;
            this.txtFilterTerm.Name = "txtFilterTerm";
            this.txtFilterTerm.Size = new System.Drawing.Size(219, 25);
            this.txtFilterTerm.TabIndex = 8;
            this.txtFilterTerm.Visible = false;
            this.txtFilterTerm.TextChanged += new System.EventHandler(this.txtFilterTerm_TextChanged);
            this.txtFilterTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterTerm_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.ManageDriversImg;
            this.pictureBox1.Location = new System.Drawing.Point(416, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1136, 743);
            this.Controls.Add(this.txtFilterTerm);
            this.Controls.Add(this.cmbFilterDrivers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDriversList);
            this.Font = new System.Drawing.Font("Segoe UI Historic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageDrivers";
            this.Text = "frmManageDrivers";
            this.Load += new System.EventHandler(this.frmManageDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDriversList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFilterDrivers;
        private System.Windows.Forms.TextBox txtFilterTerm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewLicenseToolStripMenuItem;
    }
}