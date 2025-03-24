namespace _01_FirstWinFormsPro
{
    partial class frmDateTimePicker
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChortDate = new System.Windows.Forms.Button();
            this.btnLongDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 76);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(249, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 132);
            this.label1.MaximumSize = new System.Drawing.Size(400, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnChortDate
            // 
            this.btnChortDate.Location = new System.Drawing.Point(131, 266);
            this.btnChortDate.Name = "btnChortDate";
            this.btnChortDate.Size = new System.Drawing.Size(107, 41);
            this.btnChortDate.TabIndex = 2;
            this.btnChortDate.Text = "Short Date String";
            this.btnChortDate.UseVisualStyleBackColor = true;
            this.btnChortDate.Click += new System.EventHandler(this.btnChortDate_Click);
            // 
            // btnLongDate
            // 
            this.btnLongDate.Location = new System.Drawing.Point(313, 266);
            this.btnLongDate.Name = "btnLongDate";
            this.btnLongDate.Size = new System.Drawing.Size(107, 41);
            this.btnLongDate.TabIndex = 3;
            this.btnLongDate.Text = "Long Date String";
            this.btnLongDate.UseVisualStyleBackColor = true;
            this.btnLongDate.Click += new System.EventHandler(this.btnLongDate_Click);
            // 
            // frmDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLongDate);
            this.Controls.Add(this.btnChortDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "frmDateTimePicker";
            this.Text = "frmDateTimePicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChortDate;
        private System.Windows.Forms.Button btnLongDate;
    }
}