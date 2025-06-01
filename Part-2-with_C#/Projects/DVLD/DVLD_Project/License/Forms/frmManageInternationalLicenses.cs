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
using DVLD_BusinessLayer.Licenses;

namespace DVLD_Project.License.Forms
{
    public partial class frmManageInternationalLicenses : Form
    {
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }
        
        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _LoadInternationalLicensesList();
            _LoadFilterOptions();
        }

        private void _LoadInternationalLicensesList()
        {
            txtFilterTerm.Visible = false;
            cmbIsActive.Visible = false;

            DataTable DT =clsInternationalLicenses.ListInternationalLicenses();

            dgvListInternationalLicenses.DataSource = DT;

            dgvListInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "I License ID";
            dgvListInternationalLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvListInternationalLicenses.Columns["DriverID"].HeaderText = "DriverID";
            dgvListInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L License ID";
            dgvListInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvListInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvListInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active";
            dgvListInternationalLicenses.Columns["CreatedByUserID"].HeaderText = "Created By User ID";

            DataGridViewCheckBoxColumn IsActiveCheckBox = new DataGridViewCheckBoxColumn();

            byte IsActiveIndex = (byte)dgvListInternationalLicenses.Columns["IsActive"].Index;
            dgvListInternationalLicenses.Columns.RemoveAt(IsActiveIndex);

            IsActiveCheckBox.HeaderText = "Is Active";
            IsActiveCheckBox.Name = "IsActive";
            IsActiveCheckBox.DataPropertyName = "IsActive";
            dgvListInternationalLicenses.Columns.Insert(IsActiveIndex, IsActiveCheckBox);

            lblRecords.Text = "[ " + dgvListInternationalLicenses.RowCount.ToString() + " ]";

        }

        Dictionary<string, string> dicFilterOptions = new Dictionary<string, string>();
        private void _LoadFilterOptions()
        {
            dicFilterOptions.Add("None", "None");
            dicFilterOptions.Add("InternationalLicenseID", "I License ID");
            dicFilterOptions.Add("DriverID", "Driver ID");
            dicFilterOptions.Add("IssuedUsingLocalLicenseID", "L License ID");
            dicFilterOptions.Add("IsActive", "Is Active");

            cmbFilterOptions.DataSource = new BindingSource(dicFilterOptions, null);
            cmbFilterOptions.DisplayMember = "Value";
            cmbFilterOptions.ValueMember = "Key";
            cmbFilterOptions.SelectedIndex = 0;


            cmbIsActive.Items.Add("All");
            cmbIsActive.Items.Add("Active");
            cmbIsActive.Items.Add("Inactive");
            cmbIsActive.SelectedIndex = 0;
        }

        private void _FilterBy_FilterTerm()
        {
            string FilterTerm = txtFilterTerm.Text;
            string FilterByColumn = cmbFilterOptions.SelectedValue.ToString();
            DataTable DT = new DataTable();
            if(FilterTerm != string.Empty && int.TryParse(FilterTerm, out int ID))
            {
                DT=clsInternationalLicenses.FilterBy<int>(FilterByColumn, ID);
            } else
            {
                DT = clsInternationalLicenses.ListInternationalLicenses();
            }

            dgvListInternationalLicenses.DataSource = DT;
            lblRecords.Text = "[ " + dgvListInternationalLicenses.RowCount.ToString() + " ]";
        }

        private void _FilterBy_IsActive()
        {
            string FilterColumn = cmbIsActive.SelectedItem.ToString();

            DataTable DT = new DataTable();
            switch (FilterColumn)
            {
                case "All":
                    DT = clsInternationalLicenses.ListInternationalLicenses();
                    break;
                case "Active":
                    DT = clsInternationalLicenses.FilterBy<byte>("IsActive", 1);
                    break;
                case "Inactive":
                    DT = clsInternationalLicenses.FilterBy<byte>("IsActive", 0);
                    break;
                default:
                    DT = clsInternationalLicenses.ListInternationalLicenses();
                    break;
            }

            dgvListInternationalLicenses.DataSource = DT;
            lblRecords.Text = "<< " + dgvListInternationalLicenses.RowCount.ToString() + " >>";
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterBy_IsActive();
        }

        private void txtFilterTerm_TextChanged(object sender, EventArgs e)
        {
            _FilterBy_FilterTerm();
        }

        private void txtFilterTerm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterOpt = cmbFilterOptions.SelectedValue.ToString();

            if(!dicFilterOptions.ContainsKey(FilterOpt)) return;
           
            if(FilterOpt == "None")
            {
                txtFilterTerm.Visible = false;
                cmbIsActive.Visible = false;
                dgvListInternationalLicenses.DataSource = clsInternationalLicenses.ListInternationalLicenses();
                lblRecords.Text = "[ " + dgvListInternationalLicenses.RowCount.ToString() + " ]";
            } else
            {
                if(FilterOpt == "IsActive")
                {
                    txtFilterTerm.Visible = false;
                    cmbIsActive.Visible = true;
                    return;
                }
                cmbIsActive.Visible = false;
                txtFilterTerm.Visible = true;
                txtFilterTerm.Focus();
            }
        }

        private void btnAddNewInternationalLicens_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication AddNewInternationalLicense=new frmAddNewInternationalLicenseApplication();
            AddNewInternationalLicense.ShowDialog();
            frmManageInternationalLicenses_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
