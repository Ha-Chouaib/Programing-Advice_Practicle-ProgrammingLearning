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
        private int _PersonID = -1;
        clsPeople _Person;
      
        private bool _EnableFilter = true;
        public bool __EnableFilter 
        { 
            get { return _EnableFilter; }

            set {   _EnableFilter= value;
                    gbFilterContainer.Enabled = _EnableFilter;
                }
        }

        public int __PersonID { get {  return _PersonID; } set { _PersonID = value; } }
        public clsPeople __PersonInf 
        {
            get { return _Person; }
        }


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
       

        private bool _FindPerson()
       {

            string Term = txtSearchTerm.Text;
            string FindBy = cmbFilterOpts.SelectedValue.ToString();

            if ( FindBy== "NationalNo")
            {

                _Person = clsPeople.Find(Term);
                if(_Person == null)
                {
                    MessageBox.Show($"No Person with National No << {Term} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                _PersonID = _Person.PersonID;
               
            }
            else
            {

                int Pid = int.Parse(Term);
                if(! clsPeople.IsExist(Pid))
                {
                    MessageBox.Show($"No Person with ID << {Term} >>", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return false;
                }
                _PersonID = Pid;
            }

            _Person = clsPeople.Find(_PersonID);
            return true ;

        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if(_FindPerson())
                __GetPersonID?.Invoke(this, _PersonID);
        }
        private void txtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindPerson.PerformClick();

            if(cmbFilterOpts.SelectedValue.ToString() == "PersonID")
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
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
            _Person=clsPeople.Find(_PersonID);
            __GetPersonID?.Invoke(this, _PersonID);

        }

    }
}
