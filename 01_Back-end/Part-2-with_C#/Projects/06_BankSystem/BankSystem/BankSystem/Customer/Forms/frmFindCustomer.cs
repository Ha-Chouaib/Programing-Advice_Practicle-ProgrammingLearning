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
    public partial class frmFindCustomer : Form
    {
        public frmFindCustomer()
        {
            InitializeComponent();
            ctrlFindCustomer1.__initializeFindControl();
        }
        public frmFindCustomer(int customerID)
        {
            InitializeComponent();
            ctrlFindCustomer1.__DisplayCustomerData(clsCustomer.FindCustomerByID(customerID));
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
