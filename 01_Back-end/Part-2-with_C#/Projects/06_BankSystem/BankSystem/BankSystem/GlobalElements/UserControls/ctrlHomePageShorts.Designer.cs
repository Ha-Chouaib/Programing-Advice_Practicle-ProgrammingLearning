namespace BankSystem.GlobalElements.UserControls
{
    partial class ctrlHomePageShorts
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
            System.Windows.Forms.Button btnFindCustomer;
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnAddNewAccount = new System.Windows.Forms.Button();
            this.btnFindAccount = new System.Windows.Forms.Button();
            btnFindCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransactions
            // 
            this.btnTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.ForeColor = System.Drawing.Color.Cyan;
            this.btnTransactions.Location = new System.Drawing.Point(95, 70);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(327, 55);
            this.btnTransactions.TabIndex = 0;
            this.btnTransactions.Text = "Make a Transaction";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnFindCustomer
            // 
            btnFindCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFindCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFindCustomer.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnFindCustomer.ForeColor = System.Drawing.Color.Cyan;
            btnFindCustomer.Location = new System.Drawing.Point(95, 164);
            btnFindCustomer.Name = "btnFindCustomer";
            btnFindCustomer.Size = new System.Drawing.Size(327, 55);
            btnFindCustomer.TabIndex = 1;
            btnFindCustomer.Text = "Find Customer";
            btnFindCustomer.UseVisualStyleBackColor = true;
            btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // btnAddNewAccount
            // 
            this.btnAddNewAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAccount.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewAccount.ForeColor = System.Drawing.Color.Cyan;
            this.btnAddNewAccount.Location = new System.Drawing.Point(475, 164);
            this.btnAddNewAccount.Name = "btnAddNewAccount";
            this.btnAddNewAccount.Size = new System.Drawing.Size(327, 55);
            this.btnAddNewAccount.TabIndex = 2;
            this.btnAddNewAccount.Text = "Add New Account";
            this.btnAddNewAccount.UseVisualStyleBackColor = true;
            this.btnAddNewAccount.Click += new System.EventHandler(this.btnAddNewAccount_Click);
            // 
            // btnFindAccount
            // 
            this.btnFindAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindAccount.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindAccount.ForeColor = System.Drawing.Color.Cyan;
            this.btnFindAccount.Location = new System.Drawing.Point(475, 70);
            this.btnFindAccount.Name = "btnFindAccount";
            this.btnFindAccount.Size = new System.Drawing.Size(327, 55);
            this.btnFindAccount.TabIndex = 3;
            this.btnFindAccount.Text = "Find Account";
            this.btnFindAccount.UseVisualStyleBackColor = true;
            this.btnFindAccount.Click += new System.EventHandler(this.btnFindAccount_Click);
            // 
            // ctrlHomePageShorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.Controls.Add(this.btnFindAccount);
            this.Controls.Add(this.btnAddNewAccount);
            this.Controls.Add(btnFindCustomer);
            this.Controls.Add(this.btnTransactions);
            this.Name = "ctrlHomePageShorts";
            this.Size = new System.Drawing.Size(903, 298);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnAddNewAccount;
        private System.Windows.Forms.Button btnFindAccount;
    }
}
