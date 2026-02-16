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

namespace BankSystem.Customer.UserControls
{
    public partial class ctrlFindCustomer : UserControl
    {
        public ctrlFindCustomer()
        {
            InitializeComponent();
        }

        public Action<clsCustomer> __GetCustomerRecord;
        public Action<int> __GetCustomerID;
        public void __initializeFindControl()
        {
            ctrlFind1.__Initializing(new Dictionary<string, string>
            { { "Customer ID", "CustomerID" }, { "Person ID", "PersonID" } }, clsCustomer.FindBy);
            ctrlFind1.__txtSearchTerm.KeyPress += (s, e) => { e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)); };
            ctrlFind1.__ObjectFound += _ShowData;
        }
        public void __DisplayCustomerData(clsCustomer customer)
        {
            if (customer == null) return;
            ctrlFind1.__FindOptionsCombo.Text = "Customer ID";
            ctrlFind1.__txtSearchTerm.Text = customer.CustomerID.ToString();
            ctrlFind1.Enabled = true;
            _ShowData(this, customer);
        }
        private void _ShowData(object s, object obj)
        {
            clsCustomer customer = (clsCustomer)obj;
            if (customer != null)
            {
                ctrlCustomerCard1.__DisplayCustomerData(customer);
                __GetCustomerID?.Invoke(customer.CustomerID);
                __GetCustomerRecord?.Invoke(customer);
            }
        }
    }
}
