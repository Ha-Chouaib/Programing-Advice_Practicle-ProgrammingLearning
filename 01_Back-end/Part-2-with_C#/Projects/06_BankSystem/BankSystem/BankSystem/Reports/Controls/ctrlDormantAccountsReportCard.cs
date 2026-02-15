using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Customer.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.Controls
{
    public partial class ctrlDormantAccountsReportCard : UserControl
    {
        public ctrlDormantAccountsReportCard()
        {
            InitializeComponent();
        }
        clsDormantAccountsReports Report;
        public void __DisplayReportCard(clsDormantAccountsReports DormantAccountsReport)
        {
            if (DormantAccountsReport == null) return;
            Report = DormantAccountsReport;
            txtReportID.Text = DormantAccountsReport.CustomerReportID.ToString();
            txtCustomerID.Text = DormantAccountsReport.CustomerID.ToString();
            txtDormantMonths.Text = DormantAccountsReport.DormantMonths.ToString();
            txtLastTransactionDate.Text = DormantAccountsReport.LastTransactionDate.ToShortDateString();
            txtReportDate.Text = DormantAccountsReport.ReportDate.ToString();
            lnkCustomerDetails.Enabled = (DormantAccountsReport.CustomerID == -1) ? false : true;
        }

        private void lnkCustomerDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomerCard Card = new frmCustomerCard(Report.Customer);
            Card.ShowDialog();
        }
    }
}
