using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bank_DataAccess;
using Bank_DataAccess.People;

namespace Bank_BusinessLayer
{
    public class clsPerson
    {
        enum enMode { eAddNew, eUpdate }
        enMode _Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName;
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public short CountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPerson(int PersonID, string NationalNo, string FirstName,  string LastName, DateTime DateOfBirth, byte Gender,
                                    string Email, string Phone, short CountryID, string Address,  string ImgPath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            this.FullName = FirstName + " " + LastName;
            _Mode = enMode.eUpdate;
        }
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";            
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 3;
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.CountryID = -1;
            this.ImagePath = "";
          
            _Mode = enMode.eAddNew;

        }

        public static clsPerson FindByPersonID(int PersonID)
        {
            string NationalNo = "",
                    FirstName = "",
                    LastName = "",
                    Address = "",
                    Email = "",
                    Phone = "",
                    ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 3;
            short CountryID = -1;
            if (clsPersonDataAccess.FindPersonByID(PersonID, ref  NationalNo, ref  FirstName, ref  LastName, ref  DateOfBirth, ref  Gender,
                                    ref  Email, ref  Phone, ref  CountryID, ref  Address, ref ImagePath))
            {
                return new clsPerson(PersonID,  NationalNo,  FirstName,  LastName,  DateOfBirth, Gender,
                                     Email,  Phone,  CountryID,  Address, ImagePath);
            }
            else
            {
                return null;
            }

        }
    
    
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNo,this.FirstName,this.LastName,this.DateOfBirth,this.Gender,this.Email,
                this.Phone,this.CountryID,this.Address,this.ImagePath);
            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePersonInf(this.PersonID,this.NationalNo, this.FirstName, this.LastName, this.DateOfBirth, this.Gender, this.Email,
                this.Phone, this.CountryID, this.Address, this.ImagePath);
        }
    
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.eAddNew:
                    if(_AddNewPerson())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }else return false;

                case enMode.eUpdate:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }
    
    
    }
}
