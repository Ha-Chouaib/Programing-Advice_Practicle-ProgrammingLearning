using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsBalanceStatementReports : clsCustomerReports_Main
    {
       
        public int AccountID { get; set; }
        public clsAccounts TargetAccount { get;set; }
        public double OpeningBalance { get; set; }
        public double ClosingBalance { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public clsBalanceStatementReports()
        {
            AccountID = -1;
            OpeningBalance = 0;
            ClosingBalance = 0;
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MinValue;
        }

        public clsBalanceStatementReports(int customerReportID, int customerID, DateTime reportDate, short reportTypeID, int accountID, double openingBalance, double closingBalance, DateTime fromDate, DateTime toDate)
             : base(customerReportID, customerID, reportTypeID, reportDate)
        {
            AccountID = accountID;
            TargetAccount = clsAccounts.FindByID(accountID);
            OpeningBalance = openingBalance;
            ClosingBalance = closingBalance;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public static clsBalanceStatementReports Find(int customerID, int accountID)
        {
            int ReportID = -1;
            double openingBalance = 0;
            double closingBalance = 0;
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            bool found = clsBalanceStatementReports_DAL.Find(customerID, accountID,ref ReportID, ref openingBalance, ref closingBalance, ref fromDate, ref toDate);

            var ReportHeader = clsCustomerReports_Main.Find(ReportID);
            if (found && ReportHeader != null)
            {
                return new clsBalanceStatementReports(ReportHeader.CustomerReportID, ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, accountID, openingBalance, closingBalance, fromDate, toDate);
            }
            else
            {
                return null;
            }
        }

        public static DataTable FilterReports(int? customerID, int? accountID, DateTime? fromDate, DateTime? toDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;

            dt = clsBalanceStatementReports_DAL.FilterReports(customerID, accountID, fromDate, toDate, pageNumber, pageSize, out totalRows);

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(customerID, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, accountID, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByDateRange(DateTime? fromDate, DateTime? toDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, null, fromDate, toDate, pageNumber, pageSize, out availablePages);
        }

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) CustomerID { get; private set; } = ("CustomerID", "Customer ID");
            public static (string valueMember, string DisplayMember) AccountID { get; private set; } = ("AccountID", "Account ID");
            public static (string valueMember, string DisplayMember) DateRange { get; private set; } = ("DateRange", "Date Range");
        }
        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            private static DateTime Today => DateTime.Today;
            private static DateTime ThisMonthStart => new DateTime(Today.Year, Today.Month, 1);
            private static DateTime LastMonthStart => ThisMonthStart.AddMonths(-1);
            private static DateTime ThisYearStart => new DateTime(Today.Year, 1, 1);
            private static DateTime LastYearStart => ThisYearStart.AddYears(-1);

            public static (string GroupName, Dictionary<string, string> GroupItems) DateRange
            {
                get
                {
                    return (Filter_Mapping.DateRange.valueMember,
                        new Dictionary<string, string>
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

            public static (string GroupName, Dictionary<string, string> GroupItems) CustomerStatus
            {
                get
                {
                    return ("customerstatus",
                        new Dictionary<string, string>
                        {
                    { "All", "" },
                    { "Active", "1" },
                    { "Inactive", "0" }
                        });
                }
            }
        }

        private delegate DataTable FilterDelegate(string term, byte pageNumber, byte pageSize, out short availablePages);
        private static Dictionary<string, FilterDelegate> _filterAction;
        private static Dictionary<string, FilterDelegate> _FilterAction
        {
            get
            {
                if (_filterAction == null)
                {
                    _filterAction = new Dictionary<string, FilterDelegate>
                    {
                        { Filter_Mapping.All.valueMember, (string term,byte page,byte size,out short pages)=> ListAll(page,size,out pages) },
                        { Filter_Mapping.CustomerID.valueMember,  (string term,byte page,byte size,out short pages)=>
                            {
                                if(int.TryParse(term, out int custID))
                                    return FilterByCustomerID(custID, page, size, out pages);
                                return ListAll(page,size,out pages);
                            }
                        },
                        { Filter_Mapping.AccountID.valueMember,  (string term,byte page,byte size,out short pages)=>
                            {
                                if(int.TryParse(term, out int accID))
                                    return FilterByAccountID(accID, page, size, out pages);
                                return ListAll(page,size,out pages) ;
                            }
                        },
                        { Filter_Mapping.DateRange.valueMember,  (string term,byte page,byte size,out short pages)=>
                            {
                                var dates = term.Split('|');
                                if (dates.Length == 2 &&DateTime.TryParse(dates[0], out DateTime fromDate) && DateTime.TryParse(dates[1], out DateTime toDate))
                                {
                                    return FilterByDateRange(fromDate, toDate, page, size, out pages);
                                }else
                                    return ListAll(page, size, out pages);

                            }
                        }
                };
            }
                return _filterAction;
            }
        }

        public static DataTable FilterBalanceStatementReports
            (
            string column,
            string term,
            byte pageNumber,
            byte pageSize,
            out short availablePages
            )
        {
            
            term = term?.Trim();
            if(_FilterAction.TryGetValue(column, out FilterDelegate filteraction))
            {
                return filteraction(term, pageNumber, pageSize, out availablePages);
            }
            return ListAll(pageNumber, pageSize, out availablePages);
           
        }

    }

}
