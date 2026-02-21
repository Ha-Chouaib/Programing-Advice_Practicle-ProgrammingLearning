using Bank_BusinessLayer;
using BankSystem.Accounts.Forms;
using BankSystem.Person;
using BankSystem.Person.Forms;
using BankSystem.Properties;
using BankSystem.Reports.Forms;
using BankSystem.User.Forms;
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
            _HasPermissions();
            LoadManageRecordsControl();
        }

        private void _HasPermissions()
        {
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_ViewAccounts))
            {
                MessageBox.Show("You don't have permission to view customers.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
        }
        static class ContextMenuItems
        {

            public static (string valueMember, string displayMember) ViewCustomerDetails => ("ViewCustomerDetails", "View Details");
            public static (string valueMember, string displayMember) EditCustomer => ("EditCustomer", "Edit Customer");
            public static (string valueMember, string displayMember) DeleteCustomer => ("DeleteCustomer", "Delete Customer");
            public static (string valueMember, string displayMember) SendEmail => ("SendEmail", "Send Email");
            public static (string valueMember, string displayMember) CallCustomer => ("CallCustomer", "Call Customer");
            public static (string valueMember, string displayMember) Separator => ("Separator", "-----------------");
            public static (string valueMember, string displayMember) ConvertToUser => ("ConvertToUser", "Convert To User");
            public static (string valueMember, string displayMember) AddAccount => ("AddAccount", "Add Account");
            public static (string valueMember, string displayMember) LoadCustomerSummaryReport => ("LoadCustomerSummaryReport", "Load Customer Summary Report");
        }

        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__AddNewRecordDelegate += _AddNewCustomer;
            ctrlManageRecords1.__UpdateRecordDelegate += _EditCustomer;
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;

            ctrlManageRecords1.__HeaderImg.Image = Resources.social_responsibility_18024872;


            ctrlManageRecords1.__AddNewBtn.Text = "Add New Customer";
            ctrlManageRecords1.__UpdateBtn.Text = "Edit Customer";

            ctrlManageRecords1.__AddNewBtn.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_Add);
            ctrlManageRecords1.__UpdateBtn.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Customers_Edit);


            ctrlManageRecords1.__Initialize( _FilterBy_Options(), clsCustomer.FilterCustomers, _ContextMenuPackage(), _FilterByGroups());
            ctrlManageRecords1.__ContextMenuStrip.Opening += (s, e) =>
            {
                var user = clsGlobal_BL.LoggedInUser;

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.ViewCustomerDetails.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Customers_View);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.EditCustomer.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Customers_Edit);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.DeleteCustomer.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Customers_Delete);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.AddAccount.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Accounts_Add);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.LoadCustomerSummaryReport.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Reports_Customer);
            };

            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsCustomer.Filter_Mapping));

        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsCustomer.Filter_ByGroupsMapping));
        }

        private List<((string valueMember, string displayMember) ContextMenuItem, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            var contextMenuItems = new List<((string valueMember, string displayMember), Action<int, ToolStripMenuItem>)>
            {
                (ContextMenuItems.ViewCustomerDetails, _ContextMenuViewCustomerDetails),
                (ContextMenuItems.EditCustomer, _ContextMenuEditCustomer),
                (ContextMenuItems.DeleteCustomer, _ContextMenuDeleteCustomer),
                (ContextMenuItems.SendEmail, _ContextMenuSendCustomerEmail),
                (ContextMenuItems.CallCustomer, _ContextMenuCallCustomer),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.ConvertToUser, _ContextMenuConvertToUser),
                (ContextMenuItems.AddAccount, _ContextMenuAddNewAccount),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.LoadCustomerSummaryReport, _ContextMenuLoadCustomerSummaryReport),
            };

            return contextMenuItems;
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
                MessageBox.Show($"No record found by id [{customerID}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Sure To delete this record?!", "Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsCustomer.Delete(customerID, clsGlobal_BL.LoggedInUser.UserID))
                {
                    MessageBox.Show($"The customer's record With id [{customerID}] was deleted successfully");
                    ctrlManageRecords1.__RefreshRecordsList();
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
             clsCustomer cust = clsCustomer.FindCustomerByID(customerID); 
            if(cust != null)
            {
                frmAddNewUser ToUser = new frmAddNewUser(cust.PersonID);
                ToUser.ShowDialog();
                return;
            }
            MessageBox.Show($"No Customer Exists With id [{customerID}]","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuAddNewAccount(int customerID, ToolStripMenuItem menuItem)
        {
            if(clsCustomer.IsCustomerExistsByID(customerID))
            {
                frmAddNewAccount addAccount = new frmAddNewAccount(customerID);
                addAccount.ShowDialog();
                return;
            }
            MessageBox.Show($"No Customer Exists With id [{customerID}]","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuLoadCustomerSummaryReport(int customerID, ToolStripMenuItem menuItem)
        {
            if (clsCustomer.IsCustomerExistsByID(customerID))
            {
                frmCustomerSummaryCard card = new frmCustomerSummaryCard(customerID); card.ShowDialog();
                return;
            }
            MessageBox.Show($"No Customer Exists With id [{customerID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (grid.RowCount == 0) return;

            grid.Columns["PersonID"].HeaderText = "Person ID";
            grid.Columns["FullName"].HeaderText = "Full Name";
            grid.Columns["CustomerType"].HeaderText = "Customer Type";
            grid.Columns["CreatedDate"].HeaderText = "Created Date";
            grid.Columns["CreatedByUserID"].HeaderText = "Added By User";

            int index = grid.Columns["IsActive"].Index;
            grid.Columns.Remove("IsActive");

            var chk = new DataGridViewCheckBoxColumn();
            chk.Name = "IsActive";
            chk.HeaderText = "Is Active";
            chk.DataPropertyName = "IsActive";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.ReadOnly = true;

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

