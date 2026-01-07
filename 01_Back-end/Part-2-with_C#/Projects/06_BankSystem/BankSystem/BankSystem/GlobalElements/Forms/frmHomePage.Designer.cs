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
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.pnlSubMain = new System.Windows.Forms.Panel();
            this.pnlMainContainer.SuspendLayout();
            this.pnlSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlSideBarMenu1
            // 
            this.ctrlSideBarMenu1.AutoSize = true;
            this.ctrlSideBarMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ctrlSideBarMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSideBarMenu1.Location = new System.Drawing.Point(0, 0);
            this.ctrlSideBarMenu1.MenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ctrlSideBarMenu1.Name = "ctrlSideBarMenu1";
            this.ctrlSideBarMenu1.Size = new System.Drawing.Size(417, 658);
            this.ctrlSideBarMenu1.TabIndex = 2;
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.pnlSubMain);
            this.pnlMainContainer.Controls.Add(this.pnlSideBar);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 89);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1420, 658);
            this.pnlMainContainer.TabIndex = 3;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.Controls.Add(this.ctrlSideBarMenu1);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(417, 658);
            this.pnlSideBar.TabIndex = 3;
            // 
            // pnlSubMain
            // 
            this.pnlSubMain.BackColor = System.Drawing.Color.Black;
            this.pnlSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubMain.Location = new System.Drawing.Point(417, 0);
            this.pnlSubMain.Name = "pnlSubMain";
            this.pnlSubMain.Size = new System.Drawing.Size(1003, 658);
            this.pnlSubMain.TabIndex = 4;
            // 
            // frmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 789);
            this.Controls.Add(this.pnlMainContainer);
            this.Name = "frmHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHomePage";
            this.Load += new System.EventHandler(this.frmHomePage_Load);
            this.Controls.SetChildIndex(this.pnlMainContainer, 0);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlSideBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SideBarMenu.ctrlSideBarMenu ctrlSideBarMenu1;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlSubMain;
    }
}