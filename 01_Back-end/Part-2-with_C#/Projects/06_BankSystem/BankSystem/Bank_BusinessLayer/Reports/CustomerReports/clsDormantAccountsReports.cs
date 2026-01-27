using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsDormantAccountsReports : clsCustomerReports_Main
    {
        public int AccountID { get;private set; }
        public int TransactionID { get;private set; }
        public DateTime LastTransactionDate { get; private set; }
        public byte DormantMonths { get;private set; }

        public clsDormantAccountsReports()
        {
            this.AccountID = -1;
            this.CustomerID = -1;
            this.TransactionID = -1;
            this.LastTransactionDate = DateTime.MinValue;
            this.DormantMonths = 0;
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
            if (found && ReportHeader != null)
            {
                return new clsDormantAccountsReports(ReportHeader.CustomerReportID, ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, accountID, -1, transactionID, lastTransactionDate, dormantMonths);
            }
            else
            {
                return null;
            }
        }        
        public static DataTable FilterReports(int? AccountID, int? CustomerID, DateTime? ReportDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;

            dt = clsDormantAccountsReports_DAL.FilterReports(AccountID, CustomerID, ReportDate, pageNumber, pageSize, out totalRows);

            AvailablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

        
        public static DataTable ListAll(byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, pageNumber, pageSize, out AvailablePages);
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(accountID, null, null, pageNumber, pageSize, out AvailablePages);
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, customerID, null, pageNumber, pageSize, out AvailablePages);
        }

        public static DataTable FilterByReportDate(DateTime reportDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, reportDate, pageNumber, pageSize, out AvailablePages);
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
                    return FilterByAccountID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "customerid":
                    return FilterByCustomerID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "reportdate":
                    return FilterByReportDate(DateTime.Parse(term), pageNumber, pageSize, out availablePages);

                default:
                    return ListAll(pageNumber, pageSize, out availablePages);
            }
        }

    }
}
