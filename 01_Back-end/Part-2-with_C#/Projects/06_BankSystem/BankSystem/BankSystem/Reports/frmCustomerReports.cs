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
            
        }
        enum enCustomerReports { enCustomerSummary = 1, enAccountActivity = 2, enBalanceStatement = 3, enDormantAccounts = 4 }
        public class SelectReportEventArgs : EventArgs
        {
            public Button CurrentReport { get; }
            public Button PreviousReport { get; }

            public SelectReportEventArgs (Button CurrentReport, Button PreviousReport)
            {
                this.CurrentReport = CurrentReport;
                this.PreviousReport = PreviousReport;
            }

        }
        public event EventHandler<SelectReportEventArgs> OnReportSelected;

        Button CurrentReport { get; set; } 

        private void InitializeReportsTypes()
        {
            ctrlManageRecords1.__AddNewBtn.Visible = false;
            ctrlManageRecords1.__UpdateBtn.Visible = false;


            CurrentReport = btnCustomerSummary;

            btnCustomerSummary.Tag = enCustomerReports.enCustomerSummary;
            btnAccountActivity.Tag = enCustomerReports.enAccountActivity;
            btnBalanceStatment.Tag = enCustomerReports.enBalanceStatement;
            btnDormantAccounts.Tag = enCustomerReports.enDormantAccounts;

            btnCustomerSummary.Click += (sender, e) =>
            {
                Button PreviousReport = CurrentReport;
                CurrentReport = (Button)sender;
                OnReportSelected?.Invoke(this, new SelectReportEventArgs(PreviousReport,CurrentReport));
            };
            btnAccountActivity.Click += (sender, e) =>
            {
                Button PreviousReport = CurrentReport;
                CurrentReport = (Button)sender;
                OnReportSelected?.Invoke(this, new SelectReportEventArgs(PreviousReport, CurrentReport));
            };
            btnBalanceStatment.Click += (sender, e) =>
            {
                Button PreviousReport = CurrentReport;
                CurrentReport = (Button)sender;
                OnReportSelected?.Invoke(this, new SelectReportEventArgs(PreviousReport, CurrentReport));
            };
            btnDormantAccounts.Click += (sender, e) =>
            {
                Button PreviousReport = CurrentReport;
                CurrentReport = (Button)sender;
                OnReportSelected?.Invoke(this, new SelectReportEventArgs(PreviousReport, CurrentReport));
            };
        }

       private void _RegularReportButtonStyles(Button PreviousReport)
       {
            CurrentReport.BackColor = Color.Black;
            CurrentReport.ForeColor = Color.Cyan;
            CurrentReport.FlatStyle = FlatStyle.Flat;
        }
        private void _SelectedReportButtonStyles(Button CurrentReport)
        {
            CurrentReport.BackColor = Color.Cyan;
            CurrentReport.ForeColor = Color.Black;
            CurrentReport.FlatStyle = FlatStyle.Popup;
        }

        private void _LoadCudtomerSummaryReport()
        {
            ctrlManageRecords1.__Initialize()

        }
}
