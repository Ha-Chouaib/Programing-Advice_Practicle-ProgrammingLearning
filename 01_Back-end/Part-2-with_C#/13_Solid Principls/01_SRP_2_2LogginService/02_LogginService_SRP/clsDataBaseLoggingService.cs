using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LogginService_SRP
{
    public class clsDataBaseLoggingService
    {

        public static void Log(string message)
        {
            Console.WriteLine($"\nLog to Database: {message}");
        }
    }
}
