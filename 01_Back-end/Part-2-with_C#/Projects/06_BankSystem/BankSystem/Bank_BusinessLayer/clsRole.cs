using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer
{
    public class clsRole
    {
        public int RoleID { get; private set; }
        public string RoleName { get; set; }
        public long Permissions { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedAt { get; set; }
        public int AddedByUserID { get; set; }

        enum enMode
        {
            AddNew,
            Update
        }
        enMode _Mode;

        [Flags]
        public enum enPermissions : long
        {
            None = 0,
            All = -1L,


            // ===== People =====
            People_View = 1L << 0,
            People_Add = 1L << 1,
            People_Edit = 1L << 2,
            People_Delete = 1L << 3,
            People_Find = 1L << 4,

            // ===== Customers =====
            Customers_View = 1L << 5,
            Customers_Add = 1L << 6,
            Customers_Edit = 1L << 7,
            Customers_Delete = 1L << 8,
            Customers_Find = 1L << 9,
            Customers_ViewAccounts = 1L << 10,  

            // ===== Accounts =====
            Accounts_View = 1L << 11,
            Accounts_Add = 1L << 12,
            Accounts_Find = 1L << 13,
            Accounts_ChangeStatus = 1L << 14,  
            Accounts_Delete = 1L << 15, 

            // ===== Users =====
            Users_View = 1L << 16,
            Users_Add = 1L << 17,  
            Users_Edit = 1L << 18,  
            Users_Delete = 1L << 19,
            Users_Find = 1L << 20,
            Users_ChangePassword = 1L << 21,
            Users_ManageRoles = 1L << 22,  

            // ===== Roles =====
            Roles_View = 1L << 23,  
            Roles_Add = 1L << 24,
            Roles_Edit = 1L << 25,
            Roles_Delete = 1L << 26,

            // ===== Transactions =====
            Transactions_View = 1L << 27,
            Transactions_Deposit = 1L << 28,
            Transactions_Withdraw = 1L << 29,
            Transactions_Transfer = 1L << 30,
            Transactions_History = 1L << 31,

            // ===== Reports =====
            Reports_View = 1L << 32,
            Reports_Customer = 1L << 33,
            Reports_Transaction = 1L << 34,  
            Reports_UserActivity = 1L << 35,
            Reports_SystemLogs = 1L << 36,
            // ===== Currencies =====
            Currencies_View = 1L << 37,
            Currencies_UpdateRate = 1L << 38,
           
        }
        [Flags]
        public enum enRolePresets : long
        {
            None = 0,

            Teller =
                enPermissions.Customers_View | enPermissions.Customers_Find | enPermissions.Customers_ViewAccounts |
                enPermissions.Accounts_View | enPermissions.Accounts_Find |
                enPermissions.Transactions_View | enPermissions.Transactions_Deposit |
                enPermissions.Transactions_Withdraw | enPermissions.Transactions_Transfer |
                enPermissions.Transactions_History,

            CustomerService =
                enPermissions.People_View | enPermissions.People_Edit | enPermissions.People_Find |
                enPermissions.Customers_View | enPermissions.Customers_Edit |
                enPermissions.Customers_Find | enPermissions.Customers_ViewAccounts |
                enPermissions.Accounts_View | enPermissions.Accounts_Find,

            AccountOfficer =
                enPermissions.Customers_View | enPermissions.Customers_Find | enPermissions.Customers_ViewAccounts |
                enPermissions.Accounts_View | enPermissions.Accounts_Add | enPermissions.Accounts_Find |
                enPermissions.Accounts_ChangeStatus | enPermissions.Accounts_Delete |
                enPermissions.Transactions_View | enPermissions.Transactions_History,

            ReportingOfficer =
                enPermissions.Customers_View | enPermissions.Customers_Find |
                enPermissions.Accounts_View | enPermissions.Accounts_Find |
                enPermissions.Transactions_View | enPermissions.Transactions_History |
                enPermissions.Reports_View | enPermissions.Reports_Customer |
                enPermissions.Reports_Transaction | enPermissions.Reports_UserActivity,

            Auditor =
                enPermissions.People_View | enPermissions.People_Find |
                enPermissions.Customers_View | enPermissions.Customers_Find | enPermissions.Customers_ViewAccounts |
                enPermissions.Accounts_View | enPermissions.Accounts_Find |
                enPermissions.Users_View | enPermissions.Users_Find |
                enPermissions.Transactions_View | enPermissions.Transactions_History |
                enPermissions.Reports_View | enPermissions.Reports_Customer |
                enPermissions.Reports_Transaction | enPermissions.Reports_UserActivity |
                enPermissions.Reports_SystemLogs,

            ITSupport =
                enPermissions.Users_View | enPermissions.Users_Add | enPermissions.Users_Edit |
                enPermissions.Users_Delete | enPermissions.Users_Find |
                enPermissions.Users_ChangePassword | enPermissions.Users_ManageRoles |
                enPermissions.Roles_View | enPermissions.Roles_Add |
                enPermissions.Roles_Edit | enPermissions.Roles_Delete |
                enPermissions.Reports_View | enPermissions.Reports_SystemLogs,

            BranchManager =
                enPermissions.People_View | enPermissions.People_Find |
                enPermissions.Customers_View | enPermissions.Customers_Add | enPermissions.Customers_Edit |
                enPermissions.Customers_Find | enPermissions.Customers_ViewAccounts |
                enPermissions.Accounts_View | enPermissions.Accounts_Add | enPermissions.Accounts_Find |
                enPermissions.Accounts_ChangeStatus | enPermissions.Accounts_Delete |
                enPermissions.Users_View | enPermissions.Users_Find |
                enPermissions.Transactions_View | enPermissions.Transactions_Deposit |
                enPermissions.Transactions_Withdraw | enPermissions.Transactions_Transfer |
                enPermissions.Transactions_History |
                enPermissions.Reports_View | enPermissions.Reports_Customer |
                enPermissions.Reports_Transaction | enPermissions.Reports_UserActivity |
                enPermissions.Reports_SystemLogs,

            Admin = enPermissions.All,
        }
        
        public static Dictionary<string, long> GetPermissionsList()
        {
            Dictionary<string, long> PermissionBits = new Dictionary<string, long>
            {
                // ===== People =====
                { "People_View",              1L << 0 },
                { "People_Manage",            1L << 1 },
                { "People_Add",               1L << 2 },
                { "People_Edit",              1L << 3 },
                { "People_Find",              1L << 4 },
            
                // ===== Customers =====
                { "Customers_View",           1L << 5 },
                { "Customers_Manage",         1L << 6 },
                { "Customers_Add",            1L << 7 },
                { "Customers_Edit",           1L << 8 },
                { "Customers_Find",           1L << 9 },
                { "Customers_Accounts",       1L << 10 },
            
                // ===== Accounts =====
                { "Accounts_View",            1L << 11 },
                { "Accounts_Manage",          1L << 12 },
                { "Accounts_Add",             1L << 13 },
                { "Accounts_Find",            1L << 14 },
            
                // ===== Users =====
                { "Users_View",              1L << 15 },
                { "Users_Manage",            1L << 16 },
                { "Users_AddEdit",           1L << 17 },
                { "Users_ChangePassword",    1L << 18 },
                { "Users_Find",              1L << 19 },
            
                // ===== Transactions =====
                { "Transactions_View",       1L << 20 },
                { "Transactions_Deposit",    1L << 21 },
                { "Transactions_Withdraw",   1L << 22 },
                { "Transactions_Transfer",   1L << 23 },
                { "Transactions_History",    1L << 24 },
            
                // ===== Reports =====
                { "Reports_View",            1L << 25 },
                { "Reports_Customer",        1L << 26 },
                { "Reports_Transaction",     1L << 27 },
                { "Reports_UserActivity",    1L << 28 },
                { "Reports_SystemLogs",      1L << 29 }
            };
            return PermissionBits;
        }

        public clsRole()
        {
            RoleID = -1;
            RoleName = string.Empty;
            Permissions = 0;
            Description = string.Empty;
            IsActive = true;
            AddedAt = DateTime.Now;
            AddedByUserID = -1;
            _Mode = enMode.AddNew;
        }
        private clsRole(int roleID, string roleName, long permissions, string description, bool isActive, DateTime addedAt, int addedByUserID)
        {
            RoleID = roleID;
            RoleName = roleName;
            Permissions = permissions;
            Description = description;
            IsActive = isActive;
            AddedAt = addedAt;
            AddedByUserID = addedByUserID;
            _Mode = enMode.Update;
        }

        public static clsRole Find(int roleID)
        {
            string roleName = string.Empty;
            long permissions = 0;
            string description = string.Empty;
            bool isActive = false;
            DateTime addedAt = DateTime.Now;
            int addedByUserID = -1;
            bool found = clsRolesDataAccess.Find(roleID, ref roleName, ref permissions, ref isActive, ref description, ref addedAt,ref addedByUserID);
            if (found)
            {
                return new clsRole(roleID, roleName, permissions, description, isActive, addedAt, addedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static clsRole Find(string roleName)
        {
            int roleID = -1;
            long permissions = 0;
            string description = string.Empty;
            bool isActive = false;
            DateTime addedAt = DateTime.Now;
            int addedByUserID = -1;
            bool found = clsRolesDataAccess.Find(roleName, ref roleID, ref permissions, ref isActive, ref description,ref addedAt,ref addedByUserID);
            if (found)
            {
                return new clsRole(roleID, roleName, permissions, description, isActive, addedAt, addedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddRole()
        {
            return (this.RoleID = clsRolesDataAccess.AddNewRole(RoleName, Permissions, Description, IsActive, AddedAt, AddedByUserID)) != -1;
        }
        private bool _UpdateRole()
        {
            return clsRolesDataAccess.Update(RoleID, RoleName, Permissions, Description, IsActive);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddRole())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateRole();
                default:
                    return false;
            }
        }
        
        public static DataTable ListRoles()
        {
            return clsRolesDataAccess.GetRoles();
        }
        

    }
}
