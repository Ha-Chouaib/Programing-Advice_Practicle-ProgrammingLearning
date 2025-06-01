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
using DVLD_Project.Users.Forms;

namespace DVLD_Project
{
    public partial class frmManagePeople: Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadPeople();
            _LoadFilterOptions();
            txtFilterPeople.Visible = false;
        }

       
        private void _LoadPeople()
        {
            DataTable dtPeople = clsPeople.ListAll();

            dgvLsitPeople.DataSource = dtPeople;
            lblRecordsCount.Text = dgvLsitPeople.RowCount.ToString();

        }
        private void ReloadPeople(object sender)
        {
            dgvLsitPeople.DataSource = clsPeople.ListAll();
            lblRecordsCount.Text = dgvLsitPeople.RowCount.ToString();
        }
        Dictionary<string, string> FilterColumns = new Dictionary<string, string>();
        private void _LoadFilterOptions()
        {
            FilterColumns.Add("_None", "None");
            FilterColumns.Add("NationalNo", "National No");
            FilterColumns.Add("FirstName", "First Name");
            FilterColumns.Add("SecondName", "Second Name");
            FilterColumns.Add("ThirdName", "Third Name");
            FilterColumns.Add("LastName", "Last Name");
            FilterColumns.Add("NationalityCountryID", "Nationality");
            FilterColumns.Add("Gendor", "Gender");
            FilterColumns.Add("Phone", "Phone");
            FilterColumns.Add("Email", "Email");

            cmbFilter.DataSource = new BindingSource(FilterColumns, null);
            cmbFilter.DisplayMember = "Value";
            cmbFilter.ValueMember = "Key";
            cmbFilter.SelectedIndex = 0;
        }
        private void _FilterPeopole()
        {
    
            string FilterTerm = txtFilterPeople.Text;
            string SelectedColumn = cmbFilter.SelectedValue.ToString();

            if (SelectedColumn != "_None" || FilterTerm != string.Empty)
            {
                if (SelectedColumn != "PersonID" && SelectedColumn != "NationalityCountryID")
                {
                    txtFilterPeople.KeyPress -= txtFilterPeople_KeyPress;
                    if(SelectedColumn != "Gendor")
                    {
                        dgvLsitPeople.DataSource = clsPeople.FilterPeople<string>(SelectedColumn, FilterTerm);

                    }else
                    {
                     
                        FilterTerm.ToLower();
                        if (FilterTerm.StartsWith("m") || FilterTerm.StartsWith("f"))
                        {
                            byte Gender;

                            if (FilterTerm.StartsWith("m")) Gender = 0;
                            else
                                Gender = 1;

                            dgvLsitPeople.DataSource = clsPeople.FilterPeople<byte>(SelectedColumn, Gender);
                        }

                    }

                }
                else
                {
                    txtFilterPeople.KeyPress += txtFilterPeople_KeyPress;
                    if(int.TryParse(FilterTerm,out int Int_Value))
                        dgvLsitPeople.DataSource=clsPeople.FilterPeople<int>(SelectedColumn, Int_Value);
                }
            }
            else
            {
                _LoadPeople();
            }
        }
        private void txtFilterPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(! char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;// Here We Block The Key
            }
        }

        private void txtFilterPeople_KeyUp(object sender, KeyEventArgs e)
        {
            _FilterPeopole();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedValue.ToString() == "_None")
            {
                txtFilterPeople.Text=string.Empty;
                txtFilterPeople.Visible = false;
                _LoadPeople();

            }
            else
            {

                txtFilterPeople.Visible = true;
                txtFilterPeople.Focus();
            }
        }

        private void dgvLsitPeople_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLsitPeople.Columns[e.ColumnIndex].Name == "Gendor" && e.Value is byte Gdr)
            {
                e.Value = Gdr == 0 ? "Male" : "Female";
                e.FormattingApplied = true;
            }
        }
         private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_People frmAddEdit = new frmAdd_Edit_People();
            frmAddEdit.ReLoadData += ReloadPeople;
            frmAddEdit.Show();
        }
        private void tsmAddNew_Click(object sender, EventArgs e)
        {
            btnAddNew_Click(sender, e);
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            
            frmAdd_Edit_People frmAddEdit = new frmAdd_Edit_People((int)dgvLsitPeople.CurrentRow.Cells[0].Value);
            frmAddEdit.ReLoadData += ReloadPeople;
            frmAddEdit.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int ID =(int) dgvLsitPeople.CurrentRow.Cells[0].Value;
            if(!clsPeople.IsExist(ID))
            {
                MessageBox.Show("Person Not Found");
                return;
            }

            if(MessageBox.Show("Sure To Delete this Record?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(clsPeople.DeletePerson(ID))
                {
                    MessageBox.Show("Deleted Successfully", "Alert");
                    ReloadPeople(sender);
                }else
                {
                    MessageBox.Show("Couldn't Delete the Record, Cause Of Refrential Intigrity !!");
                }
            }
        }


        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int ID =(int) dgvLsitPeople.CurrentRow.Cells[0].Value;
            Form PrsnDetails = new frmPersonDetails(ID);
            PrsnDetails.ShowDialog();
        }

        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented Yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Not Implemented Yet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cmsManagePeople_Opening(object sender, CancelEventArgs e)
        {
            toUserToolStripMenuItem.Enabled = true;

            int ID = (int)dgvLsitPeople.CurrentRow.Cells[0].Value;
            if (clsUsers.ExistByPersonID(ID))
                toUserToolStripMenuItem.Enabled = false;
        }

        private void toUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvLsitPeople.CurrentRow.Cells[0].Value;
            frmAdd_EditUser MakeItUser = new frmAdd_EditUser(frmAdd_EditUser.enMode.eAddNewUser, ID);
            MakeItUser.ShowDialog();
        }
    }
}
