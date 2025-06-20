using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
namespace DVLD_DataAccessLayer
{
    public class clsDetainLicenseDataAccess
    {
        public static bool Find(int DetainID,ref int LicenseID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
                               ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    LicenseID = (int)Reader["LicenseID"];                   
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (float)(decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.Now;
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    if (Reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];

                    
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ Find() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool FindByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, ref bool IsReleased,
                                 ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From DetainedLicenses WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (float)(decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.Now;
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    if (Reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];


                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ FindByLicenseID() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static int DetainLicense(int LicenseID,DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INto DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                                         Values
                                            (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@DetainDate", DetainDate);
            cmd.Parameters.AddWithValue("@FineFees", FineFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
           
            int DetainID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) DetainID = ID;

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ DetainLicense() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return DetainID;
        }
        public static bool ReleaseLicense(int DetainID,bool IsReleased ,DateTime ReleaseDate,int ReleasedByUserID,int ReleaseApplicationID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update DetainedLicenses SET
                                                    IsReleased = @IsReleased, 
                                                    ReleaseDate = @ReleaseDate, 
                                                    ReleasedByUserID = @ReleasedByUserID, 
                                                    ReleaseApplicationID = @ReleaseApplicationID 
                                                    
                                                    Where DetainID= @DetainID;";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);
            cmd.Parameters.AddWithValue("@IsReleased", IsReleased);
            cmd.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            cmd.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ ReleaseLicense() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }
        public static bool Delete(int DetainID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete DetainedLicenses Where DetainID=@DetainID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ Delete() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static bool IsDetained(int DetainID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select Found=1 from DetainedLicenses Where DetainID=@DetainID AND IsReleased = 0 ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) Found = true;

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ IsDetained() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return Found;
        }
        public static bool IsDetained_ByLicenseID(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select Found=1 from DetainedLicenses Where LicenseID=@LicenseID AND IsReleased = 0 ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) Found = true;

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ IsDetained_ByLicenseID() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static DataTable ListAll()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From DetainedLicenses_View ;";

            SqlCommand cmd = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DT.Load(reader);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ ListAll() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

        public static DataTable FilterBy<T>(string Column,T Term)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
           
            DataTable DT = new DataTable();
            try
            {

                string[] AllowedColumns = new string[] { "DetainID", "NationalNo", "IsReleased", "FullName","ReleaseApplicationID" };

                if(!AllowedColumns.Contains(Column))
                {
                    throw new ArgumentException($"InValid Column Name ! [{Column}]");
                }

                string Query = $"SELECT * From DetainedLicenses_View WHERE {Column} Like @Term ;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@Term", "%" + Term + "%");

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DT.Load(reader);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"DetainLicense DataAccess: [ FilterBy() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

    }
}
