using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsAccountActivityReports : clsCustomerReports_Main
    {

        public int AccountID { get; private set; }
        public clsAccounts TargetAccount { get; private set; }
        public byte TransactionCount { get; private set; }
        public double TotalDebit { get; private set; }
        public double TotalCredit { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }

        private static string _sectionKey => "CUSTOMER-ACCOUNT-ACTIVITY-REPORT";

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) CustomerID { get; private set; } = ("CustomerID", "Customer ID");
            public static (string valueMember, string DisplayMember) AccountID { get; private set; } = ("AccountID", "Account ID");
            public static (string valueMember, string DisplayMember) DateRange { get; private set; } = ("FromDate-To", "Date Range");
            public static (string valueMember, string DisplayMember) MinTransactions { get; private set; } = ("MinTransactions", "Min Transaction Counts");

        }
        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            private static DateTime Today => DateTime.Today;
            private static DateTime ThisMonthStart => new DateTime(Today.Year, Today.Month, 1);
            private static DateTime LastMonthStart => ThisMonthStart.AddMonths(-1);
            private static DateTime ThisYearStart => new DateTime(Today.Year, 1, 1);
            private static DateTime LastYearStart => ThisYearStart.AddYears(-1);

            public static (string GroupName, Dictionary<string, string> GroupItems) LastActivityDate { get { return ("FromDate-To", new Dictionary<string, string>
            {
                { "All", "All" },
                { "Today", Today.ToString("yyyy-MM-dd") },
                { "Yesterday", Today.AddDays(-1).ToString("yyyy-MM-dd") },
                { "Last 7 Days", $"{Today.AddDays(-7):yyyy-MM-dd}|{Today:yyyy-MM-dd}" },
                { "This Month", $"{ThisMonthStart:yyyy-MM-dd}|{ThisMonthStart.AddMonths(1):yyyy-MM-dd}" },
                { "Last Month", $"{LastMonthStart:yyyy-MM-dd}|{ThisMonthStart:yyyy-MM-dd}" },
                { "This Year", $"{ThisYearStart:yyyy-MM-dd}|{ThisYearStart.AddYears(1):yyyy-MM-dd}" },
                { "Last Year", $"{LastYearStart:yyyy-MM-dd}|{ThisYearStart:yyyy-MM-dd}" }
            }); } }
            public static (string GroupName, Dictionary<string, string> GroupItems) CustomerStatus { get { return ("CustomerStatus", new Dictionary<string, string> 
            {
                { "All", "" },
                { "Active", "1" },
                { "Inactive", "0" }
            }); } }
        }
        public clsAccountActivityReports()
        {
            AccountID = -1;
            TransactionCount = 0;
            TotalDebit = 0;
            TotalCredit = 0;
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MinValue;
        }


        public clsAccountActivityReports(int customerReportID, int customerID, DateTime reportDate, short reportTypeID, int accountID, byte transactionCount, double totalDebit, double totalCredit, DateTime fromDate, DateTime toDate)
             : base(customerReportID, customerID, reportTypeID, reportDate)
        {
            AccountID = accountID;
            TransactionCount = transactionCount;
            TotalDebit = totalDebit;
            TotalCredit = totalCredit;
            FromDate = fromDate;
            ToDate = toDate;
            TargetAccount = clsAccounts.FindByID(accountID);
        }


        public static clsAccountActivityReports Find(int accountID, DateTime requestedDate)
        {
            int ReportID = -1;


            byte transactionCount = 0;
            double totalDebit = 0;
            double totalCredit = 0;
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            bool found = clsAccountActivityReports_DAL.Find(accountID, requestedDate, ref ReportID, ref transactionCount, ref totalDebit, ref totalCredit, ref fromDate, ref toDate);

            var ReportHeader = clsCustomerReports_Main.Find(ReportID);
            clsAccountActivityReports report = null;
            if (found && ReportHeader != null)
            {

                report = new clsAccountActivityReports(ReportHeader.CustomerReportID, ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, accountID, transactionCount, totalDebit, totalCredit, fromDate, toDate);
                
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(report), report.CustomerReportID), found && ReportHeader != null, (_sectionKey, $"Read customer account activity report record for account: {accountID}"));
            }

            return report;
        }


        private static DataTable FilterReports(int? customerID, int? accountID, DateTime? fromDate, DateTime? toDate, byte? minTransactions, double? minDebit, double? minCredit, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;

            dt = clsAccountActivityReports_DAL.FilterReports(customerID, accountID, fromDate, toDate, minTransactions, minDebit, minCredit, pageNumber, pageSize, out totalRows);

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }



        public static DataTable ListAll(byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterReports(null, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List All customer account activity report Records"));
            return dt;
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterReports(customerID, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer account activity report Records by customer id [{customerID}]"));
            return dt;
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short availablePages)
        {

            DataTable dt = FilterReports(null, accountID, null, null, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer account activity report Records by account id [{accountID}]"));
            return dt;
        }

        public static DataTable FilterByDateRange(DateTime fromDate, DateTime toDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = FilterReports(null, null, fromDate, toDate, null, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer account activity report Records by Date range from[{fromDate}] to [{toDate}]"));
            return dt;
        }

        public static DataTable FilterByMinTransactions(byte minTransactions, byte pageNumber, byte pageSize, out short availablePages)
        {

            DataTable dt = FilterReports(null, null, null, null, minTransactions, null, null, pageNumber, pageSize, out availablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer account activity report Records by minimum transaction count[{minTransactions}]"));
            return dt;
        }

        private delegate DataTable FilterDelegate(string term, byte pageNumber, byte pageSize, out short availablePages);

        private static Dictionary<string, FilterDelegate> _filterActions ;
        private static  Dictionary<string, FilterDelegate> _FilterActions
        {
            get
            {
                if(_filterActions == null)
                {
                    _filterActions = new Dictionary<string, FilterDelegate>
                    {

                        {Filter_Mapping.CustomerID.valueMember,
                            (string term, byte page, byte size, out short pages) =>
                            {
                                if(int.TryParse(term, out int customerID))
                                    return FilterByCustomerID(customerID, page, size, out pages);
                                else
                                    return ListAll(page, size, out pages);
                            }
                        },
                        {Filter_Mapping.AccountID.valueMember,
                            (string term,byte page,byte size, out short pages) =>
                            {
                                if(int.TryParse(term, out int accountID))
                                    return FilterByAccountID(accountID, page, size, out pages);
                                else
                                    return ListAll(page, size, out pages);
                            }
                        },

                        {Filter_Mapping.DateRange.valueMember,(string term,byte page,byte size, out short pages) =>

                            {
                                var dates = term.Split('|');
                                if (dates.Length == 2 &&DateTime.TryParse(dates[0], out DateTime fromDate) && DateTime.TryParse(dates[1], out DateTime toDate))
                                {
                                    return FilterByDateRange(fromDate, toDate, page, size, out pages);
                                }else
                                    return ListAll(page, size, out pages);
                                }
                        },

                        {Filter_Mapping.MinTransactions.valueMember,(string term,byte page,byte size, out short pages) =>
                            {
                                if(byte.TryParse(term, out byte minTransactions))
                                    return FilterByMinTransactions(minTransactions, page, size, out pages);
                                else
                                    return ListAll(page, size, out pages);
                            }
                        },
                        
                        {Filter_Mapping.All.valueMember,(string term,byte page,byte size, out short pages) => ListAll(page, size, out pages) }

                    };
                }
                return _filterActions;
            }

        }




        public static DataTable FilterAccountActivityReports
              (
                    string column,
                    string term,
                    byte pageNumber,
                    byte pageSize,
                    out short availablePages
              )
        {
            term = term?.Trim();

            if(_FilterActions.TryGetValue(column, out FilterDelegate filterAction))
                return filterAction(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }

    } 
}
