namespace BankSystem.Reports.Controls
{
    partial class ctrlCustomerSummaryReportCard
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
            this.lnkCustomerDetails = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastActivityDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Closing = new System.Windows.Forms.Label();
            this.AccountID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActiveAccounts = new System.Windows.Forms.TextBox();
            this.txtReportDate = new System.Windows.Forms.TextBox();
            this.txtTotalAccounts = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lnkCustomerDetails
            // 
            this.lnkCustomerDetails.AutoSize = true;
            this.lnkCustomerDetails.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomerDetails.LinkColor = System.Drawing.Color.Cyan;
            this.lnkCustomerDetails.Location = new System.Drawing.Point(405, 460);
            this.lnkCustomerDetails.Name = "lnkCustomerDetails";
            this.lnkCustomerDetails.Size = new System.Drawing.Size(200, 23);
            this.lnkCustomerDetails.TabIndex = 53;
            this.lnkCustomerDetails.TabStop = true;
            this.lnkCustomerDetails.Text = "View Customer Details";
            this.lnkCustomerDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomerDetails_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(594, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 52;
            this.label7.Text = "Total Balance";
            // 
            // txtTotalBalance
            // 
            this.txtTotalBalance.BackColor = System.Drawing.Color.Black;
            this.txtTotalBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBalance.ForeColor = System.Drawing.Color.White;
            this.txtTotalBalance.Location = new System.Drawing.Point(598, 298);
            this.txtTotalBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalBalance.Multiline = true;
            this.txtTotalBalance.Name = "txtTotalBalance";
            this.txtTotalBalance.ReadOnly = true;
            this.txtTotalBalance.Size = new System.Drawing.Size(336, 48);
            this.txtTotalBalance.TabIndex = 51;
            this.txtTotalBalance.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(90, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Last Activity Date";
            // 
            // txtLastActivityDate
            // 
            this.txtLastActivityDate.BackColor = System.Drawing.Color.Black;
            this.txtLastActivityDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastActivityDate.ForeColor = System.Drawing.Color.White;
            this.txtLastActivityDate.Location = new System.Drawing.Point(94, 298);
            this.txtLastActivityDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastActivityDate.Multiline = true;
            this.txtLastActivityDate.Name = "txtLastActivityDate";
            this.txtLastActivityDate.ReadOnly = true;
            this.txtLastActivityDate.Size = new System.Drawing.Size(336, 48);
            this.txtLastActivityDate.TabIndex = 49;
            this.txtLastActivityDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(594, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Total Accounts";
            // 
            // Closing
            // 
            this.Closing.AutoSize = true;
            this.Closing.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closing.ForeColor = System.Drawing.SystemColors.Info;
            this.Closing.Location = new System.Drawing.Point(594, 178);
            this.Closing.Name = "Closing";
            this.Closing.Size = new System.Drawing.Size(125, 20);
            this.Closing.TabIndex = 47;
            this.Closing.Text = "Active Accounts";
            // 
            // AccountID
            // 
            this.AccountID.AutoSize = true;
            this.AccountID.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID.ForeColor = System.Drawing.SystemColors.Info;
            this.AccountID.Location = new System.Drawing.Point(90, 178);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(99, 20);
            this.AccountID.TabIndex = 46;
            this.AccountID.Text = "Customer ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(200, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Report Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(90, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Report ID";
            // 
            // txtActiveAccounts
            // 
            this.txtActiveAccounts.BackColor = System.Drawing.Color.Black;
            this.txtActiveAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActiveAccounts.ForeColor = System.Drawing.Color.White;
            this.txtActiveAccounts.Location = new System.Drawing.Point(598, 202);
            this.txtActiveAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.txtActiveAccounts.Multiline = true;
            this.txtActiveAccounts.Name = "txtActiveAccounts";
            this.txtActiveAccounts.ReadOnly = true;
            this.txtActiveAccounts.Size = new System.Drawing.Size(336, 48);
            this.txtActiveAccounts.TabIndex = 43;
            this.txtActiveAccounts.TabStop = false;
            // 
            // txtReportDate
            // 
            this.txtReportDate.BackColor = System.Drawing.Color.Black;
            this.txtReportDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportDate.ForeColor = System.Drawing.Color.White;
            this.txtReportDate.Location = new System.Drawing.Point(90, 388);
            this.txtReportDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportDate.Multiline = true;
            this.txtReportDate.Name = "txtReportDate";
            this.txtReportDate.ReadOnly = true;
            this.txtReportDate.Size = new System.Drawing.Size(336, 48);
            this.txtReportDate.TabIndex = 42;
            this.txtReportDate.TabStop = false;
            this.txtReportDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalAccounts
            // 
            this.txtTotalAccounts.BackColor = System.Drawing.Color.Black;
            this.txtTotalAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAccounts.ForeColor = System.Drawing.Color.White;
            this.txtTotalAccounts.Location = new System.Drawing.Point(598, 111);
            this.txtTotalAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalAccounts.Multiline = true;
            this.txtTotalAccounts.Name = "txtTotalAccounts";
            this.txtTotalAccounts.ReadOnly = true;
            this.txtTotalAccounts.Size = new System.Drawing.Size(336, 48);
            this.txtTotalAccounts.TabIndex = 41;
            this.txtTotalAccounts.TabStop = false;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.Black;
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.ForeColor = System.Drawing.Color.White;
            this.txtCustomerID.Location = new System.Drawing.Point(94, 202);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerID.Multiline = true;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(336, 48);
            this.txtCustomerID.TabIndex = 40;
            this.txtCustomerID.TabStop = false;
            // 
            // txtReportID
            // 
            this.txtReportID.BackColor = System.Drawing.Color.Black;
            this.txtReportID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportID.ForeColor = System.Drawing.Color.White;
            this.txtReportID.Location = new System.Drawing.Point(94, 111);
            this.txtReportID.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportID.Multiline = true;
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.ReadOnly = true;
            this.txtReportID.Size = new System.Drawing.Size(336, 48);
            this.txtReportID.TabIndex = 39;
            this.txtReportID.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(698, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Customer Status";
            // 
            // txtCustomerStatus
            // 
            this.txtCustomerStatus.BackColor = System.Drawing.Color.Black;
            this.txtCustomerStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerStatus.ForeColor = System.Drawing.Color.White;
            this.txtCustomerStatus.Location = new System.Drawing.Point(596, 388);
            this.txtCustomerStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerStatus.Multiline = true;
            this.txtCustomerStatus.Name = "txtCustomerStatus";
            this.txtCustomerStatus.ReadOnly = true;
            this.txtCustomerStatus.Size = new System.Drawing.Size(336, 48);
            this.txtCustomerStatus.TabIndex = 54;
            this.txtCustomerStatus.TabStop = false;
            this.txtCustomerStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctrlCustomerSummaryReportCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerStatus);
            this.Controls.Add(this.lnkCustomerDetails);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastActivityDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Closing);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActiveAccounts);
            this.Controls.Add(this.txtReportDate);
            this.Controls.Add(this.txtTotalAccounts);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtReportID);
            this.Name = "ctrlCustomerSummaryReportCard";
            this.Size = new System.Drawing.Size(1024, 497);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkCustomerDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastActivityDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Closing;
        private System.Windows.Forms.Label AccountID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtActiveAccounts;
        private System.Windows.Forms.TextBox txtReportDate;
        private System.Windows.Forms.TextBox txtTotalAccounts;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtReportID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerStatus;
    }
}
