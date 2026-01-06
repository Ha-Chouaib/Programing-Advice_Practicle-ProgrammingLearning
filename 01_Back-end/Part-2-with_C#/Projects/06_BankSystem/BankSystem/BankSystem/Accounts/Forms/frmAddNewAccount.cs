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
            ctrlAddNewAccount1.__OnOperationDone += NewAccountAddedSucessfully;
            ctrlAddNewAccount1.__OnOperationaCanceled += Close_Cancel;
        }
        public frmAddNewAccount(int customerID)
        {
            InitializeComponent();
            ctrlAddNewAccount1.__AddNewAccount(customerID);
            ctrlAddNewAccount1.__OnOperationDone += NewAccountAddedSucessfully;
            ctrlAddNewAccount1.__OnOperationaCanceled += Close_Cancel;
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
