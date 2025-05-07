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
            _ShowInfo();
        }

        private void _ShowInfo()
        {
            if(_LDL_AppID != -1)
            {
                clsLocalDrivingLicense LocalApp = clsLocalDrivingLicense.Find(_LDL_AppID);
                
                lblLDL_AppID.Text= _LDL_AppID.ToString();
                lblPassedTests.Text = $"{clsLocalDrivingLicense.GetPassedTestsCount(_LDL_AppID)}/3";
                lblLicenseClassName.Text = clsLicenseClasses.Find(LocalApp.LicenseClassID).LicenseClassName;
            }
        }
        public void __DisplayLDL_AppInfo(int LDL_AppID)
        {
            _LDL_AppID = LDL_AppID;
        }

        private void lnkShoeLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
