namespace _01_FirstWinFormsPro
{
    partial class MessageBoxForm
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
            this.btnMSGBoxClose = new System.Windows.Forms.Button();
            this.btnShowMSGBox = new System.Windows.Forms.Button();
            this.btnMSGwithCanlcelBtn = new System.Windows.Forms.Button();
            this.MSG_Icons = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMSGBoxClose
            // 
            this.btnMSGBoxClose.BackColor = System.Drawing.Color.Red;
            this.btnMSGBoxClose.Location = new System.Drawing.Point(680, 12);
            this.btnMSGBoxClose.Name = "btnMSGBoxClose";
            this.btnMSGBoxClose.Size = new System.Drawing.Size(108, 34);
            this.btnMSGBoxClose.TabIndex = 0;
            this.btnMSGBoxClose.Text = "Close";
            this.btnMSGBoxClose.UseVisualStyleBackColor = false;
            this.btnMSGBoxClose.Click += new System.EventHandler(this.btnMSGBoxClose_Click);
            // 
            // btnShowMSGBox
            // 
            this.btnShowMSGBox.Location = new System.Drawing.Point(332, 48);
            this.btnShowMSGBox.Name = "btnShowMSGBox";
            this.btnShowMSGBox.Size = new System.Drawing.Size(108, 51);
            this.btnShowMSGBox.TabIndex = 1;
            this.btnShowMSGBox.Text = "DisplayMsgBox";
            this.btnShowMSGBox.UseVisualStyleBackColor = true;
            this.btnShowMSGBox.Click += new System.EventHandler(this.btnShowMSGBox_Click);
            // 
            // btnMSGwithCanlcelBtn
            // 
            this.btnMSGwithCanlcelBtn.Location = new System.Drawing.Point(320, 117);
            this.btnMSGwithCanlcelBtn.Name = "btnMSGwithCanlcelBtn";
            this.btnMSGwithCanlcelBtn.Size = new System.Drawing.Size(132, 41);
            this.btnMSGwithCanlcelBtn.TabIndex = 2;
            this.btnMSGwithCanlcelBtn.Text = "ShowMSG_CancelBtn";
            this.btnMSGwithCanlcelBtn.UseVisualStyleBackColor = true;
            this.btnMSGwithCanlcelBtn.Click += new System.EventHandler(this.btnMSGwithCanlcelBtn_Click);
            // 
            // MSG_Icons
            // 
            this.MSG_Icons.Location = new System.Drawing.Point(320, 164);
            this.MSG_Icons.Name = "MSG_Icons";
            this.MSG_Icons.Size = new System.Drawing.Size(132, 41);
            this.MSG_Icons.TabIndex = 3;
            this.MSG_Icons.Text = "ShowMSG_Icons";
            this.MSG_Icons.UseVisualStyleBackColor = true;
            this.MSG_Icons.Click += new System.EventHandler(this.MSG_Icons_Click);
            // 
            // MessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MSG_Icons);
            this.Controls.Add(this.btnMSGwithCanlcelBtn);
            this.Controls.Add(this.btnShowMSGBox);
            this.Controls.Add(this.btnMSGBoxClose);
            this.Name = "MessageBoxForm";
            this.Text = "MessageBoxForm";
            this.Load += new System.EventHandler(this.MessageBoxForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMSGBoxClose;
        private System.Windows.Forms.Button btnShowMSGBox;
        private System.Windows.Forms.Button btnMSGwithCanlcelBtn;
        private System.Windows.Forms.Button MSG_Icons;
    }
}