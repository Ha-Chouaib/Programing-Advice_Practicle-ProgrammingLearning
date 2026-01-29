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
        public static DataTable FilterReports(int? CustomerID, byte? ActiveAccounts, DateTime? LastActivityFrom,DateTime? LastActivityTo, bool? CustomerStatus, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable result = new DataTable();
            int TotalRecords = 1;
            result = clsCustomerSummaryReportsDAL.FilterReports(CustomerID,ActiveAccounts,LastActivityFrom,LastActivityTo,CustomerStatus, pageNumber, pageSize, out TotalRecords);
            AvailablePages = (short)Math.Ceiling((double)TotalRecords / pageSize);
            return result;
        }
        public static DataTable ListAll(byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null,null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByCustomerID(int CustomerID, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(CustomerID, null, null, null,null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByActiveAccountsStatus(byte? ActiveAccounts, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, ActiveAccounts, null, null,null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByLastActivityDate(DateTime? LastActivityfrom, DateTime? LastActivityTo, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, LastActivityfrom, LastActivityTo, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByCustomerStatus(bool? CustomerStatus, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, null,CustomerStatus, pageNumber, pageSize, out AvailablePages);
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

                                if (DateTime.TryParse(dateParts[0], out DateTime fromDate))
                                    from = fromDate;

                                if (DateTime.TryParse(dateParts[1], out DateTime toDate))
                                    to = toDate;
                            }
                            else
                            {
                                // Single date → treat as one day range
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
