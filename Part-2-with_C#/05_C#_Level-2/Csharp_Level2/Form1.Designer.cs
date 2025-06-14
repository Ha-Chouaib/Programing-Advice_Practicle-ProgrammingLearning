namespace Csharp_Level2
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
            this.ctrlSimpleEvent1 = new Csharp_Level2.ctrlSimpleEvent();
            this.ctrlSimpleEventWithParameters1 = new Csharp_Level2.ctrlSimpleEventWithParameters();
            this.SuspendLayout();
            // 
            // ctrlSimpleEvent1
            // 
            this.ctrlSimpleEvent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ctrlSimpleEvent1.Location = new System.Drawing.Point(2, 12);
            this.ctrlSimpleEvent1.Name = "ctrlSimpleEvent1";
            this.ctrlSimpleEvent1.Size = new System.Drawing.Size(255, 97);
            this.ctrlSimpleEvent1.TabIndex = 0;
            this.ctrlSimpleEvent1.OnbtnCliked += new System.Action<string>(this.ctrlSimpleEvent1_OnbtnCliked);
            // 
            // ctrlSimpleEventWithParameters1
            // 
            this.ctrlSimpleEventWithParameters1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlSimpleEventWithParameters1.Location = new System.Drawing.Point(2, 125);
            this.ctrlSimpleEventWithParameters1.Name = "ctrlSimpleEventWithParameters1";
            this.ctrlSimpleEventWithParameters1.Size = new System.Drawing.Size(311, 211);
            this.ctrlSimpleEventWithParameters1.TabIndex = 1;
            this.ctrlSimpleEventWithParameters1.OnCalculationComplete += new System.EventHandler<Csharp_Level2.ctrlSimpleEventWithParameters.GetCalcResultEventArgs>(this.ctrlSimpleEventWithParameters1_OnCalculationComplete);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.ctrlSimpleEventWithParameters1);
            this.Controls.Add(this.ctrlSimpleEvent1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlSimpleEvent ctrlSimpleEvent1;
        private ctrlSimpleEventWithParameters ctrlSimpleEventWithParameters1;
    }
}

