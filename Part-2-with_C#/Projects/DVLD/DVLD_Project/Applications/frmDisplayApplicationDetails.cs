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

namespace DVLD_Project.Applications
{
    public partial class frmDisplayApplicationDetails : Form
    {
        public frmDisplayApplicationDetails()
        {
            InitializeComponent();
        }

        int _LDL_AppID = -1;
        public frmDisplayApplicationDetails(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            this._LDL_AppID = LocalDrivingLicenseAppID;
        }

        private void frmDisplayApplicationDetails_Load(object sender, EventArgs e)
        {
            _DisplayInfo();
        }

        private void _DisplayInfo()
        {
            ctrlDisplayApplicationLicenseInfo1.__DisplayLDL_AppInfo(_LDL_AppID);
            int MainApplicationID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LDL_AppID).MainApplicationID;
            ctrlDisplayApplicationInfo1.__DisplayApplicationInfo(MainApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();      
        }
    }
}
