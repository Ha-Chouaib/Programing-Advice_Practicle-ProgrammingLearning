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
                ctrlPersonDetails1.DisplayPersonInfo(User.PersonID);
                ctrlShowLoginInfo1.DisplayUserInfo(User.UserID);
                txtCurrentPassword.Validating += txtCurrentPassword_Validating;
            }
            else 
            {
                MessageBox.Show($"No User With ID-<< {_UserID} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool _ChangePassword()
        {
            User = clsUsers.Find(_UserID);
            bool isChanged = false;

            if (User != null && txtCurrentPassword.Text == User.Password)
            {
                txtCurrentPassword.Validating -= txtCurrentPassword_Validating;
                User.Password=txtNewPassword.Text;
                isChanged=User.Save();
            }else
            {
                MessageBox.Show("Could Not Change The Password. Unfound User/Unvalid Password !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

                return isChanged;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtCurrentPassword.Text == string.Empty || txtCurrentPassword.Text != User.Password)
            {
                errorProv.SetError(txtCurrentPassword, "Required Field/The Current Password Doesn't Match The Original One!");
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
                e.Cancel = true;
            }
            else
            {
                errorProv.SetError(txtB, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Sure To Change The Password ?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(_ChangePassword())
                {
                    MessageBox.Show("Done Successfully");
                }else
                {
                    MessageBox.Show("Error Cant Save The Current Changes Please Try Again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
