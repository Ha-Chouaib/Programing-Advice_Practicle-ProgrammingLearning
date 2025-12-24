namespace BankSystem.User.UserControls
{
    partial class ctrlAddEditUser
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
            this.ctrlCheckedComboBox1 = new BankSystem.User.UserControls.CheckedComboBox.ctrlCheckedComboBox();
            this.SuspendLayout();
            // 
            // ctrlCheckedComboBox1
            // 
            this.ctrlCheckedComboBox1.Location = new System.Drawing.Point(450, 147);
            this.ctrlCheckedComboBox1.Name = "ctrlCheckedComboBox1";
            this.ctrlCheckedComboBox1.Size = new System.Drawing.Size(292, 47);
            this.ctrlCheckedComboBox1.TabIndex = 0;
            // 
            // ctrlAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlCheckedComboBox1);
            this.Name = "ctrlAddEditUser";
            this.Size = new System.Drawing.Size(761, 215);
            this.Load += new System.EventHandler(this.ctrlAddEditUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedComboBox.ctrlCheckedComboBox ctrlCheckedComboBox1;
    }
}
