using Bank_BusinessLayer;
using BankSystem.Accounts.Forms;
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
        public void __LoadCustomerAccounts(int CustomerID)
        {
            InitializeComponent();
            if(clsCustomer.IsCustomerExistsByID(CustomerID))
            {
                ctrlCustomerCard1.__DisplayCustomerData(clsCustomer.FindCustomerByID(CustomerID));
                dgvCustomerAccounts.DataSource = new BindingSource(clsCustomer.GetCustomerAccounts(CustomerID), null);

            }
        }
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsAccounts selectedAccount = new clsAccounts();
            if (dgvCustomerAccounts.CurrentRow != null)
            {
                selectedAccount = clsAccounts.FindByID((int)dgvCustomerAccounts.CurrentRow.Cells[0].Value);
            } 
            if(selectedAccount != null)
            {

                contextMenuStrip1.Items["activeItem"].Enabled = !selectedAccount.IsActive;
                contextMenuStrip1.Items["inactiveItem"].Enabled = selectedAccount.IsActive;

                contextMenuStrip1.Items["transactionsMainItem"].Enabled = (selectedAccount.Balance > 0);


            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindAccount displayAccountInf = new frmFindAccount(clsAccounts.FindByID((int)dgvCustomerAccounts.CurrentRow.Cells[0].Value));
            displayAccountInf.ShowDialog();
        }

        private void depositItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO DO");
        }

        private void transferItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO DO");

        }

        private void withdrawalItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO DO");

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
    }
}
