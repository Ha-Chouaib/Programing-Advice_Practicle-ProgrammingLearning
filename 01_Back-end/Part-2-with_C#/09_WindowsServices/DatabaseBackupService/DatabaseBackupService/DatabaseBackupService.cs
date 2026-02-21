using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DatabaseBackupService
{
    public partial class DatabaseBackupService : ServiceBase
    {
        
        public DatabaseBackupService()
        {
            InitializeComponent();
            CanPauseAndContinue = true;
            CanStop = true;
            clsSettings.InitializeSettings();


        }
        private System.Timers.Timer backupTimer;

        private CancellationTokenSource _cts;
        private Task _runningTask;

        public void ScheduleTimer()
        {
            // Parse interval from settings (in minutes)
            if (!double.TryParse(clsSettings.ScheduleTime, out double intervalMinutes))
            {
                clsSettings.LogAction("Invalid ScheduleTime setting, using default 60 minutes.");
                intervalMinutes = 60;
            }

            // Create the timer
            backupTimer = new  System.Timers.Timer
            {
                Interval = intervalMinutes * 60 * 1000, // convert minutes to milliseconds
                AutoReset = true,                      // repeat automatically
                Enabled = true
            };

            backupTimer.Elapsed += (sender, e) =>
            {

                if (_runningTask != null && !_runningTask.IsCompleted)
                {
                    clsSettings.LogAction("Previous backup still running. Skipping this interval.");
                    return;
                }

                _runningTask = Task.Run(() => PerformBackup(_cts.Token));
            };

            backupTimer.Start();
            clsSettings.LogAction($"Backup timer scheduled every {intervalMinutes} minutes.");
        }

                private void PerformBackup(CancellationToken token)
        {
            try
            {
                if (token.IsCancellationRequested)
                {
                    clsSettings.LogAction("Backup canceled before starting.");
                    return;
                }

                clsSettings.LogAction("Backup started.");

                string backupFile = Path.Combine(
                    clsSettings.BackupDirectoryPath,
                    $"{clsSettings.DatabaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak");

                if (token.IsCancellationRequested)
                {
                    clsSettings.LogAction("Backup canceled.");
                    return;
                }

                bool result = clsBackup_DB.BackupDatabase(
                    clsSettings.ConnectionString,
                    backupFile,
                    clsSettings.DatabaseName);

                if (result)
                    clsSettings.LogAction("Backup completed successfully.");
                else
                    clsSettings.LogAction("Backup failed.");
            }
            catch (Exception ex)
            {
                clsSettings.LogAction("Backup error: " + ex.Message);
            }
        }


        protected override void OnStart(string[] args)
        {
            _cts = new CancellationTokenSource();

            clsSettings.LogAction("Database Backup Service started.");

            ScheduleTimer();
        }

        protected override void OnPause()
        {
            clsSettings.LogAction("Database Backup Service paused.");

            backupTimer?.Stop();
        }
        protected override void OnContinue()
        {
            clsSettings.LogAction("Database Backup Service resumed.");
            backupTimer?.Start();
        }
        protected override void OnStop()
        {
            clsSettings.LogAction("Database Backup Service stopping...");


            backupTimer?.Stop();
            backupTimer?.Dispose();
            _cts?.Cancel();

             _runningTask?.Wait(TimeSpan.FromSeconds(30));
            clsSettings.LogAction("Database Backup Service stopped.");
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
