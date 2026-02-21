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
    public partial class frmDormantAccountsReportCard : Form
    {
        public frmDormantAccountsReportCard()
        {
            InitializeComponent();
        }

        public frmDormantAccountsReportCard(clsDormantAccountsReports report)
        {
            InitializeComponent();
            ctrlDormantAccountsReportCard1.__DisplayReportCard(report);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
