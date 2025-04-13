using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsPeople
    {
        enum enMode { eAddNew,eUpdate}
        enMode _Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        clsPeople(string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            _Mode = enMode.eUpdate;
        }
        clsPeople()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender =3;
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";

            _Mode = enMode.eUpdate;

        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleDataAccess.AddNew(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                        this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.Update(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                        this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPeople Find(int PersonID)
        {
            string  NationalNo = "",
                    FirstName = "",
                    SecondName = "",
                    ThirdName = "",
                    LastName = "",
                    Address = "",
                    Email = "",
                    Phone = "",
                    ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender =3;
            int NationalityCountryID = -1;
            if (clsPeopleDataAccess.Find(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                        ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,Address,Phone,
                                    Email,NationalityCountryID,ImagePath);
            }
            else
            {
                return null;
            }
              



        }

        public static clsPeople Find(string NationalNo)
        {
            int PersonID=-1;
            string FirstName = "",
                    SecondName = "",
                    ThirdName = "",
                    LastName = "",
                    Address = "",
                    Email = "",
                    Phone = "",
                    ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 3;
            int NationalityCountryID = -1;
            if (clsPeopleDataAccess.Find(NationalNo, ref PersonID,ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                        ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeople(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone,
                                    Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }




        }

        public static bool IsExist(int PersonID)
        {
            return clsPeopleDataAccess.IsExist(PersonID);
        }
        public static bool IsExist(string NationalN)
        {
            return clsPeopleDataAccess.IsExist(NationalN);
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
                    }
                    else
                    {
                        return false;
                    }
                case enMode.eUpdate:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);
        }
        public static DataTable ListAll()
        {
            return clsPeopleDataAccess.ListAll();
        }
        public static DataTable FilterPeople(string Column,string FilterTerm)
        {
            return clsPeopleDataAccess.FilterPeople(Column, FilterTerm);
        }
        public static DataTable FilterPeople(int NationalityCountryID)
        {
            return clsPeopleDataAccess.FilterPeople(NationalityCountryID);
        }
    }
}
