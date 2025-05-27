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
using DVLD_BusinessLayer.Applications;
using DVLD_BusinessLayer.Licenses;
using DVLD_Project.License;

namespace DVLD_Project.Applications.RenewLocalDrivingLicense_App
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }
        clsLicenses _OldLicense;
        clsLicenses _NewedLicense;
        clsMainApplication _RenewLicenseApplication;
        clsMainApplication _OldApplication;

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlFindAndDisplayDriverLicense1.__GetLicenseRecord += _GetOldLicenseRecord;
            lnkShowNewLicenseInfo.Enabled = false;
            lnkShowLicensesHist.Enabled = false;
        }

        private void _GetOldLicenseRecord(object sender,clsLicenses OldLicense)
        {
            _OldLicense = OldLicense;
            ctrlFindAndDisplayDriverLicense1.__DisplayLicenseRecord(_OldLicense.LicenseID);
            _OldApplication = clsMainApplication.Find(_OldLicense.ApplicationID);
            _DisplayRenewApplicationBasicInfo();
            lnkShowLicensesHist.Enabled = true;

        }

        private void _DisplayRenewApplicationBasicInfo()
        {

            lblApplicationDate.Text =  DateTime.Now.ToShortDateString();

            lblApplicationFees.Text =  _OldApplication.PaidFees.ToString();

            lblCurrentUserName.Text = clsUsers.Find(clsGlobal.CurrentUserID).UserName;

            lblIssueDate.Text =  DateTime.Now.ToShortDateString();

            lblExpirationDate.Text =DateTime.Now.AddYears(clsLicenseClasses.Find(_OldLicense.LicenseClassID).DefaultValidityLength).ToShortDateString();

            lblLicenseFees.Text=_OldLicense.PaidFees.ToString();

            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();

            lblTotalFees.Text = (_OldLicense.PaidFees + _OldApplication.PaidFees).ToString();

            
        }
        private bool _AddNewLicense()
        {
            _NewedLicense = new clsLicenses();
            _RenewLicenseApplication = new clsMainApplication();


            _RenewLicenseApplication.AppTypeID = _OldApplication.AppTypeID;
            _RenewLicenseApplication.AppDate = DateTime.Now;
            _RenewLicenseApplication.CreatedByUserID = clsGlobal.CurrentUserID;
            _RenewLicenseApplication.AppStatus =(byte) clsMainApplication.enApplicationStatus.Completed;
            _RenewLicenseApplication.ApplicantPersonID =_OldApplication.ApplicantPersonID;
            _RenewLicenseApplication.LastStatusDate = DateTime.Now;
            _RenewLicenseApplication.PaidFees = _OldApplication.PaidFees;



            _NewedLicense.CreatedByUserID = clsGlobal.CurrentUserID;
            _NewedLicense.DriverID = _OldLicense.DriverID;
            _NewedLicense.IsActive = true;
            _NewedLicense.LicenseClassID = _OldLicense.LicenseClassID;
            _NewedLicense.IssueReason = _OldLicense.IssueReason = (byte)clsLicenses.enIssueReason.RenewLicense;
            _NewedLicense.IssueDate = DateTime.Now;
            _NewedLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.Find(_OldLicense.LicenseClassID).DefaultValidityLength);
            _NewedLicense.PaidFees = _OldLicense.PaidFees;
            _NewedLicense.Notes = txtNotes.Text;

            if(_OldLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"This License Not Expirted Yet (The Expiration Date Will Be at [{_OldLicense.ExpirationDate}])", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(!_OldLicense.IsActive)
            {
                MessageBox.Show("InActive License ! Please Enter A Valide License ID)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!_RenewLicenseApplication.Save())
            {
                MessageBox.Show("Couldn't Save The Application [Renew Local Driving License]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _NewedLicense.ApplicationID = _RenewLicenseApplication.AppID;
            if(!_NewedLicense.Save())
            {
                MessageBox.Show("Couldn't Save The New License Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsMainApplication.DeleteApp(_RenewLicenseApplication.AppID);
                return false;
            }
            _OldLicense.IsActive = false;
            _OldLicense.Save();
            return true;


        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure To Completed The Operation ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_AddNewLicense())
                {
                    MessageBox.Show("Done Successfully");
                    lblR_ApplicationID.Text = _RenewLicenseApplication.AppID.ToString();
                    lblRenewedLicenseID.Text = _NewedLicense.LicenseID.ToString();
                    lnkShowNewLicenseInfo.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("The Operation Ignored successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkShowLicensesHist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicensesHistory ShowLicensesHist = new frmShowDriverLicensesHistory(_OldApplication.ApplicantPersonID);
            ShowLicensesHist.ShowDialog();
        }

        private void lnkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDisplayLocalLicenseInfo DisplayNewLicenseInfo = new frmDisplayLocalLicenseInfo(_NewedLicense.LicenseID);
            DisplayNewLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
