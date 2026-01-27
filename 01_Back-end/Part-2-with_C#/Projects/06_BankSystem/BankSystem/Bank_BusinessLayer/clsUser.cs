using Bank_DataAccess;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer
{
    public class clsUser
    {
        public int UserID { get; private set; }
        public int PersonID {  get; set; }
        public clsPerson PersonalInfo { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get;  set; }
        public int RoleID { get; set; }
        public clsRole Role { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public ulong CustomPermissions { get; set; }
        public ulong RevokedPermissions { get; set; }
        public ulong EffectivePermissions { get; set; }
        enum enMode { enAddNew, enUpdate}
        enMode _Mode = enMode.enAddNew;
       
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
            int CreatedByUserID, ulong CustomPermissions,ulong RevokedPermissions)
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

        
        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this.CreatedDate, this.RoleID, this.Password, this.IsActive, this.CreatedByUserID, this.CustomPermissions,this.RevokedPermissions);

            return this.UserID != -1;
        }
        private bool _Update()
        {
            return clsUserDataAccess.Update(this.UserID, this.UserName, this.Password,this.RoleID, this.IsActive,this.CustomPermissions,this.RevokedPermissions);
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
            bool IsActive = false ;
            int CreatedByUserID = -1;
            ulong CustomPermissions = 0;
            ulong RevokedPermissions = 0;
            if(clsUserDataAccess.FindUserByID(UserID,ref PersonID,ref UserName,ref CreatedDate,ref RoleID,ref Password,ref IsActive,ref CreatedByUserID,ref CustomPermissions,ref RevokedPermissions ))
            {
                return new clsUser(UserID,PersonID,UserName,CreatedDate,RoleID,Password,IsActive,CreatedByUserID,CustomPermissions,RevokedPermissions);
            }else
                return null;
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
            ulong CustomPermissions =0;
            ulong RevokedPermissions =0;
            if (clsUserDataAccess.FindUserByPersonID(PersonID, ref UserID, ref UserName, ref CreatedDate, ref RoleID, ref Password, ref IsActive, ref CreatedByUserID,ref CustomPermissions,ref RevokedPermissions))
            {
                return new clsUser(UserID, PersonID, UserName, CreatedDate, RoleID, Password, IsActive, CreatedByUserID, CustomPermissions, RevokedPermissions);
            }
            else
                return null;
        }
        public static clsUser FindUserByName(string UserName)
        {

            int PersonID = -1;
            int UserID  = -1;
            DateTime CreatedDate = DateTime.MinValue;
            int RoleID =-1;
            string Password = "";
            bool IsActive = false;
            int CreatedByUserID = -1;
            ulong CustomPermissions = 0;
            ulong RevokedPermissions = 0;
            if (clsUserDataAccess.FindUserByName(UserName,ref  UserID,ref PersonID, ref CreatedDate, ref RoleID, ref Password, ref IsActive, ref CreatedByUserID,ref CustomPermissions,ref RevokedPermissions))
            {
                return new clsUser(UserID, PersonID, UserName, CreatedDate, RoleID, Password, IsActive, CreatedByUserID, CustomPermissions, RevokedPermissions);
            }
            else
                return null;
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
            return clsUserDataAccess.UpdateUserName(UserID, UserName);
        }
        public static bool UpdateUsePassword(int UserID, string Password)
        {
            return clsUserDataAccess.UpdateUsePassword(UserID, Password);
        }
        public static bool UpdateUserRole(int UserID, int RoleID)
        {
            return clsUserDataAccess.UpdateUserRole(UserID, RoleID);
        }
        public static bool UpdateUserStatus(int UserID, bool IsActive)
        {
            return clsUserDataAccess.UpdateUserStatus(UserID, IsActive);
        }
        public static bool UpdateUserPermissions(int UserID, ulong CustomPermissions,ulong RevokedPermissions)
        {
            return clsUserDataAccess.UpdateUserPermissions(UserID, CustomPermissions, RevokedPermissions);
        }

        public static bool ExistByID(int UserID)
        {   
            return clsUserDataAccess.ExistsByID(UserID);
        }
        public static bool ExistByPersonID(int PersonID)
        {
            return clsUserDataAccess.ExistsByPersonID(PersonID);
        }
        public static bool ExistByUserName(string UserName)
        {
            return clsUserDataAccess.ExistsByUserName(UserName);
        }        
        public bool HasPermission(clsRole.enPermissions permission)
        {
            return (this.EffectivePermissions & (ulong)permission) == (ulong)permission;
        }    
        public static bool Delete(int UserID, int DeletedByUserID)
        {
            return clsUserDataAccess.Delete(UserID, DeletedByUserID);
        }
        public static bool IsUserActive(int UserID)
        {
            return clsUserDataAccess.IsActive(UserID);
        }
        public static DataTable FilterUsers
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
            return FilterUsers(null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByUserID(int userID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterUsers(userID, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByPersonID(int personID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterUsers(null, personID, null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByStatus(bool isActive, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterUsers(null, null, null, isActive, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByCreatedBy(int createdByUserID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterUsers(null, null, createdByUserID, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByUserName(string userName, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterUsers(null, null, null, null, userName, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByRoleName(string roleName, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterUsers(null, null, null, null, null, roleName, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterUsers
        (
            string column,
            string term,
            byte pageNumber,
            byte pageSize,
            out short availablePages
        )
        {
            column = column?.Trim().ToLower();
            term = term?.Trim();

            switch (column)
            {
                case "userid":
                    return FilterByUserID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "personid":
                    return FilterByPersonID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "status":
                case "isactive":
                    return FilterByStatus(bool.Parse(term), pageNumber, pageSize, out availablePages);

                case "createdby":
                case "createdbyuserid":
                    return FilterByCreatedBy(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "username":
                    return FilterByUserName(term, pageNumber, pageSize, out availablePages);

                case "rolename":
                    return FilterByRoleName(term, pageNumber, pageSize, out availablePages);

                default:
                    return ListAll(pageNumber, pageSize, out availablePages);
            }
        }

    }
}
