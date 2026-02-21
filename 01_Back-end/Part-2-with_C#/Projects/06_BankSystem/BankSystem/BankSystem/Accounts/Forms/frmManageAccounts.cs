using Bank_BusinessLayer;
using BankSystem.Customer.Forms;
using BankSystem.Properties;
using BankSystem.Reports.Forms;
using BankSystem.Transactions.Forms;
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
            if (!clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Accounts_View))
            {
                MessageBox.Show("Access Denied.", "Permission", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Load += (s, e) => this.Close();
                return;
            }
            LoadManageRecordsControl();
        }
        static class ContextMenuItems
        {
            public static (string valueMember, string displayMember) ViewAccountDetails => ("ViewAccountDetails", "View Details");
            public static (string valueMember, string displayMember) ViewOwner => ("ViewOwner", "View Owner");
            public static (string valueMember, string displayMember) ViewRelatedAccounts => ("ViewRelatedAccounts", "View Related Accounts");
            public static (string valueMember, string displayMember) Separator => ("Separator", "----------------------");
            public static (string valueMember, string displayMember) Deposit => ("Deposit", "Deposit");
            public static (string valueMember, string displayMember) Withdrawal => ("Withdrawal", "Withdrawal");
            public static (string valueMember, string displayMember) Transfer => ("Transfer", "Transfer");
            public static (string valueMember, string displayMember) UpdateStatus => ("UpdateAccountStatus", "Update Status");
            public static (string valueMember, string displayMember) DeleteAccount => ("DeleteAccount", "Delete");
            public static (string valueMember, string displayMember) LoadBalanceStatementReport => ("LoadBalanceStatementReport", "Load Balance Statement Report");
            public static (string valueMember, string displayMember) LoadAccountActivityReport => ("LoadAccountActivityReport", "Load Account Activity Report");
        }

        public void LoadManageRecordsControl()
        {
            ctrlManageRecords1.__AddNewRecordDelegate += _AddNewAccount;
            ctrlManageRecords1.__CloseFormDelegate += _EndSession;

            ctrlManageRecords1.__HeaderImg.Image = Resources.process_8257890;

            ctrlManageRecords1.__AddNewBtn.Text = "Add New Account";
            ctrlManageRecords1.__AddNewBtn.Visible = clsGlobal_BL.LoggedInUser.HasPermission(clsRole.enPermissions.Accounts_Add);
            ctrlManageRecords1.__UpdateBtn.Visible = false;
            ctrlManageRecords1.__ContextMenuStrip.Opening += (s, e) =>
            {
                var user = clsGlobal_BL.LoggedInUser;

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.Deposit.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Transactions_Deposit);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.Withdrawal.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Transactions_Withdraw);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.Transfer.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Transactions_Transfer);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.UpdateStatus.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Accounts_ChangeStatus);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.DeleteAccount.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Accounts_Delete);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.LoadBalanceStatementReport.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Reports_Transaction);

                ctrlManageRecords1.__ContextMenuStrip.Items[ContextMenuItems.LoadAccountActivityReport.valueMember].Visible =
                    user.HasPermission(clsRole.enPermissions.Reports_Transaction);
            };

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

        private List<((string valueMember, string displayMember) ContextMenuItem, Action<int, ToolStripMenuItem> ContextMenuAction)> _ContextMenuPackage()
        {
            var contextMenuItems = new List<((string valueMember, string displayMember), Action<int, ToolStripMenuItem>)>
            {
                (ContextMenuItems.ViewAccountDetails, _ContextMenuViewAccountDetails),
                (ContextMenuItems.ViewOwner, _ContextMenuViewCustomerDetails),
                (ContextMenuItems.ViewRelatedAccounts, _ContextMenuViewRelatedAccounts),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.Deposit, _ContextMenuDeposit),
                (ContextMenuItems.Withdrawal, _ContextMenuWithdraw),
                (ContextMenuItems.Transfer, _ContextMenuTransfer),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.UpdateStatus, _ContextMenuChangeStatus),
                (ContextMenuItems.DeleteAccount, _ContextMenuDeleteAccount),
                (ContextMenuItems.Separator, null),
                (ContextMenuItems.LoadBalanceStatementReport, _ContextMenuLoadBalanceStatementReport),
                (ContextMenuItems.LoadAccountActivityReport, _ContextMenuLoadAcountActivityReport),
            };

            return contextMenuItems;
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
            frmDepositMoney dep = new frmDepositMoney(accountID);
            dep.ShowDialog();
        }
        void _ContextMenuWithdraw(int accountID, ToolStripMenuItem menuItem)
        {
            frmWithdrawMoney withdraw = new frmWithdrawMoney(accountID);
            withdraw.ShowDialog();
        }
        void _ContextMenuTransfer(int accountID, ToolStripMenuItem menuItem)
        {
            frmTransferMoney transfer = new frmTransferMoney(accountID); transfer.ShowDialog();
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
