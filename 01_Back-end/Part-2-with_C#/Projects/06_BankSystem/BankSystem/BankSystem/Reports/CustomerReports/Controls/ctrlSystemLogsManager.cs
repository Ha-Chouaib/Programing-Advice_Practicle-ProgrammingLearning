using BankSystem.Reports.Forms;
using BankSystem.Reports.UserReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.Controls.Customer
{
    public partial class ctrlSystemLogsManager : UserControl
    {
        public ctrlSystemLogsManager()
        {
            InitializeComponent();
            
        }

        private void btnTransactionsHist_Click(object sender, EventArgs e)
        {
            frmTransactionsHistory history = new frmTransactionsHistory();
            history.ShowDialog();
        }

        private void btnCustomerReports_Click(object sender, EventArgs e)
        {
            frmCustomerReports customerReports = new frmCustomerReports();
            customerReports.ShowDialog();
        }

        private void btnUserActivity_Click(object sender, EventArgs e)
        {
            frmManageUserReports userActivity = new frmManageUserReports();
            userActivity.ShowDialog();
        }

        private void btnLoggingHist_Click(object sender, EventArgs e)
        {
            frmLoggingHistory history = new frmLoggingHistory();
            history.ShowDialog();
        }
    }
}
