using Bank_BusinessLayer;
using BankSystem.Accounts.Forms;
using BankSystem.Customer.Forms;
using BankSystem.Properties;
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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
            _HasPermissions();
            LoadManageRecordsControl();
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_View))
            {
                MessageBox.Show("You don't have permission to view Users records.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
         static class ContextMenuItems
        {
            public static (string valueMember, string displayMember) ViewUserCard => ("ViewUserCard", "View User Card");
            public static (string valueMember, string displayMember) EditUser => ("EditUser", "Edit User");
            public static (string valueMember, string displayMember) UpdatePassword => ("UpdatePassword", "Update Password");
            public static (string valueMember, string displayMember) UpdateStatus => ("UpdateStatus", "Update Status");
            public static (string valueMember, string displayMember) DeleteUser => ("DeleteUser", "Delete");
            public static (string valueMember, string displayMember) Separator => ("Separator", "-------------------");
            public static (string valueMember, string displayMember) MakeUserCustomer => ("MakeUserCustomer", "Make User a Customer");
            public static (string valueMember, string displayMember) SendEmail => ("SendEmail", "Send Email");
            public static (string valueMember, string displayMember) SendSMS => ("SendSMS", "Send SMS");
            public static (string valueMember, string displayMember) CallUser => ("CallUser", "Call User");
        }

        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__AddNewRecordDelegate += _AddNewUser;
            ctrlManageRecords1.__UpdateRecordDelegate += _EditUser;
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;

            ctrlManageRecords1.__HeaderImg.Image = Resources.ManageUsersImg;

            ctrlManageRecords1.__AddNewBtn.Text = "Add New User";
            ctrlManageRecords1.__UpdateBtn.Text = "Edit User";
            ctrlManageRecords1.__AddNewBtn.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_Add);
            ctrlManageRecords1.__UpdateBtn.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_Edit);

            ctrlManageRecords1.__Initialize(_FilterBy_Options(), clsUser.FilterUsers, _ContextMenuPackage(), _FilterByGroups());
            ctrlManageRecords1.__ContextMenuStrip.Opening += (s, e) =>
            {
                var user = clsGlobal_BL.LoggedInUser;

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.ViewUserCard.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Users_View);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.EditUser.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Users_Edit);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.DeleteUser.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Users_Delete);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.UpdateStatus.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Users_Edit);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.UpdatePassword.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Users_ChangePassword);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.MakeUserCustomer.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Customers_Add);
            };
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsUser.Filter_Mapping));
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsUser.Filter_ByGroupsMapping));
        }

        private List<((string valueMember, string displayMember) ContextMenuItem, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            var contextMenuItems = new List<((string valueMember, string displayMember), Action<int, ToolStripMenuItem>)>
            {
                (ContextMenuItems.ViewUserCard, _ContextMenuViewUserCard),
                (ContextMenuItems.EditUser, _ContextMenuEditUser),
                (ContextMenuItems.UpdatePassword, _ContextMenuUpdatePassword),
                (ContextMenuItems.UpdateStatus, _ContextMenuChangeStatus),
                (ContextMenuItems.DeleteUser, _ContextMenuDeleteUser),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.MakeUserCustomer, _ContextMenuConvertToCustomer),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.SendEmail, _ContextMenuSendUserEmail),
                (ContextMenuItems.SendSMS, _ContextMenuSendUserSMS),
                (ContextMenuItems.CallUser, _ContextMenuCallUser),
            };

            return contextMenuItems;
        }
 
        void _ContextMenuViewUserCard(int userID, ToolStripMenuItem menuItem)
        {
            clsUser user = clsUser.FindUserByID(userID);
            if (user != null)
            {
                frmFindUser UserCard = new frmFindUser(userID);
                UserCard.ShowDialog();
            }
            else
                MessageBox.Show($"Can't Find Any User with id [{userID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuEditUser(int userid, ToolStripMenuItem menuItem)
        {
          
            if (clsUser.ExistByID(userid))
            {
                frmEditUser editUser = new frmEditUser(userid);
                editUser.__OperationDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
                editUser.ShowDialog();
            }
            else
                MessageBox.Show($"Can't Find Any User with id [{userid}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuUpdatePassword(int userid, ToolStripMenuItem menuItem)
        {
            if (clsUser.ExistByID(userid))
            {
                frmChangePassword changePass = new frmChangePassword(userid);
                changePass.__OperationDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
                changePass.ShowDialog();
                return;
            }
            MessageBox.Show($"No record found by id [{userid}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        void _ContextMenuDeleteUser(int userid, ToolStripMenuItem menuItem)
        {
            if (!clsUser.ExistByID(userid))
            {
                MessageBox.Show($"No record found by id [{userid}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Sure To delete this record?!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.Delete(userid, clsGlobal_BL.LoggedInUser.UserID))
                {
                    MessageBox.Show($"The User's record With id [{userid}] was deleted successfully");
                    ctrlManageRecords1.__RefreshRecordsList();
                }
                else MessageBox.Show($"Can't Delete This Record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _ContextMenuChangeStatus(int userID, ToolStripMenuItem menuItem)
        {
            if (clsAccounts.Exists(userID))
            {
                if (MessageBox.Show("Sure To Change User Status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if (clsUser.UpdateUserStatus(userID, !clsUser.IsUserActive(userID)))
                {
                    MessageBox.Show("Done SucessFully");
                    ctrlManageRecords1.__RefreshRecordsList();
                    return;
                }

                MessageBox.Show("Operation Failed, Can't Save Changes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"No User Exists With ID [{userID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void _ContextMenuConvertToCustomer(int userID, ToolStripMenuItem menuItem)
        {
            clsUser user = clsUser.FindUserByID(userID);
            if (user != null)
            {
                if (MessageBox.Show("Sure To Make this User a Customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                frmAddNewCustomer ToCustomer = new frmAddNewCustomer(user.PersonID);
                ToCustomer.ShowDialog();
                return;
            }
            MessageBox.Show($"No User Exists With ID [{userID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuSendUserEmail(int userid, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"Send Email To user with id [{userid}] -> Not Implemented yet");
        }
        void _ContextMenuSendUserSMS(int userid, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"Send Email To user with id [{userid}] -> Not Implemented yet");
        }
        void _ContextMenuCallUser(int userid, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"call the  user with id [{userid}] -> Not Implemented yet");
        }

        private void _EndSession()
        {
            this.Close();
        }
        private void _AddNewUser()
        {
            frmAddNewUser addNewUser = new frmAddNewUser();
            addNewUser.__OperationDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
            addNewUser.ShowDialog();
        }
        private void _EditUser()
        {
            frmEditUser editUser = new frmEditUser();
            editUser.__OperationDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
            editUser.ShowDialog();
        }
        private void _ConfigureDataRecordsContainer()
        {


            var grid = ctrlManageRecords1.__RecordsContainer;

            grid.Columns["PersonID"].HeaderText = "Person ID";
            grid.Columns["NationalNo"].HeaderText = "National No";
            grid.Columns["UserName"].HeaderText = "User Name";
            grid.Columns["RoleName"].HeaderText = "Role";
            grid.Columns["IsActive"].HeaderText = "Active";
            grid.Columns["CreatedDate"].HeaderText = "Created Date";
            grid.Columns["CreatedByUserID"].HeaderText = "Added By User";

            int index = grid.Columns["IsActive"].Index;
            grid.Columns.Remove("IsActive");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "IsActive";
            chk.HeaderText = "Is Active";
            chk.DataPropertyName = "IsActive";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true;

            grid.Columns.Insert(index, chk);

            grid.CellFormatting += (s, e) =>
            {
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "CreatedByUserID" && e.Value is int usr)
                {
                    e.Value = clsUser.FindUserByID(usr)?.UserName ?? "(N/A)";
                }

            };

        }

       
    }
}
