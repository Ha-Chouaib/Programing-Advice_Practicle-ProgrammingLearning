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

        private string _default_MainDirectory;
        private string _default_SourceDirectory;
        private string _default_DestinationDirectory;
        private string _default_LogDirectory;
        private string _defaultLogFileName;

        private string _LogFileName;
        private string _LogFilePath;

        private FileSystemWatcher _FileSystemWatcher;
        readonly ConcurrentQueue<string> TargetFiles = new ConcurrentQueue<string>();
        private readonly AutoResetEvent _signal = new AutoResetEvent(false);
        private CancellationTokenSource _cts;

        private readonly ManualResetEventSlim _pauseEvent = new ManualResetEventSlim(true);

        public FileMonitoringService()
        {
            InitializeComponent();

            CanPauseAndContinue = true;
            CanStop = true;

            _default_MainDirectory = @"C:\FileMonitoringService";
            _default_SourceDirectory = @"c:\FileMonitoringService\SourceFolder";
            _default_DestinationDirectory = @"c:\FileMonitoringService\DestinationFolder";
            _default_LogDirectory = @"c:\FileMonitoringService\LogFolder";
            _defaultLogFileName = "ServiceLog.txt";

            InitializeRequiredDirectories();
            _LogFilePath = Path.Combine(_LogDirectory, _LogFileName??_defaultLogFileName );


        }

        private void _ConfigureRequiredDirectories()
        {
            _MainDirectory = ConfigurationManager.AppSettings["MainFolder"];
            _SourceDirectory = ConfigurationManager.AppSettings["SourceDirectory"];
            _DestinationDirectory = ConfigurationManager.AppSettings["DestinationDirectory"];
            _LogDirectory = ConfigurationManager.AppSettings["LogDirectory"];

           

        }
        private void InitializeRequiredDirectories()
        {
            _ConfigureRequiredDirectories();

            _SetDefaultIfNoConfigured(ref _MainDirectory, _default_MainDirectory);
            _SetDefaultIfNoConfigured(ref _SourceDirectory, _default_SourceDirectory);
            _SetDefaultIfNoConfigured(ref _DestinationDirectory, _default_DestinationDirectory);
            _SetDefaultIfNoConfigured(ref _LogDirectory, _default_LogDirectory);

            _CreateDirectoryIfNoExists(_MainDirectory);
            _CreateDirectoryIfNoExists(_SourceDirectory);
            _CreateDirectoryIfNoExists(_DestinationDirectory);
            _CreateDirectoryIfNoExists(_LogDirectory);
            _LogFileName = ConfigurationManager.AppSettings["LogFileName"];
        }
        private void _SetDefaultIfNoConfigured(ref string directoryPath, string defaultPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryPath = defaultPath;
                _LogAction($"Directory not configured. Using default: {defaultPath}");
            }
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
            Console.WriteLine(logMessage);
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
        private async Task WaitForFileAsync(string path, CancellationToken token)
        {
            const int maxAttempts = 10;
            const short delayMs = 500;

            for (int i = 0; i < maxAttempts; i++)
            {
                token.ThrowIfCancellationRequested();

                try
                {
                    using (FileStream stream = File.Open(
                        path,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.None))
                    {
                        return; // File is ready
                    }
                }
                catch (IOException)
                {
                    await Task.Delay(delayMs, token);
                }
            }

            throw new IOException($"File remained locked: {path}");
        }

        private void OnFileInserted(object sender, FileSystemEventArgs e)
        {

            TargetFiles.Enqueue(e.FullPath);
            _signal.Set();
        }
        private void StartWorker()
        {
            Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    _signal.WaitOne();
                    _pauseEvent.Wait(_cts.Token);

                    while (TargetFiles.TryDequeue(out var file))
                    {
                        _pauseEvent.Wait(_cts.Token);
                        try
                        {
                            await WaitForFileAsync(file, _cts.Token);

                            var guidPath = _RenameFileToGuid(file);
                            var destinationPath = _ChangeFilePath(guidPath, _DestinationDirectory);

                            File.Move(guidPath, destinationPath);

                            _LogAction($"File moved: {file} → {destinationPath}");
                        }
                        catch (OperationCanceledException)
                        {
                            return; 
                        }
                        catch (Exception ex)
                        {
                            _LogAction($"Error processing {file}: {ex.Message}");
                        }
                    }
                }
            }, _cts.Token);
        }

        protected override void OnStart(string[] args)
        {
            _cts = new CancellationTokenSource();

            Process process = Process.GetCurrentProcess();
            process.PriorityClass = ProcessPriorityClass.BelowNormal;

            _LogAction("Service Started");

            _FileSystemWatcher = new FileSystemWatcher
            {
                Path = _SourceDirectory,
                Filter = "*.*",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
                IncludeSubdirectories = false
            };

            _FileSystemWatcher.Created += OnFileInserted;
            _FileSystemWatcher.EnableRaisingEvents = true;
            StartWorker();

        }
      
        protected override void OnStop()
        {
            _cts.Cancel();
            _FileSystemWatcher.EnableRaisingEvents = false;
            _FileSystemWatcher.Dispose();
            _LogAction("Service Stopped");
        }

        protected override void OnPause()
        {
            _pauseEvent.Reset(); // block worker
            _FileSystemWatcher.EnableRaisingEvents = false;
            _LogAction("Service Paused");
        }

        protected override void OnContinue()
        {
            _pauseEvent.Set(); // resume worker
            _FileSystemWatcher.EnableRaisingEvents = true;

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
