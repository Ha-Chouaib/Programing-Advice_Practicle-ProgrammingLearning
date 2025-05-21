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
            clsInternationalLicenses ILicense = clsInternationalLicenses.Find(_InternationalLicenseID);
            if (ILicense != null)
            {
                lblInterLicenseID.Text = "<< " + ILicense.InternationalLicenseID.ToString() + " >>";
                lblLicenseID.Text = ILicense.IssuedUsingLocalLicenseID.ToString();
                lblDriverID.Text = ILicense.DriverID.ToString();
                lblApplicationID.Text = ILicense.ApplicationID.ToString();
                lblIssueDate.Text = ILicense.IssueDate.ToShortDateString();
                lblExpirationDate.Text = ILicense.ExpirationDate.ToShortDateString();

                if (ILicense.IsActive)
                    lblIsActive.Text = "Yes";
                else
                    lblIsActive.Text = "No";

                clsPeople Person = clsPeople.Find(clsMainApplication.Find(ILicense.ApplicationID).ApplicantPersonID);

                lblNationalNo.Text = Person.NationalNo;
                lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();

                Image DefaultImg;
                if (Person.Gender == 0)
                {
                    DefaultImg = Resources.user_Male;
                    lblGender.Text = "Male";
                }
                else
                {
                    DefaultImg = Resources.user_female;
                    lblGender.Text = "Female";
                }

                lblDriverName.Text = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;

                if (Person.ImagePath == string.Empty || !File.Exists(Person.ImagePath))
                {
                    pbDriverImg.Image = DefaultImg;
                }
                else
                {
                    pbDriverImg.Image = Image.FromFile(Person.ImagePath);
                }
            }

        }
    
    
    }
}
