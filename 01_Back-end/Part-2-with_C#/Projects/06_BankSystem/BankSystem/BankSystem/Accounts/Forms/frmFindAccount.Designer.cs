namespace BankSystem.Accounts.Forms
{
    partial class frmFindAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAccountCard1 = new BankSystem.Accounts.UserControls.ctrlAccountCard();
            this.ctrlFind1 = new BankSystem.ctrlFind();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(220, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find Account";
            // 
            // ctrlAccountCard1
            // 
            this.ctrlAccountCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlAccountCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountCard1.Location = new System.Drawing.Point(12, 137);
            this.ctrlAccountCard1.Name = "ctrlAccountCard1";
            this.ctrlAccountCard1.Size = new System.Drawing.Size(723, 496);
            this.ctrlAccountCard1.TabIndex = 1;
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(57, 91);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(623, 40);
            this.ctrlFind1.TabIndex = 0;
            // 
            // frmFindAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(747, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlAccountCard1);
            this.Controls.Add(this.ctrlFind1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFindAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlFind ctrlFind1;
        private UserControls.ctrlAccountCard ctrlAccountCard1;
        private System.Windows.Forms.Label label1;
    }
}