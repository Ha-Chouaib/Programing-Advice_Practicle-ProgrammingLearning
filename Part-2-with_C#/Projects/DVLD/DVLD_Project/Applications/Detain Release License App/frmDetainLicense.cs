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
using DVLD_BusinessLayer.Licenses;

namespace DVLD_Project.Applications.Detain_License_App
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        clsLicenses _License;
        clsDetainLicenses _DetainLicenseOperation;
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlFindAndDisplayDriverLicense1.__GetLicenseRecord += _GetTargetedLicense;
            
        }

        private void _GetTargetedLicense(object sender, clsLicenses License)
        {
            _License = License;
            ctrlFindAndDisplayDriverLicense1.__DisplayLicenseRecord(_License.LicenseID);
            _DisplayBasicInfo();
        }

        private void _DisplayBasicInfo()
        {
            lblCurrentUserName.Text = clsUsers.Find(clsGlobal.CurrentUserID).UserName;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblLicenseID.Text = _License.LicenseID.ToString();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if(txtFineFees.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider ErrorPro = new ErrorProvider();
            if(txtFineFees.Text == string.Empty)
            {
                ErrorPro.SetError(txtFineFees, "You Have To Enter The Fine Fees First To Detain a License");
            }else
            {
                ErrorPro.SetError(txtFineFees, "");

            }
        }

        private bool _DetainLicens()
        {
            if(!_License.IsActive)
            {
                MessageBox.Show("InActive License ! Please Enter A Valide License ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsDetainLicenses.IsDetainedByLicenseID(_License.LicenseID))
            {
                MessageBox.Show("This License Is Already Detained !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _DetainLicenseOperation = new clsDetainLicenses();

            _DetainLicenseOperation.LicenseID = _License.LicenseID;
            _DetainLicenseOperation.DetainDate = DateTime.Now;
            _DetainLicenseOperation.FineFees = float.Parse(txtFineFees.Text);
            _DetainLicenseOperation.CreatedByUserID = clsGlobal.CurrentUserID;
            _DetainLicenseOperation.IsReleased = false;

            if(!_DetainLicenseOperation.Save())
            {
                MessageBox.Show("Can't Detain This License [Saving Detain Record Issue] !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            


            return true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(txtFineFees.Text == string.Empty)
            {
                txtFineFees.KeyPress += txtFineFees_KeyPress;
                return;
            }

            if(MessageBox.Show("Sure To Completed The Operation?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                if(_DetainLicens())
                {
                    MessageBox.Show("The License Detained Successfully");
                    lblDetainID.Text = "[ "+_DetainLicenseOperation.DetainID.ToString() +" ]";
                }

            }else
            {
                MessageBox.Show("Ignored Successfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
