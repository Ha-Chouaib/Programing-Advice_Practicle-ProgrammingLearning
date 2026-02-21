namespace BankSystem.Reports.Controls
{
    partial class ctrlDormantAccountsReportCard
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastTransactionDate = new System.Windows.Forms.TextBox();
            this.lnkCustomerDetails = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDormantMonths = new System.Windows.Forms.TextBox();
            this.Closing = new System.Windows.Forms.Label();
            this.AccountID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActiveAccounts = new System.Windows.Forms.TextBox();
            this.txtReportDate = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(633, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "Last Transaction Date";
            // 
            // txtLastTransactionDate
            // 
            this.txtLastTransactionDate.BackColor = System.Drawing.Color.Black;
            this.txtLastTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastTransactionDate.ForeColor = System.Drawing.Color.White;
            this.txtLastTransactionDate.Location = new System.Drawing.Point(554, 92);
            this.txtLastTransactionDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastTransactionDate.Multiline = true;
            this.txtLastTransactionDate.Name = "txtLastTransactionDate";
            this.txtLastTransactionDate.ReadOnly = true;
            this.txtLastTransactionDate.Size = new System.Drawing.Size(336, 48);
            this.txtLastTransactionDate.TabIndex = 71;
            this.txtLastTransactionDate.TabStop = false;
            this.txtLastTransactionDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lnkCustomerDetails
            // 
            this.lnkCustomerDetails.AutoSize = true;
            this.lnkCustomerDetails.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomerDetails.LinkColor = System.Drawing.Color.Cyan;
            this.lnkCustomerDetails.Location = new System.Drawing.Point(399, 361);
            this.lnkCustomerDetails.Name = "lnkCustomerDetails";
            this.lnkCustomerDetails.Size = new System.Drawing.Size(200, 23);
            this.lnkCustomerDetails.TabIndex = 70;
            this.lnkCustomerDetails.TabStop = true;
            this.lnkCustomerDetails.Text = "View Customer Details";
            this.lnkCustomerDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomerDetails_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(651, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "Dormant Months";
            // 
            // txtDormantMonths
            // 
            this.txtDormantMonths.BackColor = System.Drawing.Color.Black;
            this.txtDormantMonths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDormantMonths.ForeColor = System.Drawing.Color.White;
            this.txtDormantMonths.Location = new System.Drawing.Point(554, 183);
            this.txtDormantMonths.Margin = new System.Windows.Forms.Padding(4);
            this.txtDormantMonths.Multiline = true;
            this.txtDormantMonths.Name = "txtDormantMonths";
            this.txtDormantMonths.ReadOnly = true;
            this.txtDormantMonths.Size = new System.Drawing.Size(336, 48);
            this.txtDormantMonths.TabIndex = 66;
            this.txtDormantMonths.TabStop = false;
            this.txtDormantMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Closing
            // 
            this.Closing.AutoSize = true;
            this.Closing.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closing.ForeColor = System.Drawing.SystemColors.Info;
            this.Closing.Location = new System.Drawing.Point(95, 255);
            this.Closing.Name = "Closing";
            this.Closing.Size = new System.Drawing.Size(115, 20);
            this.Closing.TabIndex = 64;
            this.Closing.Text = "Transaction ID";
            // 
            // AccountID
            // 
            this.AccountID.AutoSize = true;
            this.AccountID.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID.ForeColor = System.Drawing.SystemColors.Info;
            this.AccountID.Location = new System.Drawing.Point(95, 159);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(99, 20);
            this.AccountID.TabIndex = 63;
            this.AccountID.Text = "Customer ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(662, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "Report Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(95, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "Report ID";
            // 
            // txtActiveAccounts
            // 
            this.txtActiveAccounts.BackColor = System.Drawing.Color.Black;
            this.txtActiveAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActiveAccounts.ForeColor = System.Drawing.Color.White;
            this.txtActiveAccounts.Location = new System.Drawing.Point(99, 279);
            this.txtActiveAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.txtActiveAccounts.Multiline = true;
            this.txtActiveAccounts.Name = "txtActiveAccounts";
            this.txtActiveAccounts.ReadOnly = true;
            this.txtActiveAccounts.Size = new System.Drawing.Size(336, 48);
            this.txtActiveAccounts.TabIndex = 60;
            this.txtActiveAccounts.TabStop = false;
            // 
            // txtReportDate
            // 
            this.txtReportDate.BackColor = System.Drawing.Color.Black;
            this.txtReportDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportDate.ForeColor = System.Drawing.Color.White;
            this.txtReportDate.Location = new System.Drawing.Point(554, 279);
            this.txtReportDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportDate.Multiline = true;
            this.txtReportDate.Name = "txtReportDate";
            this.txtReportDate.ReadOnly = true;
            this.txtReportDate.Size = new System.Drawing.Size(336, 48);
            this.txtReportDate.TabIndex = 59;
            this.txtReportDate.TabStop = false;
            this.txtReportDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.Black;
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.ForeColor = System.Drawing.Color.White;
            this.txtCustomerID.Location = new System.Drawing.Point(99, 183);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerID.Multiline = true;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(336, 48);
            this.txtCustomerID.TabIndex = 57;
            this.txtCustomerID.TabStop = false;
            // 
            // txtReportID
            // 
            this.txtReportID.BackColor = System.Drawing.Color.Black;
            this.txtReportID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportID.ForeColor = System.Drawing.Color.White;
            this.txtReportID.Location = new System.Drawing.Point(99, 92);
            this.txtReportID.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportID.Multiline = true;
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.ReadOnly = true;
            this.txtReportID.Size = new System.Drawing.Size(336, 48);
            this.txtReportID.TabIndex = 56;
            this.txtReportID.TabStop = false;
            // 
            // ctrlDormantAccountsReportCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLastTransactionDate);
            this.Controls.Add(this.lnkCustomerDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDormantMonths);
            this.Controls.Add(this.Closing);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActiveAccounts);
            this.Controls.Add(this.txtReportDate);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtReportID);
            this.Name = "ctrlDormantAccountsReportCard";
            this.Size = new System.Drawing.Size(934, 412);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastTransactionDate;
        private System.Windows.Forms.LinkLabel lnkCustomerDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDormantMonths;
        private System.Windows.Forms.Label Closing;
        private System.Windows.Forms.Label AccountID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActiveAccounts;
        private System.Windows.Forms.TextBox txtReportDate;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtReportID;
    }
}
