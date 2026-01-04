namespace BankSystem.User.Forms
{
    partial class frmAddNewUser
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
            this.ctrlAddEditUser1 = new BankSystem.User.UserControls.ctrlAddEditUser();
            this.SuspendLayout();
            // 
            // ctrlAddEditUser1
            // 
            this.ctrlAddEditUser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlAddEditUser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAddEditUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditUser1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditUser1.Name = "ctrlAddEditUser1";
            this.ctrlAddEditUser1.Size = new System.Drawing.Size(1188, 799);
            this.ctrlAddEditUser1.TabIndex = 0;
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1188, 799);
            this.Controls.Add(this.ctrlAddEditUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewUser";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ctrlAddEditUser ctrlAddEditUser1;
    }
}