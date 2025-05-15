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
    public partial class ctrlDisplayDriverLicenseInfo : UserControl
    {
        public ctrlDisplayDriverLicenseInfo()
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
            clsPeople Person = clsPeople.Find(clsMainApplication.Find(License.ApplicationID).ApplicantPersonID);

            if(License != null)
            {
                Image DriverDefaultPicture;

                lblLicenseID.Text = _LicenseID.ToString();

                lblNationalNo.Text =Person.NationalNo;
                lblDriverID.Text =License.DriverID.ToString();

                if(Person.Gender == 0)
                {
                    lblGender.Text ="Male";
                    DriverDefaultPicture = Resources.user_Male;
                }
                else
                {
                    lblGender.Text ="Female";
                    DriverDefaultPicture = Resources.user_female;
                }

                lblDateOfBirth.Text =Person.DateOfBirth.ToShortDateString();

                if(License.Notes == string.Empty)
                    txtNotes.Text = "No Notes";
                else
                    txtNotes.Text = License.Notes;

                lblIssueDate.Text =License.IssueDate.ToShortDateString();
                lblExpirationDate.Text =License.ExpirationDate.ToShortDateString();
                lblIssueReason.Text =License.IssueReason.ToString();

                lblIsDetained.Text ="No";//return Back

                if(License.IsActive)
                    lblIsActive.Text ="Yes";
                else
                    lblIsActive.Text = "No";

                lblLicenseClassName.Text =clsLicenseClasses.Find(License.LicenseClassID).LicenseClassName;
                lblDriverName.Text = Person.FirstName+" "+ Person.SecondName + " " + Person.ThirdName + " " + Person.LastName ;

                if (Person.ImagePath != string.Empty && File.Exists(Person.ImagePath))
                {
                    pbDriverImg.Image = Image.FromFile(Person.ImagePath);
                }
                else
                    pbDriverImg.Image = DriverDefaultPicture;
            }

        }

    }
}
