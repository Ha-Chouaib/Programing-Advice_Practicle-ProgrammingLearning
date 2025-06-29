namespace _02_Pool_Club
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
            this.ctrlPoolClub1 = new _02_Pool_Club.ctrlPoolClub();
            this.SuspendLayout();
            // 
            // ctrlPoolClub1
            // 
            this.ctrlPoolClub1.BackColor = System.Drawing.Color.Black;
            this.ctrlPoolClub1.HourlyRate = 15F;
            this.ctrlPoolClub1.Location = new System.Drawing.Point(23, 12);
            this.ctrlPoolClub1.Name = "ctrlPoolClub1";
            this.ctrlPoolClub1.PlyerName = "Chouaib";
            this.ctrlPoolClub1.Size = new System.Drawing.Size(299, 281);
            this.ctrlPoolClub1.TabIndex = 0;
            this.ctrlPoolClub1.TableName = "Table";
            this.ctrlPoolClub1.TableComplated += new System.EventHandler<_02_Pool_Club.ctrlPoolClub.TableEventArgs>(this.ctrlPoolClub1_TableComplated);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.ctrlPoolClub1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPoolClub ctrlPoolClub1;
    }
}

