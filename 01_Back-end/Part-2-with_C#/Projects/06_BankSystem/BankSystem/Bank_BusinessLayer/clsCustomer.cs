using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.clsCustomer;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer
{
    public class clsCustomer
    {
        enum enMode { enAddNew, enUpdate }
        enMode _Mode = enMode.enAddNew;
        public enum enCustomerType { enIndividual = 1, enBusiness = 2, enVIP = 3 }

        public int CustomerID { get; private set; }
        public int PersonID { get; set; }
        public clsPerson PersonalInf { get; set; }
        public string Occupation { get; set; }
        public  enCustomerType CustomerType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser { get; set; }
        public bool IsActive { get; set; }

        private static string _sectionKey => "CUSTOMER";
       
        public clsCustomer()
        {
            CustomerID = -1;
            PersonID = -1;
            Occupation = string.Empty;
            CustomerType = enCustomerType.enIndividual;
            CreatedDate = DateTime.Now;
            CreatedByUserID = -1;
            IsActive = false;
            _Mode= enMode.enAddNew;
        }
        clsCustomer(int CustomerID,  int PersonID,  string Occupation,  enCustomerType CustomerType,  DateTime CreatedDate,  int CreatedByUserID, bool IsActive)
        {
            this.CustomerID = CustomerID;
            this.PersonID = PersonID;
            this.PersonalInf = clsPerson.Find(this.PersonID);
            this.Occupation = Occupation;
            this.CustomerType = CustomerType;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID=CreatedByUserID;
            this.CreatedByUser = clsUser.FindUserByID(this.CreatedByUserID);
            this.IsActive = IsActive;

            _Mode = enMode.enUpdate;
        }

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) CustomerID { get; private set; } = ("ID", "Customer ID");
            public static (string valueMember, string DisplayMember) PersonID { get; private set; } = ("PersonID", "Person ID");
            public static (string valueMember, string DisplayMember) CreatedByUserID { get; private set; } = ("CreatedByUserID", "Created By User ID");
            public static (string valueMember, string DisplayMember) Status { get; private set; } = ("IsActive", "Status");
            public static (string valueMember, string DisplayMember) CustomerType { get; private set; } = ("CustomerType", "Customer Type");
        }
        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            // ---- IsActive group
            public static (string GroupName, Dictionary<string, string> GroupItems) Status
            {
                get
                {
                    return (Filter_Mapping.Status.valueMember,
                        new Dictionary<string, string>
                        {
                    { "All", "All" },
                    { "Active", "1" },
                    { "InActive", "0" }
                        });
                }
            }

            // ---- Customer Type group
            public static (string GroupName, Dictionary<string, string> GroupItems) CustomerType
            {
                get
                {
                    return (Filter_Mapping.CustomerType.valueMember,
                        new Dictionary<string, string>
                        {
                    { "All", "All" },
                    { "Individual", "1" },
                    { "Business", "2" },
                    { "VIP", "3" }
                        });
                }
            }
        }

        public static clsCustomer FindCustomerByID(int CustomerID)
        {
            int PersonID = -1;
            string Occupation = string.Empty;
            byte CustomerType = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;
            bool IsActive = false;

            clsCustomer _customer = null;
            bool _Success = false;

            if (clsCustomerDataAccess.FindCustomerByID(CustomerID, ref PersonID, ref Occupation, ref CustomerType, ref CreatedDate, ref CreatedByUserID, ref IsActive))
            {
                _customer = new clsCustomer(CustomerID, PersonID, Occupation, (enCustomerType)CustomerType, CreatedDate, CreatedByUserID, IsActive);
                _Success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_customer), CustomerID), _Success, (_sectionKey, $"Read customer record with customer id: {CustomerID}"));
            }

            return _customer;
          
        }
        public static clsCustomer FindCustomerByPersonID(int PersonID)
        {
            int CustomerID = -1;
            string Occupation = string.Empty;
            byte CustomerType = 0;
            DateTime CreatedDate = DateTime.Now;
            int CreatedByUserID = -1;
            bool IsActive = false;

            clsCustomer _customer = null;
            bool _Success = false;

            if (clsCustomerDataAccess.FindCustomerByPersonID(PersonID, ref CustomerID, ref Occupation, ref CustomerType, ref CreatedDate, ref CreatedByUserID, ref IsActive))
            {
                _customer = new clsCustomer(CustomerID, PersonID, Occupation, (enCustomerType)CustomerType, CreatedDate, CreatedByUserID, IsActive);
                _Success = true;
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(_customer), CustomerID), _Success, (_sectionKey, $"Read customer record with Person id: {PersonID}"));
            }

            return _customer;
          
        }
        public static clsCustomer FindBy(string findBy, string Term)
        {
            switch(findBy)
            {
                case "CustomerID":
                    {
                        
                        if (int.TryParse(Term, out int CustomerID))
                            return FindCustomerByID(CustomerID);
                        else
                            return null;
                    }
                case "PersonID":
                    {
                     
                        if (int.TryParse(Term, out int PersonID))
                            return FindCustomerByPersonID(PersonID);
                        else
                            return null;
                    }
                default:
                    return null;
            }
        }
        private bool _AddNewCustomer()
        {
            this.CustomerID= clsCustomerDataAccess.AddNewCustomer(this.PersonID,this.Occupation,Convert.ToByte(this.CustomerType),this.CreatedDate,this.CreatedByUserID,this.IsActive);
            bool OperationSucceed = this.CustomerID != -1;
            AuditingHelper.AuditCreateOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(this), OperationSucceed ? this.PersonID : (int?)null), OperationSucceed, (_sectionKey, "Add New customer Record"));

            return OperationSucceed;
        }
        private bool _Update()
        {

            var OldRecord = FindCustomerByID(this.CustomerID);
            bool OperationSucceed = clsCustomerDataAccess.Update(this.CustomerID, this.Occupation, Convert.ToByte(this.CustomerType), this.IsActive);
            var NewRecord = FindCustomerByID(this.CustomerID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_sectionKey, "Update customer Record"), changes.Before, changes.After, this.CustomerID);
            return OperationSucceed;
        }        
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewCustomer())
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
        public static bool IsCustomerExistsByID(int CustomerID)
        {
            bool found = clsCustomerDataAccess.IsCustomerExistsByID(CustomerID);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var customer = FindCustomerByID(CustomerID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(customer);
                AuditingHelper.AuditValidationOperation((target, CustomerID), found, (_sectionKey, $"Check customer existance by cusotomer id: {CustomerID}"));
            }
            return found;
        }
        public static bool IsCustomerExistsByPersonID(int PersonID)
        {
            bool found = clsCustomerDataAccess.IsCustomerExistsByPersonID((int)PersonID);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var customer = FindCustomerByID(PersonID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(customer);
                AuditingHelper.AuditValidationOperation((target, customer.CustomerID), found, (_sectionKey, $"Check customer existance by person id: {PersonID}"));
            }
            return found;
        }
        public static bool IsCustomerActive(int CustomerID)
        {
            bool active = clsCustomerDataAccess.IsActive(CustomerID);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var customer = FindCustomerByID(CustomerID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(customer);
                AuditingHelper.AuditValidationOperation((target, CustomerID), active, (_sectionKey, $"Check customer status by cusotomer id: {CustomerID}"));
            }
            return active;
        }
        public static bool HasAccountType(int CustomerID, clsAccounts.enAccountType AccountType)
        {
            bool has = clsCustomerDataAccess.HasAccountType(CustomerID, (byte)AccountType);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                var customer = FindCustomerByID(CustomerID);
                var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(customer);
                AuditingHelper.AuditValidationOperation((target, CustomerID), has, (_sectionKey, $"Check if the customer[{CustomerID}] has similar account type[{AccountType}] "));
            }
            return has;
        }

        public static bool UpdateCustomerStatus(int CustomerID, bool IsActive)
        {
            var OldRecord = FindCustomerByID(CustomerID);
            bool OperationSucceed = clsCustomerDataAccess.UpdateCustomerStatus(CustomerID, IsActive);
            var NewRecord = FindCustomerByID(CustomerID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_sectionKey, "Update customer Status Only"), changes.Before, changes.After, CustomerID);
            return OperationSucceed;
        }
        public bool UpdateCustomerStatus(bool IsActive)
        {
            return UpdateCustomerStatus(this.CustomerID, IsActive);
        }
       
        public static bool Delete(int CustomerID, int DeletedByUserID)
        {
            clsCustomer DeletedRecord = FindCustomerByID(CustomerID);
            bool deleted = clsCustomerDataAccess.Delete(CustomerID, DeletedByUserID);
            AuditingHelper.AuditDeletionOperation((DeletedRecord, CustomerID), deleted, (_sectionKey, $"Delete customer Record with id < {CustomerID} >"));
            return deleted;
        }
        public bool Delete(int DeletedByUserID)
        {
            return Delete(this.CustomerID);
        }

        public static DataTable GetCustomerAccounts(int CustomerID)
        {
            DataTable dt = clsCustomerDataAccess.GetCustomerAccounts(CustomerID);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"List customer[{CustomerID}] related accounts"));
            return dt;
        }
      

        private static DataTable FilterCustomers
        (
            int? customerID,
            int? personID,
            int? createdByUserID,
            bool? isActive,
            byte? customerType,
            byte pageNumber,
            byte pageSize,
            out short availablePages
        )
        {
            int totalRows = 0;

            DataTable dt = clsCustomerDataAccess.FilterCustomers
            (
                customerID,
                personID,
                createdByUserID,
                isActive,
                customerType,
                pageNumber,
                pageSize,
                out totalRows
            );

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }
        public static DataTable ListAll(byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterCustomers(null, null, null, null, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List All cutomer Records"));
            return dt;
        }
        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterCustomers(customerID, null, null, null, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer records by customer id [{customerID}]"));
            return dt;
        }
        public static DataTable FilterByPersonID(int personID, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterCustomers(null, personID, null, null, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer records by person id [{personID}]"));
            return dt;
        }
        public static DataTable FilterByStatus(bool isActive, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterCustomers(null, null, null, isActive, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer records by customer status [{isActive}]"));
            return dt;
        }
        public static DataTable FilterByCustomerType(byte customerType, byte pageNumber, byte pageSize, out short pages)
        {

            DataTable dt = FilterCustomers(null, null, null, null, customerType, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer records by customer type [{customerType}]"));
            return dt;
        }
        public static DataTable FilterByCreatedByUser(int userID, byte pageNumber, byte pageSize, out short pages)
        {

            DataTable dt = FilterCustomers(null, null, userID, null, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer records by user how created it [{userID}]"));
            return dt;
        }

        private delegate DataTable FilterDelegate(string term, byte pageNumber, byte pageSize, out short availablePages);
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
                    Filter_Mapping.CustomerID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByCustomerID(int.Parse(term), page, size, out pages)
                },

                {
                    Filter_Mapping.PersonID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByPersonID(int.Parse(term), page, size, out pages)
                },

                {
                    Filter_Mapping.Status.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByStatus(bool.Parse(term), page, size, out pages)
                },

                {
                    Filter_Mapping.CustomerType.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByCustomerType(byte.Parse(term), page, size, out pages)
                },

                {
                    Filter_Mapping.CreatedByUserID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByCreatedByUser(int.Parse(term), page, size, out pages)
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
        public static DataTable FilterCustomers
        (
            string column,
            string term,
            byte pageNumber,
            byte pageSize,
            out short availablePages
        )
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate action))
                return action(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }

    }
}
