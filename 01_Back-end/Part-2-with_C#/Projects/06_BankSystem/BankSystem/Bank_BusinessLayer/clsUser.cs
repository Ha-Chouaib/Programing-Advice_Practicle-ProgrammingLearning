using Bank_BusinessLayer.Reports;
using Bank_DataAccess;
using BankSystem;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;
using static System.Collections.Specialized.BitVector32;

namespace Bank_BusinessLayer
{
    public class clsUser
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class AuditIgnoreAttribute : Attribute { }

        public int UserID { get; private set; }
        public int PersonID { get; set; }

        [AuditIgnore]
        public clsPerson PersonalInfo { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RoleID { get; set; }

        [AuditIgnore]
        public clsRole Role { get; set; }

        [AuditIgnore]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public ulong CustomPermissions { get; set; }
        public ulong RevokedPermissions { get; set; }
        public ulong EffectivePermissions { get; set; }
        enum enMode { enAddNew, enUpdate }
        enMode _Mode = enMode.enAddNew;
        
        [AuditIgnore]
        private static string _SectionKey => "USER";
        
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.CreatedDate = DateTime.MinValue;
            this.RoleID = -1;
            //set Role class later
            this.Password = string.Empty;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.EffectivePermissions = 0;
            this.CustomPermissions = 0;
            this.RevokedPermissions = 0;
            _Mode = enMode.enAddNew;
        }
        private clsUser(int UserID, int PersonID, string UserName, DateTime CreatedDate, int RoleID, string Password, bool IsActive,
            int CreatedByUserID, ulong CustomPermissions, ulong RevokedPermissions)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.CreatedDate = CreatedDate;
            this.RoleID = RoleID;
            this.Role = clsRole.Find(RoleID);
            this.Password = Password;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.PersonalInfo = clsPerson.Find(PersonID);
            this.CustomPermissions = CustomPermissions;
            this.RevokedPermissions = RevokedPermissions;
            this.EffectivePermissions = (((Role != null) ? Role.IsActive ? Role.Permissions : 0 : 0) | (CustomPermissions)) & ~RevokedPermissions;
            _Mode = enMode.enUpdate;
        }


        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) UserID { get; private set; } = ("ID", "User ID");
            public static (string valueMember, string DisplayMember) CreatedByuserID { get; private set; } = ("CreatedByUserID", "Created By User ID");
            public static (string valueMember, string DisplayMember) PersonID { get; private set; } = ("PersonID", "Person ID");
            public static (string valueMember, string DisplayMember) UserName { get; private set; } = ("UserName", "User Name");
            public static (string valueMember, string DisplayMember) Role { get; private set; } = ("RoleName", "Role");
            public static (string valueMember, string DisplayMember) Status { get; private set; } = ("IsActive", "Status");
        }
        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            public static (string GroupName, Dictionary<string, string> GroupItems) Status
            {
                get
                {
                    return (Filter_Mapping.Status.valueMember,
                        new Dictionary<string, string>
                        {
                    { "All", "All" },
                    { "Active", "true" },
                    { "InActive", "false" }
                        });
                }
            }

            public static (string GroupName, Dictionary<string, string> GroupItems) Roles
            {
                get
                {
                    var roles = new Dictionary<string, string>();

                    foreach (DataRow r in clsRole.ListRoles().Rows)
                    {
                        var roleName = r["RoleName"].ToString();
                        roles[roleName] = roleName;
                    }

                    return (Filter_Mapping.Role.valueMember, roles);
                }
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this.CreatedDate, this.RoleID, this.Password, this.IsActive, this.CreatedByUserID, this.CustomPermissions, this.RevokedPermissions);

            bool OperationSucceed = this.UserID != -1;
            AuditingHelper.AuditCreateOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(this),OperationSucceed ? this.UserID : (int?)null), OperationSucceed,(_SectionKey, "Add New User Record"));

            return OperationSucceed;
        }
        private bool _Update()
        {

            var OldRecord = FindUserByID(this.UserID);
            bool OperationSucceed = clsUserDataAccess.Update(this.UserID, this.UserName, this.Password, this.RoleID, this.IsActive, this.CustomPermissions, this.RevokedPermissions);
            var NewRecord = FindUserByID(this.UserID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update User Record"), changes.Before, changes.After, this.UserID);
            return OperationSucceed;

        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else return false;

                case enMode.enUpdate:
                    return _Update();

                default:
                    return false;
            }
        }

        public static clsUser FindUserByID(int UserID)
        {

            int PersonID = -1;
            string UserName = "";
            DateTime CreatedDate = DateTime.MinValue;
            int RoleID = -1;
            string Password = "";
            bool IsActive = false;
            int CreatedByUserID = -1;
            ulong CustomPermissions = 0;
            ulong RevokedPermissions = 0;

            clsUser _user = null;
            bool _Success = false;

            if (clsUserDataAccess.FindUserByID(UserID, ref PersonID, ref UserName, ref CreatedDate, ref RoleID, ref Password, ref IsActive, ref CreatedByUserID, ref CustomPermissions, ref RevokedPermissions))
            {
                _user = new clsUser(UserID, PersonID, UserName, CreatedDate, RoleID, Password, IsActive, CreatedByUserID, CustomPermissions, RevokedPermissions);
                _Success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_user), UserID), _Success, (_SectionKey, $"Read user record with UserID: {UserID}"));
            }

            return _user;
        }
        public static clsUser FindUserByPersonID(int PersonID)
        {

            int UserID = -1;
            string UserName = "";
            DateTime CreatedDate = DateTime.MinValue;
            int RoleID = -1;
            string Password = "";
            bool IsActive = false;
            int CreatedByUserID = -1;
            ulong CustomPermissions = 0;
            ulong RevokedPermissions = 0;

            clsUser _User = null;
            bool _Success = false;
            if (clsUserDataAccess.FindUserByPersonID(PersonID, ref UserID, ref UserName, ref CreatedDate, ref RoleID, ref Password, ref IsActive, ref CreatedByUserID, ref CustomPermissions, ref RevokedPermissions))
            {
                _User = new clsUser(UserID, PersonID, UserName, CreatedDate, RoleID, Password, IsActive, CreatedByUserID, CustomPermissions, RevokedPermissions);
                _Success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_User), UserID), _Success, (_SectionKey, $"Read user record with PersonID: {PersonID}"));
            }
            return _User;
        }
        public static clsUser FindUserByName(string UserName)
        {

            int PersonID = -1;
            int UserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            int RoleID = -1;
            string Password = "";
            bool IsActive = false;
            int CreatedByUserID = -1;
            ulong CustomPermissions = 0;
            ulong RevokedPermissions = 0;

            clsUser _user = null;
            bool _success = false;
            if (clsUserDataAccess.FindUserByName(UserName, ref UserID, ref PersonID, ref CreatedDate, ref RoleID, ref Password, ref IsActive, ref CreatedByUserID, ref CustomPermissions, ref RevokedPermissions))
            {
                _user = new clsUser(UserID, PersonID, UserName, CreatedDate, RoleID, Password, IsActive, CreatedByUserID, CustomPermissions, RevokedPermissions);
                _success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_user), UserID), _success, (_SectionKey, $"Read user record with User name: {UserName}"));
            }
            return _user;

        }

        public static clsUser FindBy(string Column, string Trem)
        {
            switch (Column)
            {
                case "UserID":
                    if (int.TryParse(Trem, out int UserID))
                    {
                        return FindUserByID(UserID);
                    }
                    else
                        return null;

                case "PersonID":

                    if (int.TryParse(Trem, out int PersonID))
                    {
                        return FindUserByPersonID(PersonID);
                    }
                    else
                        return null;

                case "UserName":
                    return FindUserByName(Trem);
                default:
                    return null;

            }
        }

        public static bool UpdateUserName(int UserID, string UserName)
        {
            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserName(UserID, UserName);
            var NewRecord = FindUserByID(UserID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update User Name Only"), changes.Before, changes.After, UserID);
            return OperationSucceed;
        }
        public static bool UpdateUsePassword(int UserID, string Password)
        {
            bool OperationSucceed = clsUserDataAccess.UpdateUsePassword(UserID, Password);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update password Only"), null, null, UserID);
            return OperationSucceed;
        }
        public static bool UpdateUserRole(int UserID, int RoleID)
        {
            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserRole(UserID, RoleID);
            var NewRecord = FindUserByID(UserID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update User Role Only"), changes.Before, changes.After, UserID);
            return OperationSucceed;
        }
        public static bool UpdateUserStatus(int UserID, bool IsActive)
        {

            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserStatus(UserID, IsActive);
            var NewRecord = FindUserByID(UserID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update User Status Only"), changes.Before, changes.After, UserID);
            return OperationSucceed;
        }
        public static bool UpdateUserPermissions(int UserID, ulong CustomPermissions, ulong RevokedPermissions)
        {


            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserPermissions(UserID, CustomPermissions, RevokedPermissions);
            var NewRecord = FindUserByID(UserID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update User Permissions Only"), changes.Before, changes.After, UserID);
            return OperationSucceed;
        }

        public static bool ExistByID(int UserID)
        {
            bool found = clsUserDataAccess.ExistsByID(UserID);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var user = FindUserByID(UserID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(user);
                AuditingHelper.AuditValidationOperation((target,UserID),found,(_SectionKey, $"Check existance of user record with UserID: {UserID}"));
            }
            return found;
        }
        public static bool ExistByPersonID(int PersonID)
        {
            bool found = clsUserDataAccess.ExistsByPersonID(PersonID);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var user = FindUserByPersonID(PersonID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(user);
                AuditingHelper.AuditValidationOperation((target, user.UserID), found, (_SectionKey, $"Check existance of user record with PersonID: {PersonID}"));
            }
            return found;
        }
        public static bool ExistByUserName(string UserName)
        {
            bool found = clsUserDataAccess.ExistsByUserName(UserName);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var user = FindUserByName(UserName);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(user);
                AuditingHelper.AuditValidationOperation((target, user.UserID), found, (_SectionKey, $"Check existance of user record with User name: {UserName}"));
            }
            return found;
        }
        public bool HasPermission(clsRole.enPermissions permission)
        {
            bool hasPerm = (this.EffectivePermissions & (ulong)permission) == (ulong)permission;
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(this);
                AuditingHelper.AuditValidationOperation((target, this.UserID), hasPerm, (_SectionKey, $"Check if the User with ID {this.UserID} Has Necessary Permissions?"));
            }
          
            return hasPerm;
        }
        public static bool Delete(int UserID, int DeletedByUserID)
        {
            clsUser DeletedRecord = FindUserByID(UserID);
            bool deleted = clsUserDataAccess.Delete(UserID, DeletedByUserID);
            AuditingHelper.AuditDeletionOperation((DeletedRecord, UserID), deleted, (_SectionKey, $"Delete User Record with id < {UserID} >"));
            return deleted;
        }
        public static bool IsUserActive(int UserID)
        {
            bool active = clsUserDataAccess.IsActive(UserID);

            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var user = FindUserByID(UserID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(user);
                AuditingHelper.AuditValidationOperation((target, UserID), active, (_SectionKey, $"Check status for the user with UserID: {UserID}"));
            }
            return active;
        }
        private static DataTable FilterUsers
        (
            int? userID,
            int? personID,
            int? createdByUserID,
            bool? isActive,
            string userName,
            string roleName,
            byte pageNumber,
            byte pageSize,
            out short availablePages
        )
        {
            int totalRows = 0;

            DataTable dt = clsUserDataAccess.FilterUsers
            (
                userID,
                personID,
                createdByUserID,
                isActive,
                userName,
                roleName,
                pageNumber,
                pageSize,
                out totalRows
            );

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "List All User Records"));
            return dt;
        }
        public static DataTable FilterByUserID(int userID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(userID, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "Filter User Records By UserID"));

            return dt;
        }
        public static DataTable FilterByPersonID(int personID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, personID, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "Filter User Records By PersonID"));

            return dt;
        }
        public static DataTable FilterByStatus(bool isActive, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, null, isActive, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "Filter User Records By Status"));

            return dt;
        }
        public static DataTable FilterByCreatedBy(int createdByUserID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, createdByUserID, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "Filter User Recods By Created by any User using <ID>"));
            return dt;
        }
        public static DataTable FilterByUserName(string userName, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, null, null, userName, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "Filter User Records By User name"));
            return dt;
        }
        public static DataTable FilterByRoleName(string roleName, byte pageNumber, byte pageSize, out short availablePages)
        {
            ;
            DataTable dt = FilterUsers(null, null, null, null, null, roleName, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "Filter User Records By Role name"));

            return dt;
        }

        // Delegate for generic filtering
        private delegate DataTable FilterDelegate(string term, byte pageNumber, byte pageSize, out short availablePages);


        // Lazy-loaded filter actions dictionary
        private static Dictionary<string, FilterDelegate> _filterActions;
        private static Dictionary<string, FilterDelegate> _FilterActions
        {
            get
            {
                if (_filterActions == null)
                {
                    _filterActions = new Dictionary<string, FilterDelegate>
                {
                    {
                        Filter_Mapping.UserID.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            int.TryParse(term, out int id) ? FilterByUserID(id, page, size, out pages) : ListAll(page, size, out pages)
                    },

                    {
                        Filter_Mapping.PersonID.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            int.TryParse(term, out int id) ? FilterByPersonID(id, page, size, out pages) : ListAll(page, size, out pages)
                    },

                    {
                        Filter_Mapping.Status.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            bool.TryParse(term, out bool status) ? FilterByStatus(status, page, size, out pages) : ListAll(page, size, out pages)
                    },

                    {
                        Filter_Mapping.CreatedByuserID.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            int.TryParse(term, out int id) ? FilterByCreatedBy(id, page, size, out pages) : ListAll(page, size, out pages)
                    },

                    {
                        Filter_Mapping.UserName.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            FilterByUserName(term, page, size, out pages)
                    },

                    {
                        Filter_Mapping.Role.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            FilterByRoleName(term, page, size, out pages)
                    },

                    {
                        Filter_Mapping.All.valueMember,
                        (string term, byte page, byte size, out short pages) =>
                            ListAll(page, size, out pages)
                    }
                };
                }

                return _filterActions;
            }
        }

        public static DataTable FilterUsers(string column, string term, byte pageNumber, byte pageSize, out short availablePages)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate action))
                return action(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }

        }
}
