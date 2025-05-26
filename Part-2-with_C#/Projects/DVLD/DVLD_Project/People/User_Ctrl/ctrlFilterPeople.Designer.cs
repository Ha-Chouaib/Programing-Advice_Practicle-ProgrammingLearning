namespace DVLD_Project.Users.UserControls
{
    partial class ctrlFilterPeople
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
            this.cmbFilterOpts = new System.Windows.Forms.ComboBox();
            this.gbFilterContainer = new System.Windows.Forms.GroupBox();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.gbFilterContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbFilterOpts
            // 
            this.cmbFilterOpts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.cmbFilterOpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOpts.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterOpts.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFilterOpts.FormattingEnabled = true;
            this.cmbFilterOpts.Location = new System.Drawing.Point(126, 24);
            this.cmbFilterOpts.Name = "cmbFilterOpts";
            this.cmbFilterOpts.Size = new System.Drawing.Size(221, 26);
            this.cmbFilterOpts.TabIndex = 0;
            // 
            // gbFilterContainer
            // 
            this.gbFilterContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.gbFilterContainer.Controls.Add(this.txtSearchTerm);
            this.gbFilterContainer.Controls.Add(this.label1);
            this.gbFilterContainer.Controls.Add(this.btnAddNewPerson);
            this.gbFilterContainer.Controls.Add(this.btnFindPerson);
            this.gbFilterContainer.Controls.Add(this.cmbFilterOpts);
            this.gbFilterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFilterContainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbFilterContainer.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterContainer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.gbFilterContainer.Location = new System.Drawing.Point(0, 0);
            this.gbFilterContainer.Name = "gbFilterContainer";
            this.gbFilterContainer.Size = new System.Drawing.Size(938, 66);
            this.gbFilterContainer.TabIndex = 1;
            this.gbFilterContainer.TabStop = false;
            this.gbFilterContainer.Text = "Filter";
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtSearchTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchTerm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchTerm.Location = new System.Drawing.Point(364, 24);
            this.txtSearchTerm.Multiline = true;
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(233, 26);
            this.txtSearchTerm.TabIndex = 4;
            this.txtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchTerm_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find By->";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAddNewPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewPerson.ForeColor = System.Drawing.Color.Cyan;
            this.btnAddNewPerson.Location = new System.Drawing.Point(782, 20);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(141, 29);
            this.btnAddNewPerson.TabIndex = 2;
            this.btnAddNewPerson.Text = "Add New Person";
            this.btnAddNewPerson.UseVisualStyleBackColor = false;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnFindPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPerson.ForeColor = System.Drawing.SystemColors.Info;
            this.btnFindPerson.Location = new System.Drawing.Point(653, 20);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(111, 29);
            this.btnFindPerson.TabIndex = 1;
            this.btnFindPerson.Text = "Find Person";
            this.btnFindPerson.UseVisualStyleBackColor = false;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // ctrlFilterPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.gbFilterContainer);
            this.Name = "ctrlFilterPeople";
            this.Size = new System.Drawing.Size(938, 66);
            this.Load += new System.EventHandler(this.ctrlFilterPeople_Load);
            this.gbFilterContainer.ResumeLayout(false);
            this.gbFilterContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFilterOpts;
        private System.Windows.Forms.GroupBox gbFilterContainer;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchTerm;
    }
}
