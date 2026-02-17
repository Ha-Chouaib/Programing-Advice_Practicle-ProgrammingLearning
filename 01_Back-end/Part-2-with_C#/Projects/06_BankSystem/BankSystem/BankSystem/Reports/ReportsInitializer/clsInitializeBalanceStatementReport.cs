using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports
{
    public class clsInitializeBalanceStatementReport
    {
        public clsInitializeBalanceStatementReport(ref ctrlManageRecords recordsManager)
        {
            _RecordsManager = recordsManager;
        }

        private ctrlManageRecords _RecordsManager { get; set; }

        public void LoadManageRecordsControl()
        {
            _RecordsManager.__UpdateBtn.Visible = false;
            _RecordsManager.__AddNewBtn.Visible = false;

            _RecordsManager.__HeaderImg.Image = Resources.BalanceStatement_report;

            _RecordsManager.__Initialize(_FilterBy_Options(), clsBalanceStatementReports.FilterBalanceStatementReports, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsBalanceStatementReports.Filter_Mapping));
        }
        private List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> ContextMenuItems = new List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)>
            {
                ("View Details", _ContextMenuViewReportDetails),
            };

            return ContextMenuItems;
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsBalanceStatementReports.Filter_ByGroupsMapping));
        }

        void _ContextMenuViewReportDetails(int ReportID, ToolStripMenuItem menuItem)
        {
            MessageBox.Show("Not Implemented Yet");
        }


        private void _ConfigureDataRecordsContainer()
        {
            if (_RecordsManager.__RecordsContainer == null) return;

            _RecordsManager.__RecordsContainer.Columns["CustomerReportsID"].HeaderText = "Customer Report ID";
            _RecordsManager.__RecordsContainer.Columns["CustomerID"].HeaderText = "Customer ID";
            _RecordsManager.__RecordsContainer.Columns["CustomerName"].HeaderText = "Full Name";
            _RecordsManager.__RecordsContainer.Columns["AccountID"].HeaderText = "Account ID";
            _RecordsManager.__RecordsContainer.Columns["OpeningBalance"].HeaderText = "Opening Balance";
            _RecordsManager.__RecordsContainer.Columns["ClosingBalance"].HeaderText = "Closing Balance";
            _RecordsManager.__RecordsContainer.Columns["FromDate"].HeaderText = "From Date";
            _RecordsManager.__RecordsContainer.Columns["ToDate"].HeaderText = "To Date";
            _RecordsManager.__RecordsContainer.Columns["ReportDate"].HeaderText = "Report Date";

        }
    }
}
