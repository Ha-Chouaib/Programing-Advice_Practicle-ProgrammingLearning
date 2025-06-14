using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project.Applications.User_Controls;

namespace DVLD_Project.License
{
    public partial class frmDisplayLocalLicenseInfo : Form
    {
        public frmDisplayLocalLicenseInfo()
        {
            InitializeComponent();
        }

        int _LicenseID = -1;
        public frmDisplayLocalLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            _DisplayLicenseInfo();
        }
        private void _DisplayLicenseInfo()
        {
            ctrlDisplayDriverLicenseInfo1.__DisplayDriverLicenseInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
