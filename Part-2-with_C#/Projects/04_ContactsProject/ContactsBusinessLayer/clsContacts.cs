using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public  class clsContacts
    {   
        enum enMode { enAddNew=0, enUpdate=1}
        enMode Mode ;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfbirth { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsContacts(int ID, string FirstName, string LastName, string Email, string Phone, string Address,
                            DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfbirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.enUpdate;

        }

        public  clsContacts()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfbirth = DateTime.Now;
            this.CountryID = 0;
            this.ImagePath = "";

            Mode = enMode.enAddNew;
        }

        private bool _AddNewContact()
        {
            this.ID = clsCotactsDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                                                        this.DateOfbirth, this.CountryID, this.ImagePath);
            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsCotactsDataAccess.UpdateContact(this.ID,this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                                                        this.DateOfbirth, this.CountryID, this.ImagePath);
        }

        public static clsContacts Find(int ID)
        {
            string FirstName="", LastName="", Email="", Phone="", Address="", ImagePath="";
            DateTime DateOfBirth = DateTime.Now ;
            int CountryID = 0;
            if ( clsCotactsDataAccess.Find(ID, ref FirstName, ref LastName, ref Email, ref Phone, ref Address,
                                            ref DateOfBirth,ref CountryID, ref ImagePath ))
                return new clsContacts(ID, FirstName,LastName, Email, Phone,Address,DateOfBirth,CountryID,ImagePath);
            else
                return null;

        }
        public bool Save()
        {
            switch(Mode)
            {  
                case enMode.enAddNew:
                if (_AddNewContact())
                {
                    Mode = enMode.enUpdate;
                    return true;
                }
                return false;

                    case enMode.enUpdate:
                return _UpdateContact();

                default:
                     return  false;

            }
                


        }

        public static bool ISExist(int ID)
        {
            return clsCotactsDataAccess.IsExist(ID);
        }
        
        public static bool DeleteContact(int ID)
        {
            return clsCotactsDataAccess.DeleteContact(ID);
        }
        public static DataTable GetAllContacts()
        {
            return clsCotactsDataAccess.GetAllContacts();
        }
       public static DataTable ListContactsByFirstLast_Name(string SearchTerm)
        {
            return clsCotactsDataAccess.FindByFirstLast_Name(SearchTerm);
        }
    }
}
