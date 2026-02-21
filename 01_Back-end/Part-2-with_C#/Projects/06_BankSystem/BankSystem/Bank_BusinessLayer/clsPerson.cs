using Bank_DataAccess;
using Bank_DataAccess.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

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

        private static string _sectionKey => "PERSON";
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
        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) PersonID { get; private set; } = ("ID", "Person ID");
            public static (string valueMember, string DisplayMember) NationalNo { get; private set; } = ("NationalNo", "National No");
            public static (string valueMember, string DisplayMember) Gender { get; private set; } = ("Gender", "Gender");
            public static (string valueMember, string DisplayMember) FullName { get; private set; } = ("FullName", "Full Name");
            public static (string valueMember, string DisplayMember) Email { get; private set; } = ("Email", "Email");
            public static (string valueMember, string DisplayMember) Address { get; private set; } = ("Address", "Address");
            public static (string valueMember, string DisplayMember) Phone { get; private set; } = ("Phone", "Phone Number");
        }
        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            public static (string GroupName, Dictionary<string, string> GroupItems) Gender
            {
                get
                {
                    return (Filter_Mapping.Gender.valueMember,
                        new Dictionary<string, string>
                        {
                    { "All", "All" },
                    { "Male", "false" },
                    { "Female", "true" }
                        });
                }
            }
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

            clsPerson _person = null;
            bool _Success = false;

            if (clsPersonDataAccess.FindPersonByID(PersonID, ref NationalNo, ref FirstName, ref LastName, ref DateOfBirth, ref Gender,
                                    ref Email, ref Phone, ref CountryID, ref Address, ref ImagePath))
            {
                _person = new clsPerson(PersonID, NationalNo, FirstName, LastName, DateOfBirth, Gender,
                                     Email, Phone, CountryID, Address, ImagePath);
                _Success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_person), _person.PersonID), _Success, (_sectionKey, $"Read person record with id: {PersonID}"));
            }
            return _person;
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

            clsPerson _person = null;
            bool _Success = false;

            if (clsPersonDataAccess.FindPersonByNationalNo(NationalNo, ref PersonID, ref FirstName, ref LastName, ref DateOfBirth, ref Gender,
                                    ref Email, ref Phone, ref CountryID, ref Address, ref ImagePath))
            {
                _person = new clsPerson(PersonID, NationalNo, FirstName, LastName, DateOfBirth, Gender,
                                     Email, Phone, CountryID, Address, ImagePath);
                _Success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_person), _person.PersonID), _Success, (_sectionKey, $"Read person record with nationalNO: {NationalNo}"));
            }
            return _person;
        }

        public static clsPerson FindBy(string Column, string searchValue)
        {
            switch(Column.ToLower())
            {
                case "personid":
                    if (int.TryParse(searchValue, out int ID))
                    {
                        return Find(ID);
                    }
                    else
                        return null;

                case "nationalno":
                    return Find(searchValue);

                default:
                    return null;
            }
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNo,this.FirstName,this.LastName,this.DateOfBirth,this.Gender,this.Email,
                this.Phone,this.CountryID,this.Address,this.ImagePath);
            bool OperationSucceed = this.PersonID != -1;
            AuditingHelper.AuditCreateOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(this), OperationSucceed ? this.PersonID : (int?)null), OperationSucceed, (_sectionKey, "Add New person Record"));

            return OperationSucceed;
        }

        private bool _UpdatePerson()
        {
            var OldRecord = Find(this.PersonID);
            bool OperationSucceed = clsPersonDataAccess.UpdatePersonInf(this.PersonID, this.NationalNo, this.FirstName, this.LastName, this.DateOfBirth, this.Gender, this.Email,
                this.Phone, this.CountryID, this.Address, this.ImagePath);
            var NewRecord = Find(OldRecord.PersonID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_sectionKey, "Update person record"), changes.Before, changes.After, NewRecord.PersonID);
            return OperationSucceed;
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
            clsPerson DeletedRecord = Find(PersonID);
            bool deleted = clsPersonDataAccess.Delete(PersonID, DeletedByUserID);
            AuditingHelper.AuditDeletionOperation((DeletedRecord, PersonID), deleted, (_sectionKey, $"Delete person Record with id < {PersonID} >"));
            return deleted;
        }


        private static DataTable FilterPeople
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
            DataTable dt = clsPersonDataAccess.FilterPeople(personID,gender,nationalNo,fullName,email,phone,address,pageNumber,pageSize,out totalRows);
            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }
        public static DataTable ListPeopleRecords(byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List All person Records"));
            return dt;
        }
        public static DataTable FilterByPersonID(int personID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(personID, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by person id [{personID}]"));
            return dt;
        }
        public static DataTable FilterByNationalNo(string nationalNo, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, null, nationalNo, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by nationalNo[{nationalNo}]"));
            return dt;
        }
        public static DataTable FilterByFullName(string fullName, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, null, null, fullName, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by full name[{fullName}]"));
            return dt;
        }
        public static DataTable FilterByGender(bool gender, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, gender, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by gender[{(gender ? "Female" : "Male")}]"));
            return dt;
        }
        public static DataTable FilterByEmail(string email, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, null, null, null, email, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by email[{email}]"));
            return dt;
        }
        public static DataTable FilterByPhone(string phone, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, null, null, null, null, phone, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by email[{phone}]"));
            return dt;
        }
        public static DataTable FilterByAddress(string address, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterPeople(null, null, null, null, null, null, address, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter person Records by address[{address}]"));
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
                    Filter_Mapping.PersonID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        { return int.TryParse(term, out int id) ? FilterByPersonID(id, page, size, out pages) : ListPeopleRecords(page, size, out pages); }
                },

                {
                    Filter_Mapping.Gender.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        { return bool.TryParse(term, out bool gender) ? FilterByGender(gender, page, size, out pages) : ListPeopleRecords(page, size, out pages); }
                },

                {
                    Filter_Mapping.NationalNo.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByNationalNo(term, page, size, out pages)
                },

                {
                    Filter_Mapping.FullName.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByFullName(term, page, size, out pages)
                },

                {
                    Filter_Mapping.Email.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByEmail(term, page, size, out pages)
                },

                {
                    Filter_Mapping.Phone.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByPhone(term, page, size, out pages)
                },

                {
                    Filter_Mapping.Address.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByAddress(term, page, size, out pages)
                },

                {
                    Filter_Mapping.All.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        ListPeopleRecords(page, size, out pages)
                }
            };
                }
                return _filterActions;
            }
        }

        // Unified entry point
        public static DataTable FilterPeople(string column, string term, byte pageNumber, byte pageSize, out short availablePages)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate action))
                return action(term, pageNumber, pageSize, out availablePages);

            return ListPeopleRecords(pageNumber, pageSize, out availablePages);
        }

    }
}
