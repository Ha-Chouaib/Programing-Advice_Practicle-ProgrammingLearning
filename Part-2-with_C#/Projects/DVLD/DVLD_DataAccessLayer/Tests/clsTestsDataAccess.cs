using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer.Tests
{
    public class clsTestsDataAccess
    {
        public static bool Find(int TestAppointmentID, ref int TestID, ref bool TestResult, ref string Notes, ref short CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * FROM Tests where TestAppointmnetID=@TestAppID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@TestAppID", TestAppointmentID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (short)reader["CreatedByUserID"];
                }

            } catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, short CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert Into Tests  (TestAppointmentID ,TestResult, Notes,CreatedByUserID)
                                       VALUES (@TestAppointment,@TestResult,@Notes,@CreatedByUserID);
                            SELECT SCOPE_IDENTITY() ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);

            if(Notes == string.Empty)
                cmd.Parameters.AddWithValue("Notes@", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("Notes@", Notes);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int TestID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) TestID = ID;

            } catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return TestID;
        }

        public static bool DeleteTest(int TestID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete Tests Where TestID=@TestID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@TestID", TestID);

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

        public static DataTable ListTests()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Tests ;";

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
    }

}

