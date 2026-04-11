using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_1_OCP_LogginService
{
    public class clsLoggingService
    {

        ILoggin Logging;
        public clsLoggingService(ILoggin loggingService)
        {
            Logging = loggingService;
        }

        public void Log(string message) => Logging.Log(message);
    }
}
