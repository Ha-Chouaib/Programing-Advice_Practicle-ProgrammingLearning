namespace WinForm_Exercises
{
    partial class frmCustomControl
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
            this.btnResete = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.myHoverButton2 = new MyCustomControls.MyHoverButton();
            this.clsSmartLabel1 = new MyCustomControls.clsSmartLabel();
            this.SuspendLayout();
            // 
            // btnResete
            // 
            this.btnResete.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResete.Location = new System.Drawing.Point(112, 399);
            this.btnResete.Name = "btnResete";
            this.btnResete.Size = new System.Drawing.Size(219, 34);
            this.btnResete.TabIndex = 1;
            this.btnResete.Text = "Reste Smart Label";
            this.btnResete.UseVisualStyleBackColor = true;
            this.btnResete.Click += new System.EventHandler(this.btnResete_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.Location = new System.Drawing.Point(858, 399);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(300, 34);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "Validate The Smart Label";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // myHoverButton2
            // 
            this.myHoverButton2.Font = new System.Drawing.Font("Comic Sans MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myHoverButton2.Location = new System.Drawing.Point(429, 477);
            this.myHoverButton2.Name = "myHoverButton2";
            this.myHoverButton2.Size = new System.Drawing.Size(345, 62);
            this.myHoverButton2.TabIndex = 3;
            this.myHoverButton2.Text = "my Hover Button";
            this.myHoverButton2.UseVisualStyleBackColor = true;
            this.myHoverButton2.Click += new System.EventHandler(this.myHoverButton2_Click);
            // 
            // clsSmartLabel1
            // 
            this.clsSmartLabel1.AutoSize = true;
            this.clsSmartLabel1.Font = new System.Drawing.Font("Segoe Print", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsSmartLabel1.Location = new System.Drawing.Point(449, 55);
            this.clsSmartLabel1.MinimumSize = new System.Drawing.Size(50, 30);
            this.clsSmartLabel1.Name = "clsSmartLabel1";
            this.clsSmartLabel1.Size = new System.Drawing.Size(275, 43);
            this.clsSmartLabel1.TabIndex = 0;
            this.clsSmartLabel1.Text = "First Custom Control";
            // 
            // frmCustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 579);
            this.Controls.Add(this.myHoverButton2);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnResete);
            this.Controls.Add(this.clsSmartLabel1);
            this.Name = "frmCustomControl";
            this.Text = "frmCustomControl";
            this.Load += new System.EventHandler(this.frmCustomControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCustomControls.clsSmartLabel clsSmartLabel1;
        private System.Windows.Forms.Button btnResete;
        private System.Windows.Forms.Button btnValidate;
        private MyCustomControls.MyHoverButton myHoverButton1;
        private MyCustomControls.MyHoverButton myHoverButton2;
    }
}