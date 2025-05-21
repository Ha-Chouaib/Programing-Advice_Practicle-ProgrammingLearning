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

namespace DVLD_Project.Applications.Detain_Release_License_App
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        clsMainApplication _ReleaseLicense_Application;
        clsLicenses _License_To_Release;
        clsDetainLicenses _ReleaseDetainedLicense;

        int _LicenseID = -1;
        bool _EnabledFindLicenseControl = true;

        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReLoadContent;

        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            _EnabledFindLicenseControl = false;
        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

            _DisplayOperationInfoHandler();
        }

        private void _GetTargetedLicense(object sender,clsLicenses License)
        {
            _License_To_Release = License;
            ctrlFindAndDisplayDriverLicense1.__DisplayLicenseRecord(License.LicenseID);
            _ShowReleaseApplicationBasicInfo();

        }

        private void _DisplayOperationInfoHandler()
        {
            if(!_EnabledFindLicenseControl)
            {
                _License_To_Release = clsLicenses.Find(_LicenseID);
                ctrlFindAndDisplayDriverLicense1.__DisplayLicenseRecord(_LicenseID, _EnabledFindLicenseControl);
                _ShowReleaseApplicationBasicInfo();
            }else
            {
                ctrlFindAndDisplayDriverLicense1.__GetLicenseRecord += _GetTargetedLicense;

            }
        }

        private void _Fill_ApplicationRecord()
        {
            _ReleaseLicense_Application = new clsMainApplication();

            _ReleaseLicense_Application.AppTypeID = (int)clsGlobal.enApplicationTypes_IDs.ReleaseDetainedDrivingLicsense;
            _ReleaseLicense_Application.ApplicantPersonID = clsMainApplication.Find(_License_To_Release.ApplicationID).ApplicantPersonID;
            _ReleaseLicense_Application.AppDate = DateTime.Now;
            _ReleaseLicense_Application.AppStatus = (byte)clsGlobal.enApplicationStatus.Complete;
            _ReleaseLicense_Application.CreatedByUserID = clsGlobal.CurrentUserID;
            _ReleaseLicense_Application.LastStatusDate = DateTime.Now;
            _ReleaseLicense_Application.PaidFees = clsApplicationTypes.Find(_ReleaseLicense_Application.AppTypeID).AppFees;
        }
        private void _Fill_ReleaseLicenseOperationRecord()
        {
            _ReleaseDetainedLicense = clsDetainLicenses.FindByLicenseID(_License_To_Release.LicenseID);
            _ReleaseDetainedLicense.IsReleased = true;
            _ReleaseDetainedLicense.ReleaseDate = DateTime.Now;
            _ReleaseDetainedLicense.ReleasedByUserID = clsGlobal.CurrentUserID;
            _ReleaseDetainedLicense.ReleaseApplicationID = _ReleaseLicense_Application.AppID;
        }
        private void _ShowReleaseApplicationBasicInfo()
        {
            _Fill_ApplicationRecord();
            _Fill_ReleaseLicenseOperationRecord();


            lblApplicationDate.Text = _ReleaseLicense_Application.AppDate.ToShortDateString(); 
            lblApplicationFees.Text = _ReleaseLicense_Application.PaidFees.ToString();
            lblCurrentUserName.Text = clsUsers.Find(clsGlobal.CurrentUserID).UserName;
            lblTotalFees.Text = (_ReleaseLicense_Application.PaidFees + _ReleaseDetainedLicense.FineFees).ToString();
            lblLicenseID.Text = _License_To_Release.LicenseID.ToString();
            lblFineFees.Text = _ReleaseDetainedLicense.FineFees.ToString();
            lblDetainID.Text = _ReleaseDetainedLicense.DetainID.ToString();
       
        }

        private bool _ReleaseLicense()
        {

            if (!_License_To_Release.IsActive)
            {
                MessageBox.Show("InActive License ! Please Enter A Valide License ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!clsDetainLicenses.IsDetainedByLicenseID(_License_To_Release.LicenseID))
            {
                MessageBox.Show("This License Is not Detained [It's an Active License] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

      
           
            if (!_ReleaseLicense_Application.Save())
            {
                MessageBox.Show("Cannot Release The Current License. < Couldn't Save Release License Application >-DB Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _ReleaseDetainedLicense.ReleaseApplicationID = _ReleaseLicense_Application.AppID;
            if(!_ReleaseDetainedLicense.Save())
            {
                MessageBox.Show("Cannot Release The Current License. < Couldn't Save Release Operation Data >-DB Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsMainApplication.DeleteApp(_ReleaseLicense_Application.AppID);
                return false;
            }

            return true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Sure To Complete The Operation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_ReleaseLicense())
                {
                    MessageBox.Show("The License Released Successfully");
                   lblR_ApplicationID.Text = "[ " + _ReleaseLicense_Application.AppID.ToString() + " ]";
                    __ReLoadContent?.Invoke(this);
                }

            }
            else
            {
                MessageBox.Show("Operation Ignored Successfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
