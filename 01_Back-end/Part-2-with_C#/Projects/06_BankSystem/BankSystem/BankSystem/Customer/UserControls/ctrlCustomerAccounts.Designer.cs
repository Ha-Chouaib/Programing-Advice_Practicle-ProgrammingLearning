namespace BankSystem.Accounts.UserControls
{
    partial class ctrlCustomerAccounts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ctrlCustomerCard1 = new BankSystem.Customer.UserControls.ctrlCustomerCard();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCustomerAccounts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsMainItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawalItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inactiveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAccountsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerAccounts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlCustomerCard1
            // 
            this.ctrlCustomerCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ctrlCustomerCard1.Location = new System.Drawing.Point(180, 66);
            this.ctrlCustomerCard1.Name = "ctrlCustomerCard1";
            this.ctrlCustomerCard1.Size = new System.Drawing.Size(664, 442);
            this.ctrlCustomerCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(316, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Accounts";
            // 
            // dgvCustomerAccounts
            // 
            this.dgvCustomerAccounts.AllowUserToAddRows = false;
            this.dgvCustomerAccounts.AllowUserToDeleteRows = false;
            this.dgvCustomerAccounts.AllowUserToResizeColumns = false;
            this.dgvCustomerAccounts.AllowUserToResizeRows = false;
            this.dgvCustomerAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvCustomerAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomerAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerAccounts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCustomerAccounts.Location = new System.Drawing.Point(3, 583);
            this.dgvCustomerAccounts.Name = "dgvCustomerAccounts";
            this.dgvCustomerAccounts.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomerAccounts.RowHeadersWidth = 51;
            this.dgvCustomerAccounts.RowTemplate.Height = 24;
            this.dgvCustomerAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerAccounts.Size = new System.Drawing.Size(1025, 186);
            this.dgvCustomerAccounts.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetailsToolStripMenuItem,
            this.transactionsMainItem,
            this.changeStatusToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.viewDetailsToolStripMenuItem.Text = "View Details";
            this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewDetailsToolStripMenuItem_Click);
            // 
            // transactionsMainItem
            // 
            this.transactionsMainItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositItem,
            this.withdrawalItem,
            this.transferItem});
            this.transactionsMainItem.Name = "transactionsMainItem";
            this.transactionsMainItem.Size = new System.Drawing.Size(172, 24);
            this.transactionsMainItem.Text = "Transactions";
            // 
            // depositItem
            // 
            this.depositItem.Name = "depositItem";
            this.depositItem.Size = new System.Drawing.Size(168, 26);
            this.depositItem.Text = "Deposit";
            this.depositItem.Click += new System.EventHandler(this.depositItem_Click);
            // 
            // withdrawalItem
            // 
            this.withdrawalItem.Name = "withdrawalItem";
            this.withdrawalItem.Size = new System.Drawing.Size(168, 26);
            this.withdrawalItem.Text = "Withdrawal";
            this.withdrawalItem.Click += new System.EventHandler(this.withdrawalItem_Click);
            // 
            // transferItem
            // 
            this.transferItem.Name = "transferItem";
            this.transferItem.Size = new System.Drawing.Size(168, 26);
            this.transferItem.Text = "Transfer";
            this.transferItem.Click += new System.EventHandler(this.transferItem_Click);
            // 
            // changeStatusToolStripMenuItem
            // 
            this.changeStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeItem,
            this.inactiveItem});
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.changeStatusToolStripMenuItem.Text = "Change Status";
            // 
            // activeItem
            // 
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(143, 26);
            this.activeItem.Text = "Active";
            this.activeItem.Click += new System.EventHandler(this.activeItem_Click);
            // 
            // inactiveItem
            // 
            this.inactiveItem.Name = "inactiveItem";
            this.inactiveItem.Size = new System.Drawing.Size(143, 26);
            this.inactiveItem.Text = "Inactive";
            this.inactiveItem.Click += new System.EventHandler(this.inactiveItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(408, 555);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Accounts";
            // 
            // lblAccountsCount
            // 
            this.lblAccountsCount.AutoSize = true;
            this.lblAccountsCount.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.lblAccountsCount.ForeColor = System.Drawing.SystemColors.Info;
            this.lblAccountsCount.Location = new System.Drawing.Point(563, 555);
            this.lblAccountsCount.Name = "lblAccountsCount";
            this.lblAccountsCount.Size = new System.Drawing.Size(49, 20);
            this.lblAccountsCount.TabIndex = 4;
            this.lblAccountsCount.Text = "[N/3]";
            // 
            // ctrlCustomerAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.lblAccountsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCustomerAccounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlCustomerCard1);
            this.Name = "ctrlCustomerAccounts";
            this.Size = new System.Drawing.Size(1031, 783);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerAccounts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Customer.UserControls.ctrlCustomerCard ctrlCustomerCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCustomerAccounts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsMainItem;
        private System.Windows.Forms.ToolStripMenuItem depositItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawalItem;
        private System.Windows.Forms.ToolStripMenuItem transferItem;
        private System.Windows.Forms.ToolStripMenuItem changeStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeItem;
        private System.Windows.Forms.ToolStripMenuItem inactiveItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAccountsCount;
    }
}
