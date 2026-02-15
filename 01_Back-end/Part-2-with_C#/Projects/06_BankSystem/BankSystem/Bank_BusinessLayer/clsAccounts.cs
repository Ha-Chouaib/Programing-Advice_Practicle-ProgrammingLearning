using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static clsAccounts FindByID(int AccountID)
        {
            int CustomerID = -1;
            string AccountNumber = string.Empty;
            byte AccountType = 0;
            double Balance = 0;
            bool IsActive = false;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            if (clsAccountsDataAccess.FindByID(AccountID, ref CustomerID, ref AccountNumber, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))
                return new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            else
                return null;
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
            if (clsAccountsDataAccess.FindByAccountNumber(AccountNumber, ref AccountID, ref CustomerID, ref AccountType, ref Balance, ref IsActive, ref CreatedDate, ref CreatedByUserID))
                return new clsAccounts(AccountID, CustomerID, AccountNumber, (enAccountType)AccountType, Balance, IsActive, CreatedDate, CreatedByUserID);
            else
                return null;
        }
        
        public static clsAccounts FindBy(string Column, string Term)
        {

            switch(Column.ToLower())
            {
                case "accountid":
                    int accountID;
                    if (int.TryParse(Term, out accountID))
                        return FindByID(accountID);
                    break;
                case "accountnumber":
                    return FindByAccountNumber(Term);
               default:
                    return null;
            }
            return null;
        }
        private bool _AddNew()
        {
            var result = clsAccountsDataAccess.AddNewAccount(this.CustomerID, Convert.ToByte(this.AccountType),
                            this.Balance, this.IsActive, this.CreatedDate, this.CreatedByUserID);
            this.AccountID = result.AccountID;
            this.AccountNumber = result.AccountNumber;
            return this.AccountID != -1;
        }
        private bool _Update()
        {
            return clsAccountsDataAccess.Update(this.AccountID,Convert.ToByte( this.AccountType), this.Balance, this.IsActive);
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
            return clsAccountsDataAccess.UpdateBalance(AccountID, Balance);
        }
        public static bool UpdateStatus(int AccountID, bool IsActive)
        {
            return clsAccountsDataAccess.UpdateStatus(AccountID, IsActive);
        }
        public bool UpdateStatus(bool IsActive)
        {
            return UpdateStatus(this.AccountID, IsActive);
        }
        public static bool UpdateAccountType(int AccountID, enAccountType AccountType)
        {
            return clsAccountsDataAccess.UpdateAccountType(AccountID, (byte)AccountType);
        }

        public static bool Exists(int AccountID)
        {
            return clsAccountsDataAccess.ExistsByID(AccountID);
        }
        public static bool Exists(string AccountNumber)
        {
            return clsAccountsDataAccess.ExistsByAccountNumber(AccountNumber);
        }
        public static bool DepositWithdraw(int AccountID, double Amount)
        {
            return clsAccountsDataAccess.DepositWithdraw(AccountID, Amount);
        }
        public bool DepositWithdraw(double Amount)
        {
            return DepositWithdraw(this.AccountID, Amount);
        }

        public static bool TransferMoney(int AccountFromID, int AccountToID, double Amount)
        {
            return clsAccountsDataAccess.TransferMoney(AccountFromID, AccountToID, Amount);
        }
        public bool TransferMoney(int AccountToID, double Amount)
        {
            return TransferMoney(this.AccountID, AccountToID, Amount);

        }
        public static bool Delete(int AccountID, int DeletedByUserID)
        {
            return clsAccountsDataAccess.Delete(AccountID,DeletedByUserID);
        }

        public static bool isActive(int AccountID)
        {
            return clsAccountsDataAccess.IsActive(AccountID);
        }
        public static DataTable FilterAccounts
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
            return FilterAccounts(null, null, null, null, null, null,
                                  pageNumber, pageSize, out pages);
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short pages)
        {
            return FilterAccounts(accountID, null, null, null, null, null,
                                  pageNumber, pageSize, out pages);
        }

        public static DataTable FilterByAccountNumber(string accountNumber, byte pageNumber, byte pageSize, out short pages)
        {
            return FilterAccounts(null, accountNumber, null, null, null, null,
                                  pageNumber, pageSize, out pages);
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short pages)
        {
            return FilterAccounts(null, null, customerID, null, null, null,
                                  pageNumber, pageSize, out pages);
        }

        public static DataTable FilterByStatus(bool isActive, byte pageNumber, byte pageSize, out short pages)
        {
            return FilterAccounts(null, null, null, null, isActive, null,
                                  pageNumber, pageSize, out pages);
        }

        public static DataTable FilterByAccountType(byte accountType, byte pageNumber, byte pageSize, out short pages)
        {
            return FilterAccounts(null, null, null, null, null, accountType,
                                  pageNumber, pageSize, out pages);
        }

        public static DataTable FilterByCreatedByUser(int userID, byte pageNumber, byte pageSize, out short pages)
        {
            return FilterAccounts(null, null, null, userID, null, null,
                                  pageNumber, pageSize, out pages);
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
