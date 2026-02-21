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
    public partial class frmCustomerCard : Form
    {
       
        public frmCustomerCard(clsCustomer customer)
        {
            InitializeComponent();
            _HasPermissions();
            if (customer != null)
                ctrlCustomerCard1.__DisplayCustomerData(customer);
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_Find))
            {
                MessageBox.Show("You don't have permission to Read customer Info.",
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
