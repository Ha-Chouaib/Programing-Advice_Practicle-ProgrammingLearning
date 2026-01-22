using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsDormantAccountsReports
    {
        // Properties
        public int AccountID { get; set; }
        public int CustomerID { get; set; }
        public int TransactionID { get; set; }
        public DateTime LastTransactionDate { get; set; }
        public byte DormantMonths { get; set; }

        // Default Constructor
        public clsDormantAccountsReports()
        {
            this.AccountID = -1;
            this.CustomerID = -1;
            this.TransactionID = -1;
            this.LastTransactionDate = DateTime.MinValue;
            this.DormantMonths = 0;
        }

        // Parameterized Constructor
        public clsDormantAccountsReports(int AccountID, int CustomerID, int TransactionID, DateTime LastTransactionDate, byte DormantMonths)
        {
            this.AccountID = AccountID;
            this.CustomerID = CustomerID;
            this.TransactionID = TransactionID;
            this.LastTransactionDate = LastTransactionDate;
            this.DormantMonths = DormantMonths;
        }

        // Generate a new Dormant Accounts Report
        public static int GenerateReport()
        {
            return clsDormantAccountsReports_DAL._GenerateCustomerDormantAccountsReport();
        }

        
        public static clsDormantAccountsReports Find(int ReportID)
        {
            int accountID = -1;
            int transactionID = -1;
            DateTime lastTransactionDate = DateTime.MinValue;
            byte dormantMonths = 0;

            if (clsDormantAccountsReports_DAL.Find(ReportID, ref accountID, ref transactionID, ref lastTransactionDate, ref dormantMonths))
            {
                return new clsDormantAccountsReports(accountID, -1, transactionID, lastTransactionDate, dormantMonths);
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

    }
}
