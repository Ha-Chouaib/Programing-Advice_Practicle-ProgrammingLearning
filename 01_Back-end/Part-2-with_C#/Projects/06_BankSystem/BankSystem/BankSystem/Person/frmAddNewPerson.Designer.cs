namespace BankSystem.Person
{
    partial class frmAddNewPerson
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
            this.ctrlAddEditPerson1 = new BankSystem.Person.ctrlAddEditPerson();
            this.SuspendLayout();
            // 
            // ctrlAddEditPerson1
            // 
            this.ctrlAddEditPerson1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ctrlAddEditPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlAddEditPerson1.Location = new System.Drawing.Point(13, 13);
            this.ctrlAddEditPerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlAddEditPerson1.Name = "ctrlAddEditPerson1";
            this.ctrlAddEditPerson1.Size = new System.Drawing.Size(571, 726);
            this.ctrlAddEditPerson1.TabIndex = 0;
            // 
            // frmAddNewPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 749);
            this.Controls.Add(this.ctrlAddEditPerson1);
            this.Name = "frmAddNewPerson";
            this.Text = "Add New Person";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAddEditPerson ctrlAddEditPerson1;
    }
}