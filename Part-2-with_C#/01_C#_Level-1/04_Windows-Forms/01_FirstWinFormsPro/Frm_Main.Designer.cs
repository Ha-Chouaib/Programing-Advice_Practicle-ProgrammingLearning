namespace _01_FirstWinFormsPro
{
    partial class Frm_Main
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
            this.btnShowPart1 = new System.Windows.Forms.Button();
            this.btn_ShowForm1AsDaialog = new System.Windows.Forms.Button();
            this.btnMSG_BoxForm = new System.Windows.Forms.Button();
            this.btnToRadio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowPart1
            // 
            this.btnShowPart1.Location = new System.Drawing.Point(346, 54);
            this.btnShowPart1.Name = "btnShowPart1";
            this.btnShowPart1.Size = new System.Drawing.Size(109, 45);
            this.btnShowPart1.TabIndex = 0;
            this.btnShowPart1.Text = "Show Part 1";
            this.btnShowPart1.UseVisualStyleBackColor = true;
            this.btnShowPart1.Click += new System.EventHandler(this.btnShowPart1_Click);
            // 
            // btn_ShowForm1AsDaialog
            // 
            this.btn_ShowForm1AsDaialog.Location = new System.Drawing.Point(346, 136);
            this.btn_ShowForm1AsDaialog.Name = "btn_ShowForm1AsDaialog";
            this.btn_ShowForm1AsDaialog.Size = new System.Drawing.Size(109, 45);
            this.btn_ShowForm1AsDaialog.TabIndex = 1;
            this.btn_ShowForm1AsDaialog.Text = "Show as Dialog";
            this.btn_ShowForm1AsDaialog.UseVisualStyleBackColor = true;
            this.btn_ShowForm1AsDaialog.Click += new System.EventHandler(this.btn_ShowForm1AsDaialog_Click);
            // 
            // btnMSG_BoxForm
            // 
            this.btnMSG_BoxForm.Location = new System.Drawing.Point(346, 203);
            this.btnMSG_BoxForm.Name = "btnMSG_BoxForm";
            this.btnMSG_BoxForm.Size = new System.Drawing.Size(109, 45);
            this.btnMSG_BoxForm.TabIndex = 2;
            this.btnMSG_BoxForm.Text = "ToMessageBox";
            this.btnMSG_BoxForm.UseVisualStyleBackColor = true;
            this.btnMSG_BoxForm.Click += new System.EventHandler(this.btnMSG_BoxForm_Click);
            // 
            // btnToRadio
            // 
            this.btnToRadio.Location = new System.Drawing.Point(346, 272);
            this.btnToRadio.Name = "btnToRadio";
            this.btnToRadio.Size = new System.Drawing.Size(109, 45);
            this.btnToRadio.TabIndex = 3;
            this.btnToRadio.Text = "To Radio ";
            this.btnToRadio.UseVisualStyleBackColor = true;
            this.btnToRadio.Click += new System.EventHandler(this.btnToRadio_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToRadio);
            this.Controls.Add(this.btnMSG_BoxForm);
            this.Controls.Add(this.btn_ShowForm1AsDaialog);
            this.Controls.Add(this.btnShowPart1);
            this.Name = "Frm_Main";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowPart1;
        private System.Windows.Forms.Button btn_ShowForm1AsDaialog;
        private System.Windows.Forms.Button btnMSG_BoxForm;
        private System.Windows.Forms.Button btnToRadio;
    }
}