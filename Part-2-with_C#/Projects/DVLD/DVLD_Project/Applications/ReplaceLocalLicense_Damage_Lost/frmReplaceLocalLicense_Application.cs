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
using DVLD_BusinessLayer.Licenses;
using DVLD_BusinessLayer;
using DVLD_Project.License;

namespace DVLD_Project.Applications.ReplaceLocalLicense_Damage_Lost
{
    public partial class frmReplaceLocalLicense_Application : Form
    {
        public frmReplaceLocalLicense_Application()
        {
            InitializeComponent();
        }

        clsLicenses _OldLicense;
        clsLicenses _NewLicense;
        clsMainApplication _ReplaceLicenseApplication;
        clsMainApplication _OldApplication;
        private void frmReplaceLocalLicense_Application_Load(object sender, EventArgs e)
        {

            ctrlFindAndDisplayDriverLicense1.__GetLicenseRecord += _GetOldLicenseRecord;
            lnkShowNewLicInfo.Enabled = false;
            lnkShowLicensesHist.Enabled = false;

        }

        private void _GetOldLicenseRecord(object sender, clsLicenses OldLicense)
        {
            _OldLicense = OldLicense;
            ctrlFindAndDisplayDriverLicense1.__DisplayLicenseRecord(_OldLicense.LicenseID);
            _OldApplication = clsMainApplication.Find(_OldLicense.ApplicationID);
            _DisplayReplaceLicenseApplicationBasicInfo();
            lnkShowLicensesHist.Enabled = true;

        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(rbLostLicense.Checked ==true)
            {
                lblHeaderTitle.Text = "Replacement For Lost License";
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_LostDrivingLicense).AppFees.ToString();

            }
            else
            {
                lblHeaderTitle.Text = "Replacement For Lost License";
                lblApplicationFees.Text = clsApplicationTypes.Find((int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_DamagedDrivingLicense).AppFees.ToString();
            }
        }
        private void _DisplayReplaceLicenseApplicationBasicInfo()
        {

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();

            lblCurrentUserName.Text = clsUsers.Find(clsGlobal.CurrentUserID).UserName; 

            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();

            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_LostDrivingLicense).AppFees.ToString();

        }
        private bool _AddNewLicense()
        {
            _NewLicense = new clsLicenses();
            _ReplaceLicenseApplication = new clsMainApplication();


            _ReplaceLicenseApplication.AppDate = DateTime.Now;
            _ReplaceLicenseApplication.CreatedByUserID = clsGlobal.CurrentUserID;
            _ReplaceLicenseApplication.AppStatus =(byte) clsGlobal.enApplicationStatus.Complete;
            _ReplaceLicenseApplication.ApplicantPersonID = _OldApplication.ApplicantPersonID;
            _ReplaceLicenseApplication.LastStatusDate = DateTime.Now;



            _NewLicense.CreatedByUserID = clsGlobal.CurrentUserID;
            _NewLicense.DriverID = _OldLicense.DriverID;
            _NewLicense.IsActive = true;
            _NewLicense.LicenseClassID = _OldLicense.LicenseClassID;

            if(rbLostLicense.Checked ==true)
            {

                _ReplaceLicenseApplication.AppTypeID = (int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_LostDrivingLicense;
                _ReplaceLicenseApplication.PaidFees = clsApplicationTypes.Find((int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_LostDrivingLicense).AppFees;
                _NewLicense.IssueReason = (byte)clsGlobal.enIssueReason.ReplaceForLost;
            }
            else
            {
                _ReplaceLicenseApplication.AppTypeID = (int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_DamagedDrivingLicense;
                _ReplaceLicenseApplication.PaidFees = clsApplicationTypes.Find((int)clsGlobal.enApplicationTypes_IDs.ReplacementFor_DamagedDrivingLicense).AppFees;
                _NewLicense.IssueReason = (byte)clsGlobal.enIssueReason.ReplaceFoDamage;
                
            }

            _NewLicense.IssueDate = _OldLicense.IssueDate;
            _NewLicense.ExpirationDate = _OldLicense.ExpirationDate;
            _NewLicense.PaidFees = _OldLicense.PaidFees;
            _NewLicense.Notes = _OldLicense.Notes;

            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("InActive License ! Please Enter A Valide License ID)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!_ReplaceLicenseApplication.Save())
            {
                MessageBox.Show("Couldn't Save The Application [Renew Local Driving License]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _NewLicense.ApplicationID = _ReplaceLicenseApplication.AppID;
            if (!_NewLicense.Save())
            {
                MessageBox.Show("Couldn't Save The New License Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsMainApplication.DeleteApp(_ReplaceLicenseApplication.AppID);
                return false;
            }
            _OldLicense.IsActive = false;
            _OldLicense.Save();
            return true;


        }

        private void btnIssueReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure To Complete The Operation ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_AddNewLicense())
                {
                    MessageBox.Show("Done Successfully");
                    lblLR_ApplicationID.Text = _ReplaceLicenseApplication.AppID.ToString();
                    lblReplacedLicenseID.Text = _NewLicense.LicenseID.ToString();
                    lnkShowNewLicInfo.Enabled = true;
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

        private void lnkShowNewLicInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDisplayLocalLicenseInfo DisplayNewLicenseInfo = new frmDisplayLocalLicenseInfo(_NewLicense.LicenseID);
            DisplayNewLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
