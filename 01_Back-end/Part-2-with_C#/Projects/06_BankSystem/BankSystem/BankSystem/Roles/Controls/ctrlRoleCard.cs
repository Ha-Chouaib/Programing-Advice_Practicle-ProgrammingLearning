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

namespace BankSystem.Roles
{
    public partial class ctrlRoleCard : UserControl
    {
        public ctrlRoleCard()
        {
            InitializeComponent();
        }
        public void __SHowRoleCard(clsRole Role)
        {
            if (Role == null) 
            {
                MessageBox.Show("Role data is not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtRoleID.Text = Role.RoleID.ToString();
            txtRoleName.Text = Role.RoleName;
            txtDescription.Text = Role.Description;
            ckbIsActive.Checked = Role.IsActive;
            txtAddedByUser.Text = clsUser.FindUserByID(Role.AddedByUserID).UserName;
            txtAddedAt.Text = Role.AddedAt.ToString("g");

            fpnlPermissionsContainer.Controls.Clear();
            foreach(var perm in clsRole.GetPermissionsList())
            {
                if((Role.Permissions & perm.Value) == perm.Value)
                {
                    Label lbl = new Label
                    {
                        Text = perm.Key,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        Padding = new Padding(5),
                        Margin = new Padding(3),
                        ForeColor = Color.White,
                    };
                    fpnlPermissionsContainer.Controls.Add(lbl);
                }
              
            }
        }
    } 
}