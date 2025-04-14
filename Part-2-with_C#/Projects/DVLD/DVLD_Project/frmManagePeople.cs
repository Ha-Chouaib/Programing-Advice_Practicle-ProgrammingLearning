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
    }
}
