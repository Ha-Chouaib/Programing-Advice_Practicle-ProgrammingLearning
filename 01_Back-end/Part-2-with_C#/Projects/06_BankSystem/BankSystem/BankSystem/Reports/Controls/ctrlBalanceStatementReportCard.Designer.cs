namespace BankSystem.Reports.Controls
{
    partial class ctrlBalanceStatementReportCard
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
            this.lnkAccountDetails = new System.Windows.Forms.LinkLabel();
            this.lnkCustomerDetails = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Closing = new System.Windows.Forms.Label();
            this.AccountID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClosingBalance = new System.Windows.Forms.TextBox();
            this.txtReportDate = new System.Windows.Forms.TextBox();
            this.txtOpeningBalance = new System.Windows.Forms.TextBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lnkAccountDetails
            // 
            this.lnkAccountDetails.AutoSize = true;
            this.lnkAccountDetails.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAccountDetails.LinkColor = System.Drawing.Color.Cyan;
            this.lnkAccountDetails.Location = new System.Drawing.Point(726, 434);
            this.lnkAccountDetails.Name = "lnkAccountDetails";
            this.lnkAccountDetails.Size = new System.Drawing.Size(188, 23);
            this.lnkAccountDetails.TabIndex = 39;
            this.lnkAccountDetails.TabStop = true;
            this.lnkAccountDetails.Text = "View Account Details";
            this.lnkAccountDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAccountDetails_LinkClicked);
            // 
            // lnkCustomerDetails
            // 
            this.lnkCustomerDetails.AutoSize = true;
            this.lnkCustomerDetails.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCustomerDetails.LinkColor = System.Drawing.Color.Cyan;
            this.lnkCustomerDetails.Location = new System.Drawing.Point(70, 434);
            this.lnkCustomerDetails.Name = "lnkCustomerDetails";
            this.lnkCustomerDetails.Size = new System.Drawing.Size(200, 23);
            this.lnkCustomerDetails.TabIndex = 38;
            this.lnkCustomerDetails.TabStop = true;
            this.lnkCustomerDetails.Text = "View Customer Details";
            this.lnkCustomerDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustomerDetails_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(574, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "To Date";
            // 
            // txtToDate
            // 
            this.txtToDate.BackColor = System.Drawing.Color.Black;
            this.txtToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToDate.ForeColor = System.Drawing.Color.White;
            this.txtToDate.Location = new System.Drawing.Point(578, 278);
            this.txtToDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtToDate.Multiline = true;
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ReadOnly = true;
            this.txtToDate.Size = new System.Drawing.Size(336, 48);
            this.txtToDate.TabIndex = 36;
            this.txtToDate.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(70, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "From Date";
            // 
            // txtFromDate
            // 
            this.txtFromDate.BackColor = System.Drawing.Color.Black;
            this.txtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromDate.ForeColor = System.Drawing.Color.White;
            this.txtFromDate.Location = new System.Drawing.Point(74, 278);
            this.txtFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtFromDate.Multiline = true;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ReadOnly = true;
            this.txtFromDate.Size = new System.Drawing.Size(336, 48);
            this.txtFromDate.TabIndex = 34;
            this.txtFromDate.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(574, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Opening Balance";
            // 
            // Closing
            // 
            this.Closing.AutoSize = true;
            this.Closing.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closing.ForeColor = System.Drawing.SystemColors.Info;
            this.Closing.Location = new System.Drawing.Point(574, 158);
            this.Closing.Name = "Closing";
            this.Closing.Size = new System.Drawing.Size(123, 20);
            this.Closing.TabIndex = 30;
            this.Closing.Text = "Closing Balance";
            // 
            // AccountID
            // 
            this.AccountID.AutoSize = true;
            this.AccountID.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountID.ForeColor = System.Drawing.SystemColors.Info;
            this.AccountID.Location = new System.Drawing.Point(70, 158);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(84, 20);
            this.AccountID.TabIndex = 28;
            this.AccountID.Text = "AccountID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(448, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Report Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(70, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Report ID";
            // 
            // txtClosingBalance
            // 
            this.txtClosingBalance.BackColor = System.Drawing.Color.Black;
            this.txtClosingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClosingBalance.ForeColor = System.Drawing.Color.White;
            this.txtClosingBalance.Location = new System.Drawing.Point(578, 182);
            this.txtClosingBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtClosingBalance.Multiline = true;
            this.txtClosingBalance.Name = "txtClosingBalance";
            this.txtClosingBalance.ReadOnly = true;
            this.txtClosingBalance.Size = new System.Drawing.Size(336, 48);
            this.txtClosingBalance.TabIndex = 25;
            this.txtClosingBalance.TabStop = false;
            // 
            // txtReportDate
            // 
            this.txtReportDate.BackColor = System.Drawing.Color.Black;
            this.txtReportDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportDate.ForeColor = System.Drawing.Color.White;
            this.txtReportDate.Location = new System.Drawing.Point(338, 354);
            this.txtReportDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportDate.Multiline = true;
            this.txtReportDate.Name = "txtReportDate";
            this.txtReportDate.ReadOnly = true;
            this.txtReportDate.Size = new System.Drawing.Size(336, 48);
            this.txtReportDate.TabIndex = 24;
            this.txtReportDate.TabStop = false;
            this.txtReportDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOpeningBalance
            // 
            this.txtOpeningBalance.BackColor = System.Drawing.Color.Black;
            this.txtOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpeningBalance.ForeColor = System.Drawing.Color.White;
            this.txtOpeningBalance.Location = new System.Drawing.Point(578, 91);
            this.txtOpeningBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtOpeningBalance.Multiline = true;
            this.txtOpeningBalance.Name = "txtOpeningBalance";
            this.txtOpeningBalance.ReadOnly = true;
            this.txtOpeningBalance.Size = new System.Drawing.Size(336, 48);
            this.txtOpeningBalance.TabIndex = 23;
            this.txtOpeningBalance.TabStop = false;
            // 
            // txtAccountID
            // 
            this.txtAccountID.BackColor = System.Drawing.Color.Black;
            this.txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountID.ForeColor = System.Drawing.Color.White;
            this.txtAccountID.Location = new System.Drawing.Point(74, 182);
            this.txtAccountID.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountID.Multiline = true;
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.ReadOnly = true;
            this.txtAccountID.Size = new System.Drawing.Size(336, 48);
            this.txtAccountID.TabIndex = 21;
            this.txtAccountID.TabStop = false;
            // 
            // txtReportID
            // 
            this.txtReportID.BackColor = System.Drawing.Color.Black;
            this.txtReportID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReportID.ForeColor = System.Drawing.Color.White;
            this.txtReportID.Location = new System.Drawing.Point(74, 91);
            this.txtReportID.Margin = new System.Windows.Forms.Padding(4);
            this.txtReportID.Multiline = true;
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.ReadOnly = true;
            this.txtReportID.Size = new System.Drawing.Size(336, 48);
            this.txtReportID.TabIndex = 20;
            this.txtReportID.TabStop = false;
            // 
            // ctrlBalanceStatementReportCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.lnkAccountDetails);
            this.Controls.Add(this.lnkCustomerDetails);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Closing);
            this.Controls.Add(this.AccountID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClosingBalance);
            this.Controls.Add(this.txtReportDate);
            this.Controls.Add(this.txtOpeningBalance);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.txtReportID);
            this.Name = "ctrlBalanceStatementReportCard";
            this.Size = new System.Drawing.Size(984, 513);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkAccountDetails;
        private System.Windows.Forms.LinkLabel lnkCustomerDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Closing;
        private System.Windows.Forms.Label AccountID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClosingBalance;
        private System.Windows.Forms.TextBox txtReportDate;
        private System.Windows.Forms.TextBox txtOpeningBalance;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.TextBox txtReportID;
    }
}
