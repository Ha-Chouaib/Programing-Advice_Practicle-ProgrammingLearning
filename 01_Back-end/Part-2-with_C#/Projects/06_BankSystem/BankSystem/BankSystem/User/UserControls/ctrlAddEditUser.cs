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

namespace BankSystem.User.UserControls
{
    public partial class ctrlAddEditUser : UserControl
    {
        public ctrlAddEditUser()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
                return;

            _LoadRoles();
            tabUserData.Enabled = false;
            btnNext.Enabled = false;
        }

        public Action<clsUser> __OperationSucceeded;
        public Action __OperationFailed;
        public Action __OperationCanceld;

        private clsUser _User;
        private int _PersonID = -1;
        private ulong _CustomPermissions = 0;
        private ulong _RevokedPermissions = 0;

        private ErrorProvider _ErrorProvider = new ErrorProvider();
        enum enMode
        {
            AddNew,
            Edit
        }
        enMode _Mode;
        public void __AddNewUser()
        {
            _AddingConfiguration();
            Dictionary<string, string> FindByoptions = new Dictionary<string, string>
            {
                {"Person ID","PersonID" },
                {"National No","NationalNo" }
            };

            ctrlFind1.__Initializing(FindByoptions, clsPerson.FindBy);
            ctrlFind1.__FindOptionsCombo.SelectedValueChanged += (s, e) =>
            {
                ctrlFind1.__txtSearchTerm.KeyPress -= null;
                StringBuilder SelectdColumn = new StringBuilder();
                SelectdColumn.Append(((KeyValuePair<string, string>)ctrlFind1.__FindOptionsCombo.SelectedItem).Value);

                if (SelectdColumn.ToString() == "PersonID")
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = !char.IsControl(e1.KeyChar) && !char.IsDigit(e1.KeyChar); };
                else
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = false; };
            };

            ctrlFind1.__ObjectFound += _GetPerson;
        }
        public void __AddNewUser(int PersonID)
        {
            ctrlFind1.__txtSearchTerm.Text = PersonID.ToString();
            ctrlFind1.__FindOptionsCombo.Text = "User ID";
            ctrlFind1.Enabled = false;
            _AddingConfiguration();
           
           _GetPerson(this, clsPerson.Find(PersonID));
        }
        public void __EditUser()
        {
            _EdittingConfiguration();
            ctrlFind1.Enabled = true;
            Dictionary<string, string> FindByoptions = new Dictionary<string, string>
            {
                {"User ID","UserID" },
                {"Person ID","PersonID" },
                {"User Name","UserName" }
            };

            ctrlFind1.__Initializing(FindByoptions, clsUser.FindBy);
            ctrlFind1.__FindOptionsCombo.SelectedValueChanged += (s, e) =>
            {
                ctrlFind1.__txtSearchTerm.KeyPress -= null;

                StringBuilder SelectdColumn = new StringBuilder();
                SelectdColumn.Append(((KeyValuePair<string, string>)ctrlFind1.__FindOptionsCombo.SelectedItem).Value);

                if (SelectdColumn.ToString() != "UserName")
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = !char.IsControl(e1.KeyChar) && !char.IsDigit(e1.KeyChar); };
                else
                    ctrlFind1.__txtSearchTerm.KeyPress += (s1, e1) => { e1.Handled = false; };
            };

            ctrlFind1.__ObjectFound += _GetUser;
        }
        public void __EditUser(int UserID)
        {
            _EdittingConfiguration();
            ctrlFind1.__txtSearchTerm.Text = UserID.ToString();
            ctrlFind1.__FindOptionsCombo.Text = "User ID";
            ctrlFind1.Enabled = false;
            _User = clsUser.FindUserByID(UserID);
            _SetUserData();
        }

        private void _AddingConfiguration()
        {
            _Mode = enMode.AddNew;
            _User = new clsUser();
            lblHeaderTitle.Text = "Add New User";
            lblPickRecord.Text = "Pick a Person";
            lblConfermUpdatedPass.Visible = false;
            txtConfirmUpdatedPass.Visible = false;
        }
        private void _EdittingConfiguration()
        {
            _Mode = enMode.Edit;
            lblHeaderTitle.Text = "Update User Info";
            lblPickRecord.Text = "Pick a User";
            lblConfirmPass.Text = "Set New Password";
            lblConfermUpdatedPass.Visible = true;
            txtConfirmUpdatedPass.Visible = true;
        }
        private void _GrapUserData()
        {
            _User.PersonID = _PersonID;
            _User.RoleID = ((KeyValuePair<int, string>)cmbRoles.SelectedItem).Key;
            _User.UserName = txtUserName.Text;
            _User.Password = clsUtil_BL.EncryptString_Hashing(txtConfirmPassword.Text);
            _User.IsActive = rbIsActive.Checked;
            _User.CustomPermissions = _CustomPermissions;
            _User.RevokedPermissions = _RevokedPermissions;
            _User.CreatedDate = DateTime.Now;
            _User.CreatedByUserID = clsGlobal_BL.LoggedInUser.UserID;

        }
        private void _SetUserData()
        {
            if (_User == null) return;

            ctrlDisplayPersonDetails1.__ShowPersonalInfo(_User.PersonalInfo);

            txtUserID.Text = "[ " + _User.UserID.ToString() + " ]";
            txtUserName.Text = _User.UserName;
            cmbRoles.SelectedItem = cmbRoles.Items.Cast<KeyValuePair<int, string>>().FirstOrDefault(r => r.Key == _User.RoleID);
            rbIsActive.Checked = _User.IsActive;
            _CustomPermissions = _User.CustomPermissions;
            _RevokedPermissions = _User.RevokedPermissions;
            txtCreatedDate.Text = _User.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtCreatedByUser.Text = clsUser.FindUserByID(_User.CreatedByUserID).UserName;
            btnNext.Enabled = true;
            tabUserData.Enabled = true;
        }
        private void _LoadRoles()
        {
            DataTable dtRoles = clsRole.ListRoles();
            foreach (DataRow dr in dtRoles.Rows)
            {
                cmbRoles.Items.Add(new KeyValuePair<int, string>((int)dr["RoleID"], dr["RoleName"].ToString()));
            }
            cmbRoles.DisplayMember = "Value";
            cmbRoles.ValueMember = "Key";
            cmbRoles.SelectedIndex = 0;
        }
        private void _GetPerson(object s, object person)
        {
            clsPerson Person = person as clsPerson;
            if (Person != null)
            {
                if(clsUser.ExistByPersonID(Person.PersonID))
                {
                    MessageBox.Show("This Person Is Already a User!, Please Select another Person.","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ctrlDisplayPersonDetails1.__ShowPersonalInfo(Person);

                _PersonID = Person.PersonID;
                btnNext.Enabled = true;
                tabUserData.Enabled = true;
                txtCreatedDate.Text = DateTime.Now.ToString();
                txtCreatedByUser.Text = clsGlobal_BL.LoggedInUser.UserName;
                return;
            }
            MessageBox.Show($"No User Founded By Id [{Person.PersonID}]! Please Select A Valid ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        private void _GetUser(object s, object user)
        {
            clsUser User = user as clsUser;
            if (User != null)
            {
                _User = User;
                _SetUserData();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabUserData;
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPersonalInf;
        }
        private void _GetCustomRevokedPermissions(ulong customPermissions, ulong revokedPermissions)
        {
            _CustomPermissions = customPermissions;
            _RevokedPermissions = revokedPermissions;
        }
        private void lnkCustomPermissions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ulong RolePermissions =clsRole.Find(((KeyValuePair<int, string>)cmbRoles.SelectedItem).Key).Permissions;
            if (RolePermissions == 0)
            {
                MessageBox.Show("Please select a role first.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PopupFrm_UserPermissionSettings permissionSettings = new PopupFrm_UserPermissionSettings(RolePermissions, _CustomPermissions, _RevokedPermissions);
            permissionSettings.__CustomPermissionsDone += _GetCustomRevokedPermissions;
            permissionSettings.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnNext.Enabled)
            {
                MessageBox.Show("Please Select The Needed Record First.", "No Record Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtUserName.Focus();
            txtOriginalPassword.Focus();
            txtConfirmPassword.Focus();
            if (txtConfirmUpdatedPass.Visible) txtConfirmUpdatedPass.Focus();

            if (pnlUserDataContainer.Controls.OfType<TextBox>().Any(t => !string.IsNullOrEmpty(_ErrorProvider.GetError(t))))
            {
                MessageBox.Show("Please Fix The Errors Before Saving The User Data.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(MessageBox.Show("The Given Data Will Be Saved Once You Press [ok]","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            _GrapUserData();
            if (_User.Save())
            {
                txtUserID.Text = $"[ {_User.UserID} ]";
                __OperationSucceeded?.Invoke(_User);
                btnCancel.Text = "Close";
                if (_Mode == enMode.AddNew)
                    __EditUser(_User.UserID);
                return;
            }
            __OperationFailed?.Invoke();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            __OperationCanceld?.Invoke();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                _ErrorProvider.SetError(txtUserName, "Username cannot be empty.");
                return;
            }
            else
                _ErrorProvider.SetError(txtUserName, "");

            if (clsUser.ExistByUserName(txtUserName.Text.Trim()) && (_User?.UserName != txtUserName.Text.Trim()))
                _ErrorProvider.SetError(txtUserName, "This Username is Already Taken Please Choose another One.");
            else
                _ErrorProvider.SetError(txtUserName, "");


        }

        private void txtOriginalPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOriginalPassword.Text) && _Mode == enMode.AddNew)
            {
                _ErrorProvider.SetError(txtOriginalPassword, "Password cannot be empty.");
                return;
            }
            if (txtOriginalPassword.Text.Trim().Length < 4)
            {
                _ErrorProvider.SetError(txtOriginalPassword, "The Password must be 4 digits.");
                return;
            }
            if (_Mode == enMode.Edit)
            {
                if (clsUtil_BL.EncryptString_Hashing(txtOriginalPassword.Text.Trim()) != _User.Password)
                    _ErrorProvider.SetError(txtOriginalPassword, "The Original Password is Incorrect.");
                return;
            }

            _ErrorProvider.SetError(txtOriginalPassword, "");

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text) && (_Mode == enMode.AddNew || (_Mode == enMode.Edit && !string.IsNullOrEmpty(txtOriginalPassword.Text))))
            {
                _ErrorProvider.SetError(txtConfirmPassword, "This Feild cannot be empty.");
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                if (txtConfirmPassword.Text.Trim() != txtOriginalPassword.Text.Trim())
                {
                    _ErrorProvider.SetError(txtConfirmPassword, "The Passwords do not match.");
                    return;
                }
                
            }
            if (txtConfirmPassword.Text.Trim().Length < 4)
            {
                _ErrorProvider.SetError(txtConfirmPassword, "The Password must be 4 digits.");
                return;
            }

            _ErrorProvider.SetError(txtConfirmPassword, "");

        }

        private void txtOriginalPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtConfirmUpdatedPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmUpdatedPass.Text) && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                _ErrorProvider.SetError(txtConfirmUpdatedPass, "This Feild cannot be empty.");
                return;
            }

            if (_Mode == enMode.Edit)
            {
                if (txtConfirmUpdatedPass.Text.Trim() != txtConfirmPassword.Text.Trim())
                    _ErrorProvider.SetError(txtConfirmUpdatedPass, "The Passwords do not match.");
                return;
           }
            _ErrorProvider.SetError(txtConfirmUpdatedPass, "");

        }
    
    }
}
