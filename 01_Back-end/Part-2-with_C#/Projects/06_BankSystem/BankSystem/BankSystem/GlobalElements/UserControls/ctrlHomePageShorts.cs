using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bank_BusinessLayer;
using BankSystem.Accounts.Forms;
using BankSystem.Customer.Forms;
using BankSystem.GlobalElements.Forms;

namespace BankSystem.GlobalElements.UserControls
{
    public partial class ctrlHomePageShorts : UserControl
    {
        public ctrlHomePageShorts()
        {
            InitializeComponent();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {

            frmMappTransactions transactionsForm = new frmMappTransactions(btnTransactions);
            transactionsForm.ShowDialog();
        }

        private void btnFindAccount_Click(object sender, EventArgs e)
        {
            frmFindAccount findAccountForm = new frmFindAccount();
            findAccountForm.ShowDialog();
        }

        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            frmAddNewAccount frmAddAccount = new frmAddNewAccount();
            frmAddAccount.ShowDialog();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            frmFindCustomer frmFindCustomer = new frmFindCustomer();
            frmFindCustomer.ShowDialog();
        }
    }
}
