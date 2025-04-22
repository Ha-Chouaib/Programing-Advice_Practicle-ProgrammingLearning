using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsUsers
    {
        public int UserID { get; set; } 
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        enum enMode { eAddNew,eUpdate}
        enMode _Mode;
        clsPeople Person;
        public clsUsers(int UserID,int PersonID,string UserName, string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            _Mode = enMode.eUpdate;
        }
        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;

            _Mode = enMode.eAddNew;
        }
        public static clsUsers Find(int UserID)
        {
            int  PersonID=-1; 
            string UserName="", Password="";
            bool IsActive=false;
            if(clsUsersDataAccess.Find(UserID,ref PersonID,ref UserName,ref Password,ref IsActive))
            {
                return new clsUsers(UserID,PersonID,UserName,Password,IsActive);
            }else
            {
                return null;
            }
        }

        public static clsUsers Find(string UserName)
        {
            int PersonID = -1, UserID=-1;
            string Password = "";
            bool IsActive = false;
            if (clsUsersDataAccess.Find(UserName,ref UserID,ref PersonID,ref Password,ref IsActive))
            {
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }
       
        private bool _AddNew()
        {
            this.UserID= clsUsersDataAccess.AddNew(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (UserID != -1);
        
        }
        private bool _Update()
        {
            return clsUsersDataAccess.Update(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.eAddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }
                    else return false;
                case enMode.eUpdate:
                    return _Update();
                default:
                    return false;
            }
        }
    
        public static bool Exist(int UserID)
        {
            return clsUsersDataAccess.Exist(UserID);
        }
        public static DataTable ListAll()
        {
            return clsUsersDataAccess.ListAll();
        }
        public static DataTable FilterBy<T>(string Column, T FilterTerm)
        {
            return clsUsersDataAccess.FilterBy(Column, FilterTerm);
        }
    
        public static bool Delete(int UserID)
        {
            return clsUsersDataAccess.Delete(UserID);
        }
    }
}
