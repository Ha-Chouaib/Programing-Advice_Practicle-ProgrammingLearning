namespace _01_FirstWinFormsPro
{
    partial class frmChekedListBox
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.btnSowSelectedItems = new System.Windows.Forms.Button();
            this.btncheckAllItems = new System.Windows.Forms.Button();
            this.btnUnCheckAll = new System.Windows.Forms.Button();
            this.btnRemoveFirstItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(266, 36);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(245, 109);
            this.checkedListBox1.TabIndex = 0;
            // 
            // btnAddItems
            // 
            this.btnAddItems.Location = new System.Drawing.Point(154, 308);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(97, 43);
            this.btnAddItems.TabIndex = 1;
            this.btnAddItems.Text = "Add Items";
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // btnSowSelectedItems
            // 
            this.btnSowSelectedItems.Location = new System.Drawing.Point(284, 308);
            this.btnSowSelectedItems.Name = "btnSowSelectedItems";
            this.btnSowSelectedItems.Size = new System.Drawing.Size(97, 43);
            this.btnSowSelectedItems.TabIndex = 2;
            this.btnSowSelectedItems.Text = "Show Selected Items";
            this.btnSowSelectedItems.UseVisualStyleBackColor = true;
            this.btnSowSelectedItems.Click += new System.EventHandler(this.btnSowSelectedItems_Click);
            // 
            // btncheckAllItems
            // 
            this.btncheckAllItems.Location = new System.Drawing.Point(414, 308);
            this.btncheckAllItems.Name = "btncheckAllItems";
            this.btncheckAllItems.Size = new System.Drawing.Size(97, 43);
            this.btncheckAllItems.TabIndex = 3;
            this.btncheckAllItems.Text = "Check All Items";
            this.btncheckAllItems.UseVisualStyleBackColor = true;
            this.btncheckAllItems.Click += new System.EventHandler(this.btncheckAllItems_Click);
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Location = new System.Drawing.Point(544, 308);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(97, 43);
            this.btnUnCheckAll.TabIndex = 4;
            this.btnUnCheckAll.Text = "Uncheck All Items";
            this.btnUnCheckAll.UseVisualStyleBackColor = true;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // btnRemoveFirstItem
            // 
            this.btnRemoveFirstItem.Location = new System.Drawing.Point(354, 374);
            this.btnRemoveFirstItem.Name = "btnRemoveFirstItem";
            this.btnRemoveFirstItem.Size = new System.Drawing.Size(97, 43);
            this.btnRemoveFirstItem.TabIndex = 5;
            this.btnRemoveFirstItem.Text = "Remove First Item";
            this.btnRemoveFirstItem.UseVisualStyleBackColor = true;
            this.btnRemoveFirstItem.Click += new System.EventHandler(this.btnRemoveFirstItem_Click);
            // 
            // frmChekedListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemoveFirstItem);
            this.Controls.Add(this.btnUnCheckAll);
            this.Controls.Add(this.btncheckAllItems);
            this.Controls.Add(this.btnSowSelectedItems);
            this.Controls.Add(this.btnAddItems);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "frmChekedListBox";
            this.Text = "frmChekedListBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.Button btnSowSelectedItems;
        private System.Windows.Forms.Button btncheckAllItems;
        private System.Windows.Forms.Button btnUnCheckAll;
        private System.Windows.Forms.Button btnRemoveFirstItem;
    }
}