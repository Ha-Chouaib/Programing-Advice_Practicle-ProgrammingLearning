namespace _01_FirstWinFormsPro
{
    partial class frmProgressBar
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIcreasePB = new System.Windows.Forms.Button();
            this.btnResetPB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(278, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 28);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnIcreasePB
            // 
            this.btnIcreasePB.Location = new System.Drawing.Point(221, 257);
            this.btnIcreasePB.Name = "btnIcreasePB";
            this.btnIcreasePB.Size = new System.Drawing.Size(155, 37);
            this.btnIcreasePB.TabIndex = 2;
            this.btnIcreasePB.Text = "Increase Progress Bar";
            this.btnIcreasePB.UseVisualStyleBackColor = true;
            this.btnIcreasePB.Click += new System.EventHandler(this.btnIcreasePB_Click);
            // 
            // btnResetPB
            // 
            this.btnResetPB.Location = new System.Drawing.Point(403, 257);
            this.btnResetPB.Name = "btnResetPB";
            this.btnResetPB.Size = new System.Drawing.Size(155, 37);
            this.btnResetPB.TabIndex = 3;
            this.btnResetPB.Text = "Reset Progress Bar";
            this.btnResetPB.UseVisualStyleBackColor = true;
            this.btnResetPB.Click += new System.EventHandler(this.btnResetPB_Click);
            // 
            // frmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResetPB);
            this.Controls.Add(this.btnIcreasePB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "frmProgressBar";
            this.Text = "frmProgressBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIcreasePB;
        private System.Windows.Forms.Button btnResetPB;
    }
}