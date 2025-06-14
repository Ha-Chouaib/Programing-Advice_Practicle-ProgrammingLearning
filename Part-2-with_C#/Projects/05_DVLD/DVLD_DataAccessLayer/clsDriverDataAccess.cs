using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace DVLD_DataAccessLayer
{
    public class clsDriverDataAccess
    {

        public static bool Find(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Drivers WHERE DriverID = @DriverID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------ DB Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }


        public static bool FindByPersonID(int PersonID,ref int DriverID, ref int CreatedByUserID,ref DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Drivers WHERE PersonID = @PersonID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    DriverID = (int)Reader["DriverID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------ DB Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }


        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INto Drivers (PersonID,CreatedByUserID, CreatedDate )
                                         Values
                                            (@PersonID, @CreatedByUserID, @CreatedDate );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            cmd.Parameters.AddWithValue("@CreatedByUSerID", CreatedByUserID);

            int DriverID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) DriverID = ID;

            }
            catch (Exception ex) 
            {
                Console.WriteLine("----------------DB Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return DriverID;
        }

        public static bool DeleteDriver(int DriverID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @" Delete Drivers WHERE DriverID= @DriverID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            int rowsAffected = 0;
            try
            {
                connection.Open();
                 rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0 );
        }
        public static bool Exist(int PersonID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT Found=1 From Drivers WHERE PersonID= @PersonID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            bool found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) found = true;

            }catch(Exception ex)
            {
                Console.WriteLine("----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return found;
        }
    
        public static DataTable ListDrivers()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Drivers_View ;";

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

        public static DataTable FilterBy<T>(string FilterByColumn, T FilterTerm)
        {
            string[] AllowedColumn = new string[] { "DriverID", "PersonID", "FullName" };

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            DataTable DT = new DataTable();
            try
            {


                if (! AllowedColumn.Contains(FilterByColumn))
                {
                    throw new ArgumentException($"Invalide Column Name [{FilterByColumn}]!");
                }

                string Query = $"SELECT * From Drivers_View  Where {FilterByColumn} Like @Term;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@Term", "%" + FilterTerm + "%");
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



    }
}
