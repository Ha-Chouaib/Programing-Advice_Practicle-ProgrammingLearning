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
    public class clsDormantAccountsReports : clsCustomerReports_Main
    {
        public int AccountID { get;private set; }
        public int TransactionID { get;private set; }
        public DateTime LastTransactionDate { get; private set; }
        public byte DormantMonths { get;private set; }

        private static string _sectionKey => "CUSTOMER-DORMANT-ACCOUNT-REPORT";
        public clsDormantAccountsReports()
        {
            this.AccountID = -1;
            this.CustomerID = -1;
            this.TransactionID = -1;
            this.LastTransactionDate = DateTime.MinValue;
            this.DormantMonths = 0;
        }

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All
            { get { return ("All", "All"); } }

            public static (string valueMember, string DisplayMember) CustomerID
            { get; private set; } = ("CustomerID", "Customer ID");

            public static (string valueMember, string DisplayMember) AccountID
            { get; private set; } = ("AccountID", "Account ID");
        }

        public clsDormantAccountsReports(int customerReportID, int customerID, DateTime reportDate, short reportTypeID, int AccountID, int CustomerID, int TransactionID, DateTime LastTransactionDate, byte DormantMonths)
            : base(customerReportID, customerID, reportTypeID, reportDate)
        {
            this.AccountID = AccountID;
            this.CustomerID = CustomerID;
            this.TransactionID = TransactionID;
            this.LastTransactionDate = LastTransactionDate;
            this.DormantMonths = DormantMonths;
        }

        public static int GenerateCustomerDormantAccountsReport()
        {
            return clsDormantAccountsReports_DAL._GenerateCustomerDormantAccountsReport();
        }

        
        public new static clsDormantAccountsReports Find(int ReportID)
        {
            int accountID = -1;
            int transactionID = -1;
            DateTime lastTransactionDate = DateTime.MinValue;
            byte dormantMonths = 0;
            bool found =clsDormantAccountsReports_DAL.Find(ReportID, ref accountID, ref transactionID, ref lastTransactionDate, ref dormantMonths);

            var ReportHeader = clsCustomerReports_Main.Find(ReportID);
            clsDormantAccountsReports report = null;
            if (found && ReportHeader != null)
            {
                report = new clsDormantAccountsReports(ReportHeader.CustomerReportID, ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, accountID, -1, transactionID, lastTransactionDate, dormantMonths);
            }
            if (clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
            {
                AuditingHelper.AuditReadRecordOperation((clsUtil_BL.HandleObjectsHelper.GetObjectLegalPropertiesOnly(report), report.CustomerReportID), found && ReportHeader != null, (_sectionKey, $"Read customer dormant account report with id: [{ReportID}]"));
            }
            return report;
        }        
       
        private static DataTable FilterReports(int? AccountID, int? CustomerID, DateTime? ReportDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;

            dt = clsDormantAccountsReports_DAL.FilterReports(AccountID, CustomerID, ReportDate, pageNumber, pageSize, out totalRows);

            AvailablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }   
        public static DataTable ListAll(byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List All customer dormant accounts reports"));
            return dt;
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(accountID, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer dormant accounts reports by account id [{accountID}]"));
            return dt;
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, customerID, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer dormant accounts reports by customer id [{customerID}]"));
            return dt;
        }

        public static DataTable FilterByReportDate(DateTime reportDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, reportDate, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter customer dormant accounts reports by report date [{reportDate}]"));
            return dt;
        }
        public static DataTable FilterDormantAccountsReports
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
                case "accountid":
                    if(int.TryParse(term, out int accountId))
                        return FilterByAccountID(accountId, pageNumber, pageSize, out availablePages);
                    break;

                case "customerid":
                    if(int.TryParse(term, out int customerId))
                        return FilterByCustomerID(customerId, pageNumber, pageSize, out availablePages);
                    break;
                default:
                    return ListAll(pageNumber, pageSize, out availablePages);
            }
            return ListAll(pageNumber, pageSize, out availablePages);

        }

    }
}
