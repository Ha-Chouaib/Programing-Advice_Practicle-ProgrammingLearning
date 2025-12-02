using BankSystem.Properties;
using BankSystem.SideBarMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmHomePage : frmBaseForm
    {
        public frmHomePage()
        {
            InitializeComponent();
        }

        private void frmHomePage_Load(object sender, EventArgs e)
        {
            BuildSideBar();
        }

        private List<clsMenuBtnModel> _MenuItems()
        {

            List<clsMenuBtnModel> menu = new List<clsMenuBtnModel>
            {
                // 🔹 People
                new clsMenuBtnModel
                {
                    Key = "frmPeople",
                    Title = "People",
                    Icon = Resources.reporter,
                    SubItems = new List<clsMenuBtnModel>
                    {
                        new clsMenuBtnModel { Key = "frmManagePeople", Title = "Manage People",Icon = Resources.People_manager },
                        new clsMenuBtnModel { Key = "frmAddNewPerson", Title = "Add New Person" , Icon = Resources.add},
                        new clsMenuBtnModel { Key = "frmEditPerson", Title = "Edit Person" , Icon = Resources.update},
                        new clsMenuBtnModel { Key = "frmFindPerson", Title = "Find Person",Icon = Resources.find_in_file }
                    }
                },
            
                // 🔹 Customers
                new clsMenuBtnModel
                {
                    Key = "frmCustomers",
                    Title = "Customers",
                    Icon = Resources.customers,
                    SubItems = new List<clsMenuBtnModel>
                    {
                        new clsMenuBtnModel { Key = "frmManageCustomers", Title = "Manage Customers",Icon = Resources.People_manager },
                        new clsMenuBtnModel { Key = "frmAddNewCustomer", Title = "Add Customer",Icon = Resources.add },
                        new clsMenuBtnModel { Key = "frmEditCustomer", Title = "Edit Customer",Icon = Resources.update },
                        new clsMenuBtnModel { Key = "frmFindCustomer", Title = "Find Customer", Icon = Resources.find_in_file },
                        new clsMenuBtnModel { Key = "frmCustomerAccounts", Title = "Customer Accounts",Icon = Resources.account }
                    }
                },
            
                // 🔹 Users
                new clsMenuBtnModel
                {
                    Key = "frmUsers",
                    Title = "Users",
                    Icon = Resources.user__1_,
                    SubItems = new List<clsMenuBtnModel>
                    {
                        new clsMenuBtnModel { Key = "frmManageUsers", Title = "Manage Users",Icon = Resources.People_manager  },
                        new clsMenuBtnModel { Key = "frmAddEditUser", Title = "Add / Edit User",Icon = Resources.update },
                        new clsMenuBtnModel { Key = "frmChangePassword", Title = "Change Password",Icon = Resources.password },
                        new clsMenuBtnModel { Key = "frmFindUser", Title = "Find User",Icon= Resources.find_in_file }
                    }
                },
            
                // 🔹 Transactions
                new clsMenuBtnModel
                {
                    Key = "frmTransactions",
                    Title = "Transactions",
                    Icon = Resources.bank_transaction,
                    SubItems = new List<clsMenuBtnModel>
                    {
                        new clsMenuBtnModel { Key = "frmDeposit", Title = "Deposit",Icon = Resources.deposit },
                        new clsMenuBtnModel { Key = "frmWithdraw", Title = "Withdraw" ,Icon= Resources.withdrawal},
                        new clsMenuBtnModel { Key = "frmTransfer", Title = "Transfer" , Icon = Resources.TransferMoney },
                        new clsMenuBtnModel { Key = "frmTransactionHistory", Title = "Transaction History" ,Icon = Resources.history}
                    }
                },
            
                // 🔹 Reports
                new clsMenuBtnModel
                {
                    Key = "frmReports",
                    Title = "Reports",
                    Icon = Resources.general_reports,
                    SubItems = new List<clsMenuBtnModel>
                    {
                        new clsMenuBtnModel { Key = "frmCustomerReport", Title = "Customer Report",Icon = Resources.reporter },
                        new clsMenuBtnModel { Key = "frmTransactionReport", Title = "Transaction Report" ,Icon = Resources.bank_transaction__1_},
                        new clsMenuBtnModel { Key = "frmUserActivityReport", Title = "User Activity Report",Icon = Resources.activity },
                        new clsMenuBtnModel { Key = "frmSystemLogs", Title = "System Logs" ,Icon = Resources.log}
                    }
                },
                new clsMenuBtnModel
                {
                    Key = "Log_Out",
                    Title = "Leave",
                    Icon = Resources.sign_out,
                    BtnBackColor= Color.Red
                }


            };

            return menu;
        }
        public void BuildSideBar()
        {
            ctrlSideBarMenu1.SideBarItemClicked += LoadForm;
            ctrlSideBarMenu1.BuildSideBarMenu(_MenuItems());
        }

        private void LoadForm(object sender, clsMenuBtnModel Item)
        {
            var frm = clsGlobal.FormHelper.CreateFormInstance(Item.Key);

            if (frm == null)
            {
                MessageBox.Show($"Cannot open form: '{Item.Key}'.\nForm not found.",
                                "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm.ShowDialog();

        }
    }
}
