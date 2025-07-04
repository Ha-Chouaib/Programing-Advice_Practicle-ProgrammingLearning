﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer.Applications
{
    public class clsLocalDrivingLicenseDataAccess
    {
        public static bool Find(int LocalDrivingLicenseApplicationID, ref int ApplicationID,ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID";

            SqlCommand cmd =new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int) Reader["LicenseClassID"];
                }


            }catch(Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ Find() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return Found;
        }
        public static bool FindByMainApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * from LocalDrivingLicenseApplications Where ApplicationID= @ApplicationID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                }


            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ FindByMainApplicationID() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static int AddNewLocalLicenseApplication( int AppID,int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @" INSERT INTO LocalDrivingLicenseApplications 
                                          (ApplicationID,LicenseClassID)
                                          VALUES
                                          (@AppID,@LicenseClassID);
                            select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int ldlID = -1;
            try
            {
                connection.Open();
                 object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) ldlID = ID;
                
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ AddNewLocalLicenseApplication() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }

            return ldlID ;
        }

        public static bool UpdateLocalLicenseApplication(int LocalDrivingLicenseApplicationID, int MainApplicationID, int LicenseClassID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update LocalDrivingLicenseApplications 
                                    Set
                                        MainApplicationID = @MainApplicationID,
                                        LicenseClassID = @LicenseClassID
                                    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@MainApplicationID", MainApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ UpdateLocalLicenseApplication() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static DataTable ListAll_View()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From LocalDrivingLicenseApplications_View";

            SqlCommand cmd = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                DT.Load(Reader);

            }catch(Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ ListAll_View() ]: {ex.Message}", EventLogEntryType.Error);

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

            string[] AllowedColumns = new string[] { "LocalDrivingLicenseApplicationID", "NationalNo","FullName","Status" };
            if (!AllowedColumns.Contains(Column))
            {
                throw new ArgumentException("Not Allowed Column");
            }

            string Query = $"Select * From LocalDrivingLicenseApplications_View  Where {Column} Like @Term";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@Term", "%"+ Term +"%");

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                DT.Load(Reader);
            } catch (Exception ex)
            {

                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ FilterBy() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally 
            {
                connection.Close();    
            }
            return DT;
        }

       

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = $"Select PassedTestCount From LocalDrivingLicenseApplications_View  Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID );

            byte TestsCount = 40;
            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null && byte.TryParse(Result.ToString(), out byte PassedCountTests)) TestsCount = PassedCountTests;
            }
            catch (Exception ex)
            {

                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ GetPassedTestCount() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return TestsCount;
        }

        public static bool Delete(int LocalDrivinglicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @" Delete LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID= @LocalDrivinglicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivinglicenseID", LocalDrivinglicenseID);

            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LocalDrivingLicensesApplication DataAccess: [ Delete() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


    }
}
