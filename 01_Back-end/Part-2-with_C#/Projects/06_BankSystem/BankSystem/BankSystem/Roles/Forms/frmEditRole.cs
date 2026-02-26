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
    public partial class frmEditRole : Form
    {
        public frmEditRole(clsRole roleToEdit)
        {
            InitializeComponent();
            ctrlAddEditRole1.__EditRole(roleToEdit);

            ctrlAddEditRole1.__OperationDoneSuccessfully += OnOperationSuccess;
            ctrlAddEditRole1.__OperationFailed += OnOperationFailed;
            ctrlAddEditRole1.__OperationCancelled += OnOperationCancelled;
        }
        public Action __OperationDoneSuccessfully;
        public Action<clsRole> __RoleUpdatedSuccessfully;
        private void OnOperationSuccess(clsRole Updateddrole)
        {
            MessageBox.Show("Role Updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            __OperationDoneSuccessfully?.Invoke();
            __RoleUpdatedSuccessfully?.Invoke(Updateddrole);
        }
        private void OnOperationFailed()
        {
            MessageBox.Show("Failed to Update role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnOperationCancelled()
        {
           //MessageBox.Show("Role Editing cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }
    }
}
