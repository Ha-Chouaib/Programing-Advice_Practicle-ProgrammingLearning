namespace BankSystem.Person
{
    partial class frmEditPerson
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
            this.ctrlFind1 = new BankSystem.ctrlFind();
            this.ctrlAddEditPerson1 = new BankSystem.Person.ctrlAddEditPerson();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(521, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find a Person";
            // 
            // ctrlFind1
            // 
            this.ctrlFind1.Location = new System.Drawing.Point(12, 56);
            this.ctrlFind1.Name = "ctrlFind1";
            this.ctrlFind1.Size = new System.Drawing.Size(625, 40);
            this.ctrlFind1.TabIndex = 1;
            // 
            // ctrlAddEditPerson1
            // 
            this.ctrlAddEditPerson1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlAddEditPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAddEditPerson1.Location = new System.Drawing.Point(28, 103);
            this.ctrlAddEditPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlAddEditPerson1.Name = "ctrlAddEditPerson1";
            this.ctrlAddEditPerson1.Size = new System.Drawing.Size(580, 726);
            this.ctrlAddEditPerson1.TabIndex = 0;
            // 
            // frmEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(643, 846);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlFind1);
            this.Controls.Add(this.ctrlAddEditPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAddEditPerson ctrlAddEditPerson1;
        private ctrlFind ctrlFind1;
        private System.Windows.Forms.Label label1;
    }
}