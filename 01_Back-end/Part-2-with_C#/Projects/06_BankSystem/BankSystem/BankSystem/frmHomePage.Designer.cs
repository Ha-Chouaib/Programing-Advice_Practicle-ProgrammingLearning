namespace BankSystem
{
    partial class frmHomePage : frmBaseForm
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
            this.ctrlSideBarMenu1 = new BankSystem.SideBarMenu.ctrlSideBarMenu();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlSideBarMenu1
            // 
            this.ctrlSideBarMenu1.AutoSize = true;
            this.ctrlSideBarMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ctrlSideBarMenu1.Location = new System.Drawing.Point(3, 3);
            this.ctrlSideBarMenu1.MenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ctrlSideBarMenu1.Name = "ctrlSideBarMenu1";
            this.ctrlSideBarMenu1.Size = new System.Drawing.Size(358, 569);
            this.ctrlSideBarMenu1.TabIndex = 2;
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.ctrlSideBarMenu1);
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 96);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1276, 581);
            this.pnlMainContainer.TabIndex = 3;
            // 
            // frmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 717);
            this.Controls.Add(this.pnlMainContainer);
            this.Name = "frmHomePage";
            this.Text = "frmHomePage";
            this.Load += new System.EventHandler(this.frmHomePage_Load);
            this.Controls.SetChildIndex(this.pnlMainContainer, 0);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SideBarMenu.ctrlSideBarMenu ctrlSideBarMenu1;
        private System.Windows.Forms.Panel pnlMainContainer;
    }
}