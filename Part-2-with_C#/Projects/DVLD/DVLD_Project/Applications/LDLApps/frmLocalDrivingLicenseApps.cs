using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer.Applications;
using DVLD_Project.Applications.LDLApps;
using DVLD_Project.Applications.Tests;

namespace DVLD_Project.Applications
{
    public partial class frmManageLocalDrivingLicenseApps : Form
    {
        public frmManageLocalDrivingLicenseApps()
        {
            InitializeComponent();
        }

        private void frmManageMainApplications_Load(object sender, EventArgs e)
        {
            _LoadAppsList();
            _LoadFindByOptions();
            txtFilterTerm.Visible = false;
        }

        private void _LoadAppsList()
        {
            DataTable DT = clsLocalDrivingLicense.LocalLicenseList_View();
            dgvLDL_AppsList.DataSource = DT;
            dgvLDL_AppsList.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "LDL_AppID";
            dgvLDL_AppsList.Columns["ClassName"].HeaderText = "Driving Class";
            dgvLDL_AppsList.Columns["NationalNo"].HeaderText = "National No";
            dgvLDL_AppsList.Columns["FullName"].HeaderText = "Full Name";
            dgvLDL_AppsList.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvLDL_AppsList.Columns["PassedTestCount"].HeaderText = "Passed Teste";

            lblRecords.Text = dgvLDL_AppsList.RowCount.ToString();
        }
        private void _ReLoadLocalAppList(object sender)
        {
            _LoadAppsList();
        }

        Dictionary<string, string> FilterOpts = new Dictionary<string, string>();
        private void _LoadFindByOptions()
        {
            FilterOpts.Add("None", "None");
            FilterOpts.Add("LocalDrivingLicenseApplicationID", "LDL_AppID");
            FilterOpts.Add("NationalNo", "Natioonal No");
            FilterOpts.Add("FullName", "Full Name");
            FilterOpts.Add("Status", "Status");

            cmbFilterOptions.DataSource = new BindingSource(FilterOpts, null);
            cmbFilterOptions.DisplayMember = "Value";
            cmbFilterOptions.ValueMember = "Key";

            cmbFilterOptions.SelectedIndex = 0;

            cmbAppStatusFilter.Items.Add("All");
            cmbAppStatusFilter.Items.Add("New");
            cmbAppStatusFilter.Items.Add("Canceled");
            cmbAppStatusFilter.Items.Add("Completed");
            cmbAppStatusFilter.SelectedIndex = 0;

        }

        private void _FilterBy_SearchTerm()
        {
            string FilterTerm = txtFilterTerm.Text;
            string FilterByColumn = cmbFilterOptions.SelectedValue.ToString();
            if (FilterTerm != string.Empty)
            {
                DataTable DT;

                if (FilterByColumn == "LocalDrivingLicenseApplicationID" && int.TryParse(FilterTerm, out int LDL_AppID))
                {
                    DT = clsLocalDrivingLicense.FilterBy<int>(FilterByColumn, LDL_AppID);
                }
                else
                {
                    DT = clsLocalDrivingLicense.FilterBy<string>(FilterByColumn, FilterTerm);
                }
                dgvLDL_AppsList.DataSource = DT;

                lblRecords.Text = dgvLDL_AppsList.RowCount.ToString();
            }
            else
            {
                _LoadAppsList();
            }
        }

        private void _FilterBy_AppStatus()
        {
            string StatusTerm = cmbAppStatusFilter.SelectedItem.ToString();
            DataTable DT = clsLocalDrivingLicense.FilterBy<string>("Status", StatusTerm);

            dgvLDL_AppsList.DataSource = DT;
            lblRecords.Text = dgvLDL_AppsList.RowCount.ToString();
        }
        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedColumn = cmbFilterOptions.SelectedValue.ToString();
            if (SelectedColumn == "None")
            {
                txtFilterTerm.Visible = false;
                cmbAppStatusFilter.Visible = false;
                _LoadAppsList();
                return;
            }
            if (SelectedColumn == "Status")
            {
                txtFilterTerm.Visible = false;
                cmbAppStatusFilter.Visible = true;

            }
            else
            {
                cmbAppStatusFilter.Visible = false;
                txtFilterTerm.Visible = true;
                txtFilterTerm.Focus();
                txtFilterTerm.KeyPress -= txtFilterTerm_KeyPress;
                if(SelectedColumn == "LocalDrivingLicenseApplicationID")
                {
                    txtFilterTerm.KeyPress += txtFilterTerm_KeyPress;
                }

            }

        }

        private void _Disable_EnableTests(bool VisionTestEnabled, bool WrittenTestEnabled, bool StreetTestEnabled,bool IsCompleteAllTests=false)
        {
            tsmiSchedualeVisionTest.Enabled = VisionTestEnabled;
            tsmiSchedualWrittenTest.Enabled = WrittenTestEnabled;
            tsmiSchedualStreetTest.Enabled = StreetTestEnabled;

            tsmSchedualeTests.Enabled= !IsCompleteAllTests;


        }
        private void txtFilterTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbAppStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(cmbAppStatusFilter.SelectedItem.ToString() == "All")
            {
                _LoadAppsList();
            }else
                _FilterBy_AppStatus();
        }

        private void txtFilterTerm_KeyUp(object sender, KeyEventArgs e)
        {
            _FilterBy_SearchTerm();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewLocalApp_Click(object sender, EventArgs e)
        {
            frmAddNewLocalDrivingLicense NewLocalLicense=new frmAddNewLocalDrivingLicense();
            NewLocalLicense.__ReloadContent += _ReLoadLocalAppList;
            NewLocalLicense.ShowDialog();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void schedualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDL_AppID = (int)dgvLDL_AppsList.CurrentRow.Cells[0].Value;
            int VisionTestID = 1;
            frmTestAppointment VisionTest = new frmTestAppointment(LDL_AppID,VisionTestID);
            VisionTest.__ReLoadList+=_ReLoadLocalAppList;
            VisionTest.ShowDialog();
        }

        private void schedualWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDL_AppID = (int)dgvLDL_AppsList.CurrentRow.Cells[0].Value;
            int WrittenTestID = 2;
            frmTestAppointment WrittenTest = new frmTestAppointment(LDL_AppID, WrittenTestID);
            WrittenTest.__ReLoadList += _ReLoadLocalAppList;
            WrittenTest.ShowDialog();
        }

        private void schedualStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDL_AppID = (int)dgvLDL_AppsList.CurrentRow.Cells[0].Value;
            int StreetTestID = 3;
            frmTestAppointment StreetTest = new frmTestAppointment(LDL_AppID, StreetTestID);
            StreetTest.__ReLoadList += _ReLoadLocalAppList;
            StreetTest.ShowDialog();
        }

        private void cmsLDL_Apps_Opening(object sender, CancelEventArgs e)
        {
            int LDL_AppID = (int)dgvLDL_AppsList.CurrentRow.Cells[0].Value;
            
            byte PassedTests = (byte)clsLocalDrivingLicense.GetPassedTestsCount(LDL_AppID);
            

            switch(PassedTests)
            {
                case 0:
                    _Disable_EnableTests(true, false, false);
                    break;
                case 1:
                    _Disable_EnableTests(false, true, false);
                    break;
                case 2:
                    _Disable_EnableTests(false, false, true);
                    break;
                case 3:
                    _Disable_EnableTests(false, false, false,true);
                    break;
                default:
                    _Disable_EnableTests(false, false, false);
                    break;
            }
        }

       
    }
}
