using Bank_BusinessLayer.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.UserActivityReport
{
    public partial class frmUserReportCard : Form
    {
        public frmUserReportCard(clsAuditUserActions report)
        {
            InitializeComponent();
            ctrlUserReportCard1.__ShowCard(report);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
