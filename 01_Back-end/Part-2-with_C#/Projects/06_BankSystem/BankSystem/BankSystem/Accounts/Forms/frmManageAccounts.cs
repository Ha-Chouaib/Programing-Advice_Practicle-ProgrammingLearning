using Bank_BusinessLayer;
using BankSystem.Customer.Forms;
using BankSystem.Properties;
using BankSystem.Reports.Forms;
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

            ctrlManageRecords1.__AddNewBtn.Text = "Add New Account";
            ctrlManageRecords1.__UpdateBtn.Visible = false;

            ctrlManageRecords1.__Initialize(_FilterBy_Options(), clsAccounts.FilterAccounts, _ContextMenuPackage(), _FilterByGroups());
            _ConfigureDataRecordsContainer();
        }
        private Dictionary<string, string> _FilterBy_Options()
        {
            return clsUtil_BL.MappingHelper.GetOptionsFromMapping(typeof(clsAccounts.Filter_Mapping));
        }
        private Dictionary<string, Dictionary<string, string>> _FilterByGroups()
        {
            return clsUtil_BL.MappingHelper.FilterBy_Groups(typeof(clsAccounts.Filter_ByGroupsMapping));

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
                ("----------------------", null),
                ("Load Balance Statement Report", _ContextMenuLoadBalanceStatementReport),
                ("Load Account Activity Report", _ContextMenuLoadAcountActivityReport),

            };

            return ContextMenuItems;
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
                if (clsAccounts.Delete(accountID, clsGlobal_BL.LoggedInUser.UserID))
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

        void _ContextMenuLoadBalanceStatementReport(int accountID, ToolStripMenuItem menuItem)
        {
            clsAccounts account = clsAccounts.FindByID(accountID);
            if (account != null)
            {
                frmBalanceStatementReportCard card = new frmBalanceStatementReportCard(account.AccountID,account.CustomerID);
                card.ShowDialog();
            }
            MessageBox.Show($"Can't Find Any Account with id [{accountID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        void _ContextMenuLoadAcountActivityReport(int accountID, ToolStripMenuItem menuItem)
        {
            
            if (clsAccounts.Exists(accountID))
            {
                frmAccountActivityReportCard card = new frmAccountActivityReportCard(accountID,DateTime.Today);
                card.ShowDialog();
            }
            MessageBox.Show($"Can't Find Any Account with id [{accountID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
