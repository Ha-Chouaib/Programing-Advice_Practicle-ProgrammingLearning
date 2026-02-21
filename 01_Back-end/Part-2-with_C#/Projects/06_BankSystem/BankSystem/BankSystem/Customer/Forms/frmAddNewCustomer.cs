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

namespace BankSystem.Customer.Forms
{
    public partial class frmAddNewCustomer : Form
    {
        public frmAddNewCustomer()
        {
            InitializeComponent();
            _HasPermissions();

            ctrlAddEditCustomer1.__AddNewCustomer();
            ctrlAddEditCustomer1.__Added_Updated_Record += GetOperationResult;
            ctrlAddEditCustomer1.__CancelOperation += _CloseForm;
        }
        public frmAddNewCustomer(int personID)
        {
            InitializeComponent();
            _HasPermissions();

            ctrlAddEditCustomer1.__AddNewCustomer(personID);
            ctrlAddEditCustomer1.__Added_Updated_Record += GetOperationResult;
            ctrlAddEditCustomer1.__CancelOperation += _CloseForm;
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_Add))
            {
                MessageBox.Show("You don't have permission to add customers.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        public Action<clsCustomer> __NewCustomerAdded;
        public Action __OperatinDoneSuccessfully;
        private void GetOperationResult(clsCustomer newCustomer)
        {
            if (newCustomer != null)
            {
                __NewCustomerAdded?.Invoke(newCustomer);
                __OperatinDoneSuccessfully?.Invoke();
                MessageBox.Show("Customer record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Failed to save customer record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _CloseForm()
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
