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

namespace DVLD_Project.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        enum enFilterMode { eNone,eIsActive,ePersonFullName,eUserInf}
        enFilterMode _FilterMode;
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadFilterOptions();
            _LoadUsersList();
        }

        private void _LoadUsersList()
        {
            dgvListUsers.DataSource = clsUsers.UsersList_ViewInf();

        }
        Dictionary<string, string> FilterOptions = new Dictionary<string, string>();
        private void _LoadFilterOptions()
        {
            FilterOptions.Add("None", "None");
            FilterOptions.Add("User ID", "UserID");
            FilterOptions.Add("Person ID", "PersonID");
            FilterOptions.Add("User Name", "UserName");
            FilterOptions.Add("FullName", "FullName");
            FilterOptions.Add("IsActive", "IsActive");
            cmbFilterUsers.DataSource = FilterOptions.Keys;
            cmbFilterUsers.SelectedIndex = 0;

            cmbIsActiveOptions.Items.Add("All");
            cmbIsActiveOptions.Items.Add("Yes");
            cmbIsActiveOptions.Items.Add("No");
            cmbIsActiveOptions.SelectedIndex = 0;


        }

        private void _FilterUsers_WithSearchTerm()
        {
            string FilterColumn = cmbFilterUsers.SelectedItem.ToString();
            DataView DV =new DataView();

            DV = clsUsers.UsersList_ViewInf().DefaultView;

            if (FilterOptions.ContainsValue(FilterColumn))
            {
                FilterColumn = FilterOptions[FilterColumn];
                dgvListUsers.DataSource = DV.RowFilter =$"{FilterColumn} Like %{txtFilterTerm.Text}% ";

            }
        }

        private void cmbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = FilterOptions[cmbFilterUsers.SelectedItem.ToString()];


            if (FilterColumn == "None")
            {
                txtFilterTerm.Visible = false;
                cmbIsActiveOptions.Visible = false;
                return;

            }
            else if (FilterColumn == "IsActive")
            {
                cmbIsActiveOptions.Visible = true;
                txtFilterTerm.Visible = false;
                return;
            }
            else
            {
                txtFilterTerm.Visible = true;
                cmbIsActiveOptions.Visible = false;
                if(FilterColumn == "UserID" || FilterColumn == "PersonID")
                {
                    txtFilterTerm.KeyPress += TxtFilterTerm_KeyPress;
                }else
                {
                    txtFilterTerm.KeyPress -= TxtFilterTerm_KeyPress;
                }
            }
        }

        private void txtFilterTerm_KeyUp(object sender, KeyEventArgs e)
        {
            _FilterUsers_WithSearchTerm();
        }

        private void _FilterUsersBy_IsActive()
        {
            DataView DV = new DataView();

            DV = clsUsers.UsersList_ViewInf().DefaultView;
            string FilterBy = cmbIsActiveOptions.SelectedItem.ToString();

            if (FilterBy == "All")
            {
                dgvListUsers.DataSource = clsUsers.UsersList_ViewInf();
                return;
            }
            if (FilterBy == "Yes")
            {
                dgvListUsers.DataSource = DV.RowFilter="IsActive = true";
            }
            else
            {
                dgvListUsers.DataSource = DV.RowFilter = "IsActive = false";
            }
        }

        private void cmbIsActiveOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterUsersBy_IsActive();
        }
        private void TxtFilterTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvListUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvListUsers.Columns[e.ColumnIndex].Name == "IsActive" && e.Value is bool Active)
            {
               
            }
        }

      
    }
}
