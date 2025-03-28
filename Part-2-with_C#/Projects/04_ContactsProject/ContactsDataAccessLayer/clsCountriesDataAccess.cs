using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public static  class clsCountriesDataAccess
    {
        public static  bool Find(int ID, ref string CountryName,ref string Code, ref string PhoneCode)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = @"SELECT * From Countries WHERE CountryID=@CountryID";

            bool ISFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ISFound = true;
                    CountryName = (string)reader["CountryName"];

                    if (reader["Code"] == DBNull.Value)
                        Code = "";
                    else
                        Code = (string) reader["Code"];

                    if (reader["PhoneCode"] != DBNull.Value)
                        PhoneCode = (string)reader["PhoneCode"];
                    else
                        PhoneCode = "";
                }

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }

        public static bool Find(string CountryName, ref int CountryID,ref string Code, ref string PhoneCode )
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = @"SELECT * From Countries WHERE CountryName = @CountryName";

            bool ISFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ISFound = true;
                    CountryID = (int)reader["CountryID"];

                    if (reader["Code"] == DBNull.Value)
                        Code = "";
                    else
                        Code = (string)reader["Code"];

                    if (reader["PhoneCode"] != DBNull.Value)
                        PhoneCode = (string)reader["PhoneCode"];
                    else
                        PhoneCode = "";
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;

        }
        
        public static bool ISExist(int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = @"SELECT Found=1 From Countries WHERE CountryID=@CountryID";
            
            bool isFound  = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    isFound = true;
                }

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        
        public static int AddNewCountry(string CountryName, string Code, string PhoneCode)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = @"Insert INTO Countries(CountryName, Code, PhoneCode)
                                        Values(@CountryName,@Code,@PhoneCode);
                                        SELECT SCOPE_IDENTITY();";
            int ID = -1;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName",CountryName);
            command.Parameters.AddWithValue("@Code",Code);
            command.Parameters.AddWithValue("@PhoneCode",PhoneCode);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString() , out int CountryID))
                {
                    ID = CountryID;
;               }
            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool UpdateCountry(int ID,string CountryName,string Code,string PhoneCode)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = @"UPDATE Countries
                            SET
                               CountryName=@CountryName,
                               Code=@Code,
                               PhoneCode=@PhoneCode
                            WHERE CountryID=@CountryID ;";
            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID",ID);
            command.Parameters.AddWithValue("@CountryName",CountryName);
            command.Parameters.AddWithValue("@Code",Code);
            command.Parameters.AddWithValue("@PhoneCode",PhoneCode);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }catch(Exception ex)
            {

            }finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        
        public static bool DeleteCountry(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = "DELETE Countries WHERE CountryID=@COuntryID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", ID);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }catch(Exception ex)
            {

            }finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        
        public static DataTable GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.CountriesConnectionStrng);
            string Query = @"Select * from Countries";

            SqlCommand command = new SqlCommand(Query, connection);
            DataTable DT = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    DT.Load(reader);
                }

            }catch(Exception ex)
            {

            }finally
            {
                connection.Close();
            }
            return DT;
        }



    }
}
