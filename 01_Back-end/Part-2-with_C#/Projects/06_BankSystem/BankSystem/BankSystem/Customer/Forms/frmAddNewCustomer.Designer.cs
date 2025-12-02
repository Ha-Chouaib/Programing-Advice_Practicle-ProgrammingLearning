namespace BankSystem.Customer.Forms
{
    partial class frmAddNewCustomer
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
            this.ctrlAddEditCustomer1 = new BankSystem.Customer.UserControls.ctrlAddEditCustomer();
            this.SuspendLayout();
            // 
            // ctrlAddEditCustomer1
            // 
            this.ctrlAddEditCustomer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.ctrlAddEditCustomer1.Location = new System.Drawing.Point(22, 28);
            this.ctrlAddEditCustomer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlAddEditCustomer1.Name = "ctrlAddEditCustomer1";
            this.ctrlAddEditCustomer1.Size = new System.Drawing.Size(1089, 857);
            this.ctrlAddEditCustomer1.TabIndex = 0;
            // 
            // frmAddNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1147, 916);
            this.Controls.Add(this.ctrlAddEditCustomer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewCustomer";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrlAddEditCustomer ctrlAddEditCustomer1;
    }
}