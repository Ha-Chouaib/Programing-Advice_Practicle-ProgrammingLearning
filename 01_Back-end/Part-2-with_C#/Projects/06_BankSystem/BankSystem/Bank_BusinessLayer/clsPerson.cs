using System;
using System.Collections.Generic;
using System.Data;
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
        public int PersonID { get; private set; }
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

        private clsPerson(int PersonID, string NationalNo, string FirstName,  string LastName, DateTime DateOfBirth, byte Gender,
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
            this.ImagePath = ImgPath;
            this.FullName = FirstName + " " + LastName;
            _Mode = enMode.eUpdate;
        }
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";            
            this.LastName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gender = 3;
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.CountryID = -1;
            this.ImagePath = "";
          
            _Mode = enMode.eAddNew;

        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "",
                    FirstName = "",
                    LastName = "",
                    Address = "",
                    Email = "",
                    Phone = "",
                    ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
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
        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
             string FirstName = "",
                    LastName = "",
                    Address = "",
                    Email = "",
                    Phone = "",
                    ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 3;
            short CountryID = -1;
            if (clsPersonDataAccess.FindPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref LastName, ref DateOfBirth, ref Gender,
                                    ref Email, ref Phone, ref CountryID, ref Address, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, LastName, DateOfBirth, Gender,
                                     Email, Phone, CountryID, Address, ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static clsPerson FindBy(string Column, string searchValue)
        {
            switch(Column)
            {
                case "PersonID":
                    if (int.TryParse(searchValue, out int ID))
                    {
                        return Find(ID);
                    }
                    else
                        return null;

                case "NationalNo":
                    return Find(searchValue);

                default:
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
    
        public static bool Exists(int PersonID)
        {
            return clsPersonDataAccess.Exist(PersonID);
        }
        public static bool Exists(string NationalNo)
        {
            return clsPersonDataAccess.Exist(NationalNo);
        }
        public static bool Delete(int PersonID, int DeletedByUserID)
        {
            return clsPersonDataAccess.Delete(PersonID, DeletedByUserID);
        }


        public static DataTable FilterPeople
                    (
                        int? personID,
                        bool? gender,
                        string nationalNo,
                        string fullName,
                        string email,
                        string phone,
                        string address,
                        byte pageNumber,
                        byte pageSize,
                        out short availablePages
                    )
        {
            int totalRows = 0;

            DataTable dt = clsPersonDataAccess.FilterPeople(
                personID,
                gender,
                nationalNo,
                fullName,
                email,
                phone,
                address,
                pageNumber,
                pageSize,
                out totalRows
            );

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

        public static DataTable ListPeopleRecords(byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable FindByID(int personID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(personID, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable FilterByNationalNo(string nationalNo, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, null, nationalNo, null, null, null, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable SearchByName(string fullName, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, null, null, fullName, null, null, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable FilterByGender(bool gender, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, gender, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable SearchByEmail(string email, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, null, null, null, email, null, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable SearchByPhone(string phone, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, null, null, null, null, phone, null, pageNumber, pageSize, out availablePages);
        }
        public static DataTable SearchByAddress(string address, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterPeople(null, null, null, null, null, null, address, pageNumber, pageSize, out availablePages);
        }
        public static DataTable FilterPeople( string column,string term,byte pageNumber, byte pageSize, out short availablePages )
        {
            column = column?.Trim().ToLower();
            term = term?.Trim();

            switch (column)
            {
                case "personid":
                    if (int.TryParse(term, out int personID))
                        return FindByID(personID, pageNumber, pageSize, out availablePages);
                    break;

                case "gender":
                    if (bool.TryParse(term, out bool gender))
                        return FilterByGender(gender, pageNumber, pageSize, out availablePages);
                    break;

                case "nationalno":
                    return FilterByNationalNo(term, pageNumber, pageSize, out availablePages);

                case "fullName":
                    return SearchByName(term, pageNumber, pageSize, out availablePages);

                case "email":
                    return SearchByEmail(term, pageNumber, pageSize, out availablePages);

                case "phone":
                    return SearchByPhone(term, pageNumber, pageSize, out availablePages);

                case "address":
                    return SearchByAddress(term, pageNumber, pageSize, out availablePages);

                default:
                    return ListPeopleRecords(pageNumber, pageSize, out availablePages);
            }

            return ListPeopleRecords(pageNumber, pageSize, out availablePages);
        }


    }
}
