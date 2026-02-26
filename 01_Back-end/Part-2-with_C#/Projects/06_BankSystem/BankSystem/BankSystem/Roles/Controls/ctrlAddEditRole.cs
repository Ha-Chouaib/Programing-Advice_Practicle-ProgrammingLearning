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
using System.Xml.Serialization;

namespace BankSystem.Roles
{
    public partial class ctrlAddEditRole : UserControl
    {
        public ctrlAddEditRole()
        {
            InitializeComponent();
            LoadPermissions();
        }
        public Action<clsRole> __OperationDoneSuccessfully;
        public Action __OperationFailed;
        public Action __OperationCancelled;

        clsRole _currentRole;
        long _permissions = 0;
        enum enMode { Add, Edit }
        enMode _currentMode = enMode.Add;

        private void LoadPermissions()
        {
            _permissions = 0;
            fpnlPermissionsContainer.Controls.Clear();

            foreach (clsRole.enPermissions permission in Enum.GetValues(typeof(clsRole.enPermissions)))
            {
                var chk = new CheckBox
                {
                    Text = permission.ToString(),
                    Tag = (long)permission,
                    AutoSize = true,
                    Margin = new Padding(5),
                    ForeColor = Color.White,
                };
                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                        _permissions |= (long)permission; // Set the bit
                    else
                        _permissions &= ~(long)permission; // Clear the bit
                };
                fpnlPermissionsContainer.Controls.Add(chk);
            }
        }
        private bool _validations()
        {
            if(_currentRole == null)
            {
                MessageBox.Show("An unexpected error occurred the role object was empty. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(string.IsNullOrEmpty(txtRoleName.Text))
            {
                MessageBox.Show("Role name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(MessageBox.Show("Are you sure you want to save this role?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                //__OperationCancelled?.Invoke();
                return false;
            }
            return true;
        }
        private void _ReadCommonFields()
        {
            _currentRole.RoleName = txtRoleName.Text;
            _currentRole.Description = txtDescription.Text;
            _currentRole.Permissions = _permissions;
            _currentRole.IsActive = ckbIsActive.Checked;
        }
        private void DisplayRoleData()
        {
            if (_currentRole == null)
                return;
            txtRoleName.Text = _currentRole.RoleName;
            txtDescription.Text = _currentRole.Description;
            ckbIsActive.Checked = _currentRole.IsActive;
            txtAddedByUser.Text = clsUser.FindUserByID(_currentRole.AddedByUserID).UserName;
            txtAddedAt.Text = _currentRole.AddedAt.ToString("g");

            foreach (CheckBox chk in fpnlPermissionsContainer.Controls.OfType<CheckBox>())
            {
                long permissionValue = (long)chk.Tag;
                chk.Checked = (_currentRole.Permissions & permissionValue) == permissionValue;
            }
        }
        private bool _AddRole()
        {
            _currentRole = new clsRole();
            _ReadCommonFields();
            _currentRole.AddedAt = DateTime.Now;
            _currentRole.AddedByUserID = clsGlobal_BL.LoggedInUser.UserID;
            
            if(_currentRole.Save())return true;
           return false;
        }
        private bool _EditRole()
        {
            _ReadCommonFields();
            if (_currentRole.Save())
            {
                return true;
            }
            return false;
        }
        public void __AddRole()
        {
            _currentMode = enMode.Add;
            _currentRole = new clsRole();
            txtRoleID.Text = "Auto-generated";
            txtAddedByUser.Text = clsGlobal_BL.LoggedInUser.UserName;
            txtAddedAt.Text = DateTime.Now.ToString("g");
        }
        public void __EditRole(clsRole roleToEdit)
        {
            if (roleToEdit == null)
            {
                MessageBox.Show("An unexpected error occurred the role object was empty. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _currentMode = enMode.Edit;
            _currentRole = roleToEdit;
            txtRoleID.Text = _currentRole.RoleID.ToString();
            DisplayRoleData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_validations())
            {
                switch(_currentMode)
                {
                    case enMode.Add:
                        if(_AddRole())
                        {
                            //MessageBox.Show("Role added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtRoleID.Text = _currentRole.RoleID.ToString();
                            __OperationDoneSuccessfully?.Invoke(_currentRole);
                            _currentMode = enMode.Edit;
                        }
                        else
                        {
                            //MessageBox.Show("Failed to add role. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            __OperationFailed?.Invoke();
                        }
                        break;
                    case enMode.Edit:
                        if(_EditRole())
                        {
                            //MessageBox.Show("Role updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            __OperationDoneSuccessfully?.Invoke(_currentRole);
                        }
                        else
                        {
                           // MessageBox.Show("Failed to update role. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            __OperationFailed?.Invoke();
                        }
                        break;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to cancel? Unsaved changes will be lost.", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                __OperationCancelled?.Invoke();
        }
    }
}
