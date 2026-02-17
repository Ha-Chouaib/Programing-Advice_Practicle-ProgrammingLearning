using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports
{
    public class clsInitializeDormantAccountsReport
    {
        public clsInitializeDormantAccountsReport(ref ctrlManageRecords recordsManager)
        {
            _RecordsManager = recordsManager;
        }

        private ctrlManageRecords _RecordsManager { get; set; }

        public void LoadManageRecordsControl()
        {
            _RecordsManager.__UpdateBtn.Visible = false;
            _RecordsManager.__AddNewBtn.Visible = false;

            _RecordsManager.__HeaderImg.Image = Resources.DormantAccounts;

            _RecordsManager.__Initialize(_FilterBy_Options(), clsDormantAccountsReports.FilterDormantAccountsReports, _ContextMenuPackage(), null);
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsDormantAccountsReports.Filter_Mapping));
        }
        private List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> ContextMenuItems = new List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)>
            {
                ("View Details", _ContextMenuViewReportDetails),
            };

            return ContextMenuItems;
        }
    

        void _ContextMenuViewReportDetails(int ReportID, ToolStripMenuItem menuItem)
        {
            MessageBox.Show("Not Implemented Yet");
        }


        private void _ConfigureDataRecordsContainer()
        {
            if (_RecordsManager.__RecordsContainer.RowCount == 0) return;

            _RecordsManager.__RecordsContainer.Columns["CustomerReportsID"].HeaderText = "Customer Report ID";
            _RecordsManager.__RecordsContainer.Columns["CustomerID"].HeaderText = "Customer ID";
            _RecordsManager.__RecordsContainer.Columns["FirstName"].HeaderText = "Customer First Name";
            _RecordsManager.__RecordsContainer.Columns["LastName"].HeaderText = "Customer Last Name";
            _RecordsManager.__RecordsContainer.Columns["AccountID"].HeaderText = "Account ID";
            _RecordsManager.__RecordsContainer.Columns["LastTransactionDate"].HeaderText = "Last Transaction Date";
            _RecordsManager.__RecordsContainer.Columns["DormantMonths"].HeaderText = "Dormant Months";
            _RecordsManager.__RecordsContainer.Columns["TransactionID"].HeaderText = "Transaction ID";
            _RecordsManager.__RecordsContainer.Columns["ReportDate"].HeaderText = "Report Date";

           

        }
    }
}
