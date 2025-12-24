using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankSystem.User.UserControls
{
    public partial class ctrlAddEditUser : UserControl
    {
        public ctrlAddEditUser()
        {
            InitializeComponent();
        }


        public Action<ulong> __OnPermissionChanged;

        private Dictionary<string, ulong> _GetPermissionsList()
        {
            Dictionary<string, ulong> PermissionBits = new Dictionary<string, ulong>
            {
                // ===== People =====
                { "People_View",              1UL << 0 },
                { "People_Manage",            1UL << 1 },
                { "People_Add",               1UL << 2 },
                { "People_Edit",              1UL << 3 },
                { "People_Find",              1UL << 4 },
            
                // ===== Customers =====
                { "Customers_View",           1UL << 5 },
                { "Customers_Manage",         1UL << 6 },
                { "Customers_Add",            1UL << 7 },
                { "Customers_Edit",           1UL << 8 },
                { "Customers_Find",           1UL << 9 },
                { "Customers_Accounts",       1UL << 10 },
            
                // ===== Accounts =====
                { "Accounts_View",            1UL << 11 },
                { "Accounts_Manage",          1UL << 12 },
                { "Accounts_Add",             1UL << 13 },
                { "Accounts_Find",            1UL << 14 },
            
                // ===== Users =====
                { "Users_View",              1UL << 15 },
                { "Users_Manage",            1UL << 16 },
                { "Users_AddEdit",           1UL << 17 },
                { "Users_ChangePassword",    1UL << 18 },
                { "Users_Find",              1UL << 19 },
            
                // ===== Transactions =====
                { "Transactions_View",       1UL << 20 },
                { "Transactions_Deposit",    1UL << 21 },
                { "Transactions_Withdraw",   1UL << 22 },
                { "Transactions_Transfer",   1UL << 23 },
                { "Transactions_History",    1UL << 24 },
            
                // ===== Reports =====
                { "Reports_View",            1UL << 25 },
                { "Reports_Customer",        1UL << 26 },
                { "Reports_Transaction",     1UL << 27 },
                { "Reports_UserActivity",    1UL << 28 },
                { "Reports_SystemLogs",      1UL << 29 }
            };
            return PermissionBits;
        }

        public void __LoadPermissions(ulong UserPrmission)
        {
            ctrlCheckedComboBox1.__LoadPermissions(_GetPermissionsList(), UserPrmission);
            ctrlCheckedComboBox1.__OnValueChanged += _GetCurrentPermissions;
        }
        private void _GetCurrentPermissions(ulong permissions)
        {
            __OnPermissionChanged?.Invoke(permissions);
        }

        private void ctrlAddEditUser_Load(object sender, EventArgs e)
        {

        }
    }
}
