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
using DVLD_Project.License;

namespace DVLD_Project.Applications.User_Controls
{
    public partial class ctrlDisplayApplicationLicenseInfo : UserControl
    {
        public ctrlDisplayApplicationLicenseInfo()
        {
            InitializeComponent();
        }
        int _LDL_AppID = -1;
        private void ctrlDisplayApplicationLicenseInfo_Load(object sender, EventArgs e)
        {
            
        }

        public void __DisplayLDL_AppInfo(int LocalDrivingLicense_AppID)
        {
            _LDL_AppID = LocalDrivingLicense_AppID;
            _ShowInfo();
        } 
        private void _ShowInfo()
        {
            if(_LDL_AppID != -1)
            {
                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDL_AppID);
                
                lblLDL_AppID.Text= _LDL_AppID.ToString();
                lblPassedTests.Text = $"{clsLocalDrivingLicenseApplication.GetPassedTestsCount(_LDL_AppID)}/3";
                lblLicenseClassName.Text = LocalDrivingLicenseApplication.LicenseClassInfo.LicenseClassName;
            }
        }
       

        private void lnkShoeLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmLicenseClassDetails LicenseClassInfo = new frmLicenseClassDetails(clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDL_AppID).LicenseClassID);

            LicenseClassInfo.ShowDialog();
        }
    }
}
