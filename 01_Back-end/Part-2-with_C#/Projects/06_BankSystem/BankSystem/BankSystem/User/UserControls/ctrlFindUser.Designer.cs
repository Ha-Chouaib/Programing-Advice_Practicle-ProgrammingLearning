namespace BankSystem.User.UserControls
{
    partial class ctrlFindUser
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
            this.ctrlUserCard1 = new BankSystem.User.UserControls.ctrlUserCard();
            this.SuspendLayout();
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(14, 14);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 40);
            this.ctrlFind1.TabIndex = 0;
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlUserCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlUserCard1.Location = new System.Drawing.Point(27, 60);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(599, 455);
            this.ctrlUserCard1.TabIndex = 1;
            // 
            // ctrlFindUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.ctrlUserCard1);
            this.Controls.Add(this.ctrlFind1);
            this.Name = "ctrlFindUser";
            this.Size = new System.Drawing.Size(647, 533);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlFind ctrlFind1;
        private ctrlUserCard ctrlUserCard1;
    }
}
