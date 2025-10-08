using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    class DataAccessSettings
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["BankConnectionString"].ConnectionString;
        public static string EventLogSourceName = "BankSystem_App";

       
    }
}
