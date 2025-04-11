namespace User_Control
{
    partial class Form1
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
            this.ctrlSimpleCalc1 = new User_Control.ctrlSimpleCalc();
            this.ctrlSimpleCalc2 = new User_Control.ctrlSimpleCalc();
            this.ctrlSimpleCalc3 = new User_Control.ctrlSimpleCalc();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSimpleCalc1
            // 
            this.ctrlSimpleCalc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ctrlSimpleCalc1.Font = new System.Drawing.Font("Yu Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlSimpleCalc1.Location = new System.Drawing.Point(13, 11);
            this.ctrlSimpleCalc1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlSimpleCalc1.Name = "ctrlSimpleCalc1";
            this.ctrlSimpleCalc1.Size = new System.Drawing.Size(541, 142);
            this.ctrlSimpleCalc1.TabIndex = 0;
            // 
            // ctrlSimpleCalc2
            // 
            this.ctrlSimpleCalc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ctrlSimpleCalc2.Font = new System.Drawing.Font("Yu Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlSimpleCalc2.Location = new System.Drawing.Point(13, 161);
            this.ctrlSimpleCalc2.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlSimpleCalc2.Name = "ctrlSimpleCalc2";
            this.ctrlSimpleCalc2.Size = new System.Drawing.Size(541, 142);
            this.ctrlSimpleCalc2.TabIndex = 1;
            // 
            // ctrlSimpleCalc3
            // 
            this.ctrlSimpleCalc3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ctrlSimpleCalc3.Font = new System.Drawing.Font("Yu Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlSimpleCalc3.Location = new System.Drawing.Point(13, 311);
            this.ctrlSimpleCalc3.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlSimpleCalc3.Name = "ctrlSimpleCalc3";
            this.ctrlSimpleCalc3.Size = new System.Drawing.Size(541, 142);
            this.ctrlSimpleCalc3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Cyan;
            this.button1.Location = new System.Drawing.Point(1037, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "get Calc Result";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 524);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlSimpleCalc3);
            this.Controls.Add(this.ctrlSimpleCalc2);
            this.Controls.Add(this.ctrlSimpleCalc1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSimpleCalc ctrlSimpleCalc1;
        private ctrlSimpleCalc ctrlSimpleCalc2;
        private ctrlSimpleCalc ctrlSimpleCalc3;
        private System.Windows.Forms.Button button1;
    }
}

