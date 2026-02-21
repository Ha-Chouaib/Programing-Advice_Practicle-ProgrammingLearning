namespace BankSystem.Accounts.UserControls
{
    partial class ctrlFindAccount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlFind1 = new BankSystem.ctrlFind();
            this.ctrlAccountCard1 = new BankSystem.Accounts.UserControls.ctrlAccountCard();
            this.SuspendLayout();
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(47, 14);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 40);
            this.ctrlFind1.TabIndex = 0;
            // 
            // ctrlAccountCard1
            // 
            this.ctrlAccountCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ctrlAccountCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAccountCard1.Location = new System.Drawing.Point(3, 80);
            this.ctrlAccountCard1.Name = "ctrlAccountCard1";
            this.ctrlAccountCard1.Size = new System.Drawing.Size(721, 430);
            this.ctrlAccountCard1.TabIndex = 1;
            // 
            // ctrlFindAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.ctrlAccountCard1);
            this.Controls.Add(this.ctrlFind1);
            this.Name = "ctrlFindAccount";
            this.Size = new System.Drawing.Size(725, 512);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlFind ctrlFind1;
        private ctrlAccountCard ctrlAccountCard1;
    }
}
