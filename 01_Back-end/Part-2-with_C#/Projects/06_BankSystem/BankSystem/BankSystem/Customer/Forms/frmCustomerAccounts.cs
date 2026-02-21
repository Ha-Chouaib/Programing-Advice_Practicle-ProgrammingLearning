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
    public partial class frmCustomerAccounts : Form
    {
        public frmCustomerAccounts()
        {
            InitializeComponent();
            _HasPermissions();
            ctrlCustomerAccounts1.__InitializControl();
        }
        public frmCustomerAccounts(int customerID)
        {
            InitializeComponent();
            _HasPermissions();
            ctrlCustomerAccounts1.__LoadCustomerAccounts(customerID);
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_ViewAccounts))
            {
                MessageBox.Show("You don't have permission to view customer accounts.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
