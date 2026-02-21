using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports;
using BankSystem.Customer.Forms;
using BankSystem.Properties;
using BankSystem.User.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Reports.UserReport
{
    public partial class frmManageUserReports : Form
    {
        public frmManageUserReports()
        {
            InitializeComponent();
            _HasPermissions();
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Reports_UserActivity))
            {
                MessageBox.Show("You don't have permission to view users activity reports.",
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
            ctrlManageRecords1.__HeaderImg.Image = Resources.ManageUsersImg;

            ctrlManageRecords1.__Initialize(_FilterBy_Options(), clsAuditUserActions.FilterUserActivityReports, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsUser.Filter_Mapping));
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsUser.Filter_ByGroupsMapping));
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
            clsAuditUserActions userActions = clsAuditUserActions.Find(ReportID);
            if (userActions != null)
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

            grid.Columns["ReportID"].HeaderText = "Report ID";
            grid.Columns["UserID"].HeaderText = "User ID";
            grid.Columns["UserName"].HeaderText = "User Name";
            grid.Columns["ActionKey"].HeaderText = "Section Name";
            grid.Columns["EntityID"].HeaderText = "Target Entity ID";
            grid.Columns["ReportDate"].HeaderText = "Report Date";
            grid.Columns["Succeeded"].HeaderText = "Succeeded";

            int index = grid.Columns["Succeeded"].Index;
            grid.Columns.Remove("Succeeded");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "Succeeded";
            chk.HeaderText = "Succeeded";
            chk.DataPropertyName = "Succeeded";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true;

            grid.Columns.Insert(index, chk);

        }

    }
}
