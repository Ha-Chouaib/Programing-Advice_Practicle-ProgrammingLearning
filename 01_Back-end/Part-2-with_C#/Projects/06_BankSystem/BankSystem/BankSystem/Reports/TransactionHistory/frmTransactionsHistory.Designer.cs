namespace BankSystem.Reports.Forms
{
    partial class frmTransactionsHistory
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
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlManageRecords1 = new BankSystem.ctrlManageRecords();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 24.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(204)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(630, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 55);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transactions History";
            // 
            // ctrlManageRecords1
            // 
            this.ctrlManageRecords1.@__AvailablePages = ((short)(0));
            this.ctrlManageRecords1.@__PageNumber = ((byte)(1));
            this.ctrlManageRecords1.@__PageSize = ((byte)(50));
            this.ctrlManageRecords1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.ctrlManageRecords1.Location = new System.Drawing.Point(12, 67);
            this.ctrlManageRecords1.Name = "ctrlManageRecords1";
            this.ctrlManageRecords1.Size = new System.Drawing.Size(1602, 810);
            this.ctrlManageRecords1.TabIndex = 3;
            // 
            // frmTransactionsHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1632, 884);
            this.Controls.Add(this.ctrlManageRecords1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTransactionsHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransactionsHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private ctrlManageRecords ctrlManageRecords1;
    }
}