namespace BankSystem.Person.Forms
{
    partial class frmFindPerson
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
            this.ctrlFind1 = new BankSystem.ctrlFind();
            this.ctrlDisplayPersonDetails1 = new BankSystem.Person.UserControls.ctrlDisplayPersonDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(218, 93);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 40);
            this.ctrlFind1.TabIndex = 0;
            // 
            // ctrlDisplayPersonDetails1
            // 
            this.ctrlDisplayPersonDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlDisplayPersonDetails1.Location = new System.Drawing.Point(12, 155);
            this.ctrlDisplayPersonDetails1.Name = "ctrlDisplayPersonDetails1";
            this.ctrlDisplayPersonDetails1.Size = new System.Drawing.Size(1082, 440);
            this.ctrlDisplayPersonDetails1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(416, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find Person";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(501, 612);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1105, 664);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDisplayPersonDetails1);
            this.Controls.Add(this.ctrlFind1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFindPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlFind ctrlFind1;
        private UserControls.ctrlDisplayPersonDetails ctrlDisplayPersonDetails1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}