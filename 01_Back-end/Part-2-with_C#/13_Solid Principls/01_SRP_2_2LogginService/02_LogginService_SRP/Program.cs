namespace _02_LogginService_SRP
{
    public class LoggingService
    {
        public enum enLoggingType { ToFile, ToEventLog, ToDatabase }
        Dictionary<enLoggingType, Action<string>>? ContainerloggingStrategies;
        Dictionary<enLoggingType, Action<string>> LoggingStrategies
        {
            get 
            {
                if (ContainerloggingStrategies == null)
                {
                    ContainerloggingStrategies = new Dictionary<enLoggingType, Action<string>>();
                    ContainerloggingStrategies.Add(enLoggingType.ToFile, clslFileLoggingService.Log);
                    ContainerloggingStrategies.Add(enLoggingType.ToEventLog, clsEventLogLoggingService.Log);
                    ContainerloggingStrategies.Add(enLoggingType.ToDatabase, clsDataBaseLoggingService.Log);
                }
                return ContainerloggingStrategies;
            }
        }
        private Action<string>? GetLoggingStrategy(enLoggingType LoggingType)
        {
            if (LoggingStrategies.ContainsKey(LoggingType))
            {
                return LoggingStrategies[LoggingType];
            }
            return null;
        }
        public void Log(string message, enLoggingType LoggingType)
        {
            var loggingStrategy = GetLoggingStrategy(LoggingType);
            if (loggingStrategy != null)
            {
                loggingStrategy(message);
            }
          
        }

      



    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the LoggingService
            LoggingService LoggingService = new LoggingService();

            // Log to File
            LoggingService.Log("Error Occured line xxx.", LoggingService.enLoggingType.ToFile);

            // Log to Event Log
            LoggingService.Log("Error Occured line xxx.", LoggingService.enLoggingType.ToEventLog);

            // Log to Database
            LoggingService.Log("Error Occured line xxx.", LoggingService.enLoggingType.ToDatabase);

            Console.ReadKey();
        }
    }
}
