using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccessLayer
{
    public class clsPeopleDataAccess
    {
        
        public static bool Find(int PersonID,ref string NationalNo,ref string FirstName,ref string SecondName,ref string ThirdName,
            ref string LastName,ref DateTime DateOfBirth, ref byte Gender,ref string Address, ref string Phone,ref string Email,
            ref int NationalityCountryID,ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From People Where PersonID=@PersonID";

            bool IsFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }else
                    {
                        ImagePath = "";
                    }


                }

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool Find(string NationalNo,ref int PersonID ,ref string FirstName, ref string SecondName, ref string ThirdName,
           ref string LastName, ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email,
           ref int NationalityCountryID, ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From People Where NationalNo=@NationalNo";

            bool IsFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsExist(int PersonID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select Found=1 From People Where PersonID=@PersoonID";

            bool isFound = false;
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) isFound = true;

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool IsExist(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select Found=1 From People Where NationalNo=@NationalNo";

            bool isFound = false;
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) isFound = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        
        public static int AddNew(string NationalNo, string FirstName,  string SecondName,  string ThirdName,
            string LastName,  DateTime DateOfBirth,  byte Gender,  string Address,  string Phone,  string Email,
            int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert Into People (NationalNo ,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,Address,
                                                Phone,Email,NationalityCountryID,ImagePath)
                                         Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,
                                                @Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                             Select SCOPE_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gender", Gender);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if(ImagePath == string.Empty)
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);


            int ID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int NewID)) ID = NewID;
                

            }catch(Exception ex)
            {

            }finally
            {
                connection.Close();
            }
            return ID;

        }

        public static bool Update(string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update People 
                                    SET
                                    NationalNo= @NationalNo ,
                                    FirstName= @FirstName,
                                    SecondName= @SecondName,
                                    ThirdName= @ThirdName,
                                    LastName= @LastName,
                                    DateOfBirth= @DateOfBirth,
                                    Gender= @Gender,
                                    Address= @Address,
                                    Phone= @Phone,
                                    Email= @Email,
                                    NationalityCountryID= @NationalityCountryID,
                                    ImagePath= @ImagePath ";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            command.Parameters.AddWithValue("@Gender", Gender);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath == string.Empty)
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);


            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);

        }

        public static bool DeletePerson(int PersonID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete People Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
                
            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static DataTable ListAll()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From People";

            SqlCommand command = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                DT.Load(Reader);

            }catch(Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }
            return DT;
        }

        public static DataTable FilterPeople<T>(string Column, T FilterTerm)
        {

            string[] AllowedColumns = new [] { "PersonID", "NationalityCountryID", "NationalNo","FirstName","SecondName","ThirdName","LastName","Gendor","Address","Email","Phone" };
            if(! AllowedColumns.Contains(Column))
            {
                throw new ArgumentException("Invalid Column Name");
            }

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string Query = $"Select * From People Where {Column} Like @FilterTerm";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FilterTerm","%"+ FilterTerm +"%");

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                DT.Load(Reader);

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return DT;
        }

        //public static DataTable FilterPeople(string Column,int FilterTerm)
        //{

            
        //    SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

        //    string[] Columns = new string[] { "PersonID", "NationalityCountryID" };

        //    if (!Columns.Contains(Column))
        //    {
        //        throw new ArgumentException("Not A Valid Column Name");
        //    }

        //    string Query = $"Select * From People Where {Column} Like @Term";

        //    SqlCommand command = new SqlCommand(Query, connection);
        //    command.Parameters.AddWithValue("@Term", "%"+ FilterTerm +"%");

        //    DataTable DT = new DataTable();
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader Reader = command.ExecuteReader();
        //        DT.Load(Reader);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return DT;
        //}


    }
}
