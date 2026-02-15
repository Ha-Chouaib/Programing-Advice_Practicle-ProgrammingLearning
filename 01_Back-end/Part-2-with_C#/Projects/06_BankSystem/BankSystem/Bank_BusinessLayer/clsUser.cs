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
        public class ActionKeys
        {
            public const string User_Addition = "USER.ADD-NEW";
            public const string User_Editing = "USER.UPDATE";
            public const string User_Deletion = "USER.DELETE";
            public const string User_ReadRecord = "USER.READ_RECORD";
            public const string User_ReadRecordsList = "USER_READ_RECORDS-LIST";
            public const string User_Validation = "USER.VALIDATION_CHECK-USER-EXISTANCE";
        }
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
            _AuditAdditinOperation(this, OperationSucceed, "Add New User Record");
            return OperationSucceed;
        }
        private bool _Update()
        {

            var OldRecord = FindUserByID(this.UserID);
            bool OperationSucceed = clsUserDataAccess.Update(this.UserID, this.UserName, this.Password, this.RoleID, this.IsActive, this.CustomPermissions, this.RevokedPermissions);
            var NewRecord = FindUserByID(this.UserID);

            _AuditUpdateOperation(OperationSucceed, "Update User Record", OldRecord, NewRecord);
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
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditReadRecordOperation(_user, _Success, $"Read user record with UserID: {UserID}");
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
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditReadRecordOperation(_User, _Success, $"Read user record with PersonID: {PersonID}");
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
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditReadRecordOperation(_user, _success, $"Read user record with UserName: {UserName}");
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

            _AuditUpdateOperation(OperationSucceed, "Update User Name Only", OldRecord, NewRecord);
            return OperationSucceed;
        }
        public static bool UpdateUsePassword(int UserID, string Password)
        {
            bool OperationSucceed = clsUserDataAccess.UpdateUsePassword(UserID, Password);

            _AuditUpdateOperation(OperationSucceed, "Update Password Only", null, null);
            return OperationSucceed;
        }
        public static bool UpdateUserRole(int UserID, int RoleID)
        {
            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserRole(UserID, RoleID);
            var NewRecord = FindUserByID(UserID);

            _AuditUpdateOperation(OperationSucceed, "Update User Role Only", OldRecord, NewRecord);
            return OperationSucceed;

        }
        public static bool UpdateUserStatus(int UserID, bool IsActive)
        {

            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserStatus(UserID, IsActive);
            var NewRecord = FindUserByID(UserID);

            _AuditUpdateOperation(OperationSucceed, "Update User Status Only", OldRecord, NewRecord);
            return OperationSucceed;
        }
        public static bool UpdateUserPermissions(int UserID, ulong CustomPermissions, ulong RevokedPermissions)
        {


            var OldRecord = FindUserByID(UserID);
            bool OperationSucceed = clsUserDataAccess.UpdateUserPermissions(UserID, CustomPermissions, RevokedPermissions);
            var NewRecord = FindUserByID(UserID);

            _AuditUpdateOperation(OperationSucceed, "Update User Permissions Only", OldRecord, NewRecord);
            return OperationSucceed;
        }

        public static bool ExistByID(int UserID)
        {
            bool found = clsUserDataAccess.ExistsByID(UserID);
            if(clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditValidationOperation(found, $"Check existance of user record with UserID: {UserID}");
            }
            return found;
        }
        public static bool ExistByPersonID(int PersonID)
        {
            bool found = clsUserDataAccess.ExistsByPersonID(PersonID);
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditValidationOperation(found, $"Check existance of user record with PersonID: {PersonID}");
            }
            return found;
        }
        public static bool ExistByUserName(string UserName)
        {
            bool found = clsUserDataAccess.ExistsByUserName(UserName);
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditValidationOperation(found, $"Check existance of user record with User Name: {UserName}");
            }
            return found;
        }
        public bool HasPermission(clsRole.enPermissions permission)
        {
            bool hasPerm = (this.EffectivePermissions & (ulong)permission) == (ulong)permission;
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditValidationOperation(hasPerm, $"Check if the User with ID {this.UserID} Has Necessary Permissions?");
            }
            return hasPerm;
        }
        public static bool Delete(int UserID, int DeletedByUserID)
        {
            clsUser DeletedRecord = FindUserByID(UserID);
            bool deleted = clsUserDataAccess.Delete(UserID, DeletedByUserID);
            _AuditDeletionOperation(deleted, $"Delete User Record with id < {UserID} >", DeletedRecord);

            return deleted;
        }
        public static bool IsUserActive(int UserID)
        {
            bool active = clsUserDataAccess.IsActive(UserID);
            if (clsUtil_BL.IsExternalCall(typeof(clsUser)))
            {
                _AuditValidationOperation(active, $"Check the user status");
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
            _AuditReadRecordsListOperation(OperationSucceed, "List All User Records");
            return dt;
        }
        public static DataTable FilterByUserID(int userID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(userID, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            _AuditReadRecordsListOperation(OperationSucceed, "Filter User Records By UserID");
            return dt;
        }
        public static DataTable FilterByPersonID(int personID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, personID, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            _AuditReadRecordsListOperation(OperationSucceed, "Filter User Records By PersonID");
            return dt;
        }
        public static DataTable FilterByStatus(bool isActive, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, null, isActive, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            _AuditReadRecordsListOperation(OperationSucceed, "Filter User Records By Status");
            return dt;
        }
        public static DataTable FilterByCreatedBy(int createdByUserID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, createdByUserID, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            _AuditReadRecordsListOperation(OperationSucceed, "Filter User Recods By Created by any User using <ID>");
            return dt;
        }
        public static DataTable FilterByUserName(string userName, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterUsers(null, null, null, null, userName, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            _AuditReadRecordsListOperation(OperationSucceed, "Filter User Recods By Created by User Name");
            return dt;
        }
        public static DataTable FilterByRoleName(string roleName, byte pageNumber, byte pageSize, out short availablePages)
        {
            ;
            DataTable dt = FilterUsers(null, null, null, null, null, roleName, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            _AuditReadRecordsListOperation(OperationSucceed, "Filter User Recods By Created by Role Name");
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

        static void _AuditUserActivity(AuditAction action, clsUser TargetEntity, AuditChanges Changes, AuditResult auditResult)
        {
            var LoggedInUser = clsGlobal_BL.LoggedInUser;

            var PerformedByUser = new AuditPerformedBy();
            PerformedByUser.UserID = LoggedInUser.UserID;
            PerformedByUser.UserName = LoggedInUser.UserName;
            PerformedByUser.Role = LoggedInUser.Role.RoleName;

            var MachineInfo = new AuditMachineInfo();
            MachineInfo.MachineName = clsGlobal_BL.MachineInfo.GetMachineName();
            MachineInfo.OSVersion = clsGlobal_BL.MachineInfo.GetOSVersion();
            MachineInfo.IPAddress = clsGlobal_BL.MachineInfo.GetLocalIPAddress();
            MachineInfo.SessionID = clsGlobal_BL.UserSession.SessionID;

            var targetEntity = new AuditTargetEntity();
            if (TargetEntity != null)
            {
                targetEntity.EntityID = TargetEntity.UserID;
                targetEntity.EntityName = TargetEntity.UserName;
            }
            else
            {
                targetEntity = null;
                targetEntity.EntityID = null;
            }



            var AuditContext = new AuditContext(PerformedByUser, action, targetEntity, Changes, auditResult, MachineInfo, 1);
            clsAuditUserActions.AuditLogger(LoggedInUser.UserID, ActionKeys.User_Addition, targetEntity.EntityID, auditResult.Success, AuditContext);

        }
        static void _AuditAdditinOperation(clsUser TargetEntity, bool OperationSucceed, string SectionDescription)
        {
            var action = new clsAuditUserActions.AuditAction();
            action.ActionKey = ActionKeys.User_Addition;
            action.Description = SectionDescription;

            var auditResult = new clsAuditUserActions.AuditResult();
            if (OperationSucceed)
            {
                auditResult.Success = true;
            }
            else
            {
                auditResult.Success = false;
                auditResult.ErrorMessage = "Failed to add new user record.";
            }

            _AuditUserActivity(action, TargetEntity, null, auditResult);


        }
        static void _AuditUpdateOperation(bool OperationSucceed, string SectionDescription, object oldRecord, object NewRecord)
        {
            var action = new clsAuditUserActions.AuditAction();
            var auditResult = new clsAuditUserActions.AuditResult();
            var auditchanges = new clsAuditUserActions.AuditChanges();

            action.ActionKey = ActionKeys.User_Editing;
            action.Description = SectionDescription;

            if (OperationSucceed)
            {
                var changes = clsAuditUserActions.AuditChanges.Compare(oldRecord, NewRecord);
                auditchanges.Before = changes.Before;
                auditchanges.After = changes.After;

                auditResult.Success = true;
            }
            else
            {
                auditResult.Success = false;
                auditResult.ErrorMessage = "Failed to update user record.";
            }
            _AuditUserActivity(action, NewRecord as clsUser, auditchanges, auditResult);
        }
        static void _AuditReadRecordOperation(clsUser target, bool OperationSucceed, string SectionDescription)
        {
            var action = new clsAuditUserActions.AuditAction();
            var auditResult = new clsAuditUserActions.AuditResult();
            action.ActionKey = ActionKeys.User_ReadRecord;
            action.Description = SectionDescription;

            if (OperationSucceed)
            {
                auditResult.Success = true;
            }
            else
            {
                auditResult.Success = false;
                auditResult.ErrorMessage = "Failed to read user record.";
            }
            _AuditUserActivity(action, target, null, auditResult);
        }
        static void _AuditReadRecordsListOperation(bool OperationSucceed, string SectionDescription)
        {
            var action = new clsAuditUserActions.AuditAction();
            var auditResult = new clsAuditUserActions.AuditResult();
            action.ActionKey = ActionKeys.User_ReadRecordsList;
            action.Description = SectionDescription;
            if (OperationSucceed)
            {
                auditResult.Success = true;
            }
            else
            {
                auditResult.Success = false;
                auditResult.ErrorMessage = "Failed to read user records list.";
            }
            _AuditUserActivity(action, null, null, auditResult);

        }
        static void _AuditValidationOperation(bool OperationSucceed, string SectionDescription)
        {
            var action = new clsAuditUserActions.AuditAction();
            var auditResult = new clsAuditUserActions.AuditResult();
            action.ActionKey = ActionKeys.User_Validation;
            action.Description = SectionDescription;
            if (OperationSucceed)
            {
                auditResult.Success = true;
            }
            else
            {
                auditResult.Success = false;
                auditResult.ErrorMessage = $"Negative Result";
            }
            _AuditUserActivity(action, null, null, auditResult);
        }
        static void _AuditDeletionOperation(bool OperationSucceed, string SectionDescription, object DeletedRecord)
        {
            var action = new clsAuditUserActions.AuditAction();
            var auditResult = new clsAuditUserActions.AuditResult();
            var auditchanges = new clsAuditUserActions.AuditChanges();
            action.ActionKey = ActionKeys.User_Deletion;
            action.Description = SectionDescription;
            if (OperationSucceed)
            {
                var changes = clsAuditUserActions.AuditChanges.Compare(DeletedRecord, null);
                auditchanges.Before = changes.Before;
                auditchanges.After = null;
                auditResult.Success = true;
            }
            else
            {
                auditResult.Success = false;
                auditResult.ErrorMessage = "Failed to delete user record.";
            }
            _AuditUserActivity(action, DeletedRecord as clsUser, auditchanges, auditResult);
        }   
    }
}
