using Bank_DataAccess.Reports;
using BankSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.clsUser;

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

        private static string _sectionKey => "USER-ACTIVITY-REPORT";

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
        public sealed class AuditTargetEntity
        {
            public object  EntityRecord { get; set; }
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
        
        public sealed class AuditMachineInfo
        {
            public string IPAddress { get; set; }
            public string SessionID { get; set; }
            public string MachineName { get; set; }
            public string OSVersion { get; set; }

        }

        [Serializable]
        public sealed class AuditContext
        {
            public AuditContext(AuditPerformedBy performedBy, AuditAction action, AuditTargetEntity target, AuditChanges changes, AuditResult result,AuditMachineInfo machineInfo ,byte version)
            {
                PerformedBy = performedBy;
                Action = action;
                Target = target;
                Changes = changes;
                Result = result;
                MachineInfo = machineInfo;
                Version = version;
            }

            public AuditPerformedBy PerformedBy { get; set; }
            public AuditAction Action { get; set; }
            public AuditTargetEntity Target { get; set; }
            public AuditChanges Changes { get; set; }
            public AuditMachineInfo MachineInfo { get; set; }
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

        public clsAuditUserActions(int ReprtID,int UserID,string ActionKey,DateTime ReportDate,int? EntityID,bool Succeed, string MetaData)
        {
            this.ReportId = ReprtID;
            this.UserId = UserID;
            this.ActionKey = ActionKey;
            this.ReportDate = ReportDate;
            this.EntityId = EntityID; 
            this.Succeeded = Succeed;
            this.Metadata = MetaData;
        }
        
        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All { get; private set; } = ("All", "All");
            public static (string valueMember, string DisplayMember) UserID { get; private set; } = ("UserID", "User ID");
            public static (string valueMember, string DisplayMember) ActionKey { get; private set; } = ("ActionKey", "Action Key");
            public static (string valueMember, string DisplayMember) Succeeded { get; private set; } = ("Succeeded", "Success");
            public static (string valueMember, string DisplayMember) FromDate { get; private set; } = ("FromDate", "From Date");
            public static (string valueMember, string DisplayMember) ToDate { get; private set; } = ("ToDate", "To Date");
        }

        [Serializable]
        public static class Filter_ByGroupsMapping
        {
            private static DateTime Today => DateTime.Today;
            private static DateTime ThisMonthStart => new DateTime(Today.Year, Today.Month, 1);
            private static DateTime LastMonthStart => ThisMonthStart.AddMonths(-1);
            private static DateTime ThisYearStart => new DateTime(Today.Year, 1, 1);
            private static DateTime LastYearStart => ThisYearStart.AddYears(-1);

            public static (string GroupName, Dictionary<string, string> GroupItems) SuccessStatus
            {
                get
                {
                    return ("Succeeded", new Dictionary<string, string>
            {
                { "All", "" },
                { "Succeeded", "true" },
                { "Failed", "false" }
            });
                }
            }

            public static (string GroupName, Dictionary<string, string> GroupItems) DateRange
            {
                get
                {
                    return ("FromDate-To", new Dictionary<string, string>
            {
                { "All", "" },
                { "Today", Today.ToString("yyyy-MM-dd") },
                { "Yesterday", Today.AddDays(-1).ToString("yyyy-MM-dd") },
                { "Last 7 Days", $"{Today.AddDays(-7):yyyy-MM-dd}|{Today:yyyy-MM-dd}" },
                { "This Month", $"{ThisMonthStart:yyyy-MM-dd}|{ThisMonthStart.AddMonths(1):yyyy-MM-dd}" },
                { "Last Month", $"{LastMonthStart:yyyy-MM-dd}|{ThisMonthStart:yyyy-MM-dd}" },
                { "This Year", $"{ThisYearStart:yyyy-MM-dd}|{ThisYearStart.AddYears(1):yyyy-MM-dd}" },
                { "Last Year", $"{LastYearStart:yyyy-MM-dd}|{ThisYearStart:yyyy-MM-dd}" }
            });
                }
            }
        }

        public static int AuditLogger(int userid,string actionKey,int ? EntityID,bool Succeeded,AuditContext auditContext)
        {
            string Metadata = JsonConvert.SerializeObject(auditContext, Formatting.None);
            return clsUserActivityReports_DAL.InsertUserActivityReport(userid, actionKey, EntityID, Succeeded, Metadata);
        }
        public bool AuditLogger()
        {
            this.ReportId = clsUserActivityReports_DAL.InsertUserActivityReport(this.UserId,this.ActionKey,this.EntityId,this.Succeeded,this.Metadata);

            return this.ReportId != -1;
        }
        
        public static class AuditingHelper
        {
            public class ActionKeys
            {
                public const string Addition = ".CREATE";
                public const string Editing = ".UPDATE";
                public const string Deletion = ".DELETE";
                public const string ReadRecord = ".READ_RECORD";
                public const string ReadRecordsList = ".READ_RECORDS-LIST";
                public const string Validation = ".VALIDATION_CHECK";
            }

            public static void AuditUserActivity(AuditAction action, (object TargetEntity,int?EntityID) EntityWrapper, AuditChanges Changes, AuditResult auditResult)
            {
                var LoggedInUser = clsGlobal_BL.LoggedInUser;

                var PerformedByUser = new AuditPerformedBy();
                PerformedByUser.UserID = LoggedInUser.UserID;
                PerformedByUser.UserName = LoggedInUser.UserName;
                PerformedByUser.Role = LoggedInUser.Role.RoleName;

                var MachineInfo = new AuditMachineInfo();
                MachineInfo.MachineName = clsGlobal_BL.MachineInfo.GetMachineName();
                MachineInfo.OSVersion = clsGlobal_BL.MachineInfo.GetOSVersion();
                MachineInfo.IPAddress = clsGlobal_BL.MachineInfo.GetLocalIPAddress();
                MachineInfo.SessionID = clsGlobal_BL.UserSession.SessionID;

                var targetEntity = new AuditTargetEntity { EntityRecord = EntityWrapper.TargetEntity};
               

                var AuditContext = new AuditContext(PerformedByUser, action, targetEntity, Changes, auditResult, MachineInfo, 1);
                clsAuditUserActions.AuditLogger(LoggedInUser.UserID, action.ActionKey, EntityWrapper.EntityID, auditResult.Success, AuditContext);

            }
            public static void AuditCreateOperation((object TargetEntity, int? EntityID) EntityWrapper, bool OperationSucceed,( string sectionKey,string SectionDescription)section)
            {
                var action = new clsAuditUserActions.AuditAction();
                action.ActionKey = section.sectionKey + ActionKeys.Addition;
                action.Description = section.SectionDescription;

                var auditResult = new clsAuditUserActions.AuditResult();
                if (OperationSucceed)
                {
                    auditResult.Success = true;
                }
                else
                {
                    auditResult.Success = false;
                    auditResult.ErrorMessage = $"Failed to Create {section.sectionKey.ToLower()} record.";
                }

                AuditUserActivity(action, EntityWrapper, null, auditResult);


            }
            public static void AuditUpdateOperation(bool OperationSucceed,(string SectionKey, string SectionDescription) Section, object oldRecord, object NewRecord, int? EntityID)
            {
                var action = new clsAuditUserActions.AuditAction();
                var auditResult = new clsAuditUserActions.AuditResult();
                var auditchanges = new clsAuditUserActions.AuditChanges();

                action.ActionKey = Section.SectionKey + ActionKeys.Editing;
                action.Description = Section.SectionDescription;

                if (OperationSucceed)
                {
                    auditchanges.Before = oldRecord;
                    auditchanges.After = NewRecord;

                    auditResult.Success = true;
                }
                else
                {
                    auditchanges = null;
                    auditResult.Success = false;
                    auditResult.ErrorMessage = $"Failed to update the {Section.SectionKey.ToLower()} record.";
                }

                if (oldRecord == null && NewRecord == null) auditchanges = null;

                AuditUserActivity(action, (NewRecord,EntityID), auditchanges, auditResult);
            }
            public static void AuditReadRecordOperation((object TargetEntity, int? EntityID) EntityWrapper, bool OperationSucceed, (string SectionKey, string SectionDescription) Section)
            {
                var action = new clsAuditUserActions.AuditAction();
                var auditResult = new clsAuditUserActions.AuditResult();
                action.ActionKey = Section.SectionKey + ActionKeys.ReadRecord;
                action.Description = Section.SectionDescription;

                if (OperationSucceed)
                {
                    auditResult.Success = true;
                }
                else
                {
                    auditResult.Success = false;
                    auditResult.ErrorMessage = $"Failed to read {Section.SectionKey.ToLower()} record.";
                }
                AuditUserActivity(action, EntityWrapper, null, auditResult);
            }
            public static void AuditReadRecordsListOperation(bool OperationSucceed, (string SectionKey, string SectionDescription) Section)
            {
                var action = new clsAuditUserActions.AuditAction();
                var auditResult = new clsAuditUserActions.AuditResult();
                action.ActionKey = Section.SectionKey + ActionKeys.ReadRecordsList;
                action.Description = Section.SectionDescription;
                if (OperationSucceed)
                {
                    auditResult.Success = true;
                }
                else
                {
                    auditResult.Success = false;
                    auditResult.ErrorMessage = $"Failed to read {Section.SectionKey.ToLower()} records list.";
                }
                AuditUserActivity(action, (null,null), null, auditResult);

            }
            public static void AuditValidationOperation((object TargetEntity, int? EntityID) EntityWrapper, bool OperationSucceed, (string SectionKey, string SectionDescription) Section)
            {
                var action = new clsAuditUserActions.AuditAction();
                var auditResult = new clsAuditUserActions.AuditResult();
                action.ActionKey = Section.SectionKey + ActionKeys.Validation;
                action.Description = Section.SectionDescription;
                if (OperationSucceed)
                {
                    auditResult.Success = true;
                }
                else
                {
                    auditResult.Success = false;
                    auditResult.ErrorMessage = $"The Target {Section} Entity state Does not much the conditions !";
                }
                AuditUserActivity(action,EntityWrapper, null, auditResult);
            }
            public static void AuditDeletionOperation((object TargetEntity, int? EntityID) EntityWrapper, bool OperationSucceed, (string SectionKey, string SectionDescription) Section)
            {
                var action = new clsAuditUserActions.AuditAction();
                var auditResult = new clsAuditUserActions.AuditResult();
                var auditchanges = new clsAuditUserActions.AuditChanges();
                action.ActionKey = Section.SectionKey + ActionKeys.Deletion;
                action.Description = Section.SectionDescription;
                if (OperationSucceed)
                {
                   
                    auditchanges.Before = EntityWrapper.TargetEntity;
                    auditchanges.After = null;
                    auditResult.Success = true;
                }
                else
                {
                    auditchanges = null;
                    auditResult.Success = false;
                    auditResult.ErrorMessage = $"Failed to delete {Section.SectionKey} record.";
                }
                AuditUserActivity(action, EntityWrapper, auditchanges, auditResult);
            }

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
            DataTable dt = FilterReports(null, null, null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, "List all user activity reports"));
            return dt;
        }
        public static DataTable FilterByUserID(int userId, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(userId, null, null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter user activity reports by user id [{userId}]"));
            return dt;
        }
        public static DataTable FilterByActionKey(string ActionKey, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, ActionKey, null, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter user activity reports by action key [{ActionKey}]"));
            return dt;
        }
        public static DataTable FilterBySuccess(bool Success, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, Success, null, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter user activity reports by actions success [{Success}]"));
            return dt;
        }
        public static DataTable FilterByFromDate(DateTime fromDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, null, fromDate, null, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter user activity reports by date range from date [{fromDate}]"));
            return dt;
        }
        public static DataTable FilterByToDate(DateTime toDate, byte pageNumber, byte pageSize, out short AvailablePages)
        {
            DataTable dt = FilterReports(null, null, null, null, toDate, pageNumber, pageSize, out AvailablePages);
            bool OperationSucceed = dt != null;
            AuditingHelper.AuditReadRecordsListOperation(OperationSucceed, (_sectionKey, $"Filter user activity reports by date range to date [{toDate}]"));
            return dt;
        }
        
        private delegate DataTable FilterDelegate(string term, byte pageNumber, byte pageSize, out short availablePages);

        private static Dictionary<string, FilterDelegate> _filterActions;
        private static Dictionary<string, FilterDelegate> _FilterActions
        {
            get
            {
                if (_filterActions == null)
                {
                    _filterActions = new Dictionary<string, FilterDelegate>
            {
                {
                    Filter_Mapping.UserID.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        int.TryParse(term, out int id) ? FilterByUserID(id, page, size, out pages) : ListAll(page, size, out pages)
                },

                {
                    Filter_Mapping.ActionKey.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        FilterByActionKey(term, page, size, out pages)
                },

                {
                    Filter_Mapping.Succeeded.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        bool.TryParse(term, out bool success) ? FilterBySuccess(success, page, size, out pages) : ListAll(page, size, out pages)
                },

                {
                    Filter_Mapping.FromDate.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        DateTime.TryParse(term, out DateTime dt) ? FilterByFromDate(dt, page, size, out pages) : ListAll(page, size, out pages)
                },

                {
                    Filter_Mapping.ToDate.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        DateTime.TryParse(term, out DateTime dt) ? FilterByToDate(dt, page, size, out pages) : ListAll(page, size, out pages)
                },

                {
                    Filter_Mapping.All.valueMember,
                    (string term, byte page, byte size, out short pages) =>
                        ListAll(page, size, out pages)
                }
            };
                }

                return _filterActions;
            }
        }
        public static DataTable FilterUserActivityReports(string column, string term, byte pageNumber, byte pageSize, out short availablePages)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate action))
                return action(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }


    }
}
