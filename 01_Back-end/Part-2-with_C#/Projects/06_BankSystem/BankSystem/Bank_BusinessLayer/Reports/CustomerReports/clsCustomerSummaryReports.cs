using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsCustomerSummaryReports : clsCustomerReports_Main
    {
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
        clsCustomerSummaryReports(int customerReportID, int customerID, DateTime reportDate, short reportTypeID, byte TotalAccounts, byte ActiveAccounts, double TotalBalance, DateTime LastActivityDate, bool CustomerStatus)
            :base(customerReportID, customerID, reportTypeID, reportDate)
        {
            this.TotalAccounts = TotalAccounts;
            this.ActiveAccounts = ActiveAccounts;
            this.TotalBalance = TotalBalance;
            this.LastActivityDate = LastActivityDate;
            this.CustomerStatus = CustomerStatus;
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
            if (found && ReportHeader != null)
            {
                return new clsCustomerSummaryReports(ReportHeader.CustomerReportID, ReportHeader.CustomerID, ReportHeader.ReportDate, ReportHeader.ReportTypeID, TotalAccounts, ActiveAccounts, TotalBalance, LastActivityDate, CustomerStatus);
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
                    return FilterByCustomerID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "activeaccounts":
                    return FilterByActiveAccountsStatus(byte.Parse(term), pageNumber, pageSize, out availablePages);

                case "lastactivitydate":
                    return FilterByLastActivityDate(DateTime.Parse(term), pageNumber, pageSize, out availablePages);

                case "customerstatus":
                    return FilterByCustomerStatus(bool.Parse(term), pageNumber, pageSize, out availablePages);

                default:
                    return ListAll(pageNumber, pageSize, out availablePages);
            }
        }

    }
}
