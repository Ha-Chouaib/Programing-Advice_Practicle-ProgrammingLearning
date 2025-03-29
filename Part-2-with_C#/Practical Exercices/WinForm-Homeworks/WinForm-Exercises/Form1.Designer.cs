namespace WinForm_Exercises
{
    partial class MainForm
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
            this.btn01CheckedListBox = new System.Windows.Forms.Button();
            this.btnDateTimePicker = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGenericCode = new System.Windows.Forms.Button();
            this.btnLINQ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn01CheckedListBox
            // 
            this.btn01CheckedListBox.Font = new System.Drawing.Font("Gabriola", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01CheckedListBox.Location = new System.Drawing.Point(25, 30);
            this.btn01CheckedListBox.Name = "btn01CheckedListBox";
            this.btn01CheckedListBox.Size = new System.Drawing.Size(176, 43);
            this.btn01CheckedListBox.TabIndex = 0;
            this.btn01CheckedListBox.Text = "Task Manager";
            this.btn01CheckedListBox.UseVisualStyleBackColor = true;
            this.btn01CheckedListBox.Click += new System.EventHandler(this.btn01CheckedListBox_Click);
            // 
            // btnDateTimePicker
            // 
            this.btnDateTimePicker.Font = new System.Drawing.Font("Gabriola", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDateTimePicker.Location = new System.Drawing.Point(207, 30);
            this.btnDateTimePicker.Name = "btnDateTimePicker";
            this.btnDateTimePicker.Size = new System.Drawing.Size(176, 43);
            this.btnDateTimePicker.TabIndex = 1;
            this.btnDateTimePicker.Text = "DateTimePicker";
            this.btnDateTimePicker.UseVisualStyleBackColor = true;
            this.btnDateTimePicker.Click += new System.EventHandler(this.btnDateTimePicker_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Gabriola", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(404, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Dynamic Manupilation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Gabriola", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(694, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(329, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "Creat Custom Control <Inhiretance>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGenericCode
            // 
            this.btnGenericCode.Font = new System.Drawing.Font("Gabriola", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenericCode.Location = new System.Drawing.Point(1071, 30);
            this.btnGenericCode.Name = "btnGenericCode";
            this.btnGenericCode.Size = new System.Drawing.Size(167, 49);
            this.btnGenericCode.TabIndex = 4;
            this.btnGenericCode.Text = "Generic Code";
            this.btnGenericCode.UseVisualStyleBackColor = true;
            this.btnGenericCode.Click += new System.EventHandler(this.btnGenericCode_Click);
            // 
            // btnLINQ
            // 
            this.btnLINQ.Font = new System.Drawing.Font("Gabriola", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLINQ.Location = new System.Drawing.Point(38, 115);
            this.btnLINQ.Name = "btnLINQ";
            this.btnLINQ.Size = new System.Drawing.Size(93, 49);
            this.btnLINQ.TabIndex = 5;
            this.btnLINQ.Text = "LINQ";
            this.btnLINQ.UseVisualStyleBackColor = true;
            this.btnLINQ.Click += new System.EventHandler(this.btnLINQ_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 621);
            this.Controls.Add(this.btnLINQ);
            this.Controls.Add(this.btnGenericCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDateTimePicker);
            this.Controls.Add(this.btn01CheckedListBox);
            this.Name = "MainForm";
            this.Text = "Main-Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn01CheckedListBox;
        private System.Windows.Forms.Button btnDateTimePicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGenericCode;
        private System.Windows.Forms.Button btnLINQ;
    }
}

