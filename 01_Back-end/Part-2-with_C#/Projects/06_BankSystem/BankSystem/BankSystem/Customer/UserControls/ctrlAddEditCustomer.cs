using Bank_BusinessLayer;
using BankSystem.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Customer.UserControls
{
    public partial class ctrlAddEditCustomer : UserControl
    {
        public ctrlAddEditCustomer()
        {
            InitializeComponent();
            _LoadCustomerTypes();
            ctrlDisplayPersonDetails1.__UpdatedPersonRecord += _GetLatestPersonData;
        }

        public Action<clsCustomer> __Added_Updated_Record;
        public Action __CancelOperation;
        private clsCustomer _CurrentCustomer = new clsCustomer();
        private clsPerson _Person = new clsPerson();
        enum enMode { enAddNew, enEdit }
        enMode _CurrentMode = enMode.enAddNew;
        private void _LoadCustomerTypes()
        {
            Dictionary<string, clsCustomer.enCustomerType> customerTypes = new Dictionary<string, clsCustomer.enCustomerType>
            {
                { "Individual", clsCustomer.enCustomerType.enIndividual },
                { "Business", clsCustomer.enCustomerType.enBusiness },
                { "VIP", clsCustomer.enCustomerType.enVIP }
            };
            cmbCustomerType.DataSource = new BindingSource(customerTypes, null);
            cmbCustomerType.DisplayMember = "Key";
            cmbCustomerType.ValueMember = "Value";
            cmbCustomerType.SelectedIndex = 0;

        }
        private void _GrapCustomerDataFromUI()
        {
           
            _CurrentCustomer.PersonID = _Person.PersonID;
            _CurrentCustomer.CustomerType = (clsCustomer.enCustomerType)cmbCustomerType.SelectedValue ;
            _CurrentCustomer.CreatedDate = DateTime.Now;
            _CurrentCustomer.IsActive = cbIsActive.Checked;
            _CurrentCustomer.Occupation = txtOccupation.Text.Trim()?? string.Empty;
            _CurrentCustomer.CreatedByUserID = clsGlobal_BL.LoggedInUser.UserID;
        }

        public void __AddNewCustomer()
        {
            _CurrentMode = enMode.enAddNew;
            lblHeader.Text = "Add New Customer";

            lblSearchFor.Visible = true;
            lblSearchFor.Text = "Search For Person";
            btnAddNewPerson.Visible = true;
            _LoadFindbyOptions_ForAddNew();            
        }
        public void __AddNewCustomer(int PersonID)
        {
            _CurrentMode = enMode.enAddNew;
            lblHeader.Text = "Add New Customer";
            if((_Person =clsPerson.Find(PersonID)) != null)
            {
                lblSearchFor.Visible = false;

                ctrlFind1.__txtSearchTerm.Text = PersonID.ToString();
                ctrlFind1.__FindOptionsCombo.Text = "Person ID";
                ctrlFind1.Enabled = false;
                ctrlDisplayPersonDetails1.__ShowPersonalInfo(_Person);
                return;
            }
            MessageBox.Show($"Can't Find Any Person with id[{PersonID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            __AddNewCustomer();
        }
        private void _LoadFindbyOptions_ForAddNew()
        {
            Dictionary<string, string> findByOptions = new Dictionary<string, string> 
            {{ "Person ID","PersonID"}, { "National No","NationalNo"} };

            ctrlFind1.__Initializing(findByOptions, clsPerson.FindBy);
            ctrlFind1.__txtSearchTerm.KeyPress += (s, e) =>
            { 
                if(ctrlFind1.__FindOptionsCombo.SelectedValue.ToString() == "NationalNo")
                {
                    e.Handled = (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar));
                }
                else
                    e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)); 
            };
            ctrlFind1.__ObjectFound += _GetSelectedPersonFromFindControl;
        }
        private void _GetSelectedPersonFromFindControl(object s,object obj)
        {
            _Person = (clsPerson)obj;
            if(_Person != null)
                ctrlDisplayPersonDetails1.__ShowPersonalInfo(_Person);
           
        }
        private void _GetLatestPersonData(clsPerson Person)
        {
            _GetSelectedPersonFromFindControl(this, Person);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewPerson addNewPerson = new frmAddNewPerson();
            addNewPerson.__PersonAdded += _GetLatestPersonData;
            
            addNewPerson.ShowDialog();
        }

        public void __EditCustomer(int customerId)
        {
            _CurrentMode = enMode.enEdit;
            lblHeader.Text = "Edit Customer Info";
            lblSearchFor.Visible = false;
            if ((_CurrentCustomer = clsCustomer.FindCustomerByID(customerId)) != null)
            {
                btnAddNewPerson.Visible = false;
                ctrlFind1.__txtSearchTerm.Text = customerId.ToString();
                ctrlFind1.Enabled = false;
                _DisplayCustomerDataOnUI();
            }
            else
            {
                MessageBox.Show($"Customer not found with ID[{customerId}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void __EditCustomer()
        {
            _CurrentMode = enMode.enEdit;
            lblHeader.Text = "Edit Customer Info";
            lblSearchFor.Text = "Search For Customer";
            _LoadFindbyOptions_ForEdit();
        }
        private void _LoadFindbyOptions_ForEdit()
        {
            btnAddNewPerson.Visible = false;
            Dictionary<string, string> findByOptions = new Dictionary<string, string>
            {{ "Customer ID","CustomerID"}, { "Person ID","PersonID"} };

            ctrlFind1.__Initializing(findByOptions,clsCustomer.FindBy);
            ctrlFind1.__txtSearchTerm.KeyPress += (s, e) => { e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)); };
            ctrlFind1.__ObjectFound += _GetSelectedCustomerFromFindControl;

        }
        private void _GetSelectedCustomerFromFindControl(object s, object obj)
        {
            _CurrentCustomer = (clsCustomer)obj;
            if(_CurrentCustomer != null)
            {
                _DisplayCustomerDataOnUI();
            }
        }
        private void _DisplayCustomerDataOnUI()
        {
            if (_CurrentCustomer != null)
            {
                _Person = clsPerson.Find(_CurrentCustomer.PersonID);
                ctrlDisplayPersonDetails1.__ShowPersonalInfo(_Person);
                cmbCustomerType.SelectedValue = _CurrentCustomer.CustomerType;
                txtOccupation.Text = _CurrentCustomer.Occupation;
                cbIsActive.Checked = _CurrentCustomer.IsActive;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Person == null || _Person.PersonID <=0)
            {
                MessageBox.Show("Please select a valid person for the customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("Are you sure to save the customer record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (_CurrentMode == enMode.enAddNew && clsCustomer.IsCustomerExistsByPersonID(_Person.PersonID))
            {
                MessageBox.Show("A customer record already exists for the selected person.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _GrapCustomerDataFromUI();
            if(_CurrentCustomer.Save())
            {
                lblCustomerID.Text = _CurrentCustomer.CustomerID.ToString();
                lblCreatedDate.Visible = true;
                lblCreatedDate.Text = _CurrentCustomer.CreatedDate.ToString("yyyy-MM-dd");
                __Added_Updated_Record?.Invoke(_CurrentCustomer);
            }
            else
            {
                __Added_Updated_Record?.Invoke(null);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e) => __CancelOperation?.Invoke();

    }
}
