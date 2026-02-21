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
    public partial class frmEditCustomer : Form
    {
        public frmEditCustomer()
        {
            InitializeComponent();
            _HasPermissions();
            ctrlAddEditCustomer1.__EditCustomer();
            ctrlAddEditCustomer1.__Added_Updated_Record += GetOperationResult;
            ctrlAddEditCustomer1.__CancelOperation += _CloseForm;
        }
        public frmEditCustomer(int customerID)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlAddEditCustomer1.__EditCustomer(customerID);
            ctrlAddEditCustomer1.__Added_Updated_Record += GetOperationResult;
            ctrlAddEditCustomer1.__CancelOperation += _CloseForm;
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_Edit))
            {
                MessageBox.Show("You don't have permission to Edit customer Data.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }

        public Action<clsCustomer> __CustomerRecoredUpdated;
        public Action __OperatinDoneSuccessfully;
        private void GetOperationResult(clsCustomer UpdatedRecord)
        {
            if (UpdatedRecord != null)
            {
                __CustomerRecoredUpdated?.Invoke(UpdatedRecord);
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
