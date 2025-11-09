using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsUserDataAccess
    {

        public static int AddNewUser(int PersonID,string UserName,DateTime CreatedDate,string Role ,string Password, bool IsActive, int CreatedByUserID, short Permissions)
        {
            string Query = "Sp_AddNewUser";
            int UserID = -1;
            try
            {
                using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID",PersonID);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@CreatedDate",CreatedDate);
                    cmd.Parameters.AddWithValue("@Role",Role);
                    cmd.Parameters.AddWithValue("@Password",string.IsNullOrEmpty(Password) ? DBNull.Value : (object) Password);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID == -1 ? DBNull.Value : (object) CreatedByUserID);
                    cmd.Parameters.AddWithValue("@Permissions", Permissions);

                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            UserID = Convert.ToInt32(rdr["UserID"]);
                            if (UserID == -1)
                                throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.AddNewUser() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.AddNewUser() ] -> {ex.Message}");

            }
            return UserID;
        }
        public  static bool FindUserByID(int UserID ,ref int PersonID,ref string UserName,ref DateTime CreatedDate,
            ref string Role,ref string Password,ref bool IsActive,ref int CreatedByUserID, ref short Permissions)
        {
            string Query = "Sp_GetUserByID";
            bool found= false;
            try 
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    { 
                        if (rdr.Read())
                        {
                            PersonID = Convert.ToInt32(rdr["PersonID"]);
                            UserName = rdr["UserName"].ToString() ?? string.Empty;
                            CreatedDate = (rdr["CreatedDate"] != DBNull.Value) ? (DateTime)rdr["CreatedDate"] : DateTime.MinValue ;
                            Role = rdr["Role"].ToString() ?? string.Empty;
                            Password = rdr["Password"].ToString() ?? string.Empty;
                            IsActive = (rdr["IsActive"] != DBNull.Value) ? (bool)rdr["IsActive"] : false ;
                            CreatedByUserID = rdr["CreatedByUserID"]!= DBNull.Value ? Convert.ToInt32(rdr["CreatedByUserID"]) : -1;
                            Permissions = rdr["Permissions"]!= DBNull.Value ? Convert.ToInt16(rdr["Permissions"]) : (short) 0;

                            found = true;
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.FindUserByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.FindUserByID() ] -> {ex.Message}");

            }
            return found;

        }

        public static bool FindUserByPersonID(int PersonID, ref int UserID , ref string UserName, ref DateTime CreatedDate,
            ref string Role, ref string Password, ref bool IsActive, ref int CreatedByUserID, ref short Permissions)
        {
            string Query = "Sp_GetUserByPersonID";
            bool found = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            UserID = Convert.ToInt32(rdr["UserID"]);
                            UserName = rdr["UserName"].ToString() ?? string.Empty;
                            CreatedDate = (rdr["CreatedDate"] != DBNull.Value) ? (DateTime)rdr["CreatedDate"] : DateTime.MinValue;
                            Role = rdr["Role"].ToString() ?? string.Empty;
                            Password = rdr["Password"].ToString() ?? string.Empty;
                            IsActive = (rdr["IsActive"] != DBNull.Value) ? (bool)rdr["IsActive"] : false;
                            CreatedByUserID = rdr["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(rdr["CreatedByUserID"]) : -1;
                            Permissions = rdr["Permissions"] != DBNull.Value ? Convert.ToInt16(rdr["Permissions"]) : (short)0;

                            found = true;
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.FindUserByPersonID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.FindUserByPersonID() ] -> {ex.Message}");

            }
            return found;

        }

        public static bool FindUserByName(string UserName , ref int UserID, ref int PersonID, ref DateTime CreatedDate,
            ref string Role, ref string Password, ref bool IsActive, ref int CreatedByUserID, ref short Permissions)
        {
            string Query = "Sp_GetUserByName";
            bool found = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", UserName);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            PersonID = Convert.ToInt32(rdr["PersonID"]);
                            UserID = Convert.ToInt32(rdr["UserID"]);
                            CreatedDate = (rdr["CreatedDate"] != DBNull.Value) ? (DateTime)rdr["CreatedDate"] : DateTime.MinValue;
                            Role = rdr["Role"].ToString() ?? string.Empty;
                            Password = rdr["Password"].ToString() ?? string.Empty;
                            IsActive = (rdr["IsActive"] != DBNull.Value) ? (bool)rdr["IsActive"] : false;
                            CreatedByUserID = rdr["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(rdr["CreatedByUserID"]) : -1;
                            Permissions = rdr["Permissions"] != DBNull.Value ? Convert.ToInt16(rdr["Permissions"]) : (short)0;

                            found = true;
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.FindUserByName() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.FindUserByName() ] -> {ex.Message}");

            }
            return found;

        }

        public static bool Update(int UserID,string UserName,string Password, string Role,bool IsActive,short Permissions)
        {
            string Query = "Sp_UpdateUserInf";
            bool Success = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Role", Role);
                    cmd.Parameters.AddWithValue("@Password", string.IsNullOrEmpty(Password) ? DBNull.Value : (object)Password);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@Permissions", Permissions == -1 ? DBNull.Value : (object)Permissions);

                    conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            Success = Convert.ToBoolean(rdr["Success"]);
                            if (!Success)
                            {
                                throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.Update() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.Update() ] -> {ex.Message}");

            }
            return Success;
        }

        public static bool UpdateUserName(int UserID, string UserName)
        {
            string Query = "Sp_UpdateUserName";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID",UserID);
                    cmd.Parameters.AddWithValue("@UserName",UserName);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if(! success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserName() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserName() ] -> {ex.Message}");

            }
            
            return success;
        }
        public static bool UpdateUsePassword(int UserID, string Password)
        {
            string Query = "Sp_UpdateUserPassword";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@UserName", Password);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUsePassword() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUsePassword() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateUserRole(int UserID, string Role)
        {
            string Query = "Sp_UpdateUserRole";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@Role", Role);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserRole() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserRole() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateUserStatus(int UserID, bool IsActive)
        {
            string Query = "Sp_UpdateUserStatus";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserState() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserState() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateUserPermissions(int UserID, short Permissions)
        {
            string Query = "Sp_UpdateUserPermissions";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@Permissions", Permissions);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserPermissions() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.UpdateUserPermissions() ] -> {ex.Message}");

            }

            return success;
        }

        public static bool ExistsByID(int UserID)
        {
            string Query = @" SELECT dbo.Fn_IsUserExistsByID(@UserID)";
            bool Exists = false;
            try
            {
                using(SqlConnection connection = new SqlConnection( DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand( Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists; 
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.ExistsByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.ExistsByID() ] -> {ex.Message}");
            }
            return Exists;
        }
        public static bool ExistsByPersonID(int PersonID)
        {
            string Query = @" SELECT dbo.Fn_IsUserExistsByPersonID(@PersonID)";
            bool Exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.ExistsByPersonID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.ExistsByPersonID() ] -> {ex.Message}");
            }
            return Exists;
        }
        public static bool ExistsByUserName(string UserName)
        {
            string Query = @" SELECT dbo.Fn_IsUserExistsByName(@UserName)";
            bool Exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserName", UserName);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.ExistsByUserName() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.ExistsByUserName() ] -> {ex.Message}");
            }
            return Exists;
        }

        public static bool IsActive(int UserID)
        {
            string Query = @" SELECT dbo.Fn_IsUserActive(@UserID)";
            bool Active = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool active)) Active = active;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.IsActive() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.IsActive() ] -> {ex.Message}");
            }
            return Active;
        }
        public static bool Delete(int UserID)
        {
            string Query = "Sp_DeleteUser";
            bool Deleted = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        Deleted = Convert.ToBoolean(rdr["Success"]);
                        if (!Deleted)
                        {
                            throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.Delete() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.Delete() ] -> {ex.Message}");

            }

            return Deleted;

        }

        public static DataTable ListAllUsers()
        {
            string Query = "Sp_GetAllUsers";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: User.GetAllUsers() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: User.GetAllUsers() ] -> {ex.Message}");

            }
            return dt;
        }

    }
}
