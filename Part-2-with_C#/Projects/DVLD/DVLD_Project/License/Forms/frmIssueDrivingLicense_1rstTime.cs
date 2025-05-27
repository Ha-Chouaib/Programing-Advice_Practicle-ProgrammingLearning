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
            ctrlDisplayApplicationInfo1.__DisplayApplicationInfo(clsLocalDrivingLicense.Find(_LDL_AppID).MainApplicationID);
        }


        private bool _SaveNewLicense()
        {
            clsLocalDrivingLicense LocalLicenseApp = clsLocalDrivingLicense.Find(_LDL_AppID);
            clsMainApplication NewLocalLicense_Application = clsMainApplication.Find(LocalLicenseApp.MainApplicationID);
            clsDrivers Driver;

            bool IsNewDriver=true;
            if (clsDrivers.Exist(NewLocalLicense_Application.ApplicantPersonID))
            {
                Driver = clsDrivers.Find(NewLocalLicense_Application.ApplicantPersonID);
                IsNewDriver = false;
            }
            else
            {
                Driver = new clsDrivers();
                Driver._PersonID = NewLocalLicense_Application.ApplicantPersonID;
                Driver._CreatedByUserID = clsGlobal.CurrentUserID;
                Driver._CreatedDate = DateTime.Now;
                if (!Driver.Save())
                {
                    MessageBox.Show("Couldn't Save The [ New Driver ] Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
            }

            clsLicenseClasses LicenseClass = clsLicenseClasses.Find(LocalLicenseApp.LicenseClassID);
            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = NewLocalLicense_Application.AppID;
            NewLicense.DriverID = Driver._DriverID;
            NewLicense.LicenseClassID = LocalLicenseApp.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(LicenseClass.DefaultValidityLength);
            NewLicense.Notes = txtNotes.Text;
            NewLicense.PaidFees = LicenseClass.LicenseFees;
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
                NewLocalLicense_Application.AppStatus = (byte)clsMainApplication.enApplicationStatus.Completed;
                NewLocalLicense_Application.LastStatusDate = DateTime.Now;    
                if(!NewLocalLicense_Application.Save())
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
