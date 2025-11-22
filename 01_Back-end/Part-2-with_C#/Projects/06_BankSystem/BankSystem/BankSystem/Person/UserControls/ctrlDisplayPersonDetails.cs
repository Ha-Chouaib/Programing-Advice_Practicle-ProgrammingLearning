using Bank_BusinessLayer;
using BankSystem.Properties;
using DVLD_BusinessLayer;
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

namespace BankSystem.Person.UserControls
{
    public partial class ctrlDisplayPersonDetails : UserControl
    {
        public ctrlDisplayPersonDetails()
        {
            InitializeComponent();
        }
        private clsPerson _Person { get; set; }
        public void __ShowPersonalInfo(clsPerson  person)
        {
            _Person = person;
            if (_Person != null)
            {

                lnkEditPersonInfo.Text = $"Edit {_Person.FirstName}'s Info";

                lblPersonID.Text = "[ " + _Person.PersonID.ToString() + " ]";
                lblName.Text = _Person.FullName;
                lblNationalNo.Text = _Person.NationalNo;
                lblAddress.Text = _Person.Address;
                lblEmail.Text = _Person.Email;             
                lblGender.Text = (_Person.Gender == 0) ? "Male" : "Female";
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblPhone.Text = _Person.Phone;
                lblCountry.Text = clsCountries.Find(_Person.CountryID).CountryName;

                if (!string.IsNullOrWhiteSpace(_Person.ImagePath) && File.Exists(_Person.ImagePath))
                {
                    using (var img = Image.FromFile(_Person.ImagePath))
                    {
                        pbProfileImg.Image = new Bitmap(img);  // prevents file locking
                    }
                }
                else
                {
                    pbProfileImg.Image = (_Person.Gender == 0)
                        ? Resources.person_man
                        : Resources.person_woman;
                }


            }
        }

        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_Person != null)
            {
                frmEditPerson EditPersonInfo = new frmEditPerson(_Person);
                EditPersonInfo.__GetUpdatedPersonRecord += RefreshPersonRecord;
                EditPersonInfo.ShowDialog();
            }
        }
        private void RefreshPersonRecord(clsPerson person)
        {
            __ShowPersonalInfo(person);
        }
    }
}
