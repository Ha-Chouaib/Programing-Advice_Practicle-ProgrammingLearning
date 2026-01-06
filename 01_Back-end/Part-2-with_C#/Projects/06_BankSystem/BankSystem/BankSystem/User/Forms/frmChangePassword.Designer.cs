namespace BankSystem.User.Forms
{
    partial class frmChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOriginalPass = new System.Windows.Forms.TextBox();
            this.ctrlFindUser1 = new BankSystem.User.UserControls.ctrlFindUser();
            this.pnlEditPass = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.pnlEditPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(276, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "Update User Password";
            // 
            // txtOriginalPass
            // 
            this.txtOriginalPass.BackColor = System.Drawing.Color.Black;
            this.txtOriginalPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOriginalPass.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalPass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtOriginalPass.Location = new System.Drawing.Point(15, 49);
            this.txtOriginalPass.MaxLength = 4;
            this.txtOriginalPass.Multiline = true;
            this.txtOriginalPass.Name = "txtOriginalPass";
            this.txtOriginalPass.PasswordChar = '*';
            this.txtOriginalPass.Size = new System.Drawing.Size(239, 39);
            this.txtOriginalPass.TabIndex = 2;
            this.txtOriginalPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtOriginalPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtOriginalPass_Validating);
            // 
            // ctrlFindUser1
            // 
            this.ctrlFindUser1.@__FindControl = null;
            this.ctrlFindUser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlFindUser1.Location = new System.Drawing.Point(12, 109);
            this.ctrlFindUser1.Name = "ctrlFindUser1";
            this.ctrlFindUser1.Size = new System.Drawing.Size(631, 533);
            this.ctrlFindUser1.TabIndex = 1;
            // 
            // pnlEditPass
            // 
            this.pnlEditPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnlEditPass.Controls.Add(this.btnSave);
            this.pnlEditPass.Controls.Add(this.btnCancel);
            this.pnlEditPass.Controls.Add(this.label4);
            this.pnlEditPass.Controls.Add(this.label3);
            this.pnlEditPass.Controls.Add(this.label2);
            this.pnlEditPass.Controls.Add(this.txtConfirmPass);
            this.pnlEditPass.Controls.Add(this.txtNewPass);
            this.pnlEditPass.Controls.Add(this.txtOriginalPass);
            this.pnlEditPass.Enabled = false;
            this.pnlEditPass.Location = new System.Drawing.Point(649, 255);
            this.pnlEditPass.Name = "pnlEditPass";
            this.pnlEditPass.Size = new System.Drawing.Size(269, 323);
            this.pnlEditPass.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Cyan;
            this.btnSave.Location = new System.Drawing.Point(167, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Location = new System.Drawing.Point(15, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(16, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(16, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(16, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Old Password";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BackColor = System.Drawing.Color.Black;
            this.txtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtConfirmPass.Location = new System.Drawing.Point(15, 200);
            this.txtConfirmPass.MaxLength = 4;
            this.txtConfirmPass.Multiline = true;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(239, 39);
            this.txtConfirmPass.TabIndex = 4;
            this.txtConfirmPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPass_Validating);
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.Black;
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtNewPass.Location = new System.Drawing.Point(16, 125);
            this.txtNewPass.MaxLength = 4;
            this.txtNewPass.Multiline = true;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(239, 39);
            this.txtNewPass.TabIndex = 3;
            this.txtNewPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtNewPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPass_Validating);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(946, 656);
            this.Controls.Add(this.pnlEditPass);
            this.Controls.Add(this.ctrlFindUser1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update User Password";
            this.pnlEditPass.ResumeLayout(false);
            this.pnlEditPass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOriginalPass;
        private UserControls.ctrlFindUser ctrlFindUser1;
        private System.Windows.Forms.Panel pnlEditPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}