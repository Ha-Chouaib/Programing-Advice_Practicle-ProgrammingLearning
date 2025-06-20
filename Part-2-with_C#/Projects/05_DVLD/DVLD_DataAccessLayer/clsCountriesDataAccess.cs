using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace DVLD_DataAccessLayer
{
    public class clsCountriesDataAccess
    {
        public static bool Find(int CountryID,ref string CountryName )
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT CountryName From Countries WHERE CountryID=@CountryID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            bool IsFound = false;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsFound = true;
                    CountryName = (string)result;
                }

            }
            catch(Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Countries DataAccess: [ Find() By CountryID]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool Find(string CountryName, ref int CountryID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT CountryID From Countries WHERE CountryName=@CountryName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            bool IsFound = false;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    IsFound = true;
                    CountryID = ID;
                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Countries DataAccess: [ Find() By CountryName ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static DataTable ListAll()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Countries";

            SqlCommand command = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                DT.Load(Reader);

            }catch(Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Countries DataAccess: [ ListAll() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

    }
}
