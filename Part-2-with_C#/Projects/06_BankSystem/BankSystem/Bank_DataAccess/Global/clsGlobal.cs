using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsGlobal
    {
        public static void LogError(string message)
        {
            EventLog.WriteEntry(DataAccessSettings.EventLogSourceName,message,EventLogEntryType.Error);
        }
        public static void LogWarning(string message)
        {
            EventLog.WriteEntry(DataAccessSettings.EventLogSourceName, message, EventLogEntryType.Warning);
        }
        public static void LogInformation(string message)
        {
            EventLog.WriteEntry(DataAccessSettings.EventLogSourceName, message, EventLogEntryType.Information);
        }
        public static T SafeGet<T>(SqlDataReader rdr, string column, T defaultValue)
        {
            if (rdr[column] == DBNull.Value)
                return defaultValue;

            return (T)Convert.ChangeType(rdr[column], typeof(T));
        }
    }
}
