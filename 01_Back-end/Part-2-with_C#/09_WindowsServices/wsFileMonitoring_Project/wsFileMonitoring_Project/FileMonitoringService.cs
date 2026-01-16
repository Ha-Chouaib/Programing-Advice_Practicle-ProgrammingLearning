using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;

namespace wsFileMonitoring_Project
{
    public partial class FileMonitoringService : ServiceBase
    {
        private string _MainDirectory;
        private string _SourceDirectory;
        private string _DestinationDirectory;
        private string _LogDirectory;

        private string _TargetFile;

        private string _LogFileName;
        private string _LogFilePath;
        public FileMonitoringService()
        {
            InitializeComponent();

            CanPauseAndContinue = true;
            CanStop = true;


            InitializeRequiredDirectories();
            _LogFilePath = Path.Combine(_LogDirectory, _LogFileName);
        }

        private void _ConfigureRequiredDirectories()
        {
            _MainDirectory = ConfigurationManager.AppSettings["MainDirecory"];
            _SourceDirectory = ConfigurationManager.AppSettings["SourceDirectory"];
            _DestinationDirectory = ConfigurationManager.AppSettings["DestinationDirectory"];
            _LogDirectory = ConfigurationManager.AppSettings["LogDirectory"];
        }
        private void InitializeRequiredDirectories()
        {
            _ConfigureRequiredDirectories();

            _CreateDirectoryIfNoExists(_MainDirectory);
            _CreateDirectoryIfNoExists(_SourceDirectory);
            _CreateDirectoryIfNoExists(_DestinationDirectory);
            _CreateDirectoryIfNoExists(_LogDirectory);

        }
        private void _CreateDirectoryIfNoExists(string TargetDirectory)
        {
            if (!Directory.Exists(TargetDirectory))
            {
                Directory.CreateDirectory(TargetDirectory);
            }
        }
        private void _LogAction(string message)
        {
            string logMessage = $"[{DateTime.Now:G}] {message}\n";
            File.AppendAllText(_LogFilePath, logMessage);
        }
        private void _ConvertFileNameToDUID(string FilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FilePath))
                    throw new ArgumentException("File name cannot be null or empty.", nameof(FilePath));

                string extension = Path.GetExtension(FilePath);
                string guid = Guid.NewGuid().ToString("N");

                string NewName = Path.Combine(Directory.GetParent(FilePath).FullName, $"{guid}{extension}");
                File.Move(FilePath , NewName);
            }
            catch (Exception e)
            {
                _LogAction($"Error: {e.Message}");
            }
            
        }
        private string RenameFileToGuid(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File does not exist.", filePath);

            try
            {
                string directory = Path.GetDirectoryName(filePath);
                string extension = Path.GetExtension(filePath);
                string newFileName = $"{Guid.NewGuid():N}{extension}";
                string newPath = Path.Combine(directory, newFileName);

                File.Move(filePath, newPath);

                return newPath;
            }
            catch (IOException ex)
            {
                _LogAction($"IO error while renaming file: {ex.Message}");
                throw;
            }
        }
        private void _ChangeFileLocation(string sourcePath, string DestinationPath)
        {

            File.Move(sourcePath, DestinationPath);
            File.Delete(sourcePath);
            _LogAction($"< Target File Moved > [ {sourcePath} ==> {DestinationPath}");
        }
       
        
        protected override void OnStart(string[] args)
        {
            _LogAction("Service Started");

        }

        protected override void OnStop()
        {
            _LogAction("Service Stopped");
        }

        protected override void OnPause()
        {
            _LogAction("Service Paused");
        }

        protected override void OnContinue()
        {
            _LogAction("Service Resumed");
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
