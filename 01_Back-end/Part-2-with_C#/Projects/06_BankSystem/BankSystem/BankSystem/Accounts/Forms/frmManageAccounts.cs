using Bank_BusinessLayer;
using BankSystem.Customer.Forms;
using BankSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.Accounts.Forms
{
    public partial class frmManageAccounts : Form
    {
        public frmManageAccounts()
        {
            InitializeComponent();
            LoadManageRecordsControl();
        }
        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__AddNewRecordDelegate += _AddNewAccount;
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;

            ctrlManageRecords1.__HeaderImg.Image = Resources.process_8257890;

            ctrlManageRecords1.__HeaderTitle.Text = "Manage Accountss";
            ctrlManageRecords1.__AddNewBtn.Text = "Add New Account";
            ctrlManageRecords1.__UpdateBtn.Visible = false;

            ctrlManageRecords1.__Initialize(clsAccounts.ListAccounts(), _FilterBy_Options(), clsAccounts.FilterAccounts, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            Dictionary<string, string> Options = new Dictionary<string, string>
            {
                {"All","All"},
                {"Account ID","ID" },
                {"Customer ID","CustomerID" },
                {"Status","IsActive"},
                {"Account Type","AccountType" },

            };

            return Options;
        }
        private List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)> ContextMenuItems = new List<(string ContextMenuKey, Action<int, ToolStripMenuItem> ContextMenuAction)>
            {
                ("View Details", _ContextMenuViewAccountDetails),
                ("View Owner", _ContextMenuViewCustomerDetails),
                ("View Related Accounts", _ContextMenuViewRelatedAccounts),
                ("----------------------", null),
                ("Deposit", _ContextMenuDeposit),
                ("Withdrawal", _ContextMenuWithdraw),
                ("Transfer", _ContextMenuTransfer),
                ("----------------------", null),
                ("Update", _ContextMenuChangeStatus),
                ("Delete", _ContextMenuDeleteAccount),

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
                        "AccountType", new Dictionary<string, string>
                        {
                            { "All", "All" },
                            { "Individual", "1" },
                            { "Business", "2" },
                            { "Save", "3" },


                        }

                   }
            };

            return FilterOptions;
        }

        void _ContextMenuViewAccountDetails(int accountID, ToolStripMenuItem menuItem)
        {
            clsAccounts account = clsAccounts.FindByID(accountID);
            if (account != null)
            {
                frmFindAccount DisplayAccountInfo = new frmFindAccount(account);
                DisplayAccountInfo.ShowDialog();
            }
            else
                MessageBox.Show($"Can't Find Any Account with id [{accountID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuViewCustomerDetails(int customerID, ToolStripMenuItem menuItem)
        {
            clsCustomer customer = clsCustomer.FindCustomerByID(customerID);
            if (customer != null)
            {
                frmCustomerCard DisplayCustomerInfo = new frmCustomerCard(customer);
                DisplayCustomerInfo.ShowDialog();
            }
            else
                MessageBox.Show($"Can't Find Any Customer with id [{customerID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _ContextMenuViewRelatedAccounts(int customerID, ToolStripMenuItem menuItem)
        {
            if (clsCustomer.IsCustomerExistsByID(customerID))
            {
                frmCustomerAccounts customerAccounts = new frmCustomerAccounts(customerID);
                customerAccounts.ShowDialog();
                return;
            }
            MessageBox.Show($"No record founded by id [{customerID}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        void _ContextMenuDeleteAccount(int accountID, ToolStripMenuItem menuItem)
        {
            if (!clsAccounts.Exists(accountID))
            {
                MessageBox.Show($"No record founded by id [{accountID}] ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Sure To delete this record?!", "Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsAccounts.Delete(accountID, clsGlobal.LoggedInUser.UserID))
                {
                    MessageBox.Show($"The acount's record With id [{accountID}] was deleted successfully");
                    ctrlManageRecords1.__RefreshRecordsList();
                }
                else MessageBox.Show($"Can't Delete This Record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _ContextMenuChangeStatus(int accountID, ToolStripMenuItem menuItem)
        {
            if (clsAccounts.Exists(accountID))
            {
                if (MessageBox.Show("Sure To Change Account Status?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                if (clsAccounts.UpdateStatus(accountID, !clsAccounts.isActive(accountID)))
                {
                    MessageBox.Show("Done SucessFully");
                    ctrlManageRecords1.__RefreshRecordsList();
                    return;
                }

                MessageBox.Show("Operation Failed, Can't Save Changes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"No Account Exists With ID [{accountID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void _ContextMenuDeposit(int accountID, ToolStripMenuItem menuItem)
        {
        }
        void _ContextMenuWithdraw(int accountID, ToolStripMenuItem menuItem)
        {
        }
        void _ContextMenuTransfer(int accountID, ToolStripMenuItem menuItem)
        {
            
        }
      
        private void _EndSession()
        {
            this.Close();
        }
        private void _AddNewAccount()
        {
            frmAddNewAccount addNewAccount = new frmAddNewAccount();
            addNewAccount.__OperationDoneSuccessfully += ctrlManageRecords1.__RefreshRecordsList;
            addNewAccount.ShowDialog();
        }
       
        private void _ConfigureDataRecordsContainer()
        {


            var grid = ctrlManageRecords1.__RecordsContainer;

            grid.Columns["AccountNumber"].HeaderText = "Account Number";
            grid.Columns["CustomerID"].HeaderText = "Owner ID";
            grid.Columns["CustomerName"].HeaderText = "Owner Name";
            grid.Columns["AccountType"].HeaderText = "Account Type";
            grid.Columns["IsActive"].HeaderText = "Active";
            grid.Columns["CreatedAt"].HeaderText = "Created Date";
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
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "AccountType" && e.Value is byte type)
                {
                    e.Value = type == 1 ? "Individual" : type == 2 ? "Business" : "Save";
                }
                if (ctrlManageRecords1.__RecordsContainer.Columns[e.ColumnIndex].Name == "CreatedByUserID" && e.Value is int usr)
                {
                    e.Value = clsUser.FindUserByID(usr)?.UserName ?? "(N/A)";
                }

            };

        }

    }
}
