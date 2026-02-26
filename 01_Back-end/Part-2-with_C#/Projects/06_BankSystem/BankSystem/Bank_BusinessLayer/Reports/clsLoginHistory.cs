using Bank_DataAccess;
using Bank_DataAccess.Reports;
using BankSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.Reports.clsAuditUserActions;

namespace Bank_BusinessLayer.Reports
{
    public class clsLoginHistory
    {
       

        int LoginID { get; set; }
        DateTime LoginDate { get; set; }
        int LoggedInUserID { get; set; }
        string SessionID { get; set; }
        string MachineName { get; set; }

        private static string _sectionKey => "Login-HISTORY-REPORTS";


        clsLoginHistory()
        {
            LoginID = -1;
            LoginDate = DateTime.Now;
            LoggedInUserID = -1;
            SessionID = string.Empty;
            MachineName = string.Empty;
        }

        clsLoginHistory
        (int LoginID, int LoggedInUserID, DateTime LoginDate, string SessionID, string MachineName)
        {
            this.LoginID = LoginID;
            this.LoginDate = LoginDate;
            this.LoggedInUserID = LoggedInUserID;
            this.SessionID = SessionID;
            this.MachineName = MachineName;
        }

        public bool AuditUserLogins()
        {
            this.LoginID = clsLoggingHistory_DAL.AddNewLog(this.LoggedInUserID,this.LoginDate,this.SessionID,this.MachineName);
            return this.LoginID > 0;
        }

        public static clsLoginHistory Find(int loginID)
        {
            DateTime loginDate = DateTime.MinValue;
            int userID = -1;
            string sessionID = string.Empty;
            string machineName = string.Empty;

            bool found = clsLoggingHistory_DAL.Find(
                loginID,
                ref userID,
                ref loginDate,
                ref sessionID,
                ref machineName
            );

            if (!found)
            {
                return null;
            }
            if(clsUtil_BL.CallerInspector.IsExternalNamespaceCall())
                clsGlobal.LogInformation($"[{clsGlobal_BL.LoggedInUser.UserName}] Reads {_sectionKey} For report with Id {loginID}");

            return new clsLoginHistory(
                loginID,
                userID,
                loginDate,
                sessionID,
                machineName
            );
        }
        private static DataTable FilterLiginsHistory(
            int? loginID,
            int? loggedInUserID,
            DateTime? loginDate,
            string sessionID,
            string machineName,
            string userName,
            string roleName,
            byte pageNumber,
            byte pageSize,
            out short availablePages)
        {
            int totalRows = 0;

            DataTable dt = clsLoggingHistory_DAL.FilterLoginsHistory(
                loginID,
                loggedInUserID,
                loginDate,
                sessionID,
                machineName,
                userName,
                roleName,
                pageNumber,
                pageSize,
                out totalRows
            );

            availablePages = (short)Math.Ceiling((double)totalRows / pageSize);

            return dt;
        }

        public static DataTable ListAll(byte pageNumber, byte pageSize, out short availablePages)
        {
            clsGlobal.LogInformation($"[{clsGlobal_BL.LoggedInUser.UserName}] List All {_sectionKey}");

            return FilterLiginsHistory(null, null, null, null, null,null,null,
                pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByLoginID(int loginID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(loginID, null, null, null, null, null, null,
                pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByUserID(int userID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(null, userID, null, null, null, null, null,
                pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByDate(DateTime loginDate, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(null, null, loginDate, null, null, null, null,
                pageNumber, pageSize, out availablePages);
        }

        public static DataTable FilterByMachine(string machineName, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(null, null, null, null, machineName, null, null,
                pageNumber, pageSize, out availablePages);
        }
        public static DataTable FilterByUserName(string userName, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(null, null, null, null, null, userName, null,
                pageNumber, pageSize, out availablePages);
        }
        public static DataTable FilterByRoleName(string roleName, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(null, null, null, null, null, null, roleName,
                pageNumber, pageSize, out availablePages);
        }
        public static DataTable FilterBySessionID(string sessionID, byte pageNumber, byte pageSize, out short availablePages)
        {
            return FilterLiginsHistory(null, null, null, sessionID, null, null, null,
                pageNumber, pageSize, out availablePages);
        }

        [Serializable]
        public static class Filter_Mapping
        {
            public static (string valueMember, string DisplayMember) All
                => ("All", "All");

            public static (string valueMember, string DisplayMember) LoginID
                => ("LoginID", "Login ID");

            public static (string valueMember, string DisplayMember) LoggedInUserID
                => ("LoggedInUserID", "User ID");

            public static (string valueMember, string DisplayMember) UserName
                => ("UserName", "User Name");

            public static (string valueMember, string DisplayMember) RoleName
                => ("RoleName", "Role Name");

            public static (string valueMember, string DisplayMember) LoginDate
                => ("LoginDate", "Login Date");

            public static (string valueMember, string DisplayMember) SessionID
                => ("SessionID", "Session ID");

            public static (string valueMember, string DisplayMember) MachineName
                => ("MachineName", "Machine Name");
        }

        private delegate DataTable FilterDelegate(string term, byte page, byte size, out short pages);

        private static Dictionary<string, FilterDelegate> _filterActions;
        private static Dictionary<string, FilterDelegate> _FilterActions
        {
            get
            {
                if (_filterActions == null)
                {
                    _filterActions = new Dictionary<string, FilterDelegate>
            {
                { Filter_Mapping.LoginID.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByLoginID(id, page, size, out pages);
                        return FilterByLoginID(-1, page, size, out pages);
                    }
                },
                { Filter_Mapping.LoggedInUserID.valueMember, (string term,byte page,byte size, out short pages) =>
                    {
                        if (int.TryParse(term, out int id))
                            return FilterByUserID(id, page, size, out pages);
                        return  FilterByUserID(-1, page, size, out pages);
                    }
                },
                { Filter_Mapping.UserName.valueMember, (string term,byte page,byte size, out short pages) => FilterByUserName(term, page, size, out pages)},
                { Filter_Mapping.RoleName.valueMember, (string term,byte page,byte size, out short pages) => FilterByRoleName(term, page, size, out pages)},
                { Filter_Mapping.SessionID.valueMember, (string term,byte page,byte size, out short pages) => FilterBySessionID(term, page, size, out pages)},
                { Filter_Mapping.MachineName.valueMember, (string term,byte page,byte size, out short pages) => FilterByMachine(term, page, size, out pages)},
                { Filter_Mapping.All.valueMember, (string term,byte page,byte size, out short pages) => ListAll(page, size, out pages) }
            };
                }
                return _filterActions;
            }
        }

        public static DataTable FilterLoginHistory(string column, string term, byte pageNumber, byte pageSize, out short availablePages)
        {
            term = term?.Trim();

            if (_FilterActions.TryGetValue(column, out FilterDelegate filterAction))
                return filterAction(term, pageNumber, pageSize, out availablePages);

            return ListAll(pageNumber, pageSize, out availablePages);
        }

    }
}
