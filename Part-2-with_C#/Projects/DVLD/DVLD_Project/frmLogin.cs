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

            string Username = "", Password = "";
            if (clsGlobal.GetUserCredential(ref Username, ref Password))
            {
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
                return;
            }
           
            cbRememberMe.Checked = false;
        }
        clsUsers User;
        ErrorProvider errorProv = new ErrorProvider();


        private bool _IsValidLoging()
        {
            string UserName = txtUserName.Text.Trim();
            string PassWord = txtPassword.Text.Trim();
            if (UserName != string.Empty && PassWord != string.Empty)
            {
                User = clsUsers.Find(UserName);

                if (User == null || PassWord != User.Password)
                {
                    MessageBox.Show($"UnValid Username OR Password ! Please Enter The Correct Login Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

               if(! User.IsActive)
               {

                    MessageBox.Show("Your Account Is Blocked Please Contact Your Admin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
               }
               
            }else
            {
                txtPassword.Validating += txtPasswordUserName_Validating;
                txtUserName.Validating += txtPasswordUserName_Validating;
                return false;
            }

            return true;
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {  
            
            if(_IsValidLoging())
            {
               if(cbRememberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPasssword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }else
                {
                    clsGlobal.RememberUsernameAndPasssword("", "");
                }

                MainForm frmMain = new MainForm(this);
                clsGlobal.CurrentUserID = User.UserID;
               
                this.Hide();
                frmMain.ShowDialog();

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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
