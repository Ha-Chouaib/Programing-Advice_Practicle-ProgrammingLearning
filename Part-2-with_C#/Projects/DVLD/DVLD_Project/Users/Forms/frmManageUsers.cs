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
            _ConvertDataGridViewCell_IsActiveToCheckBox();

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
            foreach(KeyValuePair<string,string> filterOpt in FilterOptions)
            {
                cmbFilterUsers.Items.Add($"{filterOpt.Key}");
            }
            cmbFilterUsers.SelectedIndex = 0;

            cmbIsActiveOptions.Items.Add("All");
            cmbIsActiveOptions.Items.Add("Yes");
            cmbIsActiveOptions.Items.Add("No");
            cmbIsActiveOptions.SelectedIndex = 0;


        }

        private void _FilterUsers_WithSearchTerm()
        {
            if(txtFilterTerm.Text != string.Empty)
            {
                string FilterColumn = cmbFilterUsers.SelectedItem.ToString();
                DataTable DT = clsUsers.UsersList_ViewInf();
                DataView DV = DT.DefaultView;

                if(FilterOptions.TryGetValue(FilterColumn, out string Column))
                {
                    Type ColType = DT.Columns[Column].DataType;
                    if(ColType == typeof(string))
                    {
                        txtFilterTerm.KeyPress += TxtFilterTerm_KeyPress;
                        DV.RowFilter = $"{Column} LIKE '%{txtFilterTerm.Text}%'";
                    }
                    else
                    {
                        txtFilterTerm.KeyPress -= TxtFilterTerm_KeyPress;
                        DV.RowFilter = $"CONVERT({Column} , System.String) LIKE '%{txtFilterTerm.Text}%'";
                    }

                        dgvListUsers.DataSource = DV;
                }
               
            }else
            {
                _LoadUsersList();
            }
            
        }
        private void _FilterUsersBy_IsActive()
        {
            DataTable DT = clsUsers.UsersList_ViewInf();
            DataView DV = DT.DefaultView;

            DV = clsUsers.UsersList_ViewInf().DefaultView;
            string FilterBy = cmbIsActiveOptions.SelectedItem.ToString();

            if (FilterBy == "All")
            {
                dgvListUsers.DataSource = DT;
                return;
            }
            if (FilterBy == "Yes")
            {
                DV.RowFilter = "IsActive = true";
            }
            else
            {
                DV.RowFilter = "IsActive = false";
            }
            dgvListUsers.DataSource = DV;
        }

        private void cmbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = cmbFilterUsers.SelectedItem.ToString();
            
            if(FilterOptions.TryGetValue(FilterColumn,out string Column))
            {
                if (Column == "None")
                {
                    txtFilterTerm.Visible = false;
                    cmbIsActiveOptions.Visible = false;
                    return;

                }
                else if (Column == "IsActive")
                {
                    cmbIsActiveOptions.Visible = true;
                    txtFilterTerm.Visible = false;
                    return;
                }
                else
                {
                    txtFilterTerm.Visible = true;
                    cmbIsActiveOptions.Visible = false;
                }
            }
           
        }

        private void txtFilterTerm_KeyUp(object sender, KeyEventArgs e)
        {
            _FilterUsers_WithSearchTerm();
        }        
        
        private void TxtFilterTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void _ConvertDataGridViewCell_IsActiveToCheckBox()
        {
            int ColIndex = dgvListUsers.Columns["IsActive"].Index;
            dgvListUsers.Columns.Remove("IsActive");

            DataGridViewCheckBoxColumn CheckB_Col = new DataGridViewCheckBoxColumn();

            CheckB_Col.Name = "IsActive";
            CheckB_Col.HeaderText = "IsActive";
            CheckB_Col.DataPropertyName = "IsActive";
            dgvListUsers.Columns.Insert(ColIndex, CheckB_Col);
        }

        private void cmbIsActiveOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterUsersBy_IsActive();
        }
    }
}
