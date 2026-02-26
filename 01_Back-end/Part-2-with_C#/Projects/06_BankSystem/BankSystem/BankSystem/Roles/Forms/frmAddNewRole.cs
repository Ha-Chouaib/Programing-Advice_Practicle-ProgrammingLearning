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

namespace BankSystem.Roles.Forms
{
    public partial class frmAddNewRole : Form
    {
        public frmAddNewRole()
        {
            InitializeComponent();
            ctrlAddEditRole1.__AddRole();

            ctrlAddEditRole1.__OperationDoneSuccessfully += OnOperationSuccess;
            ctrlAddEditRole1.__OperationFailed += OnOperationFailed;
            ctrlAddEditRole1.__OperationCancelled += OnOperationCancelled;
        }
        public Action __OperationDoneSuccessfully;
        public Action<clsRole> __RoleAddedSuccessfully;
        private void OnOperationSuccess(clsRole Addedrole)
        {
            MessageBox.Show("Role added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            __OperationDoneSuccessfully?.Invoke();
            __RoleAddedSuccessfully?.Invoke(Addedrole);
        }
        private void OnOperationFailed()
        {
            MessageBox.Show("Failed to add role: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnOperationCancelled()
        {
           // MessageBox.Show("Role addition cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }
    }
}
