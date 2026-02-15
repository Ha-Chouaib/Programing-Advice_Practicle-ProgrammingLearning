using Bank_BusinessLayer.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.Forms
{
    public partial class frmCustomerSummaryCard : Form
    {
        public frmCustomerSummaryCard()
        {
            InitializeComponent();
        }
        public frmCustomerSummaryCard(clsCustomerSummaryReports Report)
        {
            InitializeComponent();
            ctrlCustomerSummaryReportCard1.__DisplayReportCard(Report);
        }
        public frmCustomerSummaryCard(int CustomerID)
        {
            InitializeComponent();
            ctrlCustomerSummaryReportCard1.__DisplayReportCard(CustomerID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
