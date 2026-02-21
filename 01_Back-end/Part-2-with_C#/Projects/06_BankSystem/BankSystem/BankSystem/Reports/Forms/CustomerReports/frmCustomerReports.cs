using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports
{
    public partial class frmCustomerReports : Form
    {
        public frmCustomerReports()
        {
            InitializeComponent();
            _HasPermissions();
            _InitializeReportTypes();
            
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Reports_Customer))
            {
                MessageBox.Show("You don't have permission to Navigate customer reports.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        enum enCustomerReports { enCustomerSummary = 1, enAccountActivity = 2, enBalanceStatement = 3, enDormantAccounts = 4 }
        public class SelectReportEventArgs : EventArgs
        {
            public Button CurrentReport { get; }
            public Button PreviousReport { get; }

            public SelectReportEventArgs(Button CurrentReport, Button PreviousReport)
            {
                this.CurrentReport = CurrentReport;
                this.PreviousReport = PreviousReport;
            }

        }
        public event EventHandler<SelectReportEventArgs> OnReportSelected;

        Button CurrentReport { get; set; }
        Dictionary<enCustomerReports, Action> _reportLoaders;

        private void ReportButton_Click(object sender, EventArgs e)
        {
            Button previous = CurrentReport;
            CurrentReport = (Button)sender;
            OnReportSelected?.Invoke(this, new SelectReportEventArgs(CurrentReport, previous));
        }

        private void _InitializeReportTypes()
        {
            ctrlManageRecords1.__AddNewBtn.Visible = false;
            ctrlManageRecords1.__UpdateBtn.Visible = false;


            CurrentReport = btnCustomerSummary;

            btnCustomerSummary.Tag = enCustomerReports.enCustomerSummary;
            btnAccountActivity.Tag = enCustomerReports.enAccountActivity;
            btnBalanceStatment.Tag = enCustomerReports.enBalanceStatement;
            btnDormantAccounts.Tag = enCustomerReports.enDormantAccounts;

            btnCustomerSummary.Click += ReportButton_Click;
            btnAccountActivity.Click += ReportButton_Click;
            btnBalanceStatment.Click += ReportButton_Click;
            btnDormantAccounts.Click += ReportButton_Click;

            _PerformReportsSelection();
            var ReportInitializer = new clsInitializeCustomeSummaryrReport(ref ctrlManageRecords1);
            ReportInitializer.LoadManageRecordsControl();
        }

        private void _RegularReportButtonStyles(Button PreviousReport)
        {
            PreviousReport.BackColor = Color.Black;
            PreviousReport.ForeColor = Color.Cyan;
            PreviousReport.FlatStyle = FlatStyle.Flat;
        }
        private void _SelectedReportButtonStyles(Button CurrentReport)
        {
            CurrentReport.BackColor = Color.Cyan;
            CurrentReport.ForeColor = Color.Black;
            CurrentReport.FlatStyle = FlatStyle.Popup;
        }
        
        private void _PerformReportsSelection()
        {

            OnReportSelected += (sender, e) =>
            {
                _RegularReportButtonStyles(e.PreviousReport);
                _SelectedReportButtonStyles(e.CurrentReport);

                _reportLoaders = new Dictionary<enCustomerReports, Action>
                {
                    { enCustomerReports.enCustomerSummary, () => new clsInitializeCustomeSummaryrReport(ref ctrlManageRecords1).LoadManageRecordsControl() },
                    { enCustomerReports.enAccountActivity, () => new clsInitializeAccountActivityReport(ref ctrlManageRecords1).LoadManageRecordsControl() },
                    { enCustomerReports.enBalanceStatement, () => new clsInitializeBalanceStatementReport(ref ctrlManageRecords1).LoadManageRecordsControl() },
                    { enCustomerReports.enDormantAccounts, () => new clsInitializeDormantAccountsReport(ref ctrlManageRecords1).LoadManageRecordsControl() }
                };
                _reportLoaders[(enCustomerReports)e.CurrentReport.Tag].Invoke();
            };
        }
        

    }
}
