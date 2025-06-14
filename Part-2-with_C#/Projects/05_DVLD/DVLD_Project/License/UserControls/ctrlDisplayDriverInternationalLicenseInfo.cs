using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
    public partial class ctrlDisplayDriverInternationalLicenseInfo : UserControl
    {
        public ctrlDisplayDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        int _InternationalLicenseID = -1;
        public void __DisplayDriverInternationalInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _ShowInfo();
            
        }
        private void _ShowInfo()
        {
            clsInternationalLicenses InternationalLicense = clsInternationalLicenses.Find(_InternationalLicenseID);
            if (InternationalLicense != null)
            {
                lblInterLicenseID.Text = "<< " + InternationalLicense.InternationalLicenseID.ToString() + " >>";
                lblLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
                lblDriverID.Text = InternationalLicense.DriverID.ToString();
                lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
                lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();

                if (InternationalLicense.IsActive)
                    lblIsActive.Text = "Yes";
                else
                    lblIsActive.Text = "No";


                lblNationalNo.Text = InternationalLicense.DriverInfo.PersonInfo.NationalNo;
                lblDateOfBirth.Text = InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

                Image DefaultImg;
                if (InternationalLicense.DriverInfo.PersonInfo.Gender == 0)
                {
                    DefaultImg = Resources.user_Male;
                    lblGender.Text = "Male";
                }
                else
                {
                    DefaultImg = Resources.user_female;
                    lblGender.Text = "Female";
                }

                lblDriverName.Text = InternationalLicense.DriverInfo.PersonInfo.FullName; 

                if (InternationalLicense.DriverInfo.PersonInfo.ImagePath == string.Empty || !File.Exists(InternationalLicense.DriverInfo.PersonInfo.ImagePath))
                {
                    pbDriverImg.Image = DefaultImg;
                }
                else
                {
                    pbDriverImg.Image = Image.FromFile(InternationalLicense.DriverInfo.PersonInfo.ImagePath);
                }
            }

        }
    
    
    }
}
