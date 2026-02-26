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
    public partial class ctrlCustomerSummaryReportCard : UserControl
    {
        public ctrlCustomerSummaryReportCard()
        {
            InitializeComponent();
        }
        clsCustomerSummaryReports Report;
        public void __DisplayReportCard(clsCustomerSummaryReports Report)
        {
            if (Report == null) 
            {
                MessageBox.Show("InValid Object Customer Summary Report Returns NULL Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            this.Report = Report ;
            txtReportID.Text = Report.CustomerReportID.ToString();
            txtCustomerID.Text = Report.CustomerID.ToString();
            txtTotalAccounts.Text = Report.TotalAccounts.ToString();
            txtTotalBalance.Text = Report.TotalBalance.ToString("C2");
            txtActiveAccounts.Text = Report.ActiveAccounts.ToString();
            txtLastActivityDate.Text = Report.LastActivityDate.ToString("d");
            txtCustomerStatus.Text = Report.CustomerStatus ? "Active" : "Inactive";

            lnkCustomerDetails.Enabled = Report.CustomerID == -1 ? false : true;
        }
        public void __DisplayReportCard(int customerID)
        {
            clsCustomerSummaryReports report = clsCustomerSummaryReports.Find(customerID);
            __DisplayReportCard (report);
        }
        private void lnkCustomerDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomerCard Card = new frmCustomerCard(Report.Customer);
            Card.ShowDialog();
        }
    }
}
