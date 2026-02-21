using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Transactions.Forms
{
    public partial class frmWithdrawMoney : Form
    {
        public frmWithdrawMoney()
        {
            InitializeComponent();
            _HasPermissions();
            ctrlDeposit_Withdrawal1.__Withdrawal();
        }
        public frmWithdrawMoney(clsAccounts account)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlDeposit_Withdrawal1.__Withdrawal(account);
        }
        public frmWithdrawMoney(int accountId)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlDeposit_Withdrawal1.__Withdrawal(accountId);
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Transactions_Withdraw))
            {
                MessageBox.Show("You don't have permission to perform withdrawal transactions.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        private void frmWithdrawMoney_Load(object sender, EventArgs e)
        {
            ctrlDeposit_Withdrawal1.__OperationDoneSuccessfully += _OperationSuceeded;
        }
        private void _OperationSuceeded()
        {
            MessageBox.Show("Operation Done Successfully");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
