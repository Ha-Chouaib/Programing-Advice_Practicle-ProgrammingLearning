using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports
{
    public class clsLoggingHistory_DAL
    {
        public static int AddNewLog(int LoggedInUserID, DateTime LoginDate, string SessionID, string MachineName)
        {
            string Query = "[dbo].[Sp_UserLoginHistory_AddNew]";
            int ID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                    cmd.Parameters.AddWithValue("@LoginDate", LoginDate);
                    cmd.Parameters.AddWithValue("@SessionID", SessionID);
                    cmd.Parameters.AddWithValue("@MachineName", MachineName);
                  


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        ID = clsGlobal.DB_SafeGet<int>(rdr, "LoginID", -1);
                        if (ID == -1)
                            throw new InvalidOperationException(clsGlobal.DB_SafeGet(rdr, "ErrorMSG", ""));
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: clsLoggingHistory_DAL.AddNewLog() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: clsLoggingHistory_DAL.AddNewLog() ] -> {ex.Message}");
            }
            return ID;
        }

        public static bool Find(int LoginID,ref int LoggedInUserID,ref DateTime LoginDate,ref string SessionID,ref string MachineName)
        {
            bool found = false;
            string Query = "[dbo].[Sp_UserActivityReport_GetByID]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginID", LoginID);
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            LoggedInUserID = clsGlobal.DB_SafeGet<int>(rdr, "LoggedInUserID", -1);
                            LoginDate = clsGlobal.DB_SafeGet<DateTime>(rdr, "LoginDate", DateTime.MinValue);
                            SessionID = clsGlobal.DB_SafeGet<string>(rdr, "SessionID", "");
                            MachineName = clsGlobal.DB_SafeGet<string>(rdr, "MachineName", "");
                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: clsLoggingHistory_DAL.Find() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: clsLoggingHistory_DAL.Find() ] -> {ex.Message}");
            }
            return found;
        }
        public static DataTable FilterLoginsHistory
        (int? LoginID,int? LoggedInUserID, DateTime? LoginDate, string SessionID, string MachineName, string UserName, string RoleName, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_UserLoginHistory_FilterPaged]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoginID", LoginID.HasValue ? (object)LoginID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID.HasValue ? (object)LoggedInUserID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@LoginDate", LoginDate.HasValue ? (object)LoginDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@SessionID", string.IsNullOrEmpty(SessionID) ?  DBNull.Value:(object)SessionID );
                    cmd.Parameters.AddWithValue("@MachineName", string.IsNullOrEmpty(MachineName) ?  DBNull.Value:(object)MachineName);
                    cmd.Parameters.AddWithValue("@UserName", string.IsNullOrEmpty(UserName) ?  DBNull.Value:(object)UserName);
                    cmd.Parameters.AddWithValue("@RoleName", string.IsNullOrEmpty(RoleName) ?  DBNull.Value:(object)RoleName);
                   

                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    SqlParameter totalParam = new SqlParameter("@TotalRows", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(totalParam);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }

                    totalRows = (int)(totalParam.Value ?? 0);
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsLoggingHistory_DAL.FilterLoginsHistory() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsLoggingHistory_DAL.FilterLoginsHistory() {ex.Message}");

            }
            return dt;
        }
    }
}
