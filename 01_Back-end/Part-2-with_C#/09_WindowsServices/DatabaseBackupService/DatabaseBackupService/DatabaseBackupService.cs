using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
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

            clsSettings.InitializeSettings();

        }
        
        public void ScheduleTimer()
        {

        }
        protected override void OnStart(string[] args)
        {
            clsSettings.LogAction("Database Backup Service started.");
            // Here you would add code to schedule the backup task based on ScheduleTime
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
