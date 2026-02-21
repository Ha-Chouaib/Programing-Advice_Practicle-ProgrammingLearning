using Bank_BusinessLayer.Reports;
using Bank_DataAccess;
using BankSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.clsAccounts;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer
{
    public class clsAccounts
    {
        enum enMode { enAddNew, enUpdate }
        enMode _Mode = enMode.enAddNew;

        public enum enAccountType { enIndividual = 1, enBusiness = 2,enSave = 3}
        
        public int AccountID { get; private set; }
        public int CustomerID { get;  set; }
        public clsCustomer CustomerInf { get; set; }
        public string AccountNumber { get; set; }
        public enAccountType AccountType     { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUser    { get; set; }

        public static string _SectionKey => "ACCOUNT";

        public clsAccounts()
        {
            AccountID = -1;
            CustomerID = -1;
            AccountNumber = string.Empty;
            AccountType = 0;
            Balance = 0;
            IsActive = false;
            CreatedByUserID = -1;
            CreatedDate = DateTime.MinValue;

            _Mode = enMode.enAddNew;
        }
        private clsAccounts(int AccountID,int CustomerID, string AccountNumber, enAccountType AccountType, double Balance, bool IsActive, DateTime CreatedDate, int CreatedByUserID)
        {
            this.AccountID = AccountID;
            this.CustomerID = CustomerID;
            this.AccountNumber = AccountNumber;
            this.AccountType = AccountType;
            this.Balance = Balance;
            this.IsActive = IsActive;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;

            this.CustomerInf = clsCustomer.FindCustomerByID(CustomerID);
            this.CreatedByUser = clsUser.FindUserByID(CreatedByUserID);

            _Mode = enMode.enUpdate;
        }

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) AccountID { get; private set; } = ("ID", "Account ID");
            public static (string valueMember, string DisplayMember) CustomerID { get; private set; } = ("CustomerID", "Customer ID");
            public static (string valueMember, string DisplayMember) CreatedByUserID { get; private set; } = ("CreatedByUserID", "Created By User ID");
            public static (string valueMember, string DisplayMember) AccountNumber { get; private set; } = ("AccountNumber", "Account Number");
            public static (string valueMember, string DisplayMember) Status { get; private set; } = ("IsActive", "Status");
            public static (string valueMember, string DisplayMember) AccountType { get; private set; } = ("AccountType", "Account Type");
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

            // ---- Account Type group
            public static (string GroupName, Dictionary<string, string> GroupItems) AccountType
            {
                get
                {
                    return (Filter_Mapping.AccountType.valueMember,
                        new Dictionary<string, string>
                        {
                    { "All", "All" },
                    { "Individual", "1" },
                    { "Business", "2" },
                    { "Save", "3" }
                        });
                }
            }
        }

        [Serializable]
        public static class FindBy_Mapping
        {
            public static (string valueMember, string DisplayMember) AccountID { get; private set; } = ("ID", "Account ID");
            public static (string valueMember, string DisplayMember) AccountNumber { get; private set; } = ("AccountNumber", "Account Number");
        }
        public static clsAccounts FindByID(int AccountID)
        {
            int CustomerID = -1;
            string AccountNumber = string.Empty;
            byte AccountType = 0;
            double Balance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            clsAccounts _account = null;
            if (clsAccountsDataAccess.FindByID(AccountID, ref CustomerID, ref AccountNumber, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))               
                _account = new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            if(clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((_account, AccountID), _account != null, (_SectionKey, $"Read account record with account id [{AccountID}]"));
            }

            return _account;
        }
        public static clsAccounts FindByAccountNumber(string AccountNumber)
        {
            int CustomerID = -1;
            int AccountID = -1;
            byte AccountType = 0;
            double Balance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            clsAccounts _account = null;

            if (clsAccountsDataAccess.FindByAccountNumber(AccountNumber, ref AccountID, ref CustomerID, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))
                _account = new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((_account, AccountID), _account != null, (_SectionKey, $"Read account record with account number [{AccountNumber}]"));
            }

            return _account;
        }
        
        private bool _AddNew()
        {
            var result = clsAccountsDataAccess.AddNewAccount(this.CustomerID, Convert.ToByte(this.AccountType),
                            this.Balance, this.IsActive, this.CreatedDate, this.CreatedByUserID);
            this.AccountID = result.AccountID;
            this.AccountNumber = result.AccountNumber;

            AuditingHelper.AuditCreateOperation((this, this.AccountID), this != null, (_SectionKey, "Add new account record"));

            return this.AccountID != -1;
        }
        private bool _Update()
        {
            var OldRecord = FindByID(this.AccountID);
            bool OperationSucceed = clsAccountsDataAccess.Update(this.AccountID, Convert.ToByte(this.AccountType), this.Balance, this.IsActive);
            var NewRecord = FindByID(this.AccountID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update User Record"), changes.Before, changes.After, this.AccountID);
            return OperationSucceed;
        }
        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNew())
                    {
                        //_Mode = enMode.enUpdate;
                        return true;
                    }
                    else return false;

                case enMode.enUpdate:
                    return _Update();

                default:
                    return false;
            }
        }

        public static bool UpdateBalance(int AccountID, double Balance)
        {
            var OldRecord = FindByID(AccountID);
            bool OperationSucceed = clsAccountsDataAccess.UpdateBalance(AccountID, Balance);
            var NewRecord = FindByID(AccountID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update Only Account Balance"), changes.Before, changes.After, AccountID);
            return OperationSucceed;
        }
        public static bool UpdateStatus(int AccountID, bool IsActive)
        {
            var OldRecord = FindByID(AccountID);
            bool OperationSucceed = clsAccountsDataAccess.UpdateStatus(AccountID, IsActive);
            var NewRecord = FindByID(AccountID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update Only Account status"), changes.Before, changes.After, AccountID);
            return OperationSucceed;
        }
        public bool UpdateStatus(bool IsActive)
        {
            return UpdateStatus(this.AccountID, IsActive);
        }
        public static bool UpdateAccountType(int AccountID, enAccountType AccountType)
        {

            var OldRecord = FindByID(AccountID);
            bool OperationSucceed = clsAccountsDataAccess.UpdateAccountType(AccountID, (byte)AccountType);
            var NewRecord = FindByID(AccountID);

            var changes = clsUtil_BL.HandleObjectsHelper.CompareObjects(OldRecord, NewRecord);
            AuditingHelper.AuditUpdateOperation(OperationSucceed, (_SectionKey, "Update Only Account Type"), changes.Before, changes.After, AccountID);
            return OperationSucceed;
        }

        public static bool Exists(int AccountID)
        {
            bool found = clsAccountsDataAccess.ExistsByID(AccountID);
            return found;
        }
        public static bool Exists(string AccountNumber)
        {
            bool found = clsAccountsDataAccess.ExistsByAccountNumber(AccountNumber);
            return found;
        }
        
        public static bool DepositWithdraw(int AccountID, double Amount)
        {
            var account = FindByID(AccountID);
            var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(account);
            bool done = false;
            if (!(account.Balance < Math.Abs(Amount) && Amount <= 0))
                done= clsAccountsDataAccess.DepositWithdraw(AccountID, Amount);

            (string key, string description) section;
            if (Amount > 0)
                section = ($"{_SectionKey}_TRANSACTION-DEPOSIT", $"Append the Amount [{Amount}] to Account with id {AccountID}");
            else
                section = ($"{_SectionKey}_TRANSACTION-WITHDRAWAL", $"take the Amount [{Amount}] from Account with id {AccountID}");

            AuditingHelper.AuditCreateOperation((target, AccountID), done, section);
            return done;
        }
        public bool DepositWithdraw(double Amount)
        {
            return DepositWithdraw(this.AccountID, Amount);
        }

        public static bool TransferMoney(int AccountFromID, int AccountToID, double Amount)
        {
            var account = FindByID(AccountFromID);
            var target = clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(account);
            bool done = false;
            if (!(account.Balance < Math.Abs(Amount) || Amount <= 0))
                done = clsAccountsDataAccess.TransferMoney(AccountFromID, AccountToID, Amount);
            (string key, string description) section = ($"{_SectionKey}_TRANSACTION-TRANSFERE", $"Move the Amount [{Amount}] from Account with id {AccountFromID} to account with id[{AccountToID}]");
            AuditingHelper.AuditCreateOperation((target, AccountFromID), done, section);

            return done;
        }
        public bool TransferMoney(int AccountToID, double Amount)
        {
            return TransferMoney(this.AccountID, AccountToID, Amount);

        }
        public static bool Delete(int AccountID, int DeletedByUserID)
        {
            var DeletedRecord = FindByID(AccountID);
            bool deleted = clsAccountsDataAccess.Delete(AccountID, DeletedByUserID);
            AuditingHelper.AuditDeletionOperation((DeletedRecord, AccountID), deleted, (_SectionKey, $"Delete account Record with id < {AccountID} >"));
            return deleted;
        }

        public static bool isActive(int AccountID)
        {
            bool active = clsAccountsDataAccess.IsActive(AccountID);
            return active;
        }


        private delegate clsAccounts _FindByDelegate(string term);
        static Dictionary<string, _FindByDelegate> FindByActionsRef;
        static Dictionary<string, _FindByDelegate> FindByActions
        {
            get
            {
                if (FindByActionsRef == null)
                {
                    FindByActionsRef = new Dictionary<string, _FindByDelegate>
                    {
                        {FindBy_Mapping.AccountID.valueMember,(string term)=>
                            {
                                if(int.TryParse(term, out int id))
                                    return FindByID(id);
                                return null;
                            }
                        },
                        {FindBy_Mapping.AccountNumber.valueMember,(string term)=> FindByAccountNumber(term)},
                       
                    };
                }
                return FindByActionsRef;
            }
        }
        public static clsAccounts FindBy(string column, string term)
        {

            if (FindByActions.TryGetValue(column, out _FindByDelegate action))
                return action(term.Trim());
            return null;
        }

        private static DataTable FilterAccounts
        (
            int? accountID,
            string accountNumber,
            int? customerID,
            int? createdByUserID,
            bool? isActive,
            byte? accountType,
            byte pageNumber,
            byte pageSize,
            out short availablePages
        )
        {
            int totalRows = 0;

            DataTable dt = clsAccountsDataAccess.FilterAccounts
            (
                accountID,
                accountNumber,
                customerID,
                createdByUserID,
                isActive,
                accountType,
                pageNumber,
                pageSize,
                out totalRows
            );

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(null, null, null, null, null, null, pageNumber, pageSize, out pages);

            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, "List All Accounts Records"));

            return dt;
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(accountID, null, null, null, null, null, pageNumber, pageSize, out pages);

            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, $"Filter accounts by account id [ {accountID} ]"));

            return dt;
        }

        public static DataTable FilterByAccountNumber(string accountNumber, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(null, accountNumber, null, null, null, null, pageNumber, pageSize, out pages);

            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, $"Filter accounts by account number [ {accountNumber} ]"));

            return dt;
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(null, null, customerID, null, null, null, pageNumber, pageSize, out pages);

            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, $"Filter accounts by customer id [ {customerID} ]"));

            return dt;
        }

        public static DataTable FilterByStatus(bool isActive, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(null, null, null, null, isActive, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, $"Filter accounts by customer status [ {isActive} ]"));

            return dt;
        }

        public static DataTable FilterByAccountType(byte accountType, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(null, null, null, null, null, accountType, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, $"Filter accounts by account Type [ {accountType} ]"));

            return dt;
        }

        public static DataTable FilterByCreatedByUser(int userID, byte pageNumber, byte pageSize, out short pages)
        {
            DataTable dt = FilterAccounts(null, null, null, userID, null, null, pageNumber, pageSize, out pages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_SectionKey, $"Filter accounts by the user how created it with id [ {userID} ]"));

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
                    Filter_Mapping.AccountID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByAccountID(id, page, size, out pages);

                        return ListAll(page, size, out pages);
                    }
                },

                {
                    Filter_Mapping.AccountNumber.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByAccountNumber(term, page, size, out pages)
                },

                {
                    Filter_Mapping.CustomerID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int customerID))
                            return FilterByCustomerID(customerID, page, size, out pages);

                        return ListAll(page, size, out pages);
                    }
                },

                {
                    Filter_Mapping.CreatedByUserID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int createdBy))
                            return FilterByCreatedByUser(createdBy, page, size, out pages);

                        return ListAll(page, size, out pages);
                    }
                },

                {
                    Filter_Mapping.Status.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                    {
                        if (bool.TryParse(term, out bool active))
                            return FilterByStatus(active, page, size, out pages);

                        return ListAll(page, size, out pages);
                    }
                },

                {
                    Filter_Mapping.AccountType.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                    {
                        if (byte.TryParse(term, out byte type))
                            return FilterByAccountType(type, page, size, out pages);

                        return ListAll(page, size, out pages);
                    }
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
        public static DataTable FilterAccounts(string column, string term, byte pageNumber, byte pageSize, out short availablePages)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate action))
                return action(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }

    }

}
