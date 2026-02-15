using Bank_DataAccess.Reports.CustomerReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports.CustomerReports
{
    public class clsCustomerReports_Main
    {

        public int CustomerReportID { get; protected set; }
        public int CustomerID { get;protected set; }
        public clsCustomer Customer { get; protected set; }
        public short ReportTypeID { get;protected set; }
        public DateTime ReportDate { get;protected set; }

        protected clsCustomerReports_Main()
        {
            CustomerReportID = -1;
            CustomerID = -1;
            ReportTypeID = -1;
            ReportDate = DateTime.MinValue;
        }
        protected clsCustomerReports_Main(int CustomerReportID, int customerID, short reportTypeID, DateTime reportDate)
        {
            this.CustomerReportID = CustomerReportID;
            CustomerID = customerID;
            ReportTypeID = reportTypeID;
            ReportDate = reportDate;
            Customer = clsCustomer.FindCustomerByID(customerID);
        }

        protected  static clsCustomerReports_Main Find(int customerReportID)
        {
            int customerID = -1;
            short reportTypeID = -1;
            DateTime reportDate = DateTime.MinValue;

            if (clsCustomerReports_Main_DAL.Find(customerReportID, ref customerID, ref reportTypeID, ref reportDate))
            {
                return new clsCustomerReports_Main(customerReportID, customerID, reportTypeID, reportDate);
            }else
            {
                return null;
            }
        }
    }
}
