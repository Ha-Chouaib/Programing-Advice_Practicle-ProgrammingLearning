using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsCustomerSummaryReports
    {
        int CustomerID { get; set; }
        byte TotalAccounts { get; set; }
        byte ActiveAccounts { get; set; }
        double TotalBalance { get; set; }
        DateTime LastActivityDate { get; set; }
        bool CustomerStatus { get; set; }

        clsCustomerSummaryReports()
        {
            this.CustomerID = -1;
            this.TotalAccounts = 0;
            this.ActiveAccounts = 0;
            this.TotalBalance = 0;
            this.LastActivityDate = DateTime.MinValue;
            this.CustomerStatus = false;
        }
        clsCustomerSummaryReports(int CustomerID, byte TotalAccounts, byte ActiveAccounts, double TotalBalance, DateTime LastActivityDate, bool CustomerStatus)
        {
            this.CustomerID = CustomerID;
            this.TotalAccounts = TotalAccounts;
            this.ActiveAccounts = ActiveAccounts;
            this.TotalBalance = TotalBalance;
            this.LastActivityDate = LastActivityDate;
            this.CustomerStatus = CustomerStatus;
        }
        public static clsCustomerSummaryReports Find(int CustomerID)
        {
            byte TotalAccounts = 0;
            byte ActiveAccounts = 0;
            double TotalBalance = 0;
            DateTime LastActivityDate = DateTime.MinValue;
            bool CustomerStatus = false;
            if (clsCustomerSummaryReportsDAL.Find(CustomerID, ref TotalAccounts, ref ActiveAccounts, ref TotalBalance, ref LastActivityDate, ref CustomerStatus))
            {
                return new clsCustomerSummaryReports(CustomerID, TotalAccounts, ActiveAccounts, TotalBalance, LastActivityDate, CustomerStatus);
            }
            else
                return null;
        }
        public static DataTable FilterReports(int? CustomerID, byte? ActiveAccounts, DateTime? LastActivityDate, bool? CustomerStatus, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable result = new DataTable();
            int TotalRecords = 1;
            result = clsCustomerSummaryReportsDAL.FilterReports(CustomerID,ActiveAccounts,LastActivityDate,CustomerStatus, pageNumber, pageSize, out TotalRecords);
            AvailablePages = (short)Math.Ceiling((double)TotalRecords / pageSize);
            return result;
        }
        public static DataTable ListAll(byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByCustomerID(int CustomerID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(CustomerID, null, null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByActiveAccountsStatus(byte? ActiveAccounts, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, ActiveAccounts, null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByLastActivityDate(DateTime? LastActivityDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, LastActivityDate, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByCustomerStatus(bool? CustomerStatus, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, CustomerStatus, pageNumber, pageSize, out AvailablePages);
        }   
    }
}
