namespace BankSystem.Reports.UserActivityReport
{
    partial class frmUserReportCard
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
            this.ctrlUserReportCard1 = new BankSystem.Reports.UserActivityReport.ctrlUserReportCard();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlUserReportCard1
            // 
            this.ctrlUserReportCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ctrlUserReportCard1.Location = new System.Drawing.Point(12, 71);
            this.ctrlUserReportCard1.Name = "ctrlUserReportCard1";
            this.ctrlUserReportCard1.Size = new System.Drawing.Size(916, 473);
            this.ctrlUserReportCard1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 23F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(247, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 52);
            this.label2.TabIndex = 62;
            this.label2.Text = "Target Entity Changes";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(427, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 34);
            this.btnClose.TabIndex = 61;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUserReportCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(938, 604);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlUserReportCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserReportCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserReportCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUserReportCard ctrlUserReportCard1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
    }
}