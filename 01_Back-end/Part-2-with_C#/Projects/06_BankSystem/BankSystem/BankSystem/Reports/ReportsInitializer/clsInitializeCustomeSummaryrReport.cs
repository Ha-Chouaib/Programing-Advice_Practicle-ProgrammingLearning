using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports.CustomerReports;
using BankSystem.Customer.Forms;
using BankSystem.Person;
using BankSystem.Person.Forms;
using BankSystem.Properties;
using BankSystem.User.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports
{
    public class clsInitializeCustomeSummaryrReport
    {
        public clsInitializeCustomeSummaryrReport(ref ctrlManageRecords recordsManager)
        {
            _RecordsManager = recordsManager;
        }

        private ctrlManageRecords _RecordsManager { get; set; }

        public void LoadManageRecordsControl()
        {
            _RecordsManager.__UpdateBtn.Visible = false;
            _RecordsManager.__AddNewBtn.Visible = false;

            _RecordsManager.__HeaderImg.Image = Resources.CustomerSummary;

            _RecordsManager.__Initialize(_FilterBy_Options(), clsCustomerSummaryReports.FilterCustomerSummaryReports, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.ManagerRcordsHelper.FilterBy_Options(typeof(clsCustomerSummaryReports.Filter_Mapping));

        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.ManagerRcordsHelper.FilterBy_Groups(typeof(clsCustomerSummaryReports.Filter_ByGroupsMapping));
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
            _RecordsManager.__RecordsContainer.Columns["CustomerName"].HeaderText = "Full Name";
            _RecordsManager.__RecordsContainer.Columns["TotalAccounts"].HeaderText = "Total Accounts";
            _RecordsManager.__RecordsContainer.Columns["TotalBalance"].HeaderText = "Total Balance";
            _RecordsManager.__RecordsContainer.Columns["CustomerStatus"].HeaderText = "Active Customer";
            _RecordsManager.__RecordsContainer.Columns["ActiveAccounts"].HeaderText = "Active Accounts";
            _RecordsManager.__RecordsContainer.Columns["LastActivityDate"].HeaderText = "Last Activity Date";
            _RecordsManager.__RecordsContainer.Columns["ReportDate"].HeaderText = "Report Date";

            int index = _RecordsManager.__RecordsContainer.Columns["CustomerStatus"].Index;
            _RecordsManager.__RecordsContainer.Columns.Remove("CustomerStatus");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "CustomerStatus";
            chk.HeaderText = "Active Customer";
            chk.DataPropertyName = "CustomerStatus";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true;

            _RecordsManager.__RecordsContainer.Columns.Insert(index, chk);
        }
    
    }
}
