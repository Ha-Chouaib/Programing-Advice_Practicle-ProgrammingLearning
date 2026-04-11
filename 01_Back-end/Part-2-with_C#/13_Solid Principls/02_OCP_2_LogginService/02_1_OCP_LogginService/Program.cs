using _02_LogginService_OCP;

namespace _02_1_OCP_LogginService
{
    internal class Program
    {
       

            static void Main(string[] args)
            {
                // Create an instance of the LoggingService
                clsLoggingService LoggingService = new clsLoggingService(new clslFileLoggingService());

                // Log to File
                LoggingService.Log("Error Occured line xxx.");

                LoggingService = new clsLoggingService(new clsEventLogLoggingService());
                // Log to Event Log
                LoggingService.Log("Error Occured line xxx.");
                
                LoggingService = new clsLoggingService(new clsDataBaseLoggingService());
                // Log to Database
                LoggingService.Log("Error Occured line xxx.");

                Console.ReadKey();
            }
        }
}
