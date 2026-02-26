namespace BankSystem.Roles.Forms
{
    partial class frmRoleCard
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlRoleCard1 = new BankSystem.Roles.ctrlRoleCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(208, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 54);
            this.label2.TabIndex = 2;
            this.label2.Text = "Role Card";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(268, 809);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 36);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlRoleCard1
            // 
            this.ctrlRoleCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ctrlRoleCard1.Location = new System.Drawing.Point(12, 82);
            this.ctrlRoleCard1.Name = "ctrlRoleCard1";
            this.ctrlRoleCard1.Size = new System.Drawing.Size(639, 739);
            this.ctrlRoleCard1.TabIndex = 0;
            // 
            // frmRoleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(661, 857);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlRoleCard1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRoleCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRoleCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlRoleCard ctrlRoleCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
    }
}