namespace BankSystem.Currencies.Controls
{
    partial class ctrlCurrencyCalculator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlCurrencyFrom = new BankSystem.Currencies.Controls.ctrlCurrencyCard();
            this.ctrlCurrencyTo = new BankSystem.Currencies.Controls.ctrlCurrencyCard();
            this.cmbCurrencyOptions = new System.Windows.Forms.ComboBox();
            this.rbFrom = new System.Windows.Forms.RadioButton();
            this.rbTo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(256, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 14.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(1051, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.Black;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Cyan;
            this.txtAmount.Location = new System.Drawing.Point(412, 530);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(216, 39);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.Black;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.Cyan;
            this.txtResult.Location = new System.Drawing.Point(733, 530);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(216, 39);
            this.txtResult.TabIndex = 5;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnChange
            // 
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.Cyan;
            this.btnChange.Location = new System.Drawing.Point(634, 533);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(93, 36);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(487, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(798, 502);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Result";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlCurrencyFrom
            // 
            this.ctrlCurrencyFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ctrlCurrencyFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCurrencyFrom.Location = new System.Drawing.Point(18, 162);
            this.ctrlCurrencyFrom.Name = "ctrlCurrencyFrom";
            this.ctrlCurrencyFrom.Size = new System.Drawing.Size(553, 285);
            this.ctrlCurrencyFrom.TabIndex = 9;
            // 
            // ctrlCurrencyTo
            // 
            this.ctrlCurrencyTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ctrlCurrencyTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCurrencyTo.Location = new System.Drawing.Point(803, 162);
            this.ctrlCurrencyTo.Name = "ctrlCurrencyTo";
            this.ctrlCurrencyTo.Size = new System.Drawing.Size(553, 285);
            this.ctrlCurrencyTo.TabIndex = 10;
            // 
            // cmbCurrencyOptions
            // 
            this.cmbCurrencyOptions.BackColor = System.Drawing.Color.Black;
            this.cmbCurrencyOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCurrencyOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrencyOptions.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrencyOptions.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cmbCurrencyOptions.FormattingEnabled = true;
            this.cmbCurrencyOptions.Location = new System.Drawing.Point(573, 102);
            this.cmbCurrencyOptions.Name = "cmbCurrencyOptions";
            this.cmbCurrencyOptions.Size = new System.Drawing.Size(231, 31);
            this.cmbCurrencyOptions.TabIndex = 11;
            this.cmbCurrencyOptions.SelectedIndexChanged += new System.EventHandler(this.cmbCurrencyOptions_SelectedIndexChanged);
            // 
            // rbFrom
            // 
            this.rbFrom.AutoSize = true;
            this.rbFrom.Checked = true;
            this.rbFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbFrom.Font = new System.Drawing.Font("Segoe UI", 9.8F, System.Drawing.FontStyle.Bold);
            this.rbFrom.ForeColor = System.Drawing.Color.Cyan;
            this.rbFrom.Location = new System.Drawing.Point(598, 36);
            this.rbFrom.Name = "rbFrom";
            this.rbFrom.Size = new System.Drawing.Size(187, 27);
            this.rbFrom.TabIndex = 12;
            this.rbFrom.TabStop = true;
            this.rbFrom.Text = "Pick Currency From";
            this.rbFrom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbFrom.UseVisualStyleBackColor = true;
            this.rbFrom.CheckedChanged += new System.EventHandler(this.rbFrom_CheckedChanged);
            // 
            // rbTo
            // 
            this.rbTo.AutoSize = true;
            this.rbTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbTo.Font = new System.Drawing.Font("Segoe UI", 9.8F, System.Drawing.FontStyle.Bold);
            this.rbTo.ForeColor = System.Drawing.Color.Cyan;
            this.rbTo.Location = new System.Drawing.Point(613, 69);
            this.rbTo.Name = "rbTo";
            this.rbTo.Size = new System.Drawing.Size(163, 27);
            this.rbTo.TabIndex = 13;
            this.rbTo.Text = "Pick Currency To";
            this.rbTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rbTo.UseVisualStyleBackColor = true;
            // 
            // ctrlCurrencyCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.Controls.Add(this.rbTo);
            this.Controls.Add(this.rbFrom);
            this.Controls.Add(this.cmbCurrencyOptions);
            this.Controls.Add(this.ctrlCurrencyTo);
            this.Controls.Add(this.ctrlCurrencyFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrlCurrencyCalculator";
            this.Size = new System.Drawing.Size(1375, 609);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ctrlCurrencyCard ctrlCurrencyFrom;
        private ctrlCurrencyCard ctrlCurrencyTo;
        private System.Windows.Forms.ComboBox cmbCurrencyOptions;
        private System.Windows.Forms.RadioButton rbFrom;
        private System.Windows.Forms.RadioButton rbTo;
    }
}
