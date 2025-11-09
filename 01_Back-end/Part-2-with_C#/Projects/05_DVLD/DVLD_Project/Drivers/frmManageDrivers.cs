using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_Project.Applications.LDLApps;
using DVLD_Project.License;

namespace DVLD_Project.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadDriversList();
            _LoadFilterOptions();
        }

        private void _LoadDriversList()
        {
            DataTable DT = clsDrivers.ListDrivers();

            dgvDriversList.DataSource=DT;

            dgvDriversList.Columns["DriverID"].HeaderText = "Driver ID";
            dgvDriversList.Columns["PersonID"].HeaderText = "PersonI D";
            dgvDriversList.Columns["NationalNo"].HeaderText = "National No";
            dgvDriversList.Columns["FullName"].HeaderText = "Full Name";
            dgvDriversList.Columns["CreatedDate"].HeaderText = "Date";
            dgvDriversList.Columns["NumberOfActiveLicenses"].HeaderText = "Active Licenses";

            lblRecords.Text = "[ "+dgvDriversList.RowCount.ToString() + " ]";
        }

        private void _LoadFilterOptions()
        {
            txtFilterTerm.Visible = false;
            Dictionary<string, string> FilterOptions = new Dictionary<string, string>();

            FilterOptions.Add("None", "None");
            FilterOptions.Add("DriverID", "Driver ID"); 
            FilterOptions.Add("PersonID", "Person ID");
            FilterOptions.Add("FullName", "Full Name");

            cmbFilterDrivers.SelectedIndexChanged -= cmbFilterDrivers_SelectedIndexChanged;

            cmbFilterDrivers.DataSource =new BindingSource(FilterOptions,null);
            cmbFilterDrivers.DisplayMember = "Value";
            cmbFilterDrivers.ValueMember = "Key";

            cmbFilterDrivers.SelectedIndex = 0;
            cmbFilterDrivers.SelectedIndexChanged += cmbFilterDrivers_SelectedIndexChanged;
        }

        private void _FilterOperarion()
        {
            DataTable DT = new DataTable();
            string FilterTerm = txtFilterTerm.Text;
            string FilterBy = cmbFilterDrivers.SelectedValue.ToString();

            if(FilterTerm != string.Empty)
            {
                if(FilterBy != "FullName" && int.TryParse(FilterTerm,out int ID) )
                {
                    DT = clsDrivers.FilterBy<int>(FilterBy, ID);

                }else
                {
                    DT = clsDrivers.FilterBy<string>(FilterBy, FilterTerm);
                }

            }else
            {
                DT = clsDrivers.ListDrivers();
            }
            dgvDriversList.DataSource = DT;
            lblRecords.Text = "[ " + dgvDriversList.RowCount.ToString() + " ]";
        }

        private void txtFilterTerm_TextChanged(object sender, EventArgs e)
        {
            _FilterOperarion();
        }

        private void txtFilterTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbFilterDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterOption = cmbFilterDrivers.SelectedValue.ToString();

            if(FilterOption != "None" )
            {
                txtFilterTerm.Visible = true;
                txtFilterTerm.Focus();
                txtFilterTerm.KeyPress -= txtFilterTerm_KeyPress;
                if(FilterOption != "FullName")
                {
                    txtFilterTerm.KeyPress += txtFilterTerm_KeyPress;
                }
            }
            else
            {
                txtFilterTerm.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =(int) dgvDriversList.CurrentRow.Cells["PersonID"].Value;
            frmPersonDetails DisplayDriverInfo = new frmPersonDetails(PersonID);
            DisplayDriverInfo.ShowDialog();
        }

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDriversList.CurrentRow.Cells["PersonID"].Value;
            frmShowDriverLicensesHistory showDriverLicensesHistory = new frmShowDriverLicensesHistory(PersonID);
            showDriverLicensesHistory.ShowDialog();
        }

        private void addNewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = (int)dgvDriversList.CurrentRow.Cells["PersonID"].Value;
            frmAddNewLocalDrivingLicense_App AddNewLicense = new frmAddNewLocalDrivingLicense_App(PersonID);
            AddNewLicense.ShowDialog();
        }
    }
}
