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
    public partial class frmTransferMoney : Form
    {
        public frmTransferMoney()
        {
            InitializeComponent();
            _HasPermissions();
            ctrlTransferMoney1.__TransferMoney();
        }
        public frmTransferMoney(clsAccounts accountFrom, clsAccounts accountTo)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlTransferMoney1.__TransferMoney(accountFrom, accountTo);
        }
        public frmTransferMoney(int accountFromId, int accountToId)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlTransferMoney1.__TransferMoney(accountFromId, accountToId);
        }
        public frmTransferMoney(clsAccounts accountFrom)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlTransferMoney1.__TransferMoney(accountFrom);
        }
        public frmTransferMoney(int accountFromId)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlTransferMoney1.__TransferMoney(accountFromId);

        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Transactions_Transfer))
            {
                MessageBox.Show("You don't have permission to perform transfer money transactions.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        private void frmTransferMoney_Load(object sender, EventArgs e)
        {
            ctrlTransferMoney1.__OperationDoneSuccessfully += _OperationSuceeded;
        }
        private void _OperationSuceeded()
        {
            MessageBox.Show("Operation Done Successfully");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close()
;        }

       
    }
}
