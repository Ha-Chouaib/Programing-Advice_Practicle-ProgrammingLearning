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

namespace BankSystem.Accounts.UserControls
{
    public partial class ctrlAddNewAccount : UserControl
    {
        public ctrlAddNewAccount()
        {
            InitializeComponent();
            _InitializeFindControl();
            _LoadAccountTypes();
        }
        clsCustomer _TargetCustomer = null;
        clsAccounts _account = new clsAccounts();

        public Action<clsAccounts> __OnOperationDone;
        public Action __OnOperationaCanceled;
        private void _InitializeFindControl()
        {
            Dictionary<string, string> Options = new Dictionary<string, string>
            { 
                { "Customer ID", "CustomerID"},
                { "Person ID", "PersonID" }
            };
            ctrlFind1.__Initializing(Options, clsCustomer.FindBy);
            ctrlFind1.__txtSearchTerm.KeyPress += (s, e) =>
            { 
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };
            ctrlFind1.__ObjectFound += GetTargetCustomer;
        }
        public void __AddNewAccount(int customerID)
        {

            ctrlFind1.__txtSearchTerm.Text = customerID.ToString();
            ctrlFind1.__FindOptionsCombo.Text = "Customer ID";
            ctrlFind1.Enabled = false;
            GetTargetCustomer(this,clsCustomer.FindCustomerByID(customerID));         
        }
        private void GetTargetCustomer(object s, object customer)
        {
            _TargetCustomer = customer as clsCustomer;
            btnCancel.Text = "Cancel";

            _FillCustomerInfo();
        }
        private void _FillCustomerInfo()
        {
            if(_TargetCustomer == null) return;
            txtCustomerID.Text = _TargetCustomer.CustomerID.ToString();
            txtFullName.Text = _TargetCustomer.PersonalInf.FullName;
            txtCreatedDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtCreatedByUser.Text = clsGlobal.LoggedInUser.UserName;
            
           
        }
        private void _LoadAccountTypes()
        {
            Dictionary<string, clsAccounts.enAccountType> accountTypes = new Dictionary<string, clsAccounts.enAccountType>
            {
                { "Individual", clsAccounts.enAccountType.enIndividual },
                { "Business", clsAccounts.enAccountType.enBusiness },
                { "Save", clsAccounts.enAccountType.enSave },
            };
            cmbAccountType.DataSource = new BindingSource(accountTypes, null);
            cmbAccountType.DisplayMember = "Key";
            cmbAccountType.ValueMember = "Value";
            cmbAccountType.SelectedIndex = 0;

        }
        private void _GrapAccountInfo()
        {
            _account.CustomerID = _TargetCustomer.CustomerID;
            _account.AccountType = (clsAccounts.enAccountType)cmbAccountType.SelectedValue;
            _account.Balance = 0;
            _account.IsActive = rbIsActive.Checked;
            _account.CreatedByUserID = clsGlobal.LoggedInUser.UserID;
            _account.CreatedDate = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_TargetCustomer == null)
            {
                MessageBox.Show("Please select a customer first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _GrapAccountInfo();
            if(clsCustomer.HasAccountType(_TargetCustomer.CustomerID,_account.AccountType))
            {
                MessageBox.Show("The selected customer already has an account of this type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"The Data Will be Saved Permenently Once You Click [OK]", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            if(_account.Save())
            {
                txtAccountID.Text =$"[ {_account.AccountID} ]";
                txtAccountID.ForeColor = Color.Cyan;
                txtAcountNum.Text = $"[ {_account.AccountNumber} ]";
                txtAcountNum.ForeColor = Color.Cyan;
                __OnOperationDone?.Invoke(_account);
                btnCancel.Text = "Close";
                return;
            }
            __OnOperationDone?.Invoke(null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            __OnOperationaCanceled?.Invoke();
        }
        
    }
}
