using Bank_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankSystem
{
    public class clsGlobal_BL
    {
        public static string EventLogSourceName = "BankSystem_App";
        private static clsUser _loggedInUser;
        public static clsUser LoggedInUser
        {
            get
            {
                if (_loggedInUser == null)
                    _loggedInUser = clsUser.FindUserByID(1);
                return _loggedInUser;
            }
        }

        public static void ClearSession() => _loggedInUser = null;
        public static class MachineInfo
        {
            public static string GetMachineName()
            {
                return Environment.MachineName;
            }
            public static string GetOSVersion()
            {
                return Environment.OSVersion.ToString();
            }
            public static string GetProcessorCount()
            {
                return Environment.ProcessorCount.ToString();
            }
            private static string _cachedLocalIP;
            public static string GetLocalIPAddress()
            {
                try
                {
                    if (string.IsNullOrEmpty(_cachedLocalIP) || _cachedLocalIP == "Unavailable")
                    {
                        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                        {
                            socket.Connect("8.8.8.8", 65530);
                            var endPoint = socket.LocalEndPoint as IPEndPoint;
                            _cachedLocalIP = endPoint.Address.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    clsGlobal_BL.LogHelper.LogError($"Failed to get local IP address: {ex.Message}");
                    _cachedLocalIP = "Unavailable";
                }
                return _cachedLocalIP;

            }
        }
        public static class UserSession
        {
            public static string SessionID { get; private set; }
            public static DateTime LoginTime { get; private set; }

            public static void Start()
            {
                SessionID = Guid.NewGuid().ToString("N");
                LoginTime = DateTime.UtcNow;
            }

            public static void End()
            {
                SessionID = null;
            }
        }
        public static class LogHelper
        {
            public static void LogError(string message)
            {
                EventLog.WriteEntry(EventLogSourceName, message, EventLogEntryType.Error);
            }
            public static void LogWarning(string message)
            {
                EventLog.WriteEntry(EventLogSourceName, message, EventLogEntryType.Warning);
            }
            public static void LogInformation(string message)
            {
                EventLog.WriteEntry(EventLogSourceName, message, EventLogEntryType.Information);
            }
            
        }
    }
}