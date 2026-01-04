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
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            ctrlAddEditUser1.__AddNewUser();
            ctrlAddEditUser1.__OperationSucceeded += _UserAddedSuccessfully;
            ctrlAddEditUser1.__OperationFailed += _FaildToAddUser;
            ctrlAddEditUser1.__OperationCanceld += _OperationCanceld;
        }
        
        private void _UserAddedSuccessfully(clsUser user)
        {
            MessageBox.Show("User Is Added Successfully");
        }
        private void _FaildToAddUser()
        {
            MessageBox.Show("Can't Save User Data [ Operation Fialed ]","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _OperationCanceld()
        {
            if (MessageBox.Show("Sure To Leave?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }


    }
}
