namespace BankSystem.GlobalElements.Forms
{
    partial class frmMappTransactions
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
            this.btnTransfer = new BankSystem.SystemSettings.Controls.ctrlCustomBtn();
            this.btnWithdrawal = new BankSystem.SystemSettings.Controls.ctrlCustomBtn();
            this.btnDeposit = new BankSystem.SystemSettings.Controls.ctrlCustomBtn();
            this.SuspendLayout();
            // 
            // btnTransfer
            // 
            this.btnTransfer.@__BtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnTransfer.@__BtnBackColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnTransfer.@__BtnClickAction = null;
            this.btnTransfer.@__BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnTransfer.@__BtnForeColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnTransfer.@__BtnImage = global::BankSystem.Properties.Resources.TransferMoney_logo;
            this.btnTransfer.@__BtnText = "Transfer";
            this.btnTransfer.@__HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(128)))), ((int)(((byte)(237)))));
            this.btnTransfer.@__HoverForColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(204)))), ((int)(((byte)(242)))));
            this.btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnTransfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransfer.Location = new System.Drawing.Point(36, 231);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(289, 53);
            this.btnTransfer.TabIndex = 5;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnWithdrawal
            // 
            this.btnWithdrawal.@__BtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnWithdrawal.@__BtnBackColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnWithdrawal.@__BtnClickAction = null;
            this.btnWithdrawal.@__BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnWithdrawal.@__BtnForeColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnWithdrawal.@__BtnImage = global::BankSystem.Properties.Resources.withdrawal_8813649;
            this.btnWithdrawal.@__BtnText = "Wthdrawal";
            this.btnWithdrawal.@__HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(128)))), ((int)(((byte)(237)))));
            this.btnWithdrawal.@__HoverForColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(204)))), ((int)(((byte)(242)))));
            this.btnWithdrawal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnWithdrawal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWithdrawal.Location = new System.Drawing.Point(36, 132);
            this.btnWithdrawal.Name = "btnWithdrawal";
            this.btnWithdrawal.Size = new System.Drawing.Size(289, 53);
            this.btnWithdrawal.TabIndex = 4;
            this.btnWithdrawal.Click += new System.EventHandler(this.btnWithdrawal_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.@__BtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnDeposit.@__BtnBackColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnDeposit.@__BtnClickAction = null;
            this.btnDeposit.@__BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnDeposit.@__BtnForeColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnDeposit.@__BtnImage = global::BankSystem.Properties.Resources.Deposit_Hm;
            this.btnDeposit.@__BtnText = "Deposit";
            this.btnDeposit.@__HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(128)))), ((int)(((byte)(237)))));
            this.btnDeposit.@__HoverForColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(204)))), ((int)(((byte)(242)))));
            this.btnDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnDeposit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeposit.Location = new System.Drawing.Point(36, 43);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(289, 53);
            this.btnDeposit.TabIndex = 3;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // frmMappTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(362, 338);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnWithdrawal);
            this.Controls.Add(this.btnDeposit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMappTransactions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MappTransactions";
            this.MouseLeave += new System.EventHandler(this.frmMappTransactions_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private SystemSettings.Controls.ctrlCustomBtn btnTransfer;
        private SystemSettings.Controls.ctrlCustomBtn btnWithdrawal;
        private SystemSettings.Controls.ctrlCustomBtn btnDeposit;
    }
}