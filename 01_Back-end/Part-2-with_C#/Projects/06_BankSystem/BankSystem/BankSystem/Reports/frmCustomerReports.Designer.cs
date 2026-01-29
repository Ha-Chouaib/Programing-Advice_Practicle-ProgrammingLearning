namespace BankSystem.Reports
{
    partial class frmCustomerReports
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
            this.btnCustomerSummary = new System.Windows.Forms.Button();
            this.btnAccountActivity = new System.Windows.Forms.Button();
            this.btnBalanceStatment = new System.Windows.Forms.Button();
            this.btnDormantAccounts = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctrlManageRecords1 = new BankSystem.ctrlManageRecords();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(694, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Reports";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCustomerSummary
            // 
            this.btnCustomerSummary.BackColor = System.Drawing.Color.Cyan;
            this.btnCustomerSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCustomerSummary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerSummary.Font = new System.Drawing.Font("Segoe UI Black", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnCustomerSummary.ForeColor = System.Drawing.Color.Black;
            this.btnCustomerSummary.Location = new System.Drawing.Point(3, 3);
            this.btnCustomerSummary.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnCustomerSummary.Name = "btnCustomerSummary";
            this.btnCustomerSummary.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCustomerSummary.Size = new System.Drawing.Size(405, 47);
            this.btnCustomerSummary.TabIndex = 1;
            this.btnCustomerSummary.Text = "Customer Summary";
            this.btnCustomerSummary.UseVisualStyleBackColor = false;
            // 
            // btnAccountActivity
            // 
            this.btnAccountActivity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAccountActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountActivity.Font = new System.Drawing.Font("Segoe UI Black", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnAccountActivity.ForeColor = System.Drawing.Color.Cyan;
            this.btnAccountActivity.Location = new System.Drawing.Point(416, 3);
            this.btnAccountActivity.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAccountActivity.Name = "btnAccountActivity";
            this.btnAccountActivity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAccountActivity.Size = new System.Drawing.Size(405, 47);
            this.btnAccountActivity.TabIndex = 2;
            this.btnAccountActivity.Text = "Account Activity";
            this.btnAccountActivity.UseVisualStyleBackColor = false;
            // 
            // btnBalanceStatment
            // 
            this.btnBalanceStatment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBalanceStatment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBalanceStatment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalanceStatment.Font = new System.Drawing.Font("Segoe UI Black", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnBalanceStatment.ForeColor = System.Drawing.Color.Cyan;
            this.btnBalanceStatment.Location = new System.Drawing.Point(829, 3);
            this.btnBalanceStatment.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnBalanceStatment.Name = "btnBalanceStatment";
            this.btnBalanceStatment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBalanceStatment.Size = new System.Drawing.Size(405, 47);
            this.btnBalanceStatment.TabIndex = 3;
            this.btnBalanceStatment.Text = "Balance Statement";
            this.btnBalanceStatment.UseVisualStyleBackColor = false;
            // 
            // btnDormantAccounts
            // 
            this.btnDormantAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDormantAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDormantAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDormantAccounts.Font = new System.Drawing.Font("Segoe UI Black", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnDormantAccounts.ForeColor = System.Drawing.Color.Cyan;
            this.btnDormantAccounts.Location = new System.Drawing.Point(1242, 3);
            this.btnDormantAccounts.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnDormantAccounts.Name = "btnDormantAccounts";
            this.btnDormantAccounts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDormantAccounts.Size = new System.Drawing.Size(410, 47);
            this.btnDormantAccounts.TabIndex = 4;
            this.btnDormantAccounts.Text = "Dormant Accounts";
            this.btnDormantAccounts.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnDormantAccounts, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBalanceStatment, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAccountActivity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCustomerSummary, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1657, 53);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ctrlManageRecords1
            // 
            this.ctrlManageRecords1.@__AvailablePages = ((short)(0));
            this.ctrlManageRecords1.@__PageNumber = ((byte)(1));
            this.ctrlManageRecords1.@__PageSize = ((byte)(50));
            this.ctrlManageRecords1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlManageRecords1.Location = new System.Drawing.Point(39, 131);
            this.ctrlManageRecords1.Name = "ctrlManageRecords1";
            this.ctrlManageRecords1.Size = new System.Drawing.Size(1604, 810);
            this.ctrlManageRecords1.TabIndex = 7;
            // 
            // frmCustomerReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1684, 953);
            this.Controls.Add(this.ctrlManageRecords1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomerReports";
            this.Text = "Customer Reports";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCustomerSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccountActivity;
        private System.Windows.Forms.Button btnBalanceStatment;
        private System.Windows.Forms.Button btnDormantAccounts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ctrlManageRecords ctrlManageRecords1;
    }
}