namespace BankSystem.Roles.Forms
{
    partial class frmEditRole
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
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlAddEditRole1 = new BankSystem.Roles.ctrlAddEditRole();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(219, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 68);
            this.label2.TabIndex = 5;
            this.label2.Text = "Edit Role";
            // 
            // ctrlAddEditRole1
            // 
            this.ctrlAddEditRole1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ctrlAddEditRole1.Location = new System.Drawing.Point(6, 108);
            this.ctrlAddEditRole1.Name = "ctrlAddEditRole1";
            this.ctrlAddEditRole1.Size = new System.Drawing.Size(635, 689);
            this.ctrlAddEditRole1.TabIndex = 4;
            // 
            // frmEditRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(655, 799);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlAddEditRole1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditRole";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private ctrlAddEditRole ctrlAddEditRole1;
    }
}