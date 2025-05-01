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
using System.Runtime.CompilerServices;
using DVLD_Project.Properties;
using System.IO;

namespace DVLD_Project
{
    public partial class ctrlAdd_Edit_PersonIfo: UserControl
    {
        public ctrlAdd_Edit_PersonIfo()
        {
            InitializeComponent();
        }

        enum enMode { eAddNew,eUpdate}
        enMode _Mode;
        private void ctrlAdd_Edit_PersonIfo_Load(object sender, EventArgs e)
        {
            _LoadCountriesToComboBox();
            rbGender_M.Checked = true;
        }


        public delegate void ReturnPersonInfoHandler(object sender, int PersonID);
        public event ReturnPersonInfoHandler __ReturnID;

        public delegate void TriggerFunction(object sender);
        public event TriggerFunction __LeaveForm;

        private int _PersonID ; 
        clsPeople Person ;
        ErrorProvider errProv = new ErrorProvider();

        private void _LoadCountriesToComboBox()
        {
            DataTable DT = clsCountries.ListAll();
            foreach(DataRow row in DT.Rows)
            {
                cmbCountry.Items.Add(row["CountryName"]);
            } 
            cmbCountry.SelectedIndex = 119;
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }
        public void __ApplyMode(int PersonID)
        {
            if (clsPeople.IsExist(PersonID))
            {
                _Mode = enMode.eUpdate;
                _PersonID = PersonID;
                Person = clsPeople.Find(_PersonID);
                _UploadOldDataToFields();

            }
            else
            {
                _Mode = enMode.eAddNew;
                Person = new clsPeople();
            }
        }


        private void _FillPersonRecordWithNewInfo()
        {
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = txtThirdName.Text;
            Person.LastName = txtLastName.Text;
            Person.NationalNo = txtNationalNo.Text;
            Person.Address = txtAddress.Text;
            Person.DateOfBirth = dtDateOfBirth.Value;
            Person.Phone = txtPhone.Text;
            Person.Email = txtEmail.Text;

            if (rbGender_M.Checked)
                Person.Gender = 0;
            else
                Person.Gender = 1;

            Person.NationalityCountryID = clsCountries.Find(cmbCountry.SelectedItem.ToString()).CountryID;
            if (pbPersonImg.Tag != null)
            {
                Person.ImagePath = pbPersonImg.Tag as string;
            }
        }
        
