using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBackupService
{
    public class clsSettings
    {
        clsSettings()
        {
           
        }
        public static string ConnectionString { get; set; }
        public static string MainDirectoryPath { get; set; }
        public static string BackupDirectoryPath { get; set; }
        public static string LogDirectoryPath { get; set; }
        public static string DatabaseName { get; set; }
        public static string ScheduleTime { get; set; }
        public static string LogFileName { get; set; }
        public static string LogFilePath { get; set; }


        public static string MainDirectoryPath_Default { get; set; }
        public static string BackupDirectoryPath_Default { get; set; }
        public static string LogDirectoryPath_Default { get; set; }
        public static string ScheduleTime_Default { get; set; }
        public static string LogFileName_Default { get; set; }
        public static string LogFilePath_Default { get; set; }
        
        public static void EnsureDirectoriesExist(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        public static void LogAction(string message)
        {
            string logMessage = $"[{DateTime.Now:G}] {message}\n";
            Console.WriteLine(logMessage);
            File.AppendAllText(LogFilePath, logMessage);
        }
        public static void InitializeSettings()
        {
            MainDirectoryPath_Default = @"C:\DatabaseBackupService";
            BackupDirectoryPath_Default = @"C:\DatabaseBackupService\DatabaseBackups";
            LogDirectoryPath_Default = @"C:\DatabaseBackupService\BackupLogs";
            ScheduleTime_Default = "60"; // IN Minutes
            LogFileName_Default = "BackupServiceLog.txt";
            LogFilePath_Default = Path.Combine(LogDirectoryPath_Default, LogFileName_Default);

            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"]?.ConnectionString;
            MainDirectoryPath = ConfigurationManager.AppSettings["MainFolder"] ?? MainDirectoryPath_Default;
            BackupDirectoryPath = ConfigurationManager.AppSettings["BackupRepository"] ?? BackupDirectoryPath_Default;
            LogDirectoryPath = ConfigurationManager.AppSettings["LogFolder"] ?? LogDirectoryPath_Default;
            DatabaseName = ConfigurationManager.AppSettings["DBName"];
            ScheduleTime = ConfigurationManager.AppSettings["BackupScheduleMinutes"] ?? ScheduleTime_Default;
            LogFileName = ConfigurationManager.AppSettings["LogFileName"] ?? LogFileName_Default;
            EnsureDirectoriesExist(MainDirectoryPath);
            EnsureDirectoriesExist(BackupDirectoryPath);
            EnsureDirectoriesExist(LogDirectoryPath);
            LogFilePath = Path.Combine(LogDirectoryPath, LogFileName);
        }



    }
}
