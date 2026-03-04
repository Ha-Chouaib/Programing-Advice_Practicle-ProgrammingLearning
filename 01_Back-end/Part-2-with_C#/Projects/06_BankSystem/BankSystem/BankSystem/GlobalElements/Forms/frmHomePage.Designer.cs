using System.Windows.Forms;

namespace BankSystem
{
    partial class frmHomePage : Form
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
            this.components = new System.ComponentModel.Container();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlSubMain = new System.Windows.Forms.Panel();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblClok = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTopRight = new System.Windows.Forms.Panel();
            this.btnAccountSettings = new BankSystem.SystemSettings.Controls.ctrlCustomBtn();
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.pbBankIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.ctrlSideBarMenu2 = new BankSystem.SideBarMenu.ctrlSideBarMenu();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMainContainer.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTopRight.SuspendLayout();
            this.pnlTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBankIcon)).BeginInit();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
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
            // pnlSubMain
            // 
            this.pnlSubMain.BackColor = System.Drawing.Color.Black;
            this.pnlSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubMain.Location = new System.Drawing.Point(417, 0);
            this.pnlSubMain.Name = "pnlSubMain";
            this.pnlSubMain.Size = new System.Drawing.Size(1003, 658);
            this.pnlSubMain.TabIndex = 4;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(417, 658);
            this.pnlSideBar.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.pnlFooter.Controls.Add(this.lblClok);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFooter.ForeColor = System.Drawing.Color.Cyan;
            this.pnlFooter.Location = new System.Drawing.Point(0, 881);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1659, 63);
            this.pnlFooter.TabIndex = 5;
            // 
            // lblClok
            // 
            this.lblClok.AutoSize = true;
            this.lblClok.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClok.Location = new System.Drawing.Point(12, 15);
            this.lblClok.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClok.Name = "lblClok";
            this.lblClok.Size = new System.Drawing.Size(172, 23);
            this.lblClok.TabIndex = 0;
            this.lblClok.Text = "30/010/2025 12:00:00";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.pnlHeader.Controls.Add(this.pnlTopRight);
            this.pnlHeader.Controls.Add(this.pnlTopLeft);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1659, 101);
            this.pnlHeader.TabIndex = 4;
            // 
            // pnlTopRight
            // 
            this.pnlTopRight.Controls.Add(this.btnAccountSettings);
            this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTopRight.Location = new System.Drawing.Point(446, 0);
            this.pnlTopRight.Name = "pnlTopRight";
            this.pnlTopRight.Size = new System.Drawing.Size(1213, 101);
            this.pnlTopRight.TabIndex = 2;
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.@__BtnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btnAccountSettings.@__BtnBackColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btnAccountSettings.@__BtnClickAction = null;
            this.btnAccountSettings.@__BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnAccountSettings.@__BtnForeColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnAccountSettings.@__BtnImage = null;
            this.btnAccountSettings.@__BtnText = "Account Settings";
            this.btnAccountSettings.@__HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(128)))), ((int)(((byte)(237)))));
            this.btnAccountSettings.@__HoverForColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(204)))), ((int)(((byte)(242)))));
            this.btnAccountSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(56)))));
            this.btnAccountSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountSettings.Location = new System.Drawing.Point(898, 26);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(289, 53);
            this.btnAccountSettings.TabIndex = 1;
            this.btnAccountSettings.Click += new System.EventHandler(this.btnAccountSettings_Click_1);
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.pbBankIcon);
            this.pnlTopLeft.Controls.Add(this.lblHeaderTitle);
            this.pnlTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(440, 101);
            this.pnlTopLeft.TabIndex = 2;
            // 
            // pbBankIcon
            // 
            this.pbBankIcon.Image = global::BankSystem.Properties.Resources.bank;
            this.pbBankIcon.Location = new System.Drawing.Point(4, 13);
            this.pbBankIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pbBankIcon.Name = "pbBankIcon";
            this.pbBankIcon.Size = new System.Drawing.Size(96, 62);
            this.pbBankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBankIcon.TabIndex = 2;
            this.pbBankIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(108, 26);
            this.lblHeaderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(328, 35);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Bank Managment System";
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.pnlSide.Controls.Add(this.ctrlSideBarMenu2);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 101);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(440, 780);
            this.pnlSide.TabIndex = 6;
            // 
            // ctrlSideBarMenu2
            // 
            this.ctrlSideBarMenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.ctrlSideBarMenu2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlSideBarMenu2.Location = new System.Drawing.Point(0, 0);
            this.ctrlSideBarMenu2.MenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.ctrlSideBarMenu2.Name = "ctrlSideBarMenu2";
            this.ctrlSideBarMenu2.Size = new System.Drawing.Size(440, 780);
            this.ctrlSideBarMenu2.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(440, 101);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1219, 780);
            this.pnlMain.TabIndex = 7;
            // 
            // frmHomePage
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1659, 944);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHomePage_FormClosing);
            this.Load += new System.EventHandler(this.frmHomePage_Load_1);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlTopRight.ResumeLayout(false);
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBankIcon)).EndInit();
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlSubMain;
        private Panel pnlFooter;
        private Label lblClok;
        private Panel pnlHeader;
        private Panel pnlTopRight;
        private Panel pnlTopLeft;
        private PictureBox pbBankIcon;
        private Label lblHeaderTitle;
        private Panel pnlSide;
        private SideBarMenu.ctrlSideBarMenu ctrlSideBarMenu2;
        private Panel pnlMain;
        private SystemSettings.Controls.ctrlCustomBtn btnAccountSettings;
        private Timer timer1;
    }
}