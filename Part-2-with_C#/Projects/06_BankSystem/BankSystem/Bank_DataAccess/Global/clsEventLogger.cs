using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsEventLogger
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
    }
}
