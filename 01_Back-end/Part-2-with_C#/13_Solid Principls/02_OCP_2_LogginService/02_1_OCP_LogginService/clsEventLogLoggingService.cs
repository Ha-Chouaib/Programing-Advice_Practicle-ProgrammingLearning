using _02_1_OCP_LogginService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LogginService_OCP
{
    public class clsEventLogLoggingService:ILoggin
    {

        public void Log(string message)
        {
            Console.WriteLine($"\nLog to Event Log: {message}");
        }
    }
}
