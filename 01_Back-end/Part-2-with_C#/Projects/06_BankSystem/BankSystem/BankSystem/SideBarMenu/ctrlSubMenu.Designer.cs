namespace BankSystem.SideBarMenu
{
    partial class ctrlSubMenu
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
            this.btnMain = new System.Windows.Forms.Button();
            this.pnlMainBtn = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSubContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pbArrow = new System.Windows.Forms.PictureBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pnlMainBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Segoe UI Semibold", 12.2F, System.Drawing.FontStyle.Bold);
            this.btnMain.ForeColor = System.Drawing.Color.White;
            this.btnMain.Location = new System.Drawing.Point(51, 3);
            this.btnMain.Name = "btnMain";
            this.btnMain.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMain.Size = new System.Drawing.Size(189, 56);
            this.btnMain.TabIndex = 0;
            this.btnMain.Text = "button1";
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            this.btnMain.MouseEnter += new System.EventHandler(this.btnMain_MouseEnter);
            this.btnMain.MouseLeave += new System.EventHandler(this.btnMain_MouseLeave);
            // 
            // pnlMainBtn
            // 
            this.pnlMainBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(115)))), ((int)(((byte)(158)))));
            this.pnlMainBtn.Controls.Add(this.btnMain);
            this.pnlMainBtn.Controls.Add(this.pbArrow);
            this.pnlMainBtn.Controls.Add(this.pbIcon);
            this.pnlMainBtn.Location = new System.Drawing.Point(0, 5);
            this.pnlMainBtn.Name = "pnlMainBtn";
            this.pnlMainBtn.Size = new System.Drawing.Size(303, 64);
            this.pnlMainBtn.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(400, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // pnlSubContainer
            // 
            this.pnlSubContainer.AutoSize = true;
            this.pnlSubContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSubContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSubContainer.Location = new System.Drawing.Point(0, 75);
            this.pnlSubContainer.Name = "pnlSubContainer";
            this.pnlSubContainer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlSubContainer.Size = new System.Drawing.Size(0, 5);
            this.pnlSubContainer.TabIndex = 5;
            this.pnlSubContainer.Visible = false;
            this.pnlSubContainer.WrapContents = false;
            // 
            // pbArrow
            // 
            this.pbArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbArrow.Location = new System.Drawing.Point(246, 5);
            this.pbArrow.Name = "pbArrow";
            this.pbArrow.Size = new System.Drawing.Size(54, 54);
            this.pbArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbArrow.TabIndex = 2;
            this.pbArrow.TabStop = false;
            this.pbArrow.Click += new System.EventHandler(this.pbArrow_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(3, 3);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(45, 54);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 1;
            this.pbIcon.TabStop = false;
            // 
            // ctrlSubMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(149)))), ((int)(((byte)(167)))));
            this.Controls.Add(this.pnlSubContainer);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlMainBtn);
            this.Name = "ctrlSubMenu";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.Size = new System.Drawing.Size(313, 75);
            this.Load += new System.EventHandler(this.ctrlSubMenu_Load);
            this.pnlMainBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbArrow;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Panel pnlMainBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel pnlSubContainer;
    }
}
