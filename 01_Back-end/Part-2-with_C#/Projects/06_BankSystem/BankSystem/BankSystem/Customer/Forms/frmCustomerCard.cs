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
        public frmCustomerCard()
        {
            InitializeComponent();
        }
        public frmCustomerCard(clsCustomer customer)
        {
            InitializeComponent();
            if (customer != null)
                ctrlCustomerCard1.__DisplayCustomerData(customer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
