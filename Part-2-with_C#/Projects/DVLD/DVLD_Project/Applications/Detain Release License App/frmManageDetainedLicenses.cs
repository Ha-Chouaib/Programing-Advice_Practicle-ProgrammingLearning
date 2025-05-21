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
using DVLD_Project.Applications.Detain_License_App;
using DVLD_Project.License;

namespace DVLD_Project.Applications.Detain_Release_License_App
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadDetainedLicensesInfo();
            _LoadFilterOptions();
        }

        private void  _LoadDetainedLicensesInfo()
        {
            txtFilterTerm.Visible = false;
            cmbFilterByIsReleased.Visible = false;

            DataTable DT = clsDetainLicenses.ListAll();

            dgvListDetainedLicenses.DataSource = DT;

            dgvListDetainedLicenses.Columns["DetainID"].HeaderText = "Detain ID";
            dgvListDetainedLicenses.Columns["LicenseID"].HeaderText = "License ID";
            dgvListDetainedLicenses.Columns["DetainDate"].HeaderText = "Detain Date";
            dgvListDetainedLicenses.Columns["IsReleased"].HeaderText = "Is Released";
            dgvListDetainedLicenses.Columns["FineFees"].HeaderText = "Fine Fees";
            dgvListDetainedLicenses.Columns["ReleaseDate"].HeaderText = "Release Date";
            dgvListDetainedLicenses.Columns["NationalNo"].HeaderText = "National No";
            dgvListDetainedLicenses.Columns["FullName"].HeaderText = "Full Name";
            dgvListDetainedLicenses.Columns["ReleaseApplicationID"].HeaderText = "Release App ID";

            DataGridViewCheckBoxColumn IsReleasedCheckBox= new DataGridViewCheckBoxColumn();

            byte IsReleasedIndex =(byte) dgvListDetainedLicenses.Columns["IsReleased"].Index;
            dgvListDetainedLicenses.Columns.RemoveAt(IsReleasedIndex);

            IsReleasedCheckBox.HeaderText = "Is Released";
            IsReleasedCheckBox.Name = "IsReleased";
            IsReleasedCheckBox.DataPropertyName = "IsReleased";
            dgvListDetainedLicenses.Columns.Insert(IsReleasedIndex, IsReleasedCheckBox);

            lblRecords.Text =  "<< "+ dgvListDetainedLicenses.RowCount.ToString() +" >>";
        }

        private void _ReloadDetainedLicenseList(object sender)
        {
            dgvListDetainedLicenses.DataSource = clsDetainLicenses.ListAll();
            lblRecords.Text = "<< " + dgvListDetainedLicenses.RowCount.ToString() + " >>";

        }
        Dictionary<string, string> dicFilterOptions = new Dictionary<string, string>();

        private void _LoadFilterOptions()
        {

            dicFilterOptions.Add("None", "None");
            dicFilterOptions.Add("DetainID", "Detain ID");
            dicFilterOptions.Add("IsReleased", "Is Released");
            dicFilterOptions.Add("FullName", "Full Name");
            dicFilterOptions.Add("NationalNo", "National No");
            dicFilterOptions.Add("ReleaseApplicationID", "Release Application ID");

            cmbFilterBy.DataSource = new BindingSource(dicFilterOptions, null);
            cmbFilterBy.DisplayMember = "Value";
            cmbFilterBy.ValueMember = "Key";
            cmbFilterBy.SelectedIndex = 0;


            cmbFilterByIsReleased.Items.Add("All");
            cmbFilterByIsReleased.Items.Add("Released");
            cmbFilterByIsReleased.Items.Add("Detained");
            cmbFilterByIsReleased.SelectedIndex = 0;
        }


        private void _FilterOperation_FilterTerm()
        {
            string FilterByColumn=cmbFilterBy.SelectedValue.ToString();
            string FilterTerm = txtFilterTerm.Text;
            DataTable DT = new DataTable();

            if(FilterTerm != string.Empty)
            {
                if(FilterByColumn != "FullName" && FilterByColumn !="NationalNo" && int.TryParse(FilterTerm,out int ID))
                {
                    DT = clsDetainLicenses.FilterBy<int>(FilterByColumn, ID);
                }else
                {
                    DT = clsDetainLicenses.FilterBy<string>(FilterByColumn, FilterTerm);
                }
            }
            else
            {
                DT = clsDetainLicenses.ListAll();
            }

            dgvListDetainedLicenses.DataSource=DT;
            lblRecords.Text = "<< " + dgvListDetainedLicenses.RowCount.ToString() + " >>";

        }

        private void _FilterOperation_ByIsReleased()
        {
            string FilterOption = cmbFilterByIsReleased.SelectedItem.ToString();

            DataTable DT = new DataTable();
            
            switch(FilterOption)
            {
                case "All":
                    DT = clsDetainLicenses.ListAll();
                    break;
                case "Released":
                    DT = clsDetainLicenses.FilterBy<bool>("IsReleased", true);
                    break;
                case "Detained":
                    DT = clsDetainLicenses.FilterBy<bool>("IsReleased", false);
                    break;
                default:
                    DT = clsDetainLicenses.ListAll();
                    break;
            }

            dgvListDetainedLicenses.DataSource = DT;
            lblRecords.Text = "<< " + dgvListDetainedLicenses.RowCount.ToString() + " >>";

        }

        private void txtFilterTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFilterTerm_TextChanged(object sender, EventArgs e)
        {
            _FilterOperation_FilterTerm();
        }

        private void cmbFilterByIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterOperation_ByIsReleased();
        }

        private void cmbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterOption = cmbFilterBy.SelectedValue.ToString();
            if(! dicFilterOptions.ContainsKey(FilterOption))
            {
                return;
            }

            if(FilterOption == " None")
            {
                dgvListDetainedLicenses.DataSource = clsDetainLicenses.ListAll();
                lblRecords.Text = "<< " + dgvListDetainedLicenses.RowCount.ToString() + " >>";
                return;
            }

            if(FilterOption == "IsReleased")
            {
                txtFilterTerm.Visible = false;
                cmbFilterByIsReleased.Visible = true;
            }else
            {
                txtFilterTerm.Visible = true;
                cmbFilterByIsReleased.Visible = false ;

                txtFilterTerm.KeyPress -= txtFilterTerm_KeyPress;
                if(FilterOption != "NationalNo" && FilterOption != "FullName")
                {
                    txtFilterTerm.KeyPress += txtFilterTerm_KeyPress;

                }

            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvListDetainedLicenses.CurrentRow.Cells["NationalNo"].Value.ToString();
            frmPersonDetails ShowPersonDetails = new frmPersonDetails(NationalNo);
            ShowPersonDetails.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID =(int) dgvListDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;
            frmDisplayLocalLicenseInfo LicenseDetails = new frmDisplayLocalLicenseInfo();
            LicenseDetails.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvListDetainedLicenses.CurrentRow.Cells["NationalNo"].Value.ToString();
            int PersonID = clsPeople.Find(NationalNo).PersonID;
            frmShowDriverLicensesHistory LicensesHistory = new frmShowDriverLicensesHistory(PersonID);
            LicensesHistory.ShowDialog();
        }

        private void releaseDetaindLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID =(int) dgvListDetainedLicenses.CurrentRow.Cells["LicenseID"].Value;
            frmReleaseDetainedLicense ReleaseLicense = new frmReleaseDetainedLicense(LicenseID);
            ReleaseLicense.ShowDialog();
        }

        private void cmsDetainedLic_Opening(object sender, CancelEventArgs e)
        {
            int DetainID =(int) dgvListDetainedLicenses.CurrentRow.Cells["DetainID"].Value;
            if(! clsDetainLicenses.IsDetained(DetainID))
            {
                releaseDetaindLicenseToolStripMenuItem.Enabled = false;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense ReleaseLicense = new frmReleaseDetainedLicense();
            ReleaseLicense.__ReLoadContent += _ReloadDetainedLicenseList;
            ReleaseLicense.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
            DetainLicense.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
