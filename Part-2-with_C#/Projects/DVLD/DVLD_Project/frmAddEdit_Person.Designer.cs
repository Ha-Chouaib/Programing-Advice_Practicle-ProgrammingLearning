namespace DVLD_Project
{
    partial class frmAddEdit_Person
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
            this.ctrlAdd_Edit_PersonIfo1 = new DVLD_Project.ctrlAdd_Edit_PersonIfo();
            this.SuspendLayout();
            // 
            // ctrlAdd_Edit_PersonIfo1
            // 
            this.ctrlAdd_Edit_PersonIfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ctrlAdd_Edit_PersonIfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ctrlAdd_Edit_PersonIfo1.Location = new System.Drawing.Point(30, 91);
            this.ctrlAdd_Edit_PersonIfo1.Name = "ctrlAdd_Edit_PersonIfo1";
            this.ctrlAdd_Edit_PersonIfo1.Size = new System.Drawing.Size(947, 397);
            this.ctrlAdd_Edit_PersonIfo1.TabIndex = 0;
            // 
            // frmAddEdit_Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 514);
            this.Controls.Add(this.ctrlAdd_Edit_PersonIfo1);
            this.Name = "frmAddEdit_Person";
            this.Text = "frmAddEdit_Person";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAdd_Edit_PersonIfo ctrlAdd_Edit_PersonIfo1;
    }
}