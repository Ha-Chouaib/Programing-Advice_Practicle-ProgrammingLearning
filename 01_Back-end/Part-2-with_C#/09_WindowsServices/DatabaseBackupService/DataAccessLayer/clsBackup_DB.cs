using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class clsBackup_DB
    {
        public static  string ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public static string DataBaseName = ConfigurationManager.AppSettings["DBName"];

       
        public static bool BackupDatabase(string backupPath, string DataBaseName)
        {
            string Query = $"BACKUP DATABASE [{DataBaseName}] TO DISK = N'{backupPath}' WITH NOFORMAT, NOINIT," +
                $" NAME = N'{DataBaseName}-Full Database Backup', SKIP, STATS = 10";
            bool  result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                    result = true;
                }
             
            }
            catch (SqlException sqlEx)
            {
                // Log the SQL exception (implementation depends on your logging framework)
                result = false;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging framework)
                result = false;
            }

            return result;
        }
    }
}
