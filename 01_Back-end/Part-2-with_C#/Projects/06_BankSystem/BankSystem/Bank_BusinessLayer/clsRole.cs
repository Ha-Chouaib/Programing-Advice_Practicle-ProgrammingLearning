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
        public ulong Permissions { get; set; }
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
        public enum enPermissions : ulong
        {
            None = 0,

            // ===== People =====
            People_View = 1UL << 0,
            People_Manage = 1UL << 1,
            People_Add = 1UL << 2,
            People_Edit = 1UL << 3,
            People_Find = 1UL << 4,

            // ===== Customers =====
            Customers_View = 1UL << 5,
            Customers_Manage = 1UL << 6,
            Customers_Add = 1UL << 7,
            Customers_Edit = 1UL << 8,
            Customers_Find = 1UL << 9,
            Customers_Accounts = 1UL << 10,

            // ===== Accounts =====
            Accounts_View = 1UL << 11,
            Accounts_Manage = 1UL << 12,
            Accounts_Add = 1UL << 13,
            Accounts_Find = 1UL << 14,

            // ===== Users =====
            Users_View = 1UL << 15,
            Users_Manage = 1UL << 16,
            Users_AddEdit = 1UL << 17,
            Users_ChangePassword = 1UL << 18,
            Users_Find = 1UL << 19,

            // ===== Transactions =====
            Transactions_View = 1UL << 20,
            Transactions_Deposit = 1UL << 21,
            Transactions_Withdraw = 1UL << 22,
            Transactions_Transfer = 1UL << 23,
            Transactions_History = 1UL << 24,

            // ===== Reports =====
            Reports_View = 1UL << 25,
            Reports_Customer = 1UL << 26,
            Reports_Transaction = 1UL << 27,
            Reports_UserActivity = 1UL << 28,
            Reports_SystemLogs = 1UL << 29,

            All = (1UL << 30) - 1

        }
        public static Dictionary<string, ulong> GetPermissionsList()
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
        public clsRole(int roleID, string roleName, ulong permissions, string description, bool isActive, DateTime addedAt, int addedByUserID)
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
            ulong permissions = 0;
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
            ulong permissions = 0;
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
