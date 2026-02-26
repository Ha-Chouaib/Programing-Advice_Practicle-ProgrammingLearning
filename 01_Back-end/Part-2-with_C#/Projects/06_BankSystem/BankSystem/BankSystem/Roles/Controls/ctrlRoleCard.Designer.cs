namespace BankSystem.Roles
{
    partial class ctrlRoleCard
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
            this.ckbIsActive = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAddedByUser = new System.Windows.Forms.TextBox();
            this.txtAddedAt = new System.Windows.Forms.TextBox();
            this.txtRoleID = new System.Windows.Forms.TextBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.fpnlPermissionsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ckbIsActive
            // 
            this.ckbIsActive.AutoCheck = false;
            this.ckbIsActive.AutoSize = true;
            this.ckbIsActive.Checked = true;
            this.ckbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsActive.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbIsActive.ForeColor = System.Drawing.Color.Cyan;
            this.ckbIsActive.Location = new System.Drawing.Point(270, 348);
            this.ckbIsActive.Name = "ckbIsActive";
            this.ckbIsActive.Size = new System.Drawing.Size(85, 27);
            this.ckbIsActive.TabIndex = 29;
            this.ckbIsActive.Text = "Active";
            this.ckbIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbIsActive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(376, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Added By User";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(10, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Added At";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(376, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Role Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(10, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Role ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(10, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Permissions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(266, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtDescription.Location = new System.Drawing.Point(15, 266);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(608, 76);
            this.txtDescription.TabIndex = 22;
            // 
            // txtAddedByUser
            // 
            this.txtAddedByUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtAddedByUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddedByUser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddedByUser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtAddedByUser.Location = new System.Drawing.Point(380, 161);
            this.txtAddedByUser.Multiline = true;
            this.txtAddedByUser.Name = "txtAddedByUser";
            this.txtAddedByUser.ReadOnly = true;
            this.txtAddedByUser.Size = new System.Drawing.Size(243, 35);
            this.txtAddedByUser.TabIndex = 21;
            // 
            // txtAddedAt
            // 
            this.txtAddedAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtAddedAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddedAt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddedAt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtAddedAt.Location = new System.Drawing.Point(15, 161);
            this.txtAddedAt.Multiline = true;
            this.txtAddedAt.Name = "txtAddedAt";
            this.txtAddedAt.ReadOnly = true;
            this.txtAddedAt.Size = new System.Drawing.Size(232, 35);
            this.txtAddedAt.TabIndex = 20;
            // 
            // txtRoleID
            // 
            this.txtRoleID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtRoleID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoleID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleID.ForeColor = System.Drawing.Color.Cyan;
            this.txtRoleID.Location = new System.Drawing.Point(15, 65);
            this.txtRoleID.Multiline = true;
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.ReadOnly = true;
            this.txtRoleID.Size = new System.Drawing.Size(232, 35);
            this.txtRoleID.TabIndex = 19;
            // 
            // txtRoleName
            // 
            this.txtRoleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.txtRoleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoleName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoleName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtRoleName.Location = new System.Drawing.Point(380, 65);
            this.txtRoleName.Multiline = true;
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.ReadOnly = true;
            this.txtRoleName.Size = new System.Drawing.Size(243, 35);
            this.txtRoleName.TabIndex = 18;
            // 
            // fpnlPermissionsContainer
            // 
            this.fpnlPermissionsContainer.AutoScroll = true;
            this.fpnlPermissionsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(22)))), ((int)(((byte)(29)))));
            this.fpnlPermissionsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnlPermissionsContainer.Location = new System.Drawing.Point(15, 426);
            this.fpnlPermissionsContainer.Name = "fpnlPermissionsContainer";
            this.fpnlPermissionsContainer.Size = new System.Drawing.Size(608, 296);
            this.fpnlPermissionsContainer.TabIndex = 17;
            // 
            // ctrlRoleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.ckbIsActive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtAddedByUser);
            this.Controls.Add(this.txtAddedAt);
            this.Controls.Add(this.txtRoleID);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.fpnlPermissionsContainer);
            this.Name = "ctrlRoleCard";
            this.Size = new System.Drawing.Size(636, 749);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbIsActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtAddedByUser;
        private System.Windows.Forms.TextBox txtAddedAt;
        private System.Windows.Forms.TextBox txtRoleID;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.FlowLayoutPanel fpnlPermissionsContainer;
    }
}
