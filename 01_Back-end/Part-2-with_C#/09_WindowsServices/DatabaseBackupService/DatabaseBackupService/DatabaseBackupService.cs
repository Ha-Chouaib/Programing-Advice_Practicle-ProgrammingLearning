using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using System.Threading.Tasks;

namespace DatabaseBackupService
{
    public partial class DatabaseBackupService : ServiceBase
    {
        
        public DatabaseBackupService()
        {
            InitializeComponent();
            CanShutdown = true;
            CanPauseAndContinue = true;
            CanStop = true;


        }
        private Timer backupTimer;
        private bool isBackupRunning = false;

        public void ScheduleTimer()
        {
            // Parse interval from settings (in minutes)
            if (!double.TryParse(clsSettings.ScheduleTime, out double intervalMinutes))
            {
                clsSettings.LogAction("Invalid ScheduleTime setting, using default 60 minutes.");
                intervalMinutes = 60;
            }

            // Create the timer
            backupTimer = new Timer
            {
                Interval = intervalMinutes * 60 * 1000, // convert minutes to milliseconds
                AutoReset = true,                      // repeat automatically
                Enabled = true
            };

            backupTimer.Elapsed += async (sender, e) =>
            {
                if (isBackupRunning)
                {
                    clsSettings.LogAction("Previous backup still running. Skipping this interval.");
                    return;
                }

                try
                {
                    isBackupRunning = true;
                    await Task.Run(() => PerformBackup());
                }
                finally
                {
                    isBackupRunning = false;
                }
            };

            backupTimer.Start();
            clsSettings.LogAction($"Backup timer scheduled every {intervalMinutes} minutes.");
        }

        private void PerformBackup()
        {
            // Placeholder: we will implement the actual backup next
            clsSettings.LogAction("PerformBackup() called — implement backup logic here.");
        }
            
        
        protected override void OnStart(string[] args)
        {
            clsSettings.LogAction("Database Backup Service started.");
            clsSettings.InitializeSettings();
        }

        protected override void OnStop()
        {
        }

        public void StartInConsole()
        {
            OnStart(null);
            Console.WriteLine("Press Enter to stop the service...");
            Console.ReadLine();
            OnStop();
            Console.ReadKey();

        }
    }
}
