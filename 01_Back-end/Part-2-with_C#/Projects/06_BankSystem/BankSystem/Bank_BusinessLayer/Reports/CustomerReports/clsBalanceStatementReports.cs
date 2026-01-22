using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsBalanceStatementReports
    {
       
        public int CustomerID { get; set; }
        public int AccountID { get; set; }
        public double OpeningBalance { get; set; }
        public double ClosingBalance { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public clsBalanceStatementReports()
        {
            CustomerID = -1;
            AccountID = -1;
            OpeningBalance = 0;
            ClosingBalance = 0;
            FromDate = DateTime.MinValue;
            ToDate = DateTime.MinValue;
        }

        public clsBalanceStatementReports(int customerID, int accountID, double openingBalance, double closingBalance, DateTime fromDate, DateTime toDate)
        {
            CustomerID = customerID;
            AccountID = accountID;
            OpeningBalance = openingBalance;
            ClosingBalance = closingBalance;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public static clsBalanceStatementReports Find(int customerID, int accountID)
        {
            double openingBalance = 0;
            double closingBalance = 0;
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            bool found = clsBalanceStatementReports_DAL.Find(customerID, accountID, ref openingBalance, ref closingBalance, ref fromDate, ref toDate);

            if (found)
            {
                return new clsBalanceStatementReports(customerID, accountID, openingBalance, closingBalance, fromDate, toDate);
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
    
    }

}
