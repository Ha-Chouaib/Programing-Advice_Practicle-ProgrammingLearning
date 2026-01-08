namespace BankSystem.Customer.UserControls
{
    partial class ctrlFindCustomer
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
            this.ctrlCustomerCard1 = new BankSystem.Customer.UserControls.ctrlCustomerCard();
            this.SuspendLayout();
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(25, 12);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 40);
            this.ctrlFind1.TabIndex = 0;
            // 
            // ctrlCustomerCard1
            // 
            this.ctrlCustomerCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlCustomerCard1.Location = new System.Drawing.Point(3, 58);
            this.ctrlCustomerCard1.Name = "ctrlCustomerCard1";
            this.ctrlCustomerCard1.Size = new System.Drawing.Size(664, 442);
            this.ctrlCustomerCard1.TabIndex = 1;
            // 
            // ctrlFindCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctrlCustomerCard1);
            this.Controls.Add(this.ctrlFind1);
            this.Name = "ctrlFindCustomer";
            this.Size = new System.Drawing.Size(674, 512);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlFind ctrlFind1;
        private ctrlCustomerCard ctrlCustomerCard1;
    }
}
