namespace BankSystem.Reports.UserActivityReport
{
    partial class frmUserReport_EntityChanges
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
            this.txtBefore = new System.Windows.Forms.TextBox();
            this.txtAfter = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBefore
            // 
            this.txtBefore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBefore.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBefore.ForeColor = System.Drawing.Color.MintCream;
            this.txtBefore.Location = new System.Drawing.Point(7, 118);
            this.txtBefore.Multiline = true;
            this.txtBefore.Name = "txtBefore";
            this.txtBefore.ReadOnly = true;
            this.txtBefore.Size = new System.Drawing.Size(479, 447);
            this.txtBefore.TabIndex = 54;
            this.txtBefore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAfter
            // 
            this.txtAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAfter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAfter.ForeColor = System.Drawing.Color.MintCream;
            this.txtAfter.Location = new System.Drawing.Point(526, 118);
            this.txtAfter.Multiline = true;
            this.txtAfter.Name = "txtAfter";
            this.txtAfter.ReadOnly = true;
            this.txtAfter.Size = new System.Drawing.Size(479, 447);
            this.txtAfter.TabIndex = 56;
            this.txtAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Info;
            this.btnClose.Location = new System.Drawing.Point(456, 584);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 34);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(207, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 30);
            this.label4.TabIndex = 58;
            this.label4.Text = "Before";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(730, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 30);
            this.label1.TabIndex = 59;
            this.label1.Text = "After";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 23F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 52);
            this.label2.TabIndex = 60;
            this.label2.Text = "Target Entity Changes";
            // 
            // frmUserReport_EntityChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1012, 630);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtAfter);
            this.Controls.Add(this.txtBefore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserReport_EntityChanges";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUserReport_EntityChanges";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBefore;
        private System.Windows.Forms.TextBox txtAfter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}