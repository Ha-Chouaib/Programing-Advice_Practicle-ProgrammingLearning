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

namespace DVLD_Project.License
{
    public partial class frmIssueDrivingLicense_1rstTime : Form
    {
        public frmIssueDrivingLicense_1rstTime()
        {
            InitializeComponent();
        }
        int _LDL_AppID = -1;
        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler __ReloadContent;
        public frmIssueDrivingLicense_1rstTime(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LDL_AppID = LocalDrivingLicenseID;
        }

        private void frmIssueDrivingLicense_1rstTime_Load(object sender, EventArgs e)
        {
            _DisplayLocalAppInfo();
        }
        private void _DisplayLocalAppInfo()
        {
            ctrlDisplayApplicationLicenseInfo1.__DisplayLDL_AppInfo(_LDL_AppID);
            ctrlDisplayApplicationInfo1.__DisplayApplicationInfo(clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDL_AppID).MainApplicationID);
        }


        private bool _SaveNewLicense()
        {
            clsLocalDrivingLicenseApplication LocalLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDL_AppID);
            clsDrivers Driver;

            bool IsNewDriver=true;
            if (clsDrivers.Exist(LocalLicenseApplication.ApplicantPersonID))
            {
                Driver = clsDrivers.FindByPersonID(LocalLicenseApplication.ApplicantPersonID);
                IsNewDriver = false;
            }
            else
            {
                Driver = new clsDrivers();
                Driver._PersonID = LocalLicenseApplication.ApplicantPersonID;
                Driver._CreatedByUserID = clsGlobal.CurrentUserID;
                Driver._CreatedDate = DateTime.Now;
                if (!Driver.Save())
                {
                    MessageBox.Show("Couldn't Save The [ New Driver ] Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
            }

          
            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = LocalLicenseApplication.MainApplicationID;
            NewLicense.DriverID = Driver._DriverID;
            NewLicense.LicenseClassID = LocalLicenseApplication.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(LocalLicenseApplication.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = txtNotes.Text;
            NewLicense.PaidFees = LocalLicenseApplication.LicenseClassInfo.LicenseFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason =(byte) clsLicenses.enIssueReason.FirstTime;
            NewLicense.CreatedByUserID = clsGlobal.CurrentUserID;

            if(!NewLicense.Save())
            {
                MessageBox.Show("Couldn't Save The [ New License ] Record !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (IsNewDriver)
                    clsDrivers.DeleteDriver(Driver._DriverID);
                return false;
            }
            else
            {
               
                if(!clsMainApplication.UpdateApplicationStatus(LocalLicenseApplication.MainApplicationID,clsMainApplication.enApplicationStatus.Completed))
                {
                    MessageBox.Show("Operation Fialds Please Try Again ! [Error]->(Couldn't Update Application Status)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clsLicenses.DeleteLicense(NewLicense.LicenseID);
                    if (IsNewDriver)
                        clsDrivers.DeleteDriver(Driver._DriverID);

                    return false;
                }
                return true;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(_SaveNewLicense())
            {
                MessageBox.Show("Done Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                __ReloadContent?.Invoke(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
