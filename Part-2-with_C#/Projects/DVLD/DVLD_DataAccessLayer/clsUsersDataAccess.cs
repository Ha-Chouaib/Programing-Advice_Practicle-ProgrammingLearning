using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DVLD_DataAccessLayer
{
    public class clsUsersDataAccess
    {
        public static bool Find(int UserID,ref int PersonID,ref string UserName,ref string Password,ref bool IsActive )
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Users WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            bool Found = false;

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.Read())
                {
                    Found = true;

                    PersonID = (int)Reader["PersonID"];
                    UserName = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                }

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static bool Find(string UserName, ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Users WHERE UserName=@UserName";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            bool Found = false;

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;

                    PersonID = (int)Reader["PersonID"];
                    UserID = (int)Reader["UserID"];
                    Password = (string)Reader["Password"];
                    IsActive = (bool)Reader["IsActive"];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static int AddNew(int PersonID,string UserName,string Password,bool IsActive)
        {

            SqlConnection connection = new SqlConnection( DataAccessSettings.connectionString);
            string Query = @"Insert Into Users (PersonID,UserName,Password,IsActive)
                            Values(@PersonID,@UserName,@Password,@IsActive);
                            
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID",PersonID);
            command.Parameters.AddWithValue("@UserName",UserName);
            command.Parameters.AddWithValue("@Password",Password);
            command.Parameters.AddWithValue("@IsActive",IsActive);

            int ID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int UserID)) ID = UserID;
    
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        
        public static bool Update(int UserID,string UserName,string Password,bool IsActive)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update Users 
                                    Set
                                        UserName=@UserName,
                                        Password=@Password,
                                        IsActive=@IsActive
                                    WHERE UserID=@UserID ;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            int RowsAffected=0;
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
    
        public static bool Exist(int UserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT Found=1 From Users WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) Found = true;
            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }
        public static bool ExistByPersonID(int PersonID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT Found=1 From Users WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"PersonID", PersonID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) Found = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static bool Delete(int UserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete Users Where UserID=@UserID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"UserID", UserID);

            byte RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected =(byte)command.ExecuteNonQuery();

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected !=0);
        }
        
        public static DataTable ListAll_RootInfo()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From Users";

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
        public static DataTable UsersList()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"select Users.UserID, Users.PersonID, Users.UserName ,
	                                CONCAT(People.FirstName,' ',People.SecondName,' ',People.ThirdName,' ',People.LastName) AS FullName,
                                    Users.IsActive from Users Join People On Users.PersonID = People.PersonID ;";

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
        public static DataTable FilterBy<T>(string Column,T FilterTerm)
        {
            string[] AllowedColumn= new[] { "UserID","PersonID","UserName","IsActive"};
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);


            DataTable DT = new DataTable();
            try
            {
                if (!AllowedColumn.Contains(Column))
                {
                    throw new ArgumentException("Not Allowed Column! Invalid Column Name");
                }
                string Query = $"Select * From Users Where {Column} =@Term";

                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue(@"Term", FilterTerm);
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
    
    }
}
