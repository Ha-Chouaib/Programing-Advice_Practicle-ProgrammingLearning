using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wsFileMonitoring_Project
{
    public partial class FileMonitoringService : ServiceBase
    {
        private string _MainDirectory;
        private string _SourceDirectory;
        private string _DestinationDirectory;
        private string _LogDirectory;

        private string _LogFileName;
        private string _LogFilePath;

        private FileSystemWatcher _FileSystemWatcher;
        readonly ConcurrentQueue<string> TargetFiles = new ConcurrentQueue<string>();
        private readonly AutoResetEvent _signal = new AutoResetEvent(false);
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
            _LogFileName = ConfigurationManager.AppSettings["LogFileName"];
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
        private string _RenameFileToGuid(string filePath)
        {
            

            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

                if (!File.Exists(filePath))
                    throw new FileNotFoundException("File does not exist.", filePath);
                string directory = Path.GetDirectoryName(filePath);
                string extension = Path.GetExtension(filePath);
                string newFileName = $"{Guid.NewGuid():N}{extension}";
                string newPath = Path.Combine(directory, newFileName);

                File.Move(filePath, newPath);
                _LogAction($"Rename File To GUID From[{filePath}] =To=> [{newPath}]");
                return newPath;
            }
            catch (IOException ex)
            {
                _LogAction($"IO error while renaming file: {ex.Message}");
                throw;
            }
        }
        private string _ChangeFilePath(string OldfilePath,string DestinationDirectory)
        {

            string FileName = Path.GetFileName(OldfilePath);
            string NewPath = Path.Combine(DestinationDirectory, FileName);
            return NewPath;
        }
        private void _ChangeFileLocation(string sourcePath, string DestinationPath)
        {

            File.Move(sourcePath, DestinationPath);
            if(File.Exists(sourcePath)) File.Delete(sourcePath); ;
        }
        private void _WaitForFile(string path)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        return;
                    }
                }
                catch
                {
                    Task.Delay(500).Wait();
                }
            }
        }
        private void OnFileInserted(object sender, FileSystemEventArgs e)
        {

            TargetFiles.Enqueue(e.FullPath);
            _signal.Set();
        }
        private void StartWorker()
        {
            Task.Run
                (
                    () =>
                    {
                        while (true)
                        {
                            _signal.WaitOne();


                            StringBuilder CurrentFilePath = new StringBuilder();
                            StringBuilder FilePath_GUID = new StringBuilder();
                            StringBuilder FileDestinationPath = new StringBuilder();

                            while (TargetFiles.TryDequeue(out var currentFilePath))
                            {

                                try
                                {
                                    CurrentFilePath.Append(CurrentFilePath);
                                    _WaitForFile(CurrentFilePath.ToString());

                                    FilePath_GUID.Append(_RenameFileToGuid(CurrentFilePath.ToString()));
                                    FileDestinationPath.Append(_ChangeFilePath(FilePath_GUID.ToString(), _DestinationDirectory));

                                    _ChangeFileLocation(FilePath_GUID.ToString(), FileDestinationPath.ToString());

                                    _LogAction($"< Target File Moved > [ {CurrentFilePath} ==> {FileDestinationPath}");
                                }
                                catch (Exception ex)
                                {
                                    _LogAction($"Error processing file {CurrentFilePath}: {ex.Message}");
                                }
                            }
                        }
                    }
                );
        }

        protected override void OnStart(string[] args)
        {
            Process process = Process.GetCurrentProcess();
            process.PriorityClass = ProcessPriorityClass.BelowNormal;
            _LogAction("Service Started");

            _FileSystemWatcher = new FileSystemWatcher
            {
                Path = _MainDirectory,
                Filter = "*.*",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
            };

            _FileSystemWatcher.Created += OnFileInserted;
            _FileSystemWatcher.EnableRaisingEvents = true;
            StartWorker();

        }
      
        protected override void OnStop()
        {
            _FileSystemWatcher.EnableRaisingEvents = false;
            _FileSystemWatcher.Dispose();
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
