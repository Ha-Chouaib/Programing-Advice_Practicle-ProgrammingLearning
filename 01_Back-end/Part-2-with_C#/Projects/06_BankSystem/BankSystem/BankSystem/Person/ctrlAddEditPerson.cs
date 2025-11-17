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

namespace BankSystem.Person
{
    public partial class ctrlAddEditPerson : UserControl
    {
        public ctrlAddEditPerson()
        {
            InitializeComponent();
            lblAddEdit.Text =  "Add New Person";
                 
        }
        private void ctrlAddEditPerson_Load(object sender, EventArgs e)
        {   if(!DesignMode)
            _UploadCountries();
        }

        clsPerson _person = new clsPerson();
        ErrorProvider errorProvider = new ErrorProvider();

        public event EventHandler<clsPerson> OnPersonAdded_Updated;
        public event EventHandler OnOperationCanceled;
        public Label __HeadingTitle => lblAddEdit;
        private void _GetPersonInfo()
        {
            _person.FirstName = txtFirstName.Text;
            _person.LastName = txtLastName.Text;
            _person.Email = txtEmail.Text;
            _person.Phone = txtPhoneNumber.Text;
            _person.Address = txtAddress.Text;
            _person.Gender =(byte) ( rbMail.Checked ? 0 : 1);
            _person.NationalNo = txtNationalNo.Text;
            _person.CountryID =(short) clsCountries.Find(cbCountry.SelectedItem.ToString()).CountryID;
            _person.ImagePath = (pbProfileImg.Image != Resources.person_man) || (pbProfileImg.Image != Resources.person_woman) ? pbProfileImg.ImageLocation : string.Empty;
            _person.DateOfBirth = dtDateOfBirth.Value;

        }

        public void UpdatePerson(clsPerson person)
        {

            _person = person;
            if (_person != null)
                _DisplayPersonInfo();
            lblAddEdit.Text = "Edit Person Info";


        }
        private void _DisplayPersonInfo()
        {
            txtFirstName.Text = _person.FirstName;
            txtLastName.Text = _person.LastName;
            txtEmail.Text = _person.Email;
            txtPhoneNumber.Text = _person.Phone;
            txtAddress.Text = _person.Address;
            txtNationalNo.Text = _person.NationalNo;

            if (_person.Gender == 0)
                rbMail.Checked = true;
            else
                rbFemail.Checked = true;

            clsCountries country = clsCountries.Find(_person.CountryID);
            if (country != null)
                cbCountry.SelectedItem = country.CountryName;

            if (!string.IsNullOrEmpty(_person.ImagePath) && File.Exists(_person.ImagePath))
                pbProfileImg.ImageLocation = _person.ImagePath;
            else
                pbProfileImg.Image = (_person.Gender == 0)? Resources.person_man : Resources.person_woman;

            dtDateOfBirth.Value = _person.DateOfBirth;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Can't Saving Changes Please Fill The required Fields", "Messing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("By Clicking [ Yes ] The Will Save Changes permanently","Are You Sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            _GetPersonInfo();
            if (_person.Save())
            {
                lblPersonID.Text = $"Person ID: [{_person.PersonID}]";
                OnPersonAdded_Updated?.Invoke(this, _person);
                btnCancel.Text = "Close";
                lblAddEdit.Text = "Edit Person Info";
                return;
            }
            OnPersonAdded_Updated?.Invoke(this, null);
        }

        private void _UploadCountries()
        {
            DataTable DT = clsCountries.ListAll();
            foreach (DataRow row in DT.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
            cbCountry.SelectedItem = "Morocco";
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
              
                OnOperationCanceled?.Invoke(this,null);
                return;
            
        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if (txtBox.Text == string.Empty)
                errorProvider.SetError(txtBox, "This Field is required !");
            else
                errorProvider.SetError(txtBox, "");

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            if((txtBox.Text == string.Empty) || (clsPerson.Exists(txtNationalNo.Text.Trim()) && _person.NationalNo != txtNationalNo.Text.Trim()) ) 
                errorProvider.SetError(txtBox, "This Field is required !| The NationalNo Should not be Duplicated Please Choose another one.");
            else
                errorProvider.SetError(txtBox, "");
        }

        private void rbMail_CheckedChanged(object sender, EventArgs e)
        {
            if (_person != null && (_person.ImagePath == string.Empty || !File.Exists(_person.ImagePath)))
                pbProfileImg.Image = rbMail.Checked ? Resources.person_man : Resources.person_woman;
        }

        private void lnkUploadProfileImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ofdGetProfileImg.InitialDirectory = @"C:\";
            ofdGetProfileImg.Title = "Pick an Image";
            ofdGetProfileImg.Filter = "Png (*.png)|*.png|Jpeg (*.jpeg)|*.jpeg|jpg(*.jpg)|*.jpg";
            ofdGetProfileImg.FilterIndex = 3;

            if (ofdGetProfileImg.ShowDialog() == DialogResult.OK)
            {
                pbProfileImg.Image = Image.FromFile(ofdGetProfileImg.FileName);
                pbRemoveImg.Visible = true;
            }
        }

        private void pbRemoveImg_Click(object sender, EventArgs e)
        {
            pbProfileImg.Image = rbMail.Checked ? Resources.person_man : Resources.person_woman;
            pbRemoveImg.Visible = false;

        }

      
    }
}
