using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer.Tests
{
    public class clsTestAppointmentDataAccess
    {
        public static bool Find(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,
                                ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked,ref int RetakeTestApplicationID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From TestAppointments Where TestAppointmentID = @TestAppID ";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@TestAppID", TestAppointmentID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Found = true;

                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (float)(decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID =-1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

                }

            }
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static int AddNewAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
                                float PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INto TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID, AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID )
                                         Values
                                            (@TestTypeID, @LDL_AppID, @AppointmentDate, @PaidFees, @CreatedByUSerID, @IsLocked,@RetakeTestApplicationID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LDL_AppID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUSerID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

            if(RetakeTestApplicationID == -1)
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            int TestAppointmentID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) TestAppointmentID = ID;

            }catch(Exception ex) { }
            finally
            {
                connection.Close();
            }
            return TestAppointmentID;
        }

        public static bool UpdateAppointment(int TestAppointmentID,DateTime AppointmentDate,bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update TestAppointments SET
                                                    AppointmentDate = @AppointmentDate,
                                                    IsLocked = @IsLocked
                                                    WHERE TestAppointmentID = @TestAppID";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@TestAppID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }
        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete TestAppointments Where TestAppointmentID=@TestAppID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@TestAppID", TestAppointmentID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static DataTable ListAppointments()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From TestAppointments_View ;";

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
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }
        public static DataTable ListAppointments_SchedualeInfo(int LocalDrivingLicenseApp_ID,int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select TestAppointmentID, AppointmentDate,PaidFees,IsLocked from TestAppointments
                             Where LocalDrivingLicenseApplicationID = @LDL_AppID AND TestTypeID=@TestTypeID 
                             Order By TestAppointmentID DESC;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LDL_AppID", LocalDrivingLicenseApp_ID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DT.Load(reader);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

        public static bool IsTestTypePassed(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool Result = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

        public static byte TestTrials(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }

        public static bool HasActiveTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection( DataAccessSettings.connectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

        public static int GetCurrentTestAppointmentID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT Top 1 TestAppointments.TestAppointmentID FROM  LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_AppID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID DESC;";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LDL_AppID", LocalDrivingLicenseApplicationID);
            

            int TestAppointmentID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) TestAppointmentID = ID;

            }
            catch (Exception ex) 
            {
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return TestAppointmentID;
        }



    }
}
