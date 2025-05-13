using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypesDataAccess
    {
        public static bool Find(int TestID, ref string TestTitle,ref string TestDescription ,ref float TestFees)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From TestTypes Where TestTypeID = @TestID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestTitle = (string)Reader["TestTypeTitle"];
                    TestDescription = (string)Reader["TestTypeDescription"];
                    TestFees = (float)(decimal)Reader["TestTypeFees"];
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool Find(string TestTitle,ref int TestID, ref string TestDescription, ref float TestFees)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From TestTypes Where TestTypeTitle = @TestTitle";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTitle", TestTitle);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    TestID = (short)Reader["TestTypeID"];
                    TestDescription = (string)Reader["TestTypeDescription"];
                    TestFees = (float)(decimal)Reader["TestTypeFees"];
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static bool UpdateTest(int TestID, string TestTitle,string TestDescription, double TestFees)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update TestTypes
                                                    Set
                                                        TestTypeTitle = @TestTitle,
                                                        TestTypeDescription = @TestDescription,
                                                        TestTypeFees = @TestFees
                                                    WHERE TestTypeID = @TestID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestTitle", TestTitle);
            command.Parameters.AddWithValue("@TestDescription", TestDescription);
            command.Parameters.AddWithValue("@TestFees", TestFees);

            byte RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = (byte)command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }
        public static DataTable ListAllTests()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * from TestTypes";

            SqlCommand command = new SqlCommand(Query, connection);
            DataTable Dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                Dt.Load(Reader);

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Dt;
        }

    }
}
