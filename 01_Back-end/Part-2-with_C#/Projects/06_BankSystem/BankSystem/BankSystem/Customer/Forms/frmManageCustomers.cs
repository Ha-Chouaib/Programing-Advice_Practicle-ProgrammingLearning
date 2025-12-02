using Bank_BusinessLayer;
using BankSystem.Person;
using BankSystem.Person.Forms;
using BankSystem.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Customer.Forms
{
    public partial class frmManageCustomers : Form
    {
        public frmManageCustomers()
        {
            InitializeComponent();
            LoadManageRecordsControl();
        }

        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__AddNewRecordDelegate += _AddNewCustomer;
            ctrlManageRecords1.__UpdateRecordDelegate += _EditCustomer;
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;

            ctrlManageRecords1.__HeaderImg.Image = Resources.Team;

            ctrlManageRecords1.__HeaderTitle.Text = "Manage Customers";
            ctrlManageRecords1.__AddNewBtn.Text = "Add New Customer";
            ctrlManageRecords1.__UpdateBtn.Text = "Edit Customer";

            ctrlManageRecords1.__Initialize(clsCustomer.ListCustomers(), _FilterBy_Options(), clsCustomer.FilterCustomers, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            Dictionary<string, string> Options = new Dictionary<string, string>
            {
                {"All","All"},
                {"Customer ID","CustomerID" },
                {"Person ID","PersonID" },
                {"Status","IsActive"},
                {"Customer Type","CustomerType" },
               
            };

            return Options;
        }
        private List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            List<(string ContextMenuKey, Action<int, ToolStripMenuItem > ContextMenuAction)> ContextMenuItems = new List<(string ContextMenuKey, Action<int, ToolStripMenuItem > ContextMenuAction)>
            {
                ("View Details", _ContextMenuViewCustomerDetails),
                ("Edit Customer", _ContextMenuEditCustomer),
                ("Delete Customer", _ContextMenuDeleteCustomer),
                ("Send Email", _ContextMenuSendCustomerEmail),
                ("Call Customer", _ContextMenuCallCustomer),
                ("-----------------", null),
                ("Convert To User", _ContextMenuConvertToUser),

            };

            return ContextMenuItems;
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            Dictionary<string, Dictionary<string, string>> FilterOptions = new Dictionary<string, Dictionary<string, string>>
            {
                  {
                        "IsActive", new Dictionary<string, string>
                        {
                            { "All", "All" },
                            { "Active", "1" },
                            { "InActive", "0" }
                        }

                   },
                 {
                        "CustomerType", new Dictionary<string, string>
                        {
                            { "All", "All" },
                            { "Individual", "1" },
                            { "Business", "2" },
                            { "VIP", "3" }
                           
                        }

                   }
            };

            return FilterOptions;
        }

        void _ContextMenuViewCustomerDetails(int customerID, ToolStripMenuItem menuItem)
        {
            clsCustomer customer = clsCustomer.FindCustomerByID(customerID);
            if (customer != null)
            {
                frmCustomerCard DisplayCustomerInfo = new frmCustomerCard(customer);
                DisplayCustomerInfo.ShowDialog();
            }else
                MessageBox.Show($"Can't Find Any Customer with id [{customerID}]!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        void _ContextMenuEditCustomer(int customerID, ToolStripMenuItem menuItem)
        {
            clsCustomer customer = clsCustomer.FindCustomerByID(customerID);
            if (customer != null)
            {
                frmEditCustomer editCustomer = new frmEditCustomer(customerID);
                editCustomer.__OperatinDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
                editCustomer.ShowDialog();
                return;
            }
            MessageBox.Show($"No record founded by id [{customerID}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        void _ContextMenuDeleteCustomer(int customerID, ToolStripMenuItem menuItem)
        {
            if(!clsCustomer.IsCustomerExistsByID(customerID))
            {
                MessageBox.Show($"No record founded by id [{customerID}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Sure To delete this record?!", "Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.Delete(customerID))
                {
                    MessageBox.Show($"The Person's record With id [{customerID}] was deleted successfully");
                    ctrlManageRecords1.__RefreshRecordsList(clsCustomer.ListCustomers());
                }
                else MessageBox.Show($"Can't Delete This Record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _ContextMenuSendCustomerEmail(int customerID, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"Send Email To Customer with id [{customerID}] -> Not Implemented yet");
        }
        void _ContextMenuCallCustomer(int customerID, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"call the  Customer with id [{customerID}] -> Not Implemented yet");
        }
        void _ContextMenuConvertToUser(int customerID, ToolStripMenuItem menuItem)
        {
            MessageBox.Show($"Convert Person with id [{customerID}] To User -> Not Implemented yet");
        }

        private void _EndSession()
        {
            this.Close();
        }
        private void _AddNewCustomer()
        {
            frmAddNewCustomer addNewCustomer = new frmAddNewCustomer();
            addNewCustomer.__OperatinDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
            addNewCustomer.ShowDialog();
        }
        private void _EditCustomer()
        {
            frmEditCustomer editCustomer = new frmEditCustomer();
            editCustomer.__OperatinDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
            editCustomer.ShowDialog();
        }
        private void _ConfigureDataRecordsContainer()
        {


            var grid = ctrlManageRecords1.__RecordsContainer;

            grid.Columns["CustomerID"].HeaderText = "ID";
            grid.Columns["PersonID"].HeaderText = "Person ID";
            grid.Columns["CustomerType"].HeaderText = "Customer Type";
            grid.Columns["CreatedDate"].HeaderText = "Created Date";
            grid.Columns["CreatedByUserID"].HeaderText = "Added By User";

            // Replace the IsActive column with a checkbox column ONCE
            int index = grid.Columns["IsActive"].Index;
            grid.Columns.Remove("IsActive");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "IsActive";
            chk.HeaderText = "Is Active";
            chk.DataPropertyName = "IsActive";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true; // optional

            grid.Columns.Insert(index, chk);

            grid.CellFormatting += (s, e) =>
            {
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "CustomerType" && e.Value is byte type)
                {
                    e.Value = type == 1 ? "Individual" : type == 2 ? "Business" : "(VIP)";
                    e.FormattingApplied = true;
                }
               
            };

        }
    }
}

