using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_Project.Users.Forms
{
    public partial class frmAdd_EditUser : Form
    {
        public enum enMode { eAddNewUser,eUpdateUser}
        enMode _Mode;

        int _ID;
        clsUsers User;
        ErrorProvider errorProv = new ErrorProvider();

        public frmAdd_EditUser()
        {
            InitializeComponent();
            _ID = -1;
            _Mode = enMode.eAddNewUser;
        }

        public frmAdd_EditUser(enMode Add_OR_Update,int User_PersonID)
        {
            InitializeComponent();
            this._ID = User_PersonID;
            _Mode = Add_OR_Update;

            ctrlFindPerson1.__EnableFilter = false;
        }
        public delegate void TriggerFunctionEventHandler(object sender);
        public event TriggerFunctionEventHandler RelaodContent;

        private void _GetPersonID(object sender,int PersonID)
        {
            _ID = PersonID;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text == string.Empty)
            {
                errorProv.SetError(txtUserName, "Required Field!");
            }
            else
            {
                errorProv.SetError(txtUserName, "");
            }
        }

        private void _PasswordFields_Validating(object sender, CancelEventArgs e)
        {

            TextBox txtPass = (TextBox)sender;
            if (txtPass.Text == string.Empty || txtPass.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                errorProv.SetError(txtPass, "Required Field! || Invalid Confirmation!!");
            }
            else
            {
                errorProv.SetError(txtPass, "");
            }

        }

        private void _GetNewUserInfoFromFields()
        {

            User.UserName = txtUserName.Text.Trim();
            User.Password = txtPassword.Text.Trim();
            User.PersonID = _ID;
            if (cbIsActive.Checked == true)
            {
                User.IsActive = true;
            }
            else
                User.IsActive = false;
        }

        private void _NextBtnValidation()
        {

            if(_ID == -1)
            {
                MessageBox.Show($"It Seems Like You Miss To Select a Person !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlFindPerson1.__EnableFilter = true;
                ctrlFindPerson1.Focus();
                return;
            }

            pnlUserData.Enabled = true;
            btnSave.Enabled = true;
            tabAddEditUser.SelectedTab = tabLoginInf;
        }

        private bool _AddNew()
        {
            if(clsUsers.ExistByPersonID(_ID))
            {
                MessageBox.Show($"The Person With ID << {_ID} >> Is Already a User! You Cannot Add It Twice!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsUsers.Exist(txtUserName.Text.Trim()))
            {
                MessageBox.Show($"This User Name << {txtUserName.Text} >> Is Taken Please Choose Another One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            User = new clsUsers();
            _GetNewUserInfoFromFields();
            if (!User.Save())
            {
                MessageBox.Show("Unexpected Error! Operation Fialed. Can't Add The New User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MessageBox.Show("Added Succefully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private bool _Update()
        {
            if (clsUsers.Exist(txtUserName.Text.Trim()) && User.UserName != txtUserName.Text.Trim())
            {
                MessageBox.Show($"This User Name << {txtUserName.Text} >> Is Taken Please Choose Another One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _GetNewUserInfoFromFields();
            if (!User.Save())
            {
                MessageBox.Show("Unexpected Error! Operation Fialed. Can't Update User Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MessageBox.Show("Updated Succefully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void _PerformMode()
        {
            btnSave.Enabled = false;
            pnlUserData.Enabled = false;
            if(_Mode == enMode.eAddNewUser)
            {   
                if(ctrlFindPerson1.__EnableFilter)
                    ctrlFindPerson1.__ReturnPersonID += _GetPersonID;
                else
                    ctrlFindPerson1.__DisplayPersonalInfo(_ID);

                lblAddEdit_Header.Text = "Add New User";
                return;
            }

            lblAddEdit_Header.Text = "Update User";
            User = clsUsers.Find(_ID);
            ctrlFindPerson1.__DisplayPersonalInfo(User.PersonID);
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _PerformMode();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _NextBtnValidation();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            if (MessageBox.Show("Sure To Completed The Operation", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {   
                if(_Mode == enMode.eAddNewUser)
                {
                    if (_AddNew())
                    {
                        RelaodContent?.Invoke(this);
                        lblAddEdit_Header.Text = "Update User";
                        _Mode = enMode.eUpdateUser;
                    }
                    return;
                }

                if (_Update())
                {
                    RelaodContent?.Invoke(this);
                }
               
            }
            else
                MessageBox.Show("Operation Ignored Succefully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure to Leave?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        
    }
}
