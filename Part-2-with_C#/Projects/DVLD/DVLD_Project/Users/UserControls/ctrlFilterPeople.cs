﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_Project.Users.UserControls
{
    public partial class ctrlFilterPeople : UserControl
    {
        public ctrlFilterPeople()
        {
            InitializeComponent();
        }
        private void ctrlFilterPeople_Load(object sender, EventArgs e)
        {
            _LoadFindOptions();
        }

        public delegate void SendPersonIDHandler(object sender, int PersonID);
        public event SendPersonIDHandler __GetPersonID;

        Dictionary<string,string>FindOpt=new Dictionary<string,string>();
        private void _LoadFindOptions()
        {
            FindOpt.Add("NationalNo", "National No");
            FindOpt.Add("PersonID", "Person ID");
            cmbFilterOpts.DataSource = new BindingSource(FindOpt, null);
            cmbFilterOpts.DisplayMember = "Value";
            cmbFilterOpts.ValueMember = "Key";
            cmbFilterOpts.SelectedIndex = 0;
        }
        private int _PersonID = -1;
        
        private bool _FindPerson()
       {
            bool Found = false;
            clsPeople Person;

            string Term = txtSearchTerm.Text;
            string FindBy = cmbFilterOpts.SelectedValue.ToString();

            if ( FindBy== "NationalNo")
            {

                Person = clsPeople.Find(Term);
                if(Person != null)
                {
                    _PersonID = Person.PersonID;
                    Found = true;
                }
                else
                {
                    MessageBox.Show($"No Person with National No << {Term} >>","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }else
            {

                int Pid = int.Parse(Term);
                if (clsPeople.IsExist(Pid))
                {
                    _PersonID = Pid;
                    Found = true;
                }
                else
                {
                    MessageBox.Show($"No Person with ID << {Term} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
       
            return Found;

        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if(_FindPerson())
                __GetPersonID?.Invoke(this, _PersonID);
        }
        private void txtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void cmbFilterOpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchTerm.KeyPress -= txtSearchTerm_KeyPress;

            if (cmbFilterOpts.SelectedValue.ToString() == "PersonID")
            {
                txtSearchTerm.KeyPress += txtSearchTerm_KeyPress;

            }
           

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Edit_People NewPerson = new frmAdd_Edit_People();
            NewPerson.ReturnPersonID += GetNewPersonID;
            NewPerson.ShowDialog();
        }
        private void GetNewPersonID(object sender, int PersonID)
        {
            _PersonID = PersonID;
            __GetPersonID?.Invoke(this, _PersonID);

        }

        private void gbFilterContainer_Enter(object sender, EventArgs e)
        {

        }
    }
}
