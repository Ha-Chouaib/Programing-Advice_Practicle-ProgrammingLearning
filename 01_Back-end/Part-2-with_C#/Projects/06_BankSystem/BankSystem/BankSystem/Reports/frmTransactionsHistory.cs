using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports;
using BankSystem.Properties;
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
    public partial class frmTransactionsHistory : Form
    {
        public frmTransactionsHistory()
        {
            InitializeComponent();
            _HasPermissions();
            LoadManageRecordsControl();
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Reports_Transaction))
            {
                MessageBox.Show("You don't have permission to view transactions history.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;
            ctrlManageRecords1.__AddNewBtn.Visible = false;
            ctrlManageRecords1.__UpdateBtn.Visible = false;
            ctrlManageRecords1.__HeaderImg.Image = Resources.transaction_history_18409907;

            ctrlManageRecords1.__Initialize(_FilterBy_Options(), clsTransactionsReport.FilterTransactionsHistory, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsTransactionsReport.Filter_Mapping));
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsTransactionsReport.Filter_ByGroupsMapping));
        }

        static class _ContextMenuItems
        {

            public static (string valueMember, string displayMember) ViewCustomerDetails => ("ViewReportDetails", "View Details");

        }
        private List<((string valueMember, string displayMember) ContextMenuItem, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            var contextMenuItems = new List<((string valueMember, string displayMember), Action<int, ToolStripMenuItem>)>
            {
                (_ContextMenuItems.ViewCustomerDetails, _ContextMenuViewReportCard),
            };

            return contextMenuItems;
        }

        void _ContextMenuViewReportCard(int ReportID, ToolStripMenuItem menuItem)
        {
            clsTransactionsReport transactions = clsTransactionsReport.Find(ReportID);
            if (transactions != null)
            {
                
            }
            else
                MessageBox.Show($"Can't Find Any Report with id [{ReportID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _EndSession()
        {
            this.Close();
        }

        private void _ConfigureDataRecordsContainer()
        {
            var grid = ctrlManageRecords1.__RecordsContainer;
            if(grid.DataSource == null)
                return;
            grid.Columns["TransactionID"].HeaderText = "Transaction ID";
            grid.Columns["Code"].HeaderText = "Transaction Name";
            grid.Columns["TransactionDate"].HeaderText = "Transaction Date";
            grid.Columns["AccountFromID"].HeaderText = "Account From ID";
            grid.Columns["OwnerID"].HeaderText = "Owner ID";
            grid.Columns["OwnerFirstName"].HeaderText = "Owner First Name";
            grid.Columns["OwnerLastName"].HeaderText = "Owner Last Name";
            grid.Columns["Amount"].HeaderText = "Amount";
            grid.Columns["AccountToID"].HeaderText = "Account To ID";
            grid.Columns["OldBalance"].HeaderText = "Old Balance";
            grid.Columns["NewBalance"].HeaderText = "New Balance";
            grid.Columns["PerformedByUserID"].HeaderText = "Performed By User ID";
            grid.Columns["PerformedByCustomer"].HeaderText = "Performed By Customer";
            grid.Columns["Notes"].HeaderText = "Notes";

        }
    }
}
