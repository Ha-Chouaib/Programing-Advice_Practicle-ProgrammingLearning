using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Properties;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports
{
    public class clsInitializeAccountActivityReport
    {
        public clsInitializeAccountActivityReport(ref ctrlManageRecords recordsManager)
        {
            _RecordsManager = recordsManager;
        }

        private ctrlManageRecords _RecordsManager { get; set; }

       
        public void LoadManageRecordsControl()
        {
            _RecordsManager.__UpdateBtn.Visible = false;
            _RecordsManager.__AddNewBtn.Visible = false;

            _RecordsManager.__HeaderImg.Image = Resources.AccountActivityRep;

            _RecordsManager.__Initialize(_FilterBy_Options(), clsAccountActivityReports.FilterAccountActivityReports, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
       
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsAccountActivityReports.Filter_Mapping));
        }

        static class _contextMenuItems
        {
            public static (string valueMember, string displayMember) viewDeatails => ("ViewDetails", "View Details");
        }
        private List<((string valueMember, string displayMember) ContextMenuItem, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            var contextMenuItems = new List<((string valueMember, string displayMember), Action<int, ToolStripMenuItem>)>
            {
                (_contextMenuItems.viewDeatails, _ContextMenuViewReportDetails),
            };

            return contextMenuItems;
        }

        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsAccountActivityReports.Filter_ByGroupsMapping));
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
            _RecordsManager.__RecordsContainer.Columns["CustomerName"].HeaderText = "Full Name";
            _RecordsManager.__RecordsContainer.Columns["FromDate"].HeaderText = "From Date";
            _RecordsManager.__RecordsContainer.Columns["ToDate"].HeaderText = "To Date";
            _RecordsManager.__RecordsContainer.Columns["TransactionCount"].HeaderText = "Transaction Count";
            _RecordsManager.__RecordsContainer.Columns["TotalDebit"].HeaderText = "Total Debits";
            _RecordsManager.__RecordsContainer.Columns["TotalCredit"].HeaderText = "Total Credite";
            _RecordsManager.__RecordsContainer.Columns["ReportDate"].HeaderText = "Report Date";

        }
    }
}
