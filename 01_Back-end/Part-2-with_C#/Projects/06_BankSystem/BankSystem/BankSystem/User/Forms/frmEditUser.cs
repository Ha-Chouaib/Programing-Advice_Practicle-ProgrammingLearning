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
            _HasPermissions();
            ctrlAddEditUser1.__EditUser();
            ctrlAddEditUser1.__OperationSucceeded += _RecordEditedSuccessfully;
            ctrlAddEditUser1.__OperationFailed += _FaildToEditUser;
            ctrlAddEditUser1.__OperationCanceld += _OperationCanceld;
        }
        public frmEditUser(int userID)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlAddEditUser1.__EditUser(userID);
            ctrlAddEditUser1.__OperationSucceeded += _RecordEditedSuccessfully;
            ctrlAddEditUser1.__OperationFailed += _FaildToEditUser;
            ctrlAddEditUser1.__OperationCanceld += _OperationCanceld;

        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_Edit))
            {
                MessageBox.Show("You don't have permission to edit Users.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
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
