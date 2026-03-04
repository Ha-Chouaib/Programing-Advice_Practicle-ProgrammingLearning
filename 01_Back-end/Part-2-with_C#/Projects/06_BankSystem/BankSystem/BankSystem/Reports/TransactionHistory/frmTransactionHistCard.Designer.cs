namespace BankSystem.Reports.TransactionHistory
{
    partial class frmTransactionHistCard
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
            this.ctrlTranactionsHistCard1 = new BankSystem.Reports.TransactionHistory.ctrlTranactionsHistCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlTranactionsHistCard1
            // 
            this.ctrlTranactionsHistCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ctrlTranactionsHistCard1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlTranactionsHistCard1.Location = new System.Drawing.Point(13, 13);
            this.ctrlTranactionsHistCard1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTranactionsHistCard1.Name = "ctrlTranactionsHistCard1";
            this.ctrlTranactionsHistCard1.Size = new System.Drawing.Size(962, 448);
            this.ctrlTranactionsHistCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(461, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmTransactionHistCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(986, 512);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlTranactionsHistCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTransactionHistCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction History Card";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTranactionsHistCard ctrlTranactionsHistCard1;
        private System.Windows.Forms.Button btnClose;
    }
}