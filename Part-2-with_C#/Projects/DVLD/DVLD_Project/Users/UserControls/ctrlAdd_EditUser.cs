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

namespace DVLD_Project.Users.UserControls
{
    public partial class ctrlAdd_EditUser : UserControl
    {
        public ctrlAdd_EditUser()
        {
            InitializeComponent();
        }

        private int _PersonID=-1;
        public int UserID { get; set; }

        ErrorProvider errorProv = new ErrorProvider();
        clsUsers User;
        private void ctrlAdd_EditUser_Load(object sender, EventArgs e)
        {
        }
        public void __DisplayPersonalInfo(object sender, int PersonID)
        {
            User = clsUsers.Find(UserID);
            _PersonID=PersonID;
            ctrlFindPerson1.__DisplayPersonalInfo(sender,PersonID);
            lblUserID.Text = UserID.ToString();

            txtUserName.Text = User.UserName;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabAddEditUser.SelectedTab = tabLoginInf; 
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(txtUserName.Text == string.Empty)
            {
                errorProv.SetError(txtUserName, "Required Field!");
                e.Cancel = true;
            }
            else
            {
                errorProv.SetError(txtUserName, "");
                e.Cancel = false;
            }

        }
        private void PasswordFields_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtPass = (TextBox)sender;
            if (txtPass.Text == string.Empty || txtPass.Text != txtPassword.Text)
            {
                errorProv.SetError(txtPass, "Required Field! || Invalid Confirmation!!");
                e.Cancel = true;
            }
            else
            {
                errorProv.SetError(txtPass, "");
                e.Cancel = false;
            }

        }
        
        private void _GetUserInfoFromFields(clsUsers User)
        {
            User.UserName = txtUserName.Text;
            User.Password = txtPassword.Text;
            User.PersonID = _PersonID ;
            if (cbIsActive.Checked == true)
            {
                User.IsActive = true;
            }
            else
                User.IsActive = false;
        }
        public int AddNewUser_GetID()
        {
            User = new clsUsers();

            if (_PersonID != -1)
            {
                _GetUserInfoFromFields(User);
                if (User.Save())
                    lblUserID.Text = User.UserID.ToString();

            }
            return User.UserID;
        }
        public clsUsers UpdateUser_GetUpdatedInfo(int UserID)
        {
            User = clsUsers.Find(UserID);
            if (User != null)
            {
                _GetUserInfoFromFields(User);
            }
            return User;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabAddEditUser.SelectedTab = tabPersonInf;
        }

        private void tabPersonInf_Click(object sender, EventArgs e)
        {

        }
    }
}
