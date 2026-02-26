using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsRolesDataAccess
    {
        public static int AddNewRole(string RoleName, long Permissions, string Description, bool IsActive, DateTime AddedAt, int AddedByUserID)
        {
            string Query = "[dbo].[Sp_Role_AddNew]";
            int RoleID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleName", RoleName);
                    cmd.Parameters.AddWithValue("@Permission", Permissions);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", AddedAt);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", AddedByUserID);

                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            RoleID = Convert.ToInt32(rdr["RoleID"]);
                            if (RoleID == -1)
                                throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Roles.AddNewRole() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Roles.AddNewRole() ] -> {ex.Message}");

            }
            return RoleID;
        }

        public static bool Find(int RoleID, ref string RoleName, ref long Permissions, ref bool IsActive, ref string Description,ref DateTime AddedAt,ref int AddedByUserID)
        {
            string Query = "[dbo].[Sp_Role_GetByID]";
            bool found = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleID", RoleID);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {

                            RoleName = rdr["RoleName"].ToString() ?? string.Empty;
                            Permissions = rdr["Permissions"] != DBNull.Value ? Convert.ToInt64(rdr["Permissions"]) : 0L;
                            Description = rdr["Description"].ToString() ?? string.Empty;
                            IsActive = rdr["IsActive"] != DBNull.Value ? (bool)rdr["IsActive"] : false;
                            AddedAt = (DateTime)rdr["CreatedDate"];
                            AddedByUserID = rdr["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(rdr["CreatedByUserID"]) : -1;
                            found = true;
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Roles.FindRoleByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Roles.FindRoleByID() ] -> {ex.Message}");

            }
            return found;
        }
        public static bool Find(string RoleName, ref int RoleID, ref long Permissions, ref bool IsActive, ref string Description,ref DateTime AddedAt,ref int AddedByUserID)
        {
            string Query = "[dbo].[Sp_Role_GetByName]";
            bool found = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RolName", RoleName);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {

                            RoleID = rdr["RoleID"] != DBNull.Value ? Convert.ToInt32(rdr["RoleID"]) : -1;
                            Permissions = rdr["Permissions"] != DBNull.Value ? (long)rdr["Permissions"] : 0L;
                            Description = rdr["Description"].ToString() ?? string.Empty;
                            IsActive = rdr["IsActive"] != DBNull.Value ? (bool)rdr["IsActive"] : false;
                            AddedAt = rdr["CreatedDate"] != DBNull.Value ? (DateTime)rdr["CreatedDate"] : DateTime.MinValue;
                            AddedByUserID = rdr["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(rdr["CreatedByUserID"]) : -1;

                            found = true;
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Roles.FindRoleByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Roles.FindRoleByID() ] -> {ex.Message}");

            }
            return found;
        }

        public static bool Update(int RoleID, string RoleName, long Permissions, string Description, bool IsActive)
        {
            string Query = "[dbo].[Sp_Role_Update]";
            bool Success = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    cmd.Parameters.AddWithValue("@RoleName", RoleName);
                    cmd.Parameters.AddWithValue("@Permissions", Permissions);
                    cmd.Parameters.AddWithValue("@Description", Description);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

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
                clsGlobal.LogError($"[DAL: Roles.Update() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Roles.Update() ] -> {ex.Message}");

            }
            return Success;
        }

        public static DataTable GetRoles()
        {
            string Query = "[dbo].[Sp_Roles_List]";
            DataTable dtRoles = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dtRoles.Load(rdr);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Roles.GetRoles() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Roles.GetRoles() ] -> {ex.Message}");

            }
            return dtRoles;
        }

    }
}
