namespace _01_FirstWinFormsPro
{
    partial class frmDialogs
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
            this.btnChangeForeColor = new System.Windows.Forms.Button();
            this.btnChangeBackColor = new System.Windows.Forms.Button();
            this.btnChageFont = new System.Windows.Forms.Button();
            this.txtChangeMyFont = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.btnOpenFileMultiSelect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFoldrBrowser = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnChangeForeColor
            // 
            this.btnChangeForeColor.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeForeColor.Location = new System.Drawing.Point(3, 121);
            this.btnChangeForeColor.Name = "btnChangeForeColor";
            this.btnChangeForeColor.Size = new System.Drawing.Size(173, 50);
            this.btnChangeForeColor.TabIndex = 5;
            this.btnChangeForeColor.Text = "Change Fore Color";
            this.btnChangeForeColor.UseVisualStyleBackColor = true;
            this.btnChangeForeColor.Click += new System.EventHandler(this.btnChangeForeColor_Click);
            // 
            // btnChangeBackColor
            // 
            this.btnChangeBackColor.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeBackColor.Location = new System.Drawing.Point(207, 121);
            this.btnChangeBackColor.Name = "btnChangeBackColor";
            this.btnChangeBackColor.Size = new System.Drawing.Size(173, 50);
            this.btnChangeBackColor.TabIndex = 4;
            this.btnChangeBackColor.Text = "Change Back Color";
            this.btnChangeBackColor.UseVisualStyleBackColor = true;
            this.btnChangeBackColor.Click += new System.EventHandler(this.btnChangeBackColor_Click);
            // 
            // btnChageFont
            // 
            this.btnChageFont.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChageFont.Location = new System.Drawing.Point(411, 121);
            this.btnChageFont.Name = "btnChageFont";
            this.btnChageFont.Size = new System.Drawing.Size(173, 50);
            this.btnChageFont.TabIndex = 7;
            this.btnChageFont.Text = "Change Font";
            this.btnChageFont.UseVisualStyleBackColor = true;
            this.btnChageFont.Click += new System.EventHandler(this.btnChageFont_Click);
            // 
            // txtChangeMyFont
            // 
            this.txtChangeMyFont.Location = new System.Drawing.Point(303, 41);
            this.txtChangeMyFont.Name = "txtChangeMyFont";
            this.txtChangeMyFont.Size = new System.Drawing.Size(194, 20);
            this.txtChangeMyFont.TabIndex = 6;
            this.txtChangeMyFont.Text = "Change My Font";
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFile.Location = new System.Drawing.Point(615, 121);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(173, 40);
            this.btnSaveFile.TabIndex = 8;
            this.btnSaveFile.Text = "Save File";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFileDialog.Location = new System.Drawing.Point(3, 214);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(173, 50);
            this.btnOpenFileDialog.TabIndex = 9;
            this.btnOpenFileDialog.Text = "Open File";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // btnOpenFileMultiSelect
            // 
            this.btnOpenFileMultiSelect.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFileMultiSelect.Location = new System.Drawing.Point(207, 214);
            this.btnOpenFileMultiSelect.Name = "btnOpenFileMultiSelect";
            this.btnOpenFileMultiSelect.Size = new System.Drawing.Size(249, 50);
            this.btnOpenFileMultiSelect.TabIndex = 10;
            this.btnOpenFileMultiSelect.Text = "Open File Multi Select";
            this.btnOpenFileMultiSelect.UseVisualStyleBackColor = true;
            this.btnOpenFileMultiSelect.Click += new System.EventHandler(this.btnOpenFileMultiSelect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFoldrBrowser
            // 
            this.btnFoldrBrowser.Font = new System.Drawing.Font("Gabriola", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoldrBrowser.Location = new System.Drawing.Point(487, 214);
            this.btnFoldrBrowser.Name = "btnFoldrBrowser";
            this.btnFoldrBrowser.Size = new System.Drawing.Size(179, 50);
            this.btnFoldrBrowser.TabIndex = 11;
            this.btnFoldrBrowser.Text = "Folder Browser";
            this.btnFoldrBrowser.UseVisualStyleBackColor = true;
            this.btnFoldrBrowser.Click += new System.EventHandler(this.btnFoldrBrowser_Click);
            // 
            // frmDialogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFoldrBrowser);
            this.Controls.Add(this.btnOpenFileMultiSelect);
            this.Controls.Add(this.btnOpenFileDialog);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.btnChageFont);
            this.Controls.Add(this.txtChangeMyFont);
            this.Controls.Add(this.btnChangeForeColor);
            this.Controls.Add(this.btnChangeBackColor);
            this.Name = "frmDialogs";
            this.Text = "frmDialogs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnChangeForeColor;
        private System.Windows.Forms.Button btnChangeBackColor;
        private System.Windows.Forms.Button btnChageFont;
        private System.Windows.Forms.TextBox txtChangeMyFont;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.Button btnOpenFileMultiSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFoldrBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}