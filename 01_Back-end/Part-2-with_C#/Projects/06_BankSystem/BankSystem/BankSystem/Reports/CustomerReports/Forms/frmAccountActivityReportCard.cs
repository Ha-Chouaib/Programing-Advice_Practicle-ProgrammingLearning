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
    public partial class frmAccountActivityReportCard : Form
    {
        public frmAccountActivityReportCard()
        {
            InitializeComponent();
        }
        public frmAccountActivityReportCard(clsAccountActivityReports Report)
        {
            InitializeComponent();
            ctrlAccountActtivityReport_Card1.__DisplayReportCard(Report);
        }

        public frmAccountActivityReportCard(int accountID,DateTime RequestedDate)
        {
            InitializeComponent();
            ctrlAccountActtivityReport_Card1.__DisplayReportCard(accountID,RequestedDate);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
