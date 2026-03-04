using BankSystem.GlobalElements.Forms;
using BankSystem.GlobalElements.UserControls;
using BankSystem.Properties;
using BankSystem.SideBarMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class frmHomePage : Form
    {
        public frmHomePage()
        {
            InitializeComponent();

        }
        frmLogin _LoginForm;
        public frmHomePage(frmLogin loginForm)
        {
            InitializeComponent();
            _LoginForm = loginForm;
            InitializeMainPanel();

        }

        private void InitializeMainPanel()
        {
            ctrlHomePageShorts shorts = new ctrlHomePageShorts();
            if (!pnlMain.Controls.Contains(shorts))
            {
                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(shorts);
                shorts.Location = new Point((pnlMain.Width - shorts.Width) / 2, (pnlMain.Height - shorts.Height) / 2);
                pnlMain.SizeChanged += (s, ev) => { shorts.Location = new Point((pnlMain.Width - shorts.Width) / 2, (pnlMain.Height - shorts.Height) / 2); };
                shorts.BringToFront();
            }
          
        }
        private void frmHomePage_Load_1(object sender, EventArgs e)
        {
            BuildSideBar();
            if (!IsInDesignMode())
            {
                Initialize();

            }

        }

        private bool IsInDesignMode()
        {
            // safest design-mode check that also works in inheritance
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }


        private void Initialize()
        {
            Date_Clock();
            string imgPath = clsGlobal_BL.LoggedInUser.PersonalInfo.ImagePath;
            bool isMale = clsGlobal_BL.LoggedInUser.PersonalInfo.Gender == 0;
            Image profile = !string.IsNullOrEmpty(imgPath) && File.Exists(imgPath) ? Image.FromFile(imgPath) : isMale ? Resources.person_man : Resources.person_woman;

            btnAccountSettings.__BtnImage = profile;
        }
        private void Date_Clock()
        {

            timer1.Tick += timer1_Tick;
            timer1.Start();

            _UpdateClock();


        }
        private void _UpdateClock()
        {
            lblClok.Text = $"{DateTime.Now.ToString("yyyy/MM/dd")} -- {DateTime.Now.ToString("hh:mm:ss tt")}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _UpdateClock();
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
                        new clsMenuBtnModel { Key = "frmAddNewCustomer", Title = "Add New Customer",Icon = Resources.add },
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
                        new clsMenuBtnModel { Key = "frmAddNewUser", Title = "Add New User",Icon = Resources.add },
                        new clsMenuBtnModel { Key = "frmEditUser", Title = "Edit User",Icon = Resources.update },
                        new clsMenuBtnModel { Key = "frmChangePassword", Title = "Change Password",Icon = Resources.password },
                        new clsMenuBtnModel { Key = "frmFindUser", Title = "Find User",Icon= Resources.find_in_file }
                    }
                },
                // 🔹 Accounts

                new clsMenuBtnModel
                   {
                       Key = "frmAccounts",
                       Title = "Accounts",
                       Icon = Resources.customers,
                       SubItems = new List<clsMenuBtnModel>
                       {
                           new clsMenuBtnModel { Key = "frmManageAccounts", Title = "Manage Accountss",Icon = Resources.People_manager },
                           new clsMenuBtnModel { Key = "frmAddNewAccount", Title = "Add New Account",Icon = Resources.add },
                           new clsMenuBtnModel { Key = "frmFindAccount", Title = "Find Account", Icon = Resources.find_in_file },
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
                        new clsMenuBtnModel { Key = "frmDepositMoney", Title = "Deposit",Icon = Resources.deposit },
                        new clsMenuBtnModel { Key = "frmWithdrawMoney", Title = "Withdraw" ,Icon= Resources.withdrawal},
                        new clsMenuBtnModel { Key = "frmTransferMoney", Title = "Transfer" , Icon = Resources.TransferMoney },
                    }
                },
                new clsMenuBtnModel
                {
                    Key = "frmSystemSettings",
                    Title = "System Settings",
                    Icon = Resources.settings_12891607,
                }


            };

            return menu;
        }
        public void BuildSideBar()
        {
            ctrlSideBarMenu2.SideBarItemClicked += LoadForm;
            ctrlSideBarMenu2.BuildSideBarMenu(_MenuItems());
        }

        private void LoadForm(object sender, clsMenuBtnModel Item)
        {
            var frm = clsUtil_PL.FormHelper.CreateFormInstance(Item.Key);

            if (frm == null)
            {
                MessageBox.Show($"Cannot open form: '{Item.Key}'.\nForm not found.",
                                "Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm.ShowDialog();

        }

        private void btnAccountSettings_Click_1(object sender, EventArgs e)
        {
            frmAccountSettings settings = new frmAccountSettings(btnAccountSettings);
            settings.ShowDialog();
        }

        private void frmHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsGlobal_BL.ClearSession();
            _LoginForm.Show();
        }
    }
}
