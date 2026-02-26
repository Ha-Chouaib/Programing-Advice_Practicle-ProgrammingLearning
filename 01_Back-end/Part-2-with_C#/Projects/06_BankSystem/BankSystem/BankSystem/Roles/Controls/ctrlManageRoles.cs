using Bank_BusinessLayer;
using BankSystem.Roles.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Roles.Controls
{
    public partial class ctrlManageRoles : UserControl
    {
        public ctrlManageRoles()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                LoadRoles();
                _HandleDGV_HeaderTextNaming();
            }
        }
        private void LoadRoles()
        {
            try
            {
                DataTable rolesTable = clsRole.ListRoles();
                dgvListRoles.DataSource = new BindingSource(rolesTable, null);

                lblRolesCount.Text = $"Total Roles: [{rolesTable.Rows.Count}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            frmAddNewRole addRoleForm = new frmAddNewRole();
            addRoleForm.__OperationDoneSuccessfully = LoadRoles;

            addRoleForm.ShowDialog();
        }

        private void editRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int roleId = (int)dgvListRoles.CurrentRow.Cells[0].Value;
            frmEditRole editRole = new frmEditRole(clsRole.Find(roleId));
            editRole.__OperationDoneSuccessfully = LoadRoles;
            editRole.ShowDialog();
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int roleId = (int)dgvListRoles.CurrentRow.Cells[0].Value;
            frmRoleCard roleCard = new frmRoleCard(clsRole.Find(roleId));
            roleCard.ShowDialog();
        }
      
        private void _HandleDGV_HeaderTextNaming()
        {
            if (dgvListRoles.DataSource == null) return;
            dgvListRoles.Columns["RoleID"].HeaderText = "ID";
            dgvListRoles.Columns["RoleName"].HeaderText = "Name";
            dgvListRoles.Columns["Permissions"].Visible = false;
            dgvListRoles.Columns["CreatedDate"].HeaderText = "Created At";
            dgvListRoles.Columns["RoleID"].HeaderText = "ID";
            dgvListRoles.Columns["RoleID"].HeaderText = "ID";



            int index = dgvListRoles.Columns["IsActive"].Index;
            dgvListRoles.Columns.Remove("IsActive");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "IsActive";
            chk.HeaderText = "Is Active";
            chk.DataPropertyName = "IsActive";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true;

            dgvListRoles.Columns.Insert(index, chk);

            dgvListRoles.CellFormatting += (s, e) =>
            {
                if (dgvListRoles.Columns[e.ColumnIndex].Name == "CreatedByUserID" && e.Value is int usr)
                {
                    e.Value = clsUser.FindUserByID(usr)?.UserName ?? "(N/A)";
                }

            };
        }
    }
}
