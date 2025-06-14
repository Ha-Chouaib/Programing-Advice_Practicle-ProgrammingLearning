using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Linq;

namespace ContactsDataAccessLayer
{
    public static class clsCotactsDataAccess
    {

        public static bool Find(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phone,
                                ref string Address, ref DateTime DateOfBirth, ref int CountryID, ref string ImagePath )
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"SELECT * From Contacts WHERE ContactID=@ContactID;";

            bool IsFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string) reader["ImagePath"];
                    }else
                    {
                        ImagePath = "";
                    }

                }
                reader.Close();

            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static int AddNewContact(string FirstName, string LastName, string Email, string Phone, string Address,
                            DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"INSERT INTO Contacts(FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)
                                         Values(@FirstName, @LastName, @Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath);
                                          SELECT SCOPE_IDENTITY ();  ";
            int ID = -1;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName",FirstName);
            command.Parameters.AddWithValue("@LastName",LastName);
            command.Parameters.AddWithValue("@Email",Email);
            command.Parameters.AddWithValue("@Phone",Phone);
            command.Parameters.AddWithValue("@Address",Address);
            command.Parameters.AddWithValue("@DateOfBirth",DateOfBirth);
            command.Parameters.AddWithValue("@CountryID",CountryID);
            if(ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            }else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString(), out int NewID))
                {
                    ID = NewID;

                }

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;

        }

        public static bool UpdateContact(int ID ,string FirstName, string LastName, string Email, string Phone, string Address,
                           DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"UPDATE Contacts 
                        SET FirstName= @FirstName,
                            LastName= @LastName,
                            Email=@Email,
                            Phone=@Phone,
                            Address=@Address,
                            DateOfBirth=@DateOfBirth,
                            CountryID=@CountryID,
                            ImagePath=@ImagePath  
                        WHERE ContactID=@ContactID ; ";

            int RowsAffected =0;

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if (ImagePath != string.Empty)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath",DBNull.Value);

            }

            try
            {
                Connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                Connection.Close();
            }
            return (RowsAffected > 0);

        }

        public static bool IsExist(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"SELECT Found=1 FROM Contacts WHERE ContactID=@ContactID";

            bool IsFound = false;

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    IsFound = true;


            }catch(Exception ex)
            {

            }
            finally 
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool DeleteContact(int ID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"Delete Contacts WHERE ContactID=@ContactID";

            int rowsAffected = 0;
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
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
    
    
        public static DataTable GetAllContacts()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = @"SELECT * From Contacts";

            DataTable DT = new DataTable();

            SqlCommand command = new SqlCommand(Query, connection);

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

            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

       
        public static DataTable FindByFirstLast_Name(string  SearchTerm)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string Query = "SELECT * From Contacts WHERE (FirstName LIKE @SearchTerm OR LastName LIKE @SearchTerm)";
           

            DataTable DT = new DataTable();

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@SearchTerm","%"+ SearchTerm + "%");

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            
                DT.Load(reader);
                

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
