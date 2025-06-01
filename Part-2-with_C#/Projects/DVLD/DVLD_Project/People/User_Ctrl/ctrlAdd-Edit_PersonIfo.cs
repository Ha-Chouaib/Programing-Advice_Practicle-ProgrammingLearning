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
        bool _IsValide = true;
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
        public void __ApplyMode(bool IsAddNewMode ,int PersonID= -1)
        {
             rbGender_M.Checked = true;
            pbPersonImg.Image = Resources.user_Male;
            if (!IsAddNewMode&& clsPeople.IsExist(PersonID))
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
            Person.Gender = (byte)(rbGender_M.Checked ? 0 : 1);
            Person.NationalityCountryID = clsCountries.Find(cmbCountry.SelectedItem.ToString()).CountryID;

          
        }
        
        private void _UploadOldDataToFields()
        {
           
            if (Person != null)
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
      
        private bool _AddNewPerson()
        {
            if (clsPeople.IsExist(Person.PersonID))
            {
                MessageBox.Show($"This Person Is Already Exist You Can Not Add It Twice !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;

            }
            _FillPersonRecordWithNewInfo();
            if (!Person.Save())
            {
                MessageBox.Show($"Can't Add The New Person Record Properly !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }
        private bool _SaveUpdates()
        {
            if (!clsPeople.IsExist(Person.PersonID))
            {
                MessageBox.Show($"No Person Exist With ID: << {Person.PersonID} >> !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (Person != null)
                _FillPersonRecordWithNewInfo();

            if (!Person.Save())
            {
                MessageBox.Show($"Can't Add The New Person Record Properly !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }
        private void AddOperation()
        {
           
            if (_AddNewPerson())
            {
                MessageBox.Show("Added Successfully");
                _CopyPersonImgToFile();
                __ReturnID?.Invoke(this, Person.PersonID);

                _Mode = enMode.eUpdate;
            }
           
        }
        private void UpdateOperation()
        {

            if (_SaveUpdates())
            {
                MessageBox.Show("updated Successfully");
                _CopyPersonImgToFile();
            }
           
        }

        
        private bool _TriggerValidations()
        {
            clsGlobal.ActivateContainerControlsOneByOne(this,typeof(TextBox));
           
            return _IsValide;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (!_TriggerValidations())
            {
                MessageBox.Show("You must Fill All Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _IsValide = true;
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
                errProv.SetError(txtB, "This Field Is required!");
                _IsValide = false;
            }
            else
            {
                errProv.SetError(txtB, "");

            }

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if ((txtNationalNo.Text == string.Empty) || ( clsPeople.IsExist(txtNationalNo.Text.Trim()) && txtNationalNo.Text.Trim() != Person.NationalNo))
            {
                errProv.SetError(txtNationalNo, "The Filed Should Not Be Empty// The Current National No May Already Exist !");
                _IsValide = false;
            }
            else
            {
                errProv.SetError(txtNationalNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if(txtEmail.Text != string.Empty)
            {
                if (!txtEmail.Text.EndsWith(".com") || !txtEmail.Text.Contains("@") || txtEmail.Text.EndsWith("@.com"))
                {
                    errProv.SetError(txtEmail, "Email Format Must be Like: example@example.com");
                _IsValide = false;
                }
                else
                {
                    errProv.SetError(txtEmail, "");
                }
            }
            
        }

        private void rbGender_M_CheckedChanged(object sender, EventArgs e)
        {
            if(Person != null &&(Person.ImagePath  == string.Empty || !File.Exists(Person.ImagePath)))
                pbPersonImg.Image = rbGender_M.Checked ? Resources.user_Male : Resources.user_female;
               
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
                Person.ImagePath = ofdGetImgPath.FileName;
                lnkRemoveImg.Visible = true;
            }
        }
        private void lnkRemoveImg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {               
                pbPersonImg.Image = rbGender_M.Checked ? Resources.user_Male : Resources.user_female;           
                Person.ImagePath = "";
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
                               
                if(!PersonImgGuid.ContainsKey(Person.PersonID))
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
