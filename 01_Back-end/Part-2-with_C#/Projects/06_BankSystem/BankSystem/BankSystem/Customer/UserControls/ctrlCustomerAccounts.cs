using Bank_BusinessLayer;
using BankSystem.Accounts.Forms;
using BankSystem.Transactions.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Accounts.UserControls
{
    public partial class ctrlCustomerAccounts : UserControl
    {
        public ctrlCustomerAccounts()
        {
            InitializeComponent();
           
        }
        clsAccounts _selectedAccount = new clsAccounts();

        public void __InitializControl()
        {
            ctrlFindCustomer1.__initializeFindControl();
            ctrlFindCustomer1.__GetCustomerID += _GetCustomerID;
        }
        public void __LoadCustomerAccounts(int CustomerID)
        {
           
            if(clsCustomer.IsCustomerExistsByID(CustomerID))
            {
                ctrlFindCustomer1.__DisplayCustomerData(clsCustomer.FindCustomerByID(CustomerID));
            }
            _GetCustomerID(CustomerID);
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvCustomerAccounts.CurrentRow != null)
            {
                _selectedAccount = clsAccounts.FindByID((int)dgvCustomerAccounts.CurrentRow.Cells[0].Value);
            } 
            if(_selectedAccount != null)
            {

                activeItem.Enabled = !_selectedAccount.IsActive;
                inactiveItem.Enabled = _selectedAccount.IsActive;

                transferItem.Enabled = withdrawalItem.Enabled = (_selectedAccount.Balance > 0);

            }
            depositItem.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Transactions_Deposit);
            withdrawalItem.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Transactions_Withdraw);
            transferItem.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Transactions_Transfer);
        }
        private void _GetCustomerID(int CustomerID)
        {
           
            if (clsCustomer.IsCustomerExistsByID(CustomerID))
            {
                dgvCustomerAccounts.DataSource = new BindingSource(clsCustomer.GetCustomerAccounts(CustomerID), null);
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindAccount displayAccountInf = new frmFindAccount(clsAccounts.FindByID((int)dgvCustomerAccounts.CurrentRow.Cells[0].Value));
            displayAccountInf.ShowDialog();
        }

        private void depositItem_Click(object sender, EventArgs e)
        {
            frmDepositMoney dep = new frmDepositMoney(_selectedAccount);
            dep.ShowDialog();
        }

        private void transferItem_Click(object sender, EventArgs e)
        {
            frmTransferMoney tran = new frmTransferMoney(_selectedAccount);
            tran.ShowDialog();
        }

        private void withdrawalItem_Click(object sender, EventArgs e)
        {
            frmWithdrawMoney withd = new frmWithdrawMoney(_selectedAccount);
            withd.ShowDialog();
        }

        private void activeItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Activate this Accounts?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                clsAccounts.UpdateStatus((int)dgvCustomerAccounts.CurrentRow.Cells[0].Value, true);

        }

        private void inactiveItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To disactivate this Accounts?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                clsAccounts.UpdateStatus((int)dgvCustomerAccounts.CurrentRow.Cells[0].Value, false);

        }

        private void ctrlCustomerAccounts_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomerAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
            if (dgvCustomerAccounts.Columns[e.ColumnIndex].Name == "AccountType" && e.Value is byte type)
            {
                e.Value = type == 1 ? "Individual" : type == 2 ? "Business" : "Save";
                e.FormattingApplied = true;
            }
            if (dgvCustomerAccounts.Columns[e.ColumnIndex].Name == "CreatedByUserID" && e.Value is int usr)
            {
                e.Value = clsUser.FindUserByID(usr)?.UserName ?? "(N/A)";
            }

        }
    }
}
