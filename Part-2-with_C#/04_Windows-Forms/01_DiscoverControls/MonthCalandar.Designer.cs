﻿namespace _01_FirstWinFormsPro
{
    partial class MonthCalandar
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnSelectedRange = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(256, 31);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // btnSelectedRange
            // 
            this.btnSelectedRange.Location = new System.Drawing.Point(176, 295);
            this.btnSelectedRange.Name = "btnSelectedRange";
            this.btnSelectedRange.Size = new System.Drawing.Size(105, 36);
            this.btnSelectedRange.TabIndex = 1;
            this.btnSelectedRange.Text = "Selected Range";
            this.btnSelectedRange.UseVisualStyleBackColor = true;
            this.btnSelectedRange.Click += new System.EventHandler(this.btnSelectedRange_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(336, 295);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 36);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(483, 295);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(105, 36);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // MonthCalandar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSelectedRange);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "MonthCalandar";
            this.Text = "MonthCalandar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnSelectedRange;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
    }
}