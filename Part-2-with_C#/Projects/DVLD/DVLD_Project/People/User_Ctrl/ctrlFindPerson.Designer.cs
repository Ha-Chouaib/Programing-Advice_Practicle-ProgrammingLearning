namespace DVLD_Project.People.User_Ctrl
{
    partial class ctrlFindPerson
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
            this.ctrlFilterPeople1 = new DVLD_Project.Users.UserControls.ctrlFilterPeople();
            this.ctrlPersonDetails1 = new DVLD_Project.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // ctrlFilterPeople1
            // 
            this.ctrlFilterPeople1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.ctrlFilterPeople1.Location = new System.Drawing.Point(15, 12);
            this.ctrlFilterPeople1.Name = "ctrlFilterPeople1";
            this.ctrlFilterPeople1.Size = new System.Drawing.Size(938, 66);
            this.ctrlFilterPeople1.TabIndex = 0;
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(84, 94);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(801, 347);
            this.ctrlPersonDetails1.TabIndex = 1;
            // 
            // ctrlFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Controls.Add(this.ctrlFilterPeople1);
            this.Name = "ctrlFindPerson";
            this.Size = new System.Drawing.Size(980, 473);
            this.Load += new System.EventHandler(this.ctrlFindPerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Users.UserControls.ctrlFilterPeople ctrlFilterPeople1;
        private ctrlPersonDetails ctrlPersonDetails1;
    }
}
