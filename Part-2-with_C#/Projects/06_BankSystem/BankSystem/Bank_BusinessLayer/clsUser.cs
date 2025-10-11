using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string Role { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }

        enum enMode { enAddNew, enUpdate}
        enMode _Mode = enMode.enAddNew;
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = string.Empty;
            this.CreatedDate = DateTime.MinValue;
            this.Role = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            _Mode = enMode.enAddNew;
        }

        private clsUser(int UserID,int PersonID,string UserName,DateTime CreatedDate, string Role, string Password,bool IsActive,int CreatedByUserID)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.CreatedDate = CreatedDate;
            this.Role = Role;
            this.Password = Password;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.PersonalInfo = clsPerson.Find(PersonID);
            //this.CreatedByUser = clsUser.Find(UserID);

            _Mode = enMode.enUpdate;
        }

        public bool AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.UserName, this.CreatedDate, this.Role, this.Password, this.IsActive, this.CreatedByUserID);

            return this.UserID != -1;
        }
        public static clsUser FindUserByID(int UserID)
        {
            
            int PersonID = -1;
            string UserName = "";
            DateTime CreatedDate = DateTime.MinValue;
            string Role = "";
            string Password = "";
            bool IsActive = false ;
            int CreatedByUserID = -1;
            if(clsUserDataAccess.FindUserByID(UserID,ref PersonID,ref UserName,ref CreatedDate,ref Role,ref Password,ref IsActive,ref CreatedByUserID))
            {
                return new clsUser(UserID,PersonID,UserName,CreatedDate,Role,Password,IsActive,CreatedByUserID);
            }else
                return null;
        }
        public static clsUser FindUserByPersonID(int PersonID)
        {

            int UserID = -1;
            string UserName = "";
            DateTime CreatedDate = DateTime.MinValue;
            string Role = "";
            string Password = "";
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsUserDataAccess.FindUserByPersonID(PersonID, ref UserID, ref UserName, ref CreatedDate, ref Role, ref Password, ref IsActive, ref CreatedByUserID))
            {
                return new clsUser(UserID, PersonID, UserName, CreatedDate, Role, Password, IsActive, CreatedByUserID);
            }
            else
                return null;
        }
        public static clsUser FindUserByName(string UserName)
        {

            int PersonID = -1;
            int UserID  = -1;
            DateTime CreatedDate = DateTime.MinValue;
            string Role = "";
            string Password = "";
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsUserDataAccess.FindUserByName(UserName,ref  UserID,ref PersonID, ref CreatedDate, ref Role, ref Password, ref IsActive, ref CreatedByUserID))
            {
                return new clsUser(UserID, PersonID, UserName, CreatedDate, Role, Password, IsActive, CreatedByUserID);
            }
            else
                return null;
        }

        public static bool UpdateUserName(int UserID, string UserName) 
        {
            return clsUserDataAccess.UpdateUserName(UserID, UserName);
        }
        public static bool UpdateUsePassword(int UserID, string Password)
        {
            return clsUserDataAccess.UpdateUsePassword(UserID, Password);
        }
        public static bool UpdateUserRole(int UserID, string Role)
        {
            return clsUserDataAccess.UpdateUserRole(UserID, Role);
        }
        public static bool UpdateUserState(int UserID, bool IsActive)
        {
            return clsUserDataAccess.UpdateUserState(UserID, IsActive);
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
        
        public static bool Delete(int UserID)
        {
            return clsUserDataAccess.Delete(UserID);
        }
        public static bool IsUserActive(int UserID)
        {
            return clsUserDataAccess.IsActive(UserID);
        }
        public static DataTable GetUsers()
        {
            return clsUserDataAccess.ListAllUsers();
        }

    }
}
