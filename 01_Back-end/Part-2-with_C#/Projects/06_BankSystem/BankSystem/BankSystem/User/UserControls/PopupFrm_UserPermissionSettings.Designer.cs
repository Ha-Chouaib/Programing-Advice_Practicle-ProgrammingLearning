namespace BankSystem.User.UserControls
{
    partial class PopupFrm_UserPermissionSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flpRolePermissions = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCustomPermissions = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Cyan;
            this.btnSave.Location = new System.Drawing.Point(347, 524);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkGray;
            this.btnCancel.Location = new System.Drawing.Point(203, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flpRolePermissions
            // 
            this.flpRolePermissions.AutoScroll = true;
            this.flpRolePermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.flpRolePermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpRolePermissions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRolePermissions.Location = new System.Drawing.Point(22, 45);
            this.flpRolePermissions.Name = "flpRolePermissions";
            this.flpRolePermissions.Size = new System.Drawing.Size(290, 461);
            this.flpRolePermissions.TabIndex = 0;
            this.flpRolePermissions.WrapContents = false;
            // 
            // flpCustomPermissions
            // 
            this.flpCustomPermissions.AutoScroll = true;
            this.flpCustomPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.flpCustomPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCustomPermissions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCustomPermissions.Location = new System.Drawing.Point(347, 45);
            this.flpCustomPermissions.Name = "flpCustomPermissions";
            this.flpCustomPermissions.Size = new System.Drawing.Size(295, 461);
            this.flpCustomPermissions.TabIndex = 1;
            this.flpCustomPermissions.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Role Permissions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(376, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Additional Permissions";
            // 
            // PopupFrm_UserPermissionSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(669, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flpCustomPermissions);
            this.Controls.Add(this.flpRolePermissions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopupFrm_UserPermissionSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopupFrm_UserPermissionSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flpRolePermissions;
        private System.Windows.Forms.FlowLayoutPanel flpCustomPermissions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}