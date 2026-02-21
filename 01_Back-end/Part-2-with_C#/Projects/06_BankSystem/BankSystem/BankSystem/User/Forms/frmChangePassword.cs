using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.User.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
            _HasPermissions();
            _EditPassword();
        }
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _HasPermissions();
            _EditPassword(userID);
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_ChangePassword))
            {
                MessageBox.Show("You don't have permission to change Users password.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }

        clsUser _SelectedUser;
        ErrorProvider _errorProvider = new ErrorProvider();
        public Action __OperationDoneSuccessfully;
        private void _EditPassword()
        {

            ctrlFindUser1.__ObjectFound += (user) =>
            {
                pnlEditPass.Enabled = true;
                _SelectedUser = user;
            };
        }
        private void _EditPassword(int UserID)
        {
            clsUser user = clsUser.FindUserByID(UserID);
            if (user != null)
            {
                ctrlFindUser1.__ShowUserCard(user);
                _SelectedUser = user;
                return;
            }
            MessageBox.Show($"No User Found By ID [{UserID}]","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SelectedUser == null)
            {
                MessageBox.Show("Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtOriginalPass.Focus();
            txtNewPass.Focus();
            txtConfirmPass.Focus();
            if (pnlEditPass.Controls.OfType<TextBox>().Any(t => !string.IsNullOrEmpty(_errorProvider.GetError(t))))
            {
                MessageBox.Show("Please fix the errors before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsUser.UpdateUsePassword(_SelectedUser.UserID, clsUtil_BL.EncryptString_Hashing(txtNewPass.Text.Trim())))
            {
                MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                __OperationDoneSuccessfully?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOriginalPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOriginalPass.Text))
            {
                _errorProvider.SetError(txtOriginalPass, "Original password is required.");
            }
            else if (clsUtil_BL.EncryptString_Hashing(txtOriginalPass.Text.Trim()) != _SelectedUser.Password)
            {
                _errorProvider.SetError(txtOriginalPass, "Original password is incorrect.");
            }
            else
            {
                _errorProvider.SetError(txtOriginalPass, string.Empty);
            }
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                _errorProvider.SetError(txtNewPass, "New password is required.");
            }
            else if (txtNewPass.Text.Trim().Length < 4)
            {
                _errorProvider.SetError(txtNewPass, "New password must be at least 4 characters long.");
            }
            else
            {
                _errorProvider.SetError(txtNewPass, string.Empty);
            }
        }

        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                _errorProvider.SetError(txtConfirmPass, "Please confirm the new password.");
                return;
            }
            if (txtConfirmPass.Text.Trim() != txtNewPass.Text.Trim())
            {
                _errorProvider.SetError(txtConfirmPass, "Passwords do not match.");
                return;
            }        
           _errorProvider.SetError(txtConfirmPass, string.Empty);        
        }


    }
}