        private void _UploadOldDataToFields()
        {
            if(Person != null)
            {
                txtFirstName.Text = Person.FirstName;
                txtSecondName.Text = Person.SecondName;
                txtThirdName.Text = Person.ThirdName;
                txtLastName.Text = Person.LastName;
                txtNationalNo.Text = Person.NationalNo;
                txtAddress.Text = Person.Address;
                txtPhone.Text = Person.Phone;
                txtEmail.Text = Person.Email;
                dtDateOfBirth.Value = Person.DateOfBirth;
                if (Person.Gender == 0) rbGender_M.Checked = true;
                else
                    rbGender_F.Checked = true;
                cmbCountry.SelectedIndex = cmbCountry.FindString(clsCountries.Find(Person.NationalityCountryID).CountryName);

                if(Person.ImagePath != string.Empty && File.Exists(Person.ImagePath))
                {
                    pbPersonImg.Image = Image.FromFile(Person.ImagePath);
                    lnkRemoveImg.Visible = true;
                }

            }else
            {
                MessageBox.Show($"No Record With Person ID << {_PersonID} >>!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private bool _FinalValidation()
        {
            txtEmail.Tag = "Email";
            byte isEmpty = 0;
            foreach(Control txtB in pnlContainer.Controls.OfType<TextBox>())
            {
                if(txtB.Text == string.Empty && string.IsNullOrWhiteSpace(txtB.Tag?.ToString()))
                {
                    errProv.SetError(txtB, "This Field is Required");
                    isEmpty++;
                }else
                {
                    errProv.SetError(txtB, "");
                }
            }
            txtEmail.Tag = string.Empty;
            return (isEmpty == 0);
        }
        private bool _AddNewPerson()
        {
            _FillPersonRecordWithNewInfo();
            
            return Person.Save();
        }
        private bool _SaveUpdates()
        {
            if (Person != null)
                _FillPersonRecordWithNewInfo();

            return Person.Save();
        }
        private void AddOperation()
        {   

            if (_AddNewPerson())
            {
                MessageBox.Show("Added Successfully");
                _CopyPersonImgToFile();
                __ReturnID?.Invoke(this, Person.PersonID);
            }
            else
            {
                MessageBox.Show("Something Seems To have Gone wrong.Can't Add The New Record !");
            }
        }
        private void UpdateOperation()
        {

            if (_SaveUpdates())
            {
                MessageBox.Show("updated Successfully");
                _CopyPersonImgToFile();
            }
            else
            {
                MessageBox.Show("Something Seems To have Gone wrong. The Can't Update the Recodr !");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_FinalValidation())
            {
                MessageBox.Show("You must Fill All Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            if (MessageBox.Show("Are you sure to complete the operation", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch(_Mode)
                {
                    case enMode.eAddNew:
                        AddOperation();
                        break;
                    case enMode.eUpdate:
                        UpdateOperation();
                        break;
                    default:
                        break;
                }
            }
             else
             {
                MessageBox.Show("The Operation Ignored successfully", "Info");
             }                      
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure To Leave ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                __LeaveForm?.Invoke(this);
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

        private void rbGender_M_CheckedChanged(object sender, EventArgs e)
        {
            if(Person != null &&(Person.ImagePath  == string.Empty || !File.Exists(Person.ImagePath)))
            {
                if (rbGender_M.Checked == true)
                {
                    pbPersonImg.Image = Resources.user_Male;
                }else
                {
                    pbPersonImg.Image = Resources.user_female;

                }

            }
            
        }

        private void lnkImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdGetImgPath.InitialDirectory = @"C:\";
            ofdGetImgPath.Title = "Pick an Image";
            ofdGetImgPath.Filter = "Png (*.png)|*.png|Jpeg (*.jpeg)|*.jpeg|jpg(*.jpg)|*.jpg|HEIC (*.heic)|*.heic";
            ofdGetImgPath.FilterIndex = 3;

            if(ofdGetImgPath.ShowDialog()== DialogResult.OK)
            {
                pbPersonImg.Image = Image.FromFile(ofdGetImgPath.FileName);
                pbPersonImg.Tag = ofdGetImgPath.FileName;
                lnkRemoveImg.Visible = true;
            }
        }
        private void lnkRemoveImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   
            if(rbGender_M.Checked ==true)
            {
                pbPersonImg.Image = Resources.user_Male;
            }else
            {
                pbPersonImg.Image = Resources.user_female;
            }
            pbPersonImg.Tag = null;
        }
        public struct stPersonGuid
        {
            public int PersonID { get; set; }
            public Guid ImgGuid { get; set; }

            public void SetPersonImgGuid(int PersonID)
            {
                this.PersonID = PersonID;
                this.ImgGuid = Guid.NewGuid();
            }
        }
        

        Dictionary<int, Guid> PersonImgGuid = new Dictionary<int, Guid>();
        private void _CopyPersonImgToFile()
        {
            stPersonGuid Person_ID_Guid = new stPersonGuid();

            string DestinationFolder = @"C:\DVLD_PeopleImgs";
            if (!Directory.Exists(DestinationFolder))
            {
                Directory.CreateDirectory(DestinationFolder);
            }

            if (Person.ImagePath != string.Empty)
            {
                string ImgExtension = Path.GetExtension(Person.ImagePath);
                               
                if(!PersonImgGuid.ContainsKey(Person_ID_Guid.PersonID))
                {
                    Person_ID_Guid.SetPersonImgGuid(Person.PersonID);
                    PersonImgGuid.Add(Person_ID_Guid.PersonID, Person_ID_Guid.ImgGuid);
                }


                string ImgDestinationPath = Path.Combine(DestinationFolder, Person_ID_Guid.ImgGuid + ImgExtension);

                var ExistingFiles = Directory.GetFiles(DestinationFolder, Person_ID_Guid.ImgGuid + ".*");
                foreach(var file in ExistingFiles)
                {
                    if (file != ImgDestinationPath) File.Delete(file);
                }

                File.Copy(Person.ImagePath, ImgDestinationPath, true);

            } else
            {
                if(PersonImgGuid.ContainsKey(Person.PersonID))
                {
                    string ImgExtension = Path.GetExtension(Person.ImagePath);
                    string ImgPath = Path.Combine(DestinationFolder, Person_ID_Guid.ImgGuid + ImgExtension);
                    File.Delete(ImgPath);
                }
            }



        }

       
    }
}
