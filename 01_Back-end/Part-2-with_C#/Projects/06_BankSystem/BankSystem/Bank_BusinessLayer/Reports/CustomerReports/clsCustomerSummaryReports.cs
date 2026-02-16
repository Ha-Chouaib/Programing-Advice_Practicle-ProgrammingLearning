using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsCustomerSummaryReports : clsCustomerReports_Main
    {
        public byte TotalAccounts { get; private set; }
        public byte ActiveAccounts { get; private set; }
        public double TotalBalance { get; private set; }
        public DateTime LastActivityDate { get; private set; }
        public bool CustomerStatus { get; private set; }

        private static string _sectionKey => "CUSTOMER-BALANCE-STATEMENT-REPORT";

        clsCustomerSummaryReports()
        {
            this.CustomerID = -1;
            this.TotalAccounts = 0;
            this.ActiveAccounts = 0;
            this.TotalBalance = 0;
            this.LastActivityDate = DateTime.MinValue;
            this.CustomerStatus = false;
        }
        clsCustomerSummaryReports(int customerReportID, int customerID, DateTime reportDate, short reportTypeID, byte TotalAccounts, byte ActiveAccounts, double TotalBalance, DateTime LastActivityDate, bool CustomerStatus)
            :base(customerReportID, customerID, reportTypeID, reportDate)
        {
            this.TotalAccounts = TotalAccounts;
            this.ActiveAccounts = ActiveAccounts;
            this.TotalBalance = TotalBalance;
            this.LastActivityDate = LastActivityDate;
            this.CustomerStatus = CustomerStatus;
        }
        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All
            { get; private set; } = ("All", "All");

            public static (string valueMember, string DisplayMember) CustomerID
            { get; private set; } = ("CustomerID", "Customer ID");

            public static (string valueMember, string DisplayMember) ActiveAccounts
            { get; private set; } = ("activeaccounts", "Active Accounts Count");

            public static (string valueMember, string DisplayMember) LastActivityDate
            { get; private set; } = ("lastactivitydate", "Last Activity Date");

            public static (string valueMember, string DisplayMember) CustomerStatus
            { get; private set; } = ("customerstatus", "Customer Status");
        }
        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            private static DateTime Today => DateTime.Today;
            private static DateTime ThisMonthStart => new DateTime(Today.Year, Today.Month, 1);
            private static DateTime LastMonthStart => ThisMonthStart.AddMonths(-1);
            private static DateTime ThisYearStart => new DateTime(Today.Year, 1, 1);
            private static DateTime LastYearStart => ThisYearStart.AddYears(-1);

            public static (string GroupName, Dictionary<string, string> GroupItems) LastActivityDate
            {
                get
                {
                    return (Filter_Mapping.LastActivityDate.valueMember,
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
                    return (Filter_Mapping.CustomerStatus.valueMember,
                        new Dictionary<string, string>
                        {
                    { "All", "" },
                    { "Active", "1" },
                    { "Inactive", "0" }
                        });
                }
            }
        }

        public new static clsCustomerSummaryReports Find (int CustomerID)
        {
            int ReportID = -1;
            byte TotalAccounts = 0;
            byte ActiveAccounts = 0;
            double TotalBalance = 0;
            DateTime LastActivityDate = DateTime.MinValue;
            bool CustomerStatus = false;
            bool found = clsCustomerSummaryReportsDAL.Find(CustomerID, ref ReportID, ref TotalAccounts, ref ActiveAccounts, ref TotalBalance, ref LastActivityDate, ref CustomerStatus); 


             var ReportHeader = clsCustomerReports_Main.Find(ReportID);
            clsCustomerSummaryReports report = null;
            if (found && ReportHeader != null)
            {
                report = new clsCustomerSummaryReports(ReportHeader.CustomerReportID, ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, TotalAccounts, ActiveAccounts, TotalBalance, LastActivityDate, CustomerStatus);
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(report), report.CustomerReportID), found && ReportHeader != null, (_sectionKey, $"Read customer Summary report for customer: [{CustomerID}]"));
            }
            return report;
           
        }
        private static DataTable FilterReports(int? CustomerID, byte? ActiveAccounts, DateTime? LastActivityFrom,DateTime? LastActivityTo, bool? CustomerStatus, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable result = new DataTable();
            int TotalRecords = 1;
            result = clsCustomerSummaryReportsDAL.FilterReports(CustomerID,ActiveAccounts,LastActivityFrom,LastActivityTo,CustomerStatus, pageNumber, pageSize, out TotalRecords);
            AvailablePages = (short)Math.Ceiling((double)TotalRecords / pageSize);
            return result;
        }
        public static DataTable ListAll(byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List All customer Summary reports"));
            return dt;
        }
        public static DataTable FilterByCustomerID(int CustomerID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(CustomerID, null, null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer Summary reports by customer id [{CustomerID}]"));
            return dt;
        }
        public static DataTable FilterByActiveAccountsStatus(byte? ActiveAccounts, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, ActiveAccounts, null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer Summary reports by Active accounts count [{ActiveAccounts}]"));
            return dt;
        }
        public static DataTable FilterByLastActivityDate(DateTime? LastActivityfrom, DateTime? LastActivityTo, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, LastActivityfrom, LastActivityTo, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer Summary reports by Date range from[{LastActivityfrom}] to [{LastActivityTo}]"));
            return dt;
        }
        public static DataTable FilterByCustomerStatus(bool? CustomerStatus, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, null, null, CustomerStatus, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer Summary reports by customer status [{CustomerStatus}]"));
            return dt;
        }

        public static DataTable FilterCustomerSummaryReports
            (
            string column,
            string term,
            byte pageNumber,
            byte pageSize,
            out short availablePages
            )
        {
            column = column?.Trim().ToLower();
            term = term?.Trim();

            switch (column)
            {
                case "customerid":
                    if(int.TryParse(term, out int customerID))
                        return FilterByCustomerID(customerID, pageNumber, pageSize, out availablePages);
                    break;

                case "activeaccounts":
                    if(byte.TryParse(term, out byte activeAccounts))
                        return FilterByActiveAccountsStatus(activeAccounts, pageNumber, pageSize, out availablePages);
                    break;

                case "lastactivitydate":
                    {
                        DateTime? from = null;
                        DateTime? to = null;

                        if (!string.IsNullOrWhiteSpace(term))
                        {
                            if (term.Contains("|"))
                            {
                                var dateParts = term.Split('|');


                                if (DateTime.TryParse(dateParts[0], out DateTime fromDate) && DateTime.TryParse(dateParts[1], out DateTime toDate))
                                {
                                    from = fromDate;
                                    to = toDate;
                                }
                                else
                                    break;
                            }
                            else
                            {
                                if (DateTime.TryParse(term, out DateTime date))
                                {
                                    from = date;
                                    to = date.AddDays(1);
                                }
                            }
                        }

                        return FilterByLastActivityDate(from, to, pageNumber, pageSize, out availablePages);
                    }

                case "customerstatus":
                    if(bool.TryParse(term, out bool status))
                        return FilterByCustomerStatus(status, pageNumber, pageSize, out availablePages);
                    break;

                default:
                    return ListAll(pageNumber, pageSize, out availablePages);
            }
            return ListAll(pageNumber, pageSize, out availablePages);
        }

    }
}
