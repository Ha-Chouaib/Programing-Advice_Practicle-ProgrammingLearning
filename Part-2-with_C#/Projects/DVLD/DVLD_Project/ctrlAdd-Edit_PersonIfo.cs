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

namespace DVLD_Project
{
    public partial class ctrlAdd_Edit_PersonIfo: UserControl
    {
        public ctrlAdd_Edit_PersonIfo()
        {
            InitializeComponent();
        }
       
        private void ctrlAdd_Edit_PersonIfo_Load(object sender, EventArgs e)
        {
            _LoadCountriesToComboBox();
            rbGender_M.Checked = true;
        }

        public delegate void ReturnPersonInfoHandler(object sender, int PersonID);
        public event ReturnPersonInfoHandler ReturnID;

        public delegate void TriggerFunction(object sender);
        public event TriggerFunction LeaveForm;

        clsPeople NewPerson = new clsPeople();
        //public int NewPersonID { get { return NewPerson.PersonID; } }
        enum enMode { eAddNew,eUpdate}
        enMode _Mode;
        private void _LoadCountriesToComboBox()
        {
            DataTable DT = clsCountries.ListAll();
            foreach(DataRow row in DT.Rows)
            {
                cmbCountry.Items.Add(row["CountryName"]);
            }
            cmbCountry.SelectedIndex = 10;
        }
        
        ErrorProvider errProv = new ErrorProvider();

        private void _FillPersonRecordWithNewInfo(clsPeople  _Person)
        {
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;

            if (rbGender_M.Checked)
                _Person.Gender = 0;
            else
                _Person.Gender = 1;

            _Person.NationalityCountryID = clsCountries.Find(cmbCountry.SelectedItem.ToString()).CountryID;

        }

        private bool _AddNewPerson()
        {
            _Mode = enMode.eAddNew;
            _FillPersonRecordWithNewInfo(NewPerson);
            

            return NewPerson.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.eAddNew)
            {
                if (MessageBox.Show("Are you Sure to add New Person? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(_AddNewPerson())
                    {
                        MessageBox.Show("Added Successfully");
                        ReturnID?.Invoke(this, NewPerson.PersonID);
                    }
                    else
                    {
                        MessageBox.Show("Something Seems To have Gone wrong. The Operation Faild !");

                    }
                }
                else
                {
                    MessageBox.Show("The Operation Ignored successfully", "Info");
                }
            }
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure To Leave ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LeaveForm?.Invoke(this);
            }

        }
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtB = (TextBox)sender;

            if (txtB.Text == string.Empty)
            {
                e.Cancel = true;
                errProv.SetError(txtB, "This Field Is required!");
            }
            else
            {
                e.Cancel = false;
                errProv.SetError(txtB, "");

            }

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if ((txtNationalNo.Text == string.Empty) || clsPeople.IsExist(txtNationalNo.Text))
            {
                e.Cancel = true;
                errProv.SetError(txtNationalNo, "The Filed Should Not Be Empty// The Current National No May Already Exist !");
            }
            else
            {
                e.Cancel = false;
                errProv.SetError(txtNationalNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(txtEmail.Text != string.Empty)
            {
                if (!txtEmail.Text.EndsWith(".com") || !txtEmail.Text.Contains("@") || txtEmail.Text.EndsWith("@.com"))
                {
                    e.Cancel = true;
                    errProv.SetError(txtEmail, "Email Format Must be Like: example@example.com");
                }
                else
                {
                    e.Cancel = false;
                    errProv.SetError(txtEmail, "");
                }
            }
            
        }

        
    }
}
