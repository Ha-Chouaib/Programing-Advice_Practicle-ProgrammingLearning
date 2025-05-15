using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer.Licenses;

namespace DVLD_Project.License.UserControls
{
    public partial class ctrlDriverLicensesHistory : UserControl
    {
        public ctrlDriverLicensesHistory()
        {
            InitializeComponent();
        }


        int _DriverID;
        public void __ListDriverLicenses_History(int DriverID)
        {
            _DriverID = DriverID;
            _ListLocalLicenses();
            _ListInternationalLicenses();
        }

        private void _ListLocalLicenses()
        {
            DataTable DT = clsLicenses.List_LocalLicense_History(_DriverID);
            dgvLocalLicenses.DataSource = DT;

            dgvLocalLicenses.Columns["LicenseID"].HeaderText = "Lic ID";
            dgvLocalLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvLocalLicenses.Columns["ClassName"].HeaderText = "Class Name";
            dgvLocalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvLocalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvLocalLicenses.Columns["IsActive"].HeaderText = "Is Active";

            byte IsActiveColumnID = (byte)dgvLocalLicenses.Columns["IsActive"].Index;
            dgvLocalLicenses.Columns.RemoveAt(IsActiveColumnID);

            DataGridViewCheckBoxColumn CheckBox_IsActive = new DataGridViewCheckBoxColumn();
            CheckBox_IsActive.Name = "IsActive";
            CheckBox_IsActive.HeaderText = "Is Active";
            CheckBox_IsActive.DataPropertyName = "IsActive";
            dgvLocalLicenses.Columns.Insert(IsActiveColumnID, CheckBox_IsActive);

            lblRecords_Loc.Text = "[ "+ dgvLocalLicenses.RowCount.ToString() +" ]";
        }

        private void _ListInternationalLicenses()
        {
            DataTable DT = clsLicenses.List_InternationalLicenses_History(_DriverID);

            dgvIntreNationalLicenses.DataSource = DT;

            dgvIntreNationalLicenses.Columns["InternationalLicenseID"].HeaderText = "Inter License ID";
            dgvIntreNationalLicenses.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvIntreNationalLicenses.Columns["LocalLicenseID"].HeaderText = "L. License ID";
            dgvIntreNationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvIntreNationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvIntreNationalLicenses.Columns["IsActive"].HeaderText = "Is Active";

            byte IsActiveColumnID = (byte)dgvIntreNationalLicenses.Columns["IsActive"].Index;

            dgvIntreNationalLicenses.Columns.RemoveAt(IsActiveColumnID);

            DataGridViewCheckBoxColumn CheckBox_IsActive = new DataGridViewCheckBoxColumn();
            CheckBox_IsActive.Name = "IsActive";
            CheckBox_IsActive.HeaderText = "Is Active";
            CheckBox_IsActive.DataPropertyName = "IsActive";
            dgvIntreNationalLicenses.Columns.Insert(IsActiveColumnID, CheckBox_IsActive);

            lblRecords_Inter.Text = "[ "+dgvIntreNationalLicenses.RowCount.ToString()+" ]";
        }
    }
}
