namespace _07_Menus
{
    partial class frmContexMenu
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmFormat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmForeColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClear = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.cmFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.cmFormat;
            this.textBox1.Location = new System.Drawing.Point(53, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.ContextMenuStrip = this.cmFormat;
            this.textBox2.Location = new System.Drawing.Point(53, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(203, 20);
            this.textBox2.TabIndex = 1;
            // 
            // cmFormat
            // 
            this.cmFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFont,
            this.tsmForeColor,
            this.tsmBackColor,
            this.tsmClear});
            this.cmFormat.Name = "cmFormat";
            this.cmFormat.Size = new System.Drawing.Size(174, 92);
            this.cmFormat.Text = "Format";
            // 
            // tsmFont
            // 
            this.tsmFont.Name = "tsmFont";
            this.tsmFont.Size = new System.Drawing.Size(180, 22);
            this.tsmFont.Text = "Change Font";
            this.tsmFont.Click += new System.EventHandler(this.tsmFont_Click);
            // 
            // tsmForeColor
            // 
            this.tsmForeColor.Name = "tsmForeColor";
            this.tsmForeColor.Size = new System.Drawing.Size(180, 22);
            this.tsmForeColor.Text = "Change Fore Color";
            this.tsmForeColor.Click += new System.EventHandler(this.tsmForeColor_Click);
            // 
            // tsmBackColor
            // 
            this.tsmBackColor.Name = "tsmBackColor";
            this.tsmBackColor.Size = new System.Drawing.Size(180, 22);
            this.tsmBackColor.Text = "Chage Back Color";
            this.tsmBackColor.Click += new System.EventHandler(this.tsmBackColor_Click);
            // 
            // tsmClear
            // 
            this.tsmClear.Name = "tsmClear";
            this.tsmClear.Size = new System.Drawing.Size(180, 22);
            this.tsmClear.Text = "Clear";
            this.tsmClear.Click += new System.EventHandler(this.tsmClear_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // frmContexMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "frmContexMenu";
            this.Text = "frmContexMenu";
            this.cmFormat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ContextMenuStrip cmFormat;
        private System.Windows.Forms.ToolStripMenuItem tsmFont;
        private System.Windows.Forms.ToolStripMenuItem tsmForeColor;
        private System.Windows.Forms.ToolStripMenuItem tsmBackColor;
        private System.Windows.Forms.ToolStripMenuItem tsmClear;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}