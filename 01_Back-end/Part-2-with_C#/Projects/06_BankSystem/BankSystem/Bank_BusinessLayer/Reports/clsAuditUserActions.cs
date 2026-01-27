using Bank_DataAccess.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer.Reports
{
    public class clsAuditUserActions
    {

        public int ReportId { get; set; }
        public int UserId { get; set; }
        public string ActionKey { get; set; }
        public DateTime ReportDate { get; set; }
        public bool Succeeded { get; set; }
        public int? EntityId { get; set; }
        public string Metadata { get; set; }

        public sealed class AuditPerformedBy
        {
            public int UserID { get; set; }
            public string UserName { get; set; }
            public string Role { get; set; }
        }
        public sealed class AuditAction
        {
            public string ActionKey {  set; get; }
            public string Description { set; get; }
        }
        public sealed class AuditTarget
        {
            public string EntityName { get; set; }
            public int? EntityID { get; set; }

        }
        public sealed class AuditChanges
        {
            public object Before { get; set; }
            public object After { get; set; }
        }
        public sealed class AuditResult
        {
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }
        public sealed class AuditContext
        {
            public AuditPerformedBy PerformedBy { get; set; }
            public AuditAction Action { get; set; }
            public AuditTarget Target { get; set; }
            public AuditChanges Changes { get; set; }
            public AuditResult Result { get; set; }

            public byte Version { get; set; } = 1;
        }

        public clsAuditUserActions()
        {
            this.ReportId = -1;
            this.UserId = -1;
            this.ActionKey = string.Empty;
            this.ReportDate = DateTime.MinValue;
            this.EntityId = null;
            this.Succeeded = false;
            this.Metadata = string.Empty;
        }

        private clsAuditUserActions(int ReprtID,int UserID,string ActionKey,DateTime ReportDate,int? EntityID,bool Succeed, string MetaData)
        {
            this.ReportId = ReprtID;
            this.UserId = UserID;
            this.ActionKey = ActionKey;
            this.ReportDate = ReportDate;
            this.EntityId = EntityID;
            this.Succeeded = Succeed;
            this.Metadata = MetaData;
        }

        public bool AuditLogger()
        {
            this.ReportId = clsUserActivityReports_DAL.InsertUserActivityReport(this.UserId,this.ActionKey,this.EntityId,this.Succeeded,this.Metadata);

            return this.ReportId != -1;
        }
        public static clsAuditUserActions Find(int ReportID)
        {
            int UserId = -1;
            string ActionKey = string.Empty;
            DateTime ReportDate = DateTime.MinValue;
            int? EntityId = null;
            bool Succeeded = false;
            string Metadata = string.Empty;
            if (clsUserActivityReports_DAL.FindReportByID(ReportID, ref UserId, ref ActionKey, ref ReportDate, ref EntityId, ref Succeeded, ref Metadata))
            {
                return new clsAuditUserActions(ReportID, UserId, ActionKey, ReportDate, EntityId, Succeeded, Metadata);
            }
            else
                return null;
        }
        
        public static DataTable FilterReports(int? userId, string actionKey, bool? succeeded, DateTime? fromDate, DateTime? toDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable result = new DataTable();
            int TotalRecords = 1;
            result = clsUserActivityReports_DAL.FilterReports(userId, actionKey, succeeded, fromDate, toDate, pageNumber,pageSize, out TotalRecords);

            AvailablePages = (short)Math.Ceiling((double)TotalRecords / pageSize);
            return result;
        }

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByUserID(int userId, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(userId,null,null,null,null,pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByActionKey(string ActionKey, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, ActionKey, null, null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterBySuccess(bool Success, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, Success, null, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByFromDate(DateTime fromDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, fromDate, null, pageNumber, pageSize, out AvailablePages);
        }
        public static DataTable FilterByToDate(DateTime toDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            return FilterReports(null, null, null, null, toDate, pageNumber, pageSize, out AvailablePages);
        }

        public static DataTable FilterUserActivityReports(
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
                case "userid":
                    return FilterByUserID(int.Parse(term), pageNumber, pageSize, out availablePages);

                case "actionkey":
                    return FilterByActionKey(term, pageNumber, pageSize, out availablePages);

                case "success":
                case "succeeded":
                    return FilterBySuccess(bool.Parse(term), pageNumber, pageSize, out availablePages);

                case "fromdate":
                    return FilterByFromDate(DateTime.Parse(term), pageNumber, pageSize, out availablePages);

                case "todate":
                    return FilterByToDate(DateTime.Parse(term), pageNumber, pageSize, out availablePages);

                default:
                    return ListAll(pageNumber, pageSize, out availablePages);
            }
        }


    }
}
