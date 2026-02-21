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
    public partial class frmBalanceStatementReportCard : Form
    {
        public frmBalanceStatementReportCard()
        {
            InitializeComponent();
        }
        public frmBalanceStatementReportCard(clsBalanceStatementReports Report)
        {
            InitializeComponent();
            ctrlBalanceStatementReportCard1.__DisplayReportCard(Report);
        }
        public frmBalanceStatementReportCard(int customerID, int accountID)
        {
            InitializeComponent();
            ctrlBalanceStatementReportCard1.__DisplayReportCard(customerID, accountID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
