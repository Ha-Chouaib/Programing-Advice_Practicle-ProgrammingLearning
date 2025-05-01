using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using System.IO;
using DVLD_Project.Properties;

namespace DVLD_Project
{
    public partial class ctrlPersonDetails: UserControl
    {
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        

        public int __PersonID { get; set; }
        clsPeople Person;
       
        public void __DisplayPersonInfo(int PersonID)
        {
            Person = clsPeople.Find(PersonID);
            if(Person != null)
            {
                __PersonID = PersonID;
                lblPersonID.Text = __PersonID.ToString();
                string FullName = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lblName.Text = FullName;
                lblNationalNo.Text = Person.NationalNo;
                lblAddress.Text = Person.Address;
                lblEmail.Text = Person.Email;

                if (Person.Gender == 0)
                    lblGender.Text = "Male";
                else
                    lblGender.Text = "Female";
                lblDateOfBirth.Text = Person.DateOfBirth.ToShortDateString();
                lblPhone.Text = Person.Phone;
                lblCountry.Text = clsCountries.Find(Person.NationalityCountryID).CountryName;

                if(Person.ImagePath != string.Empty && File.Exists(Person.ImagePath))
                {
                    pbProfileImg.Image = Image.FromFile( Person.ImagePath);
                }else
                {
                    if (Person.Gender == 0)
                        pbProfileImg.Image=Resources.user_Male;
                    else
                        pbProfileImg.Image=Resources.user_female;
                }

            }
           

        }

        private void btnEditPersonInfo_Click(object sender, EventArgs e)
        {
            if(clsPeople.IsExist(__PersonID))
            {
                frmAdd_Edit_People EditForm = new frmAdd_Edit_People(__PersonID);
                EditForm.ReLoadData += ReloadInfo;
                EditForm.ShowDialog();
            }else
            {
                MessageBox.Show($"No Person Exist With ID <<{__PersonID}>>");
            }

        }
        private void ReloadInfo(object sender)
        {
            __DisplayPersonInfo(__PersonID);
        }
       
    }
}
