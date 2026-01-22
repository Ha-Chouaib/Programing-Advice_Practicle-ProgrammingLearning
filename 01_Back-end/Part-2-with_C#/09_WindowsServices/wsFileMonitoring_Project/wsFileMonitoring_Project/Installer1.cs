using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace wsFileMonitoring_Project
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;
        public Installer1()
        {
            InitializeComponent();

            serviceProcessInstaller = new ServiceProcessInstaller 
            {
                Account = ServiceAccount.LocalService,

            };
            serviceInstaller = new ServiceInstaller
            {
                ServiceName = "FileMonitoringService",
                DisplayName = "File Monitoring Service",
                StartType = ServiceStartMode.Automatic,

            };


            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
