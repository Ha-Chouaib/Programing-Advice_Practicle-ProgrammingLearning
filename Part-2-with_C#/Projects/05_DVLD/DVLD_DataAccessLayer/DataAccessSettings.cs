using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    class DataAccessSettings
    {
        //public static string connectionString = "Server=.;Database=DVLD;User Id=sa;Password=123456"; !! Use App.Config Instead
        public static string connectionString = ConfigurationManager.ConnectionStrings["DVLDConnectionString"].ConnectionString;
        public static string EventLog_SourceName = "DVLD_App";

    }
}
