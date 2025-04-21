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
            txtFilterPeople.Visible = false;
        }

       
        private void _LoadPeople()
        {
            DataTable dtPeople = clsPeople.ListAll();

            dgvLsitPeople.DataSource = dtPeople;
            cmbFilter.SelectedIndex = 0;
            lblRecordsCount.Text = dgvLsitPeople.RowCount.ToString();

        }
        private void ReloadPeople(object sender)
        {
            dgvLsitPeople.DataSource = clsPeople.ListAll();
            lblRecordsCount.Text = dgvLsitPeople.RowCount.ToString();
        }
        private void _FilterPeopole()
        {

            string[] FilteringColumns = new string[] {"None","PersonID","NationalNo","FirstName","SecondName","ThirdName",
                                                      "LastName","NationalityCountryID","Gendor","Phone","Email"};

            byte ColumnIndex =(byte) cmbFilter.SelectedIndex;
            string FilterTerm = txtFilterPeople.Text;
            if (cmbFilter.SelectedIndex != 0 || txtFilterPeople.Text != string.Empty)
            {
                if (cmbFilter.SelectedIndex != 1 && cmbFilter.SelectedIndex!= 7)
                {
                    txtFilterPeople.KeyPress -= txtFilterPeople_KeyPress;
                    if(cmbFilter.SelectedIndex != 8)
                    {
                        dgvLsitPeople.DataSource = clsPeople.FilterPeople<string>(FilteringColumns[ColumnIndex], FilterTerm);

                    }else
                    {
                     
                        FilterTerm.ToLower();
                        if (FilterTerm.StartsWith("m") || FilterTerm.StartsWith("f"))
                        {
                            byte Gender;

                            if (FilterTerm.StartsWith("m")) Gender = 0;
                            else
                                Gender = 1;

                            dgvLsitPeople.DataSource = clsPeople.FilterPeople<byte>(FilteringColumns[ColumnIndex], Gender);
                        }

                    }

                }
                else
                {
                    txtFilterPeople.KeyPress += txtFilterPeople_KeyPress;
                    if(int.TryParse(FilterTerm,out int Int_Value))
                        dgvLsitPeople.DataSource=clsPeople.FilterPeople<int>(FilteringColumns[ColumnIndex],Int_Value);
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
            if (cmbFilter.SelectedIndex == 0)
            {
                txtFilterPeople.Visible = false;
            }
            else
                txtFilterPeople.Visible = true;
        }

        private void dgvLsitPeople_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLsitPeople.Columns[e.ColumnIndex].Name == "Gendor" && e.Value is byte Gdr)
            {
                e.Value = Gdr == 0 ? "Male" : "Female";
                e.FormattingApplied = true;
            }
        }

        private void pbAddNew_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_People frmAddEdit = new frmAdd_Edit_People();
            frmAddEdit.ReLoadPeopleList += ReloadPeople;
            frmAddEdit.Show();
        }

        private void tsmAddNew_Click(object sender, EventArgs e)
        {
            pbAddNew_Click(sender, e);
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            
            frmAdd_Edit_People frmAddEdit = new frmAdd_Edit_People((int)dgvLsitPeople.CurrentRow.Cells[0].Value);
            frmAddEdit.ReLoadPeopleList += ReloadPeople;
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

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
       
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int ID =(int) dgvLsitPeople.CurrentRow.Cells[0].Value;
            Form PrsnDetails = new frmPersonDetails(ID);
            PrsnDetails.ShowDialog();
        }
    }
}
