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

namespace BankSystem.Accounts.Forms
{
    public partial class frmAddNewAccount : Form
    {
        public frmAddNewAccount()
        {
            InitializeComponent();
            _HasPermissions();

            ctrlAddNewAccount1.__OnOperationDone += NewAccountAddedSucessfully;
            ctrlAddNewAccount1.__OnOperationaCanceled += Close_Cancel;
        }
        public frmAddNewAccount(int customerID)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlAddNewAccount1.__AddNewAccount(customerID);
            ctrlAddNewAccount1.__OnOperationDone += NewAccountAddedSucessfully;
            ctrlAddNewAccount1.__OnOperationaCanceled += Close_Cancel;
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Accounts_Add))
            {
                MessageBox.Show("You don't have permission to add accounts.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        public Action __OperationDoneSuccessfully;
        private void NewAccountAddedSucessfully(clsAccounts account)
        {
            MessageBox.Show("New account added sucessfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            __OperationDoneSuccessfully?.Invoke();
        }
        private void Close_Cancel()
        {
            if(MessageBox.Show("Are you sure you want to cancel adding new account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
