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
            ctrlFind1.__Initializing(new Dictionary<string, string>
            { { "Customer ID", "CustomerID" }, { "Person ID", "PersonID" } },clsCustomer.FindBy);
            ctrlFind1.__txtSearchTerm.KeyPress+=(s, e) =>{ e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));};
            ctrlFind1.__ObjectFound += _ShowData;
        }
        private void _ShowData(object s,object obj)
        {
            if (obj != null)
                ctrlCustomerCard1.__DisplayCustomerData((clsCustomer)obj);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
