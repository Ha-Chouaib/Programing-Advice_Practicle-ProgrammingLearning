using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.People
{
    public class clsPersonDataAccess
    {
        public static bool FindPersonByID(int PersonID ,ref string NationalNo, ref string FirstName, ref string LastName,ref DateTime DateOfBirth, ref byte Gender, 
                                    ref string Email, ref string Phone,ref short CountryID, ref string Address, ref string ImgPath
                                    )
        {
            string Query = "Sp_GetPersonByID";
            bool found = false;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(Query,connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {

                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                NationalNo = reader["NationalNo"] as string ?? string.Empty;
                                FirstName = reader["FirstName"] as string ?? string.Empty;
                                LastName = reader["LastName"] as string ?? string.Empty;
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Email = reader["Email"] as string ?? string.Empty;
                                Phone = reader["Phone"] as string ?? string.Empty;
                                Gender = reader["Gender"] != DBNull.Value ? Convert.ToByte(reader["Gender"]) : (byte) 3 ;
                                CountryID = reader["CountryID"] != DBNull.Value ?  Convert.ToInt16(reader["CountryID"]) : (short)0 ;
                                Address = reader["Address"] as string ?? string.Empty;
                                ImgPath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : string.Empty;
                               

                                found = true;
                            }
                            else
                            {
                                FirstName = LastName = NationalNo = Email = Phone = Address = ImgPath = string.Empty;
                                CountryID = 0; 
                                DateOfBirth =  DateTime.MinValue;
                            }
                        }
                    }
                    catch(SqlException ex)
                    {
                        clsEventLogger.LogError($"[DAL: PeopleDataAccess.FindPersonByID()] (SQL Error: {ex.Number} )-> {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        clsEventLogger.LogError($"[DAL: PeopleDataAccess.FindPersonByID()] ->  {ex.Message}");
                    }
                    return found;
                }
            }


        }
    
        public static int AddNewPerson(string NationalNo,  string FirstName,  string LastName,  DateTime DateOfBirth,  byte Gender,
                                     string Email,  string Phone,  short CountryID,  string Address,  string ImgPath)
        {

            string Query = @"Sp_AddNewPerson";
            int NewPersonID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImgPath) ? DBNull.Value : (object)ImgPath);


                    SqlParameter outputParam = new SqlParameter("@PersonID", System.Data.SqlDbType.Int) { Direction = System.Data.ParameterDirection.Output };
                    cmd.Parameters.Add(outputParam);

                    string ErrorMSG = "";
                    bool Success = false;

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Success = Convert.ToBoolean(reader["Success"]);
                            if (!Success)
                            {
                                ErrorMSG = reader["ErrorMSG"].ToString();
                                throw new InvalidOperationException(ErrorMSG);
                            }

                        }
                    }
                    NewPersonID = (int)(cmd.Parameters["@PersonID"].Value ?? -1);
                }
            }
            catch(SqlException ex)
            {
                clsEventLogger.LogError($"[DAL: Person.AddNewPerson() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsEventLogger.LogError($"[DAL: Person.AddNewPerson() ] -> {ex.Message}");

            }
            return NewPersonID;


        }
   
        public static bool UpdatePersonInf(int PersonID,string NationalNo, string FirstName, string LastName, DateTime DateOfBirth, byte Gender,
                                     string Email, string Phone, short CountryID, string Address, string ImgPath)
        {
            string Query = "Sp_UpdatePersonInf";
            bool Success = false;
          
            try
            {
                using(SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@CountryID", CountryID);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImgPath) ? DBNull.Value : (object)ImgPath);

                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            Success = Convert.ToBoolean(rdr["Success"]);
                            if(!Success)
                            {
                                throw new InvalidOperationException( rdr["ErrorMSG"].ToString()); 
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsEventLogger.LogError($"[DAL: Person.AddNewPerson() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsEventLogger.LogError($"[DAL: Person.AddNewPerson() ] -> {ex.Message}");

            }
            return Success;
        }
        public static bool Exist(int PersonID)
        {
            string Query = "SELECT dbo.Fn_IsPersonExistsByID(@PersonID)";
            bool exist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    connection.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && bool.TryParse(result.ToString(), out bool success)) exist = success;

                }
            }
            catch (SqlException ex)
            {
                clsEventLogger.LogError($"[DAL: Person.Exists() < By PersonID >] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsEventLogger.LogError($"[DAL: Person.Exists() < By PersonID > ] -> {ex.Message}");

            }
            return exist;
        }

        public static bool Exist(string NationalNo)
        {
            string Query = "SELECT dbo.Fn_IsPersonExistsByNationalNo(@NationalNo)";
            bool exist = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                    connection.Open();

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && bool.TryParse(result.ToString(), out bool success)) exist = success;

                }
            }
            catch (SqlException ex)
            {
                clsEventLogger.LogError($"[DAL: Person.Exists() < By NationalNo >] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsEventLogger.LogError($"[DAL: Person.Exists() < By NationalNo > ] -> {ex.Message}");

            }
            return exist;
        }

        public static bool Delete(int PersonID)
        {
            string Query = "Sp_DeletePerson";
            bool Deleted=false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();

                    using(SqlDataReader rdr= cmd.ExecuteReader())
                    {
                        Deleted = Convert.ToBoolean(rdr["Success"]);
                        if(!Deleted)
                        {
                            throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                clsEventLogger.LogError($"[DAL: Person.Delete() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsEventLogger.LogError($"[DAL: Person.Delete() ] -> {ex.Message}");

            }

            return Deleted;
            
        }
        
        public static DataTable ListAllPeople()
        {
            string Query = "Sp_GetAllPeople";
            DataTable dt = new DataTable();
            try
            {
                using(SqlConnection connection = new SqlConnection( DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand( Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataReader rdr= cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            dt.Load(rdr);
                        }

                        
                    }
                }
            }
            catch (SqlException ex)
            {
                clsEventLogger.LogError($"[DAL: Person.GetAllPeople() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsEventLogger.LogError($"[DAL: Person.GetAllPeople() ] -> {ex.Message}");

            }
            return dt;
        }
    
    }
}
