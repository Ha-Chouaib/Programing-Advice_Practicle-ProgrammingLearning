namespace BankSystem.Person
{
    partial class frmManagePeople
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
            this.ctrlManageRecords1.@__PageSize = ((byte)(50));
            this.ctrlManageRecords1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlManageRecords1.Location = new System.Drawing.Point(12, 92);
            this.ctrlManageRecords1.Name = "ctrlManageRecords1";
            this.ctrlManageRecords1.Size = new System.Drawing.Size(1602, 810);
            this.ctrlManageRecords1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(667, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1627, 896);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlManageRecords1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlManageRecords ctrlManageRecords1;
        private System.Windows.Forms.Label label1;
    }
}