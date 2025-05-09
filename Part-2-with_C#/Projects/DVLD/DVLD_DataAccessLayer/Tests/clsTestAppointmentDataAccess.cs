using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer.Tests
{
    public class clsTestAppointmentDataAccess
    {
        public static bool Find(int TestAppointmentID, ref byte TestTypeID, ref int LocalDrivingLicenseApplicationID,ref DateTime AppointmentDate,
                                ref float PaidFees, ref short CreatedByUserID, ref bool IsLocked)
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

                    TestTypeID = (byte)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (float)reader["PaidFees"];
                    CreatedByUserID = (short)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                }

            }
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static int AddNewAppointment(byte TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
                                float PaidFees, short CreatedByUserID, bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INto TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID, AppointmentDate,PaidFees,CreatedByUserID,IsLocked )
                                         Values
                                            (@TestTypeID, @LDL_AppID, @AppointmentDate, @PaidFees, @CreatedByUSerID, @IsLocked);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LDL_AppID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUSerID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

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

        public static bool UpdateAppointment(int TestAppointmentID,bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update TestAppointments SET
                                                    IsLocked = @IsLocked
                                                    WHERE TestAppointmentID = @TestAppID";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@TestAppID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex) { }
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
            catch (Exception ex) { }
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
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return DT;
        }
        public static DataTable ListAppointments_SchedualeInfo(int LocalDrivingLicenseApp_ID,byte TestTypeID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select TestAppointmentID, AppointmentDate,PaidFees,IsLocked from TestAppointments
                             Where LocalDrivingLicenseApplicationID = @LDL_AppID AND TestTypeID=@TestTypeID;";

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
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return DT;
        }


    }
}
