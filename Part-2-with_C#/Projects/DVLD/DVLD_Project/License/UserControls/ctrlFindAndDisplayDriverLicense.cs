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
    public partial class ctrlFindAndDisplayDriverLicense : UserControl
    {
        public ctrlFindAndDisplayDriverLicense()
        {
            InitializeComponent();
        }
        public delegate void SendLicenserecordEventHabdler(object sender, clsLicenses License);
        public event SendLicenserecordEventHabdler __GetLicenseRecord;

        clsLicenses _License;
        int _LicenseID = -1;
        private void ctrlFindAndDisplayDriverLicense_Load(object sender, EventArgs e)
        {
            ctrlFindLicense1.__SendLicense += _GetDriverLicense;
        }

        private void _GetDriverLicense(object sender,clsLicenses License)
        {
            _License = License;
            _LicenseID = License.LicenseID;
            __GetLicenseRecord?.Invoke(sender, License);
        }
       
        public void __DisplayLicenseRecord(int DriverLicense_ID,bool EnabledFindLicenseCtrl = true)
        {
            _LicenseID = DriverLicense_ID;
            ctrlDisplayDriverLicenseInfo1.__DisplayDriverLicenseInfo(_LicenseID);
            ctrlFindLicense1.__DisAbleEnableFindLicenseControl(EnabledFindLicenseCtrl);
        }
    }
}
