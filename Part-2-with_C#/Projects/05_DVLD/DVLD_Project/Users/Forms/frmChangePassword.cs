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
using DVLD_Project.Users.UserControls;

namespace DVLD_Project.Users.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        bool _IsValide = true;
        private int _UserID;
        clsUsers User;
        ErrorProvider errorProv = new ErrorProvider();
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadUserInfo();
        }
        private void _LoadUserInfo()
        {
            User =clsUsers.Find(_UserID);
            if(User !=null)
            {
                ctrlPersonDetails1.__DisplayPersonInfo(User.PersonID);
                ctrlShowLoginInfo1.__DisplayUserInfo(User.UserID);
                txtCurrentPassword.Validating += txtCurrentPassword_Validating;
            }
            else 
            {
                MessageBox.Show($"No User With ID-<< {_UserID} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool _ChangePassword()
        {
            

            if (User != null && txtCurrentPassword.Text == User.Password)
            {
                txtCurrentPassword.Validating -= txtCurrentPassword_Validating;
                User.Password=txtNewPassword.Text;
                if( ! User.Save())
                {
                    MessageBox.Show("Couldn't Save Changes Properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Could Not Change The Password. Unfound User/Unvalid Password !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true ;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtCurrentPassword.Text == string.Empty || txtCurrentPassword.Text != User.Password)
            {
                errorProv.SetError(txtCurrentPassword, "Required Field/The Current Password Doesn't Match The Original One!");
                _IsValide = false;
            }else
            {
                errorProv.SetError(txtCurrentPassword, "");
            }
        }
        private void New_ConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if (txtB.Text == string.Empty || txtB.Text != txtNewPassword.Text)
            {
                errorProv.SetError(txtB, "Required Field/The Current Password Doesn't Match The Original One!");
                _IsValide = false;
            }
            else
            {
                errorProv.SetError(txtB, "");
            }
        }

        private bool TriggerValidations()
        {
            clsGlobal.ActivateContainerControlsOneByOne(pnlUpdatePasswordContainer, typeof(TextBox));
            return _IsValide;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!TriggerValidations())
            {
                MessageBox.Show("You must Fill All Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _IsValide = true;
                return;
            }

            if (MessageBox.Show("Sure To Change The Password ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(_ChangePassword())
                {
                    MessageBox.Show("Done Successfully");
                }
            }else
            {
                MessageBox.Show("Ignored Successfully");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("Sure To Leave ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.Close();
            }
        }
    }
}
