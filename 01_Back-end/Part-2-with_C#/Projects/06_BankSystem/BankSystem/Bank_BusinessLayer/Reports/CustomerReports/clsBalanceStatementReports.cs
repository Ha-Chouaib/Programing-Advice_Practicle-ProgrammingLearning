using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsBalanceStatementReports : clsCustomerReports_Main
    {
       
        public int AccountID { get; set; }
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

        public static DataTable FilterByDateRange(DateTime fromDate, DateTime toDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterReports(null, null, fromDate, toDate, pageNumber, pageSize, out availablePages);
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
            }

            return ListAll(pageNumber, pageSize, out availablePages);
        }

    }

}
