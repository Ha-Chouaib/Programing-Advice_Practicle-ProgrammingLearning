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
    public partial class ctrlBalanceStatementReportCard : UserControl
    {
        public ctrlBalanceStatementReportCard()
        {
            InitializeComponent();
        }
        clsBalanceStatementReports Report;
        public void __DisplayReportCard(clsBalanceStatementReports BalanceStatementReport)
        {
            if (BalanceStatementReport == null)
            {
                MessageBox.Show("InValid Object Balance Statement Report Returns NULL Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            Report = BalanceStatementReport;

            txtReportID.Text = BalanceStatementReport.CustomerReportID.ToString();
            txtAccountID.Text = BalanceStatementReport.AccountID.ToString();
            txtFromDate.Text = BalanceStatementReport.FromDate.ToShortDateString();
            txtToDate.Text = BalanceStatementReport.ToDate.ToShortDateString();
            txtReportID.Text = BalanceStatementReport.ReportDate.ToString();
            txtOpeningBalance.Text = BalanceStatementReport.OpeningBalance.ToString("C2");
            txtClosingBalance.Text = BalanceStatementReport.ClosingBalance.ToString("C2");

            lnkCustomerDetails.Enabled = (BalanceStatementReport.CustomerID == -1) ? false : true;
            lnkAccountDetails.Enabled = (BalanceStatementReport.AccountID == -1) ? false : true;

        }

        public void __DisplayReportCard(int customerID,int AcountID)
        {
            clsBalanceStatementReports report = clsBalanceStatementReports.Find(customerID, AcountID);
            __DisplayReportCard(report);
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
    }
}
