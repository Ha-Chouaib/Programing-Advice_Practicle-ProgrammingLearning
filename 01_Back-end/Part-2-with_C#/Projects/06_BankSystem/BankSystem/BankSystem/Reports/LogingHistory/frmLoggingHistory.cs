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
    public partial class frmLoggingHistory : Form
    {
        public frmLoggingHistory()
        {
            InitializeComponent();
            _HasPermissions();
            LoadManageRecordsControl();
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Reports_SystemLogs))
            {
                MessageBox.Show("You don't have permission to view logging history.",
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
            ctrlManageRecords1.__HeaderImg.Image = Resources.loggingHist;

            ctrlManageRecords1.__Initialize(_FilterBy_Options(), clsLoginHistory.FilterLoginHistory, _ContextMenuPackage(),null);
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsLoginHistory.Filter_Mapping));
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
            clsLoginHistory hist = clsLoginHistory.Find(ReportID);
            if (hist != null)
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
            if (grid.DataSource == null) return;

            grid.Columns["LoginID"].HeaderText = "Login ID";
            grid.Columns["UserID"].HeaderText = "LoggedIn User ID";
            grid.Columns["UserName"].HeaderText = "User Name";
            grid.Columns["RoleName"].HeaderText = "Role Name";
            grid.Columns["IsActive"].HeaderText = "LoggedIn User Active";
            grid.Columns["LoginDate"].HeaderText = "Login Date";
            grid.Columns["SessionID"].HeaderText = "Session ID";
            grid.Columns["MachineName"].HeaderText = "Machine Name";

            int index = grid.Columns["IsActive"].Index;
            grid.Columns.Remove("IsActive");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "IsActive";
            chk.HeaderText = "LoggedIn User Active";
            chk.DataPropertyName = "IsActive";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true;

            grid.Columns.Insert(index, chk);
        }
    }
}
