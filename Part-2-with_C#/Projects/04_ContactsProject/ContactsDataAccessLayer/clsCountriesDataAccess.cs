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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"Select * from Countries Where CountryID = @ID";

            bool ISFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);

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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"SELECT * From Countries WHERE CountryName = @countryName";

            bool ISFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@countryName", CountryName);

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
        
        public static int FindCountryID(string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"SELECT CountryID From Countries WHERE CountryName = @CountryName";


            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            int CountryID = -1;
            try
            {
                connection.Open();
                
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    CountryID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return CountryID;
        }
        public static bool ISExist(int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"UPDATE Countries
                            SET
                               CountryName=@CountryName,
                               Code=@Code,
                               PhoneCode=@PhoneCode
                            WHERE CountryID=@CountryID ;";
            
            SqlCommand command = new SqlCommand(Query, connection);
           
            command.Parameters.AddWithValue("@CountryID",ID);
            command.Parameters.AddWithValue("@CountryName",CountryName);
            if (Code == string.Empty)
            {
                command.Parameters.AddWithValue("@Code", DBNull.Value);
            }else
                command.Parameters.AddWithValue("@Code", Code);

            if(PhoneCode == string.Empty)
                command.Parameters.AddWithValue("@PhoneCode",DBNull.Value);
            else
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);


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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
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
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
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
        public static DataTable ListByCountry(string SetCountryName)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"Select * from Countries WHERE CountryName LIKE '%'+ @CountryName +'%';";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryName", SetCountryName);
            DataTable DT = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DT.Load(reader);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return DT;
        }



    }
}
