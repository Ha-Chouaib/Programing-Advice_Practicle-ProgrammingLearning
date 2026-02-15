using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatabaseBackupService;

namespace DataAccessLayer
{
    public class clsBackup_DB
    {
        
       
        public static bool BackupDatabase(string ConnectionString ,string backupPath, string DataBaseName)
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
                clsSettings.LogAction("SQL Error during backup: " + sqlEx.Message);
                result = false;
            }
            catch (Exception ex)
            {
                clsSettings.LogAction("Error during backup: " + ex.Message);
                result = false;
            }

            return result;
        }
    }
}
