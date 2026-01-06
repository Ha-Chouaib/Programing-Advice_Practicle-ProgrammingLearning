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

namespace BankSystem.User.Forms
{
    public partial class frmEditUser : Form
    {
        public frmEditUser()
        {
            InitializeComponent();
            ctrlAddEditUser1.__EditUser();
            ctrlAddEditUser1.__OperationSucceeded += _RecordEditedSuccessfully;
            ctrlAddEditUser1.__OperationFailed += _FaildToEditUser;
            ctrlAddEditUser1.__OperationCanceld += _OperationCanceld;
        }
        public frmEditUser(int userID)
        {
            InitializeComponent();
            ctrlAddEditUser1.__EditUser(userID);
            ctrlAddEditUser1.__OperationSucceeded += _RecordEditedSuccessfully;
            ctrlAddEditUser1.__OperationFailed += _FaildToEditUser;
            ctrlAddEditUser1.__OperationCanceld += _OperationCanceld;

        }
        public Action __OperationDoneSuccessfully;
        private void _RecordEditedSuccessfully(clsUser user)
        {
            MessageBox.Show(" Done Successfully");
            __OperationDoneSuccessfully?.Invoke();
        }
        private void _FaildToEditUser()
        {
            MessageBox.Show("Can't Edit User Data [ Operation Fialed ]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _OperationCanceld()
        {
            if (MessageBox.Show("Sure To Leave?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
