using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Applications;
using DVLD_BusinessLayer.Licenses;
using DVLD_Project.Properties;

namespace DVLD_Project.License.UserControls
{
    public partial class ctrlDisplayDriverLocalLicenseInfo : UserControl
    {
        public ctrlDisplayDriverLocalLicenseInfo()
        {
            InitializeComponent();
        }

        int _LicenseID = -1;

        public void __DisplayDriverLicenseInfo(int DriverLicense_ID)
        {
            _LicenseID = DriverLicense_ID;
            _ShowInfo();
        }


        private void _ShowInfo()
        {
            clsLicenses License = clsLicenses.Find(_LicenseID);

            if(License != null)
            {
                Image DriverDefaultPicture;

                lblLicenseID.Text = _LicenseID.ToString();

                lblNationalNo.Text =License.DriverInfo.PersonInfo.NationalNo;
                lblDriverID.Text =License.DriverID.ToString();

                if(License.DriverInfo.PersonInfo.Gender == 0)
                {
                    lblGender.Text ="Male";
                    DriverDefaultPicture = Resources.user_Male;
                }
                else
                {
                    lblGender.Text ="Female";
                    DriverDefaultPicture = Resources.user_female;
                }

                lblDateOfBirth.Text = License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

                if(License.Notes == string.Empty)
                    txtNotes.Text = "No Notes";
                else
                    txtNotes.Text = License.Notes;

                lblIssueDate.Text =License.IssueDate.ToShortDateString();
                lblExpirationDate.Text =License.ExpirationDate.ToShortDateString();


                switch(License.IssueReason)
                {
                    case (byte)clsLicenses.enIssueReason.FirstTime:
                        lblIssueReason.Text = "FirstTime";
                        break;
                    case (byte)clsLicenses.enIssueReason.RenewLicense:
                        lblIssueReason.Text = "Renew Expired License";
                        break;
                    case (byte)clsLicenses.enIssueReason.ReplaceFoDamage:
                        lblIssueReason.Text = "Replacement for Damage";
                        break;
                    case (byte)clsLicenses.enIssueReason.ReplaceForLost:
                        lblIssueReason.Text = "Replacement for Lost";
                        break;
                    default:
                        lblIssueReason.Text = "Unknown";
                        break;
                }

                if(clsDetainLicenses.IsDetainedByLicenseID(License.LicenseID))
                    lblIsDetained.Text ="Yes";
                else
                    lblIsDetained.Text = "No";

                if (License.IsActive)
                    lblIsActive.Text ="Yes";
                else
                    lblIsActive.Text = "No";

                lblLicenseClassName.Text = License.LicenseClassInfo.LicenseClassName;
                lblDriverName.Text = License.DriverInfo.PersonInfo.FullName;

                if (License.DriverInfo.PersonInfo.ImagePath != string.Empty && File.Exists(License.DriverInfo.PersonInfo.ImagePath))
                {
                    pbDriverImg.Image = Image.FromFile(License.DriverInfo.PersonInfo.ImagePath);
                }
                else
                    pbDriverImg.Image = DriverDefaultPicture;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
