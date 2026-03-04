using Bank_BusinessLayer;
using Bank_BusinessLayer.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void _Add_EventLog()
        {
            if(!EventLog.SourceExists(clsGlobal_BL.EventLogSourceName))
            {
                EventLog.CreateEventSource(clsGlobal_BL.EventLogSourceName, "Application");
            }
        }
        clsUser User;
        ErrorProvider errorProvider;
        private void txtPasswordUserName_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtB = (TextBox)sender;
            if (txtB.Text == string.Empty)
            {
                errorProvider.SetError(txtB, "Required Field");
            }
            else
                errorProvider.SetError(txtB, "");

        }

        private bool _IsValidLoging()
        {
            string UserName = txtUserName.Text.Trim();
            string PassWord = txtPassword.Text.Trim();
            if (UserName != string.Empty && PassWord != string.Empty)
            {
                User = clsUser.FindUserByName(UserName);
                PassWord = clsUtil_BL.EncryptString_Hashing(PassWord);
                
                if (User == null || PassWord != User.Password)
                {
                    MessageBox.Show($"UnValid Username OR Password ! Please Enter The Correct Login Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!User.IsActive)
                {

                    MessageBox.Show("Your Account Is Blocked Please Contact Your Admin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            else
            {
                txtPassword.Validating += txtPasswordUserName_Validating;
                txtUserName.Validating += txtPasswordUserName_Validating;
                return false;
            }

            return true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _Add_EventLog();

            string Username = "", Password = "";
            if (clsUtil_BL.GetUserCredential(ref Username, ref Password))
            {
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                ckbRememberMe.Checked = true;
                return;
            }

            ckbRememberMe.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_IsValidLoging())
            {
                if (ckbRememberMe.Checked)
                {
                    clsUtil_BL.RememberUsernameAndPasssword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsUtil_BL.RememberUsernameAndPasssword("", "");
                }

                frmHomePage frmHomePage = new frmHomePage(this);

                clsGlobal_BL.LoggedInUser = User;
                clsGlobal_BL.UserSession.Start();
                clsLoginHistory log = new clsLoginHistory();

                log.LoggedInUserID = User.UserID;
                log.LoginDate = DateTime.Now;
                log.MachineName = Environment.MachineName;
                log.SessionID = clsGlobal_BL.UserSession.SessionID;
                
                if (!log.AuditUserLogins()) clsGlobal_BL.LogHelper.LogWarning($"Failed To Audit User Login For UserID: {User.UserID}, Username: {User.UserName}");
                this.Hide();
                frmHomePage.ShowDialog();

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
