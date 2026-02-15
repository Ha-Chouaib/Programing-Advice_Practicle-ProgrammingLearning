namespace BankSystem.Reports.UserReport
{
    partial class frmManageUserReports
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
            this.ctrlManageRecords1 = new BankSystem.ctrlManageRecords();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlManageRecords1
            // 
            this.ctrlManageRecords1.@__AvailablePages = ((short)(0));
            this.ctrlManageRecords1.@__PageNumber = ((byte)(1));
            this.ctrlManageRecords1.@__PageSize = ((byte)(3));
            this.ctrlManageRecords1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlManageRecords1.Location = new System.Drawing.Point(12, 78);
            this.ctrlManageRecords1.Name = "ctrlManageRecords1";
            this.ctrlManageRecords1.Size = new System.Drawing.Size(1586, 810);
            this.ctrlManageRecords1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(641, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage User Reports";
            // 
            // frmManageUserReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1620, 901);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlManageRecords1);
            this.Name = "frmManageUserReports";
            this.Text = "Manage User Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlManageRecords ctrlManageRecords1;
        private System.Windows.Forms.Label label1;
    }
}