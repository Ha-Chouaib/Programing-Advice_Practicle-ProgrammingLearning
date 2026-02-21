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
    public partial class PopupFrm_UserPermissionSettings : Form
    {
        public PopupFrm_UserPermissionSettings(long rolePermissions, long customPermissions, long revokedPermissions)
        {
            InitializeComponent();
            _HasPermissions();

            this.BringToFront();
            this.RolePermissions = rolePermissions;
            this.CustomPermissions = customPermissions;
            this.RevokedPermissions = revokedPermissions;
            _LoadPermissions();
        }
        public PopupFrm_UserPermissionSettings()
        {
            InitializeComponent();
        }
        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Users_ManageRoles))
            {
                MessageBox.Show("You don't have permission to view people records.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        public Action<long, long> __CustomPermissionsDone;
        public Action __Canceled;

        private long CustomPermissions;
        private long RevokedPermissions;
        private long RolePermissions;
        private void _LoadPermissions()
        {
            foreach(var perm in clsRole.GetPermissionsList())
            {
                CheckBox chk = new CheckBox 
                {
                    Text = perm.Key.Replace("_", " "),
                    Tag = perm.Value,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))),
                    AutoSize = true
                };
                chk.CheckedChanged += (s, e) =>
                {
                    long permValue = (long)chk.Tag;
                    if ((RolePermissions & permValue) == permValue)
                    {
                        if (chk.Checked)
                            RevokedPermissions &= ~permValue;
                        else
                            RevokedPermissions |= permValue;
                    }
                    else
                    {
                        if (chk.Checked)
                            CustomPermissions |= permValue;
                        else
                            CustomPermissions &= ~permValue;
                    }
                };

                if ((RolePermissions & perm.Value) == perm.Value)
                {
                    chk.Checked = (RevokedPermissions & perm.Value) != perm.Value;
                    flpRolePermissions.Controls.Add(chk);
                }
                else
                {
                    chk.Checked = (CustomPermissions & perm.Value) == perm.Value;
                    flpCustomPermissions.Controls.Add(chk);
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to save the changes to user permissions?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                __CustomPermissionsDone?.Invoke(CustomPermissions, RevokedPermissions);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
