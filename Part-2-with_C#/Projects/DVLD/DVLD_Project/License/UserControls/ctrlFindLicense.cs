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
    public partial class ctrlFindLicense : UserControl
    {
        public ctrlFindLicense()
        {
            InitializeComponent();
        }
        clsLicenses License;

        public delegate void SendLicenseRecordEventHandler(object sender, clsLicenses License);
        public event SendLicenseRecordEventHandler __SendLicense;
        private void _FindLicense()
        {
            int LicenseID = int.Parse(txtLicenseID.Text);
           
            License = clsLicenses.Find(LicenseID);
            if (License != null)
            {
                __SendLicense?.Invoke(this, License);
            }else
            {
                MessageBox.Show($"No License Exists With ID << {LicenseID} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void __DisAbleEnableFindLicenseControl(bool Enabled)
        {
            groupBox1.Enabled = Enabled;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindLicense();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
