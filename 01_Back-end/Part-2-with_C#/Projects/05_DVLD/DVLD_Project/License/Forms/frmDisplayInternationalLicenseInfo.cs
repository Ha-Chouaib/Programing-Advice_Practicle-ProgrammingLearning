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

namespace DVLD_Project.License
{
    public partial class frmDisplayInternationalLicenseInfo : Form
    {
        public frmDisplayInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        int _InternationalLicenseID = -1;

        public frmDisplayInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }
        private void frmDisplayInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            _DisplayInternationalInfo();
        }

        private void _DisplayInternationalInfo()
        {
            
            ctrlDisplayDriverInternationalLicenseInfo1.__DisplayDriverInternationalInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
