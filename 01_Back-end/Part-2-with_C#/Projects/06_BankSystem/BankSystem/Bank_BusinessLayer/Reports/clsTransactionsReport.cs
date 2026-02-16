using Bank_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer.Reports
{
    public class clsTransactionsReport
    {
        public enum enTransactionType : byte
        {
            Deposit = 1,
            Withdrawal = 2,
            Transfer = 3
        }

        int TransactionID { get; set; }
        enTransactionType TransactionType { get; set; }        
        DateTime TransactionDate { get; set; }
        int AccountFromID { get; set; }
        int? AccountToID { get; set; }
        double Amount { get; set; }
        double OldBalance { get; set; }
        double NewBalance { get; set; }
        string Notes { get; set; }
        int PerformedByUserID { get; set; }
        bool IsPerformedByAccountOwner { get; set; }

        private static string _sectionKey => "TRANSACTIONS-HISTORY-REPORT";


        clsTransactionsReport()
        {
            TransactionID = -1;
            TransactionType = 0;         
            TransactionDate = DateTime.Now;
            AccountFromID = -1;
            AccountToID = null;
            Amount = 0;
            OldBalance = 0;
            NewBalance = 0;
            Notes = string.Empty;
            PerformedByUserID = -1;
            IsPerformedByAccountOwner = false;
        }

        clsTransactionsReport
        ( enTransactionType transactionType, DateTime transactionDate, int accountFromID, int? accountToID, double amount, double oldBalance, double newBalance, string notes, int performedByUserID,bool isPerformedByAccountOwner)
        {
            TransactionType = transactionType;     
            TransactionDate = transactionDate;
            AccountFromID = accountFromID;
            AccountToID = accountToID;
            Amount = amount;
            OldBalance = oldBalance;
            NewBalance = newBalance;
            Notes = notes;
            PerformedByUserID = performedByUserID;
            IsPerformedByAccountOwner = isPerformedByAccountOwner;
        }

        public bool AuditTransaction()
        {
           this.TransactionID =  clsTransactionHistoryReport_DAL.AddNewTransaction(
                            (byte)TransactionType,
                            TransactionDate,
                            AccountFromID,
                            AccountToID,
                            Amount,
                            OldBalance,
                            NewBalance,
                            Notes,
                            PerformedByUserID,
                            false
            );
            return this.TransactionID > 0;
        }

        public static clsTransactionsReport Find(int TransactionID)
        {

            byte TransactionType = 0;
            DateTime TransactionDate = DateTime.MinValue;
            int AccountFromID = -1;
            int? AccountToID = null;
            double Amount = 0;
            double OldBalance = 0;
            double NewBalance = 0;
            string Notes= string.Empty;
            int PerformedByUserID = -1;
            bool IsPerformedByAccountOwner = false;

            bool found = clsTransactionHistoryReport_DAL.Find(TransactionID,
                ref TransactionType,
                ref TransactionDate,
                ref AccountFromID,
                ref AccountToID,
                ref Amount,
                ref OldBalance,
                ref NewBalance,
                ref Notes,
                ref PerformedByUserID,
                ref IsPerformedByAccountOwner
                );
            clsTransactionsReport hist = null;

            if (found)
                {
                hist = new clsTransactionsReport(
                    (enTransactionType)TransactionType,
                    TransactionDate,
                    AccountFromID,
                    AccountToID,
                    Amount,
                    OldBalance,
                    NewBalance,
                    Notes,
                    PerformedByUserID,
                    IsPerformedByAccountOwner
                    );
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(hist), hist.TransactionID), found, (_sectionKey, $"Read Tansaction history report with id: [{TransactionID}]"));
            }
            return hist;
        }
        private static DataTable FilterTransactions
        (int? transactionID, int? accountFromID, int? accountToID,int? accountOwnerID, bool? isPerformedByCustomer, int? performedByUserID, DateTime? transactionDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            int totalRows = 0;

            DataTable dt = clsTransactionHistoryReport_DAL.FilterTransactions(
                transactionID,
                accountFromID,
                accountToID,
                accountOwnerID,
                isPerformedByCustomer,
                performedByUserID,
                transactionDate,
                pageNumber,
                pageSize,
                out totalRows
            );

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterTransactions(null, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List All transaction history reports"));
            return dt;
        }
        public static DataTable FilterByTransactionID(int transactionID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterTransactions(transactionID, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter transaction history reports by transaction id [{transactionID}]"));
            return dt;
        }
        public static DataTable FilterByAccountFrom(int accountFromID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterTransactions(null, accountFromID, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter transaction history reports by account from id [{accountFromID}]"));
            return dt;
        }
        public static DataTable FilterByAccountTo(int accountToID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterTransactions(null, null, accountToID, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter transaction history reports by account to id [{accountToID}]"));
            return dt;
        }
        public static DataTable FilterByAccountOwner(int accountOwnerID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterTransactions(null, null, null, accountOwnerID, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter transaction history reports by account owner id [{accountOwnerID}]"));
            return dt;
        }
        public static DataTable FilterByPerformer(bool isCustomer, int? userID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterTransactions(null, null, null, null, isCustomer, userID, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter transaction history reports by transaction performer is performed by customer [{isCustomer}]"));
            return dt;
        }
        public static DataTable FilterByDate(DateTime transactionDate, byte pageNumber, byte pageSize, out short availablePages)
        {

            DataTable dt = FilterTransactions(null, null, null, null, null, null, transactionDate, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter transaction history reports by transaction date [{transactionDate}]"));
            return dt;
        }
        
        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) TransactionID { get; private set; } = ("TransactionID", "Transaction ID");
            public static (string valueMember, string DisplayMember) AccountFrom { get; private set; } = ("AccountFrom", "Account From");
            public static (string valueMember, string DisplayMember) AccountTo { get; private set; } = ("AccountTo", "Account To");
            public static (string valueMember, string DisplayMember) AccountOwner { get; private set; } = ("AccountOwner", "Account Owner");
            public static (string valueMember, string DisplayMember) Performer { get; private set; } = ("Performer", "Performed By");
            public static (string valueMember, string DisplayMember) TransactionDate { get; private set; } = ("TransactionDate", "Transaction Date");
        }

        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            private static DateTime Today => DateTime.Today;
            private static DateTime ThisMonthStart => new DateTime(Today.Year, Today.Month, 1);
            private static DateTime LastMonthStart => ThisMonthStart.AddMonths(-1);
            private static DateTime ThisYearStart => new DateTime(Today.Year, 1, 1);
            private static DateTime LastYearStart => ThisYearStart.AddYears(-1);

            public static (string GroupName, Dictionary<string, string> GroupItems) TransactionDateRange
            {
                get
                {
                    return ("TransactionDate", new Dictionary<string, string>
            {
                { "All", "" },
                { "Today", Today.ToString("yyyy-MM-dd") },
                { "Yesterday", Today.AddDays(-1).ToString("yyyy-MM-dd") },
                { "Last 7 Days", $"{Today.AddDays(-7):yyyy-MM-dd}|{Today:yyyy-MM-dd}" },
                { "This Month", $"{ThisMonthStart:yyyy-MM-dd}|{ThisMonthStart.AddMonths(1):yyyy-MM-dd}" },
                { "Last Month", $"{LastMonthStart:yyyy-MM-dd}|{ThisMonthStart:yyyy-MM-dd}" },
                { "This Year", $"{ThisYearStart:yyyy-MM-dd}|{ThisYearStart.AddYears(1):yyyy-MM-dd}" },
                { "Last Year", $"{LastYearStart:yyyy-MM-dd}|{ThisYearStart:yyyy-MM-dd}" }
            });
                }
            }
        }

        private delegate DataTable FilterDelegate(string term, byte page, byte size, out short pages);

        private static Dictionary<string, FilterDelegate> _filterActions;
        private static Dictionary<string, FilterDelegate> _FilterActions
        {
            get
            {
                if (_filterActions == null)
                {
                    _filterActions = new Dictionary<string, FilterDelegate>
            {
                { Filter_Mapping.TransactionID.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByTransactionID(id, page, size, out pages);
                        return ListAll(page, size, out pages);
                    }
                },
                { Filter_Mapping.AccountFrom.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByAccountFrom(id, page, size, out pages);
                        return ListAll(page, size, out pages);
                    }
                },
                { Filter_Mapping.AccountTo.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByAccountTo(id, page, size, out pages);
                        return ListAll(page, size, out pages);
                    }
                },
                { Filter_Mapping.AccountOwner.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByAccountOwner(id, page, size, out pages);
                        return ListAll(page, size, out pages);
                    }
                },
                { Filter_Mapping.Performer.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        var parts = term.Split('|');
                        bool isCustomer = bool.Parse(parts[0]);
                        int? userID = (parts.Length > 1 && int.TryParse(parts[1], out int uid)) ? (int?)uid : null;
                        return FilterByPerformer(isCustomer, userID, page, size, out pages);
                    }
                },
                { Filter_Mapping.TransactionDate.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (DateTime.TryParse(term, out DateTime dt))
                            return FilterByDate(dt, page, size, out pages);
                        return ListAll(page, size, out pages);
                    }
                },
                { Filter_Mapping.All.valueMember, (string term,byte page,byte size, out short pages) => ListAll(page, size, out pages) }
            };
                }
                return _filterActions;
            }
        }

        public static DataTable FilterTransactionsHistory(string column, string term, byte pageNumber, byte pageSize, out short availablePages)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate filterAction))
                return filterAction(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }


    }
}
