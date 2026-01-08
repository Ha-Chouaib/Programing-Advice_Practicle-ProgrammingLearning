namespace BankSystem.SideBarMenu
{
    partial class ctrlSideBarMenu
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
            this.fpnlSideBarContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // fpnlSideBarContainer
            // 
            this.fpnlSideBarContainer.AutoScroll = true;
            this.fpnlSideBarContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fpnlSideBarContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlSideBarContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlSideBarContainer.Location = new System.Drawing.Point(0, 0);
            this.fpnlSideBarContainer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.fpnlSideBarContainer.Name = "fpnlSideBarContainer";
            this.fpnlSideBarContainer.Size = new System.Drawing.Size(331, 548);
            this.fpnlSideBarContainer.TabIndex = 0;
            this.fpnlSideBarContainer.WrapContents = false;
            // 
            // ctrlSideBarMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.fpnlSideBarContainer);
            this.Name = "ctrlSideBarMenu";
            this.Size = new System.Drawing.Size(331, 548);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpnlSideBarContainer;
    }
}
