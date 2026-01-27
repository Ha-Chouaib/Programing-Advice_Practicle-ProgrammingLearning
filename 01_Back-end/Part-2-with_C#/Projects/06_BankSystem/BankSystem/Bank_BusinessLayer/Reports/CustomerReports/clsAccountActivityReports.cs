using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsAccountActivityReports : clsCustomerReports_Main
    {
        
        public int AccountID { get;private set; }
        public byte TransactionCount { get;private set; }
        public double TotalDebit { get;private set; }
        public double TotalCredit { get;private set; }
        public DateTime FromDate { get;private set; }
        public DateTime ToDate { get;private set; }

       
        public clsAccountActivityReports()
        {
            AccountID = -1;
            TransactionCount = 0;
            TotalDebit = 0;
            TotalCredit = 0;
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MinValue;
        }

       
        public clsAccountActivityReports(int customerReportID, int customerID,DateTime reportDate,short reportTypeID, int accountID, byte transactionCount, double totalDebit, double totalCredit, DateTime fromDate, DateTime toDate)
             : base(customerReportID,customerID,reportTypeID,reportDate)
        {
            AccountID = accountID;
            TransactionCount = transactionCount;
            TotalDebit = totalDebit;
            TotalCredit = totalCredit;
            FromDate = fromDate;
            ToDate = toDate;
        }

        
        public static clsAccountActivityReports Find(int accountID, DateTime requestedDate)
        {
            int ReportID = -1;
          

            byte transactionCount = 0;
            double totalDebit = 0;
            double totalCredit = 0;
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            bool found = clsAccountActivityReports_DAL.Find(accountID, requestedDate,ref ReportID, ref transactionCount, ref totalDebit, ref totalCredit, ref fromDate, ref toDate);

            var ReportHeader = clsCustomerReports_Main.Find(ReportID);
            if (found && ReportHeader != null)
            {
              
                return new clsAccountActivityReports(ReportHeader.CustomerReportID,ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, accountID, transactionCount, totalDebit, totalCredit, fromDate, toDate);
            }
            else
            {
                return null; 
            }
        }

       
        public static DataTable FilterReports(int? customerID, int? accountID, DateTime? fromDate, DateTime? toDate, byte? minTransactions, double? minDebit, double? minCredit, byte pageNumber, byte pageSize, out short availablePages)
        {
            DataTable dt = new DataTable();
            int totalRows = 0;

            dt = clsAccountActivityReports_DAL.FilterReports(customerID, accountID, fromDate, toDate, minTransactions, minDebit, minCredit, pageNumber, pageSize, out totalRows);

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);
            return dt;
        }

       

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByCustomerID(int customerID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(customerID, null, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByAccountID(int accountID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, accountID, null, null, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByDateRange(DateTime fromDate, DateTime toDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, null, fromDate, toDate, null, null, null, pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByMinTransactions(byte minTransactions, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, null, null, null, minTransactions, null, null, pageNumber, pageSize, out availablePages);
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
            column = column?.Trim().ToLower();
            term = term?.Trim();

            switch (column)
            {
                case "customerid":
                    return FilterByCustomerID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "accountid":
                    return FilterByAccountID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "daterange":
                case "fromdate-to":
                    // expecting term format: "yyyy-MM-dd|yyyy-MM-dd"
                    var dates = term.Split('|');
                    if (dates.Length == 2 &&
                        DateTime.TryParse(dates[0], out DateTime fromDate) &&
                        DateTime.TryParse(dates[1], out DateTime toDate))
                    {
                        return FilterByDateRange(fromDate, toDate, pageNumber, pageSize, out availablePages);
                    }
                    break;

                case "mintransactions":
                    return FilterByMinTransactions(byte.Parse(term), pageNumber, pageSize, out availablePages);
            }

            return ListAll(pageNumber, pageSize, out availablePages);
        }

    }
}
