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
        }
        public frmCustomerAccounts(int customerID)
        {
            InitializeComponent();
            ctrlCustomerAccounts1.__LoadCustomerAccounts(customerID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
