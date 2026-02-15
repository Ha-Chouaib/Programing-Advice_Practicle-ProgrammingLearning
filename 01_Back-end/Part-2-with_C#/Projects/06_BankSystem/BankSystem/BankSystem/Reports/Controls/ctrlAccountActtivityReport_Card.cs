using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Accounts.Forms;
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
    public partial class ctrlAccountActtivityReport_Card : UserControl
    {
        public ctrlAccountActtivityReport_Card()
        {
            InitializeComponent();
        }
        private clsAccountActivityReports Report;
        public void __DisplayReportCard(clsAccountActivityReports AccountActivityReport)
        {
            if (AccountActivityReport == null)
            {
                MessageBox.Show("InValid Object Account Activity Report Returns NULL Value","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            Report = AccountActivityReport;

            txtReportID.Text = AccountActivityReport.CustomerReportID.ToString();
            txtAccountID.Text = AccountActivityReport.AccountID.ToString();
            txtCustomerID.Text = AccountActivityReport.CustomerID.ToString();
            txtFromDate.Text = AccountActivityReport.FromDate.ToShortDateString();
            txtToDate.Text = AccountActivityReport.ToDate.ToShortDateString();
            txtTransactionsCount.Text = AccountActivityReport.TransactionCount.ToString();
            txtTotalDebit.Text = AccountActivityReport.TotalDebit.ToString("C2");
            txtTotalCredit.Text = AccountActivityReport.TotalCredit.ToString("C2");
            txtReportID.Text = AccountActivityReport.ReportDate.ToString();

            lnkCustomerDetails.Enabled = (AccountActivityReport.CustomerID == -1) ? false : true;
            lnkAccountDetails.Enabled = (AccountActivityReport.AccountID == -1) ? false : true;


        }
        public void __DisplayReportCard(int accountID,DateTime requestedDate)
        {
            clsAccountActivityReports AccountActivityReport = clsAccountActivityReports.Find(accountID,requestedDate);
            __DisplayReportCard(AccountActivityReport);
        }

        private void lnkCustomerDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomerCard Card = new frmCustomerCard(Report.Customer);
            Card.ShowDialog();
        }

        private void lnkAccountDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFindAccount AccountCard = new frmFindAccount(Report.TargetAccount);
            AccountCard.ShowDialog();

        }

        private void ctrlAccountActtivityReport_Card_Load(object sender, EventArgs e)
        {

        }
    }
}
