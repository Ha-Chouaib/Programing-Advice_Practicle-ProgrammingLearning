namespace BankSystem.Currencies.Controls
{
    partial class ctrlFindCurrency
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
            this.ctrlCurrencyCard1 = new BankSystem.Currencies.Controls.ctrlCurrencyCard();
            this.SuspendLayout();
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(29, 29);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 40);
            this.ctrlFind1.TabIndex = 0;
            // 
            // ctrlCurrencyCard1
            // 
            this.ctrlCurrencyCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ctrlCurrencyCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCurrencyCard1.Location = new System.Drawing.Point(55, 93);
            this.ctrlCurrencyCard1.Name = "ctrlCurrencyCard1";
            this.ctrlCurrencyCard1.Size = new System.Drawing.Size(553, 285);
            this.ctrlCurrencyCard1.TabIndex = 1;
            // 
            // ctrlFindCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.ctrlCurrencyCard1);
            this.Controls.Add(this.ctrlFind1);
            this.Name = "ctrlFindCurrency";
            this.Size = new System.Drawing.Size(666, 442);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlFind ctrlFind1;
        private ctrlCurrencyCard ctrlCurrencyCard1;
    }
}
