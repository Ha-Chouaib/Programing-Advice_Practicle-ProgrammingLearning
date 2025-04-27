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

namespace DVLD_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        clsUsers User;
        ErrorProvider errorProv = new ErrorProvider();

        private bool _LoginValidation()
        {
            string UserName = txtUserName.Text;
            string PassWord = txtPassword.Text;
            bool IsValid = false;
            if (UserName != string.Empty && PassWord != string.Empty)
            {
                User = clsUsers.Find(UserName);
                if (User != null)
                {
                    if(PassWord == User.Password)
                    {
                        IsValid = true;
                    }else
                    {

                        MessageBox.Show($"UnValid Password Please Enter The Correct Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"No User Found By User Name << {UserName} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                txtPassword.Validating += txtPasswordUserName_Validating;
                txtUserName.Validating += txtPasswordUserName_Validating;
            }

                return IsValid;
        }
        private void _RememberMe(object sender,string UserName,string UserPass )
        {
            if(clsGlobal.IsRememberMe)
            {
                txtUserName.Text = UserName;
                txtPassword.Text = UserPass;
            }else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            if(_LoginValidation())
            {
                if(User.IsActive == true)
                {   

                    clsGlobal.CurrentUserID = User.UserID;
                    if(cbRememberMe.Checked == true)
                    {
                        clsGlobal.IsRememberMe = true;

                    }else
                    {
                        clsGlobal.IsRememberMe = false;
                    }
                    MainForm HomePage = new MainForm();
                    HomePage.TriggerRememberMeFunc += _RememberMe;
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    HomePage.ShowDialog();
                }else
                {
                    MessageBox.Show("Your Account Is Blocked Please Contact Your Admin","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }


        private void txtPasswordUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtB= (TextBox)sender;
            if(txtB.Text == string.Empty)
            {
                errorProv.SetError(txtB, "Required Field");
            }else
                errorProv.SetError(txtB, "");

        }
    }
}
