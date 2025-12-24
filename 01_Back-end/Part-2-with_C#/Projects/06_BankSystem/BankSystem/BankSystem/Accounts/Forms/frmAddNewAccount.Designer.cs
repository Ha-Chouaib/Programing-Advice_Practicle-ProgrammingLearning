namespace BankSystem.Accounts.Forms
{
    partial class frmAddNewAccount
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
            this.ctrlAddNewAccount1 = new BankSystem.Accounts.UserControls.ctrlAddNewAccount();
            this.SuspendLayout();
            // 
            // ctrlAddNewAccount1
            // 
            this.ctrlAddNewAccount1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ctrlAddNewAccount1.Location = new System.Drawing.Point(12, 12);
            this.ctrlAddNewAccount1.Name = "ctrlAddNewAccount1";
            this.ctrlAddNewAccount1.Size = new System.Drawing.Size(714, 573);
            this.ctrlAddNewAccount1.TabIndex = 0;
            // 
            // frmAddNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(741, 597);
            this.Controls.Add(this.ctrlAddNewAccount1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewAccount";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrlAddNewAccount ctrlAddNewAccount1;
    }
}