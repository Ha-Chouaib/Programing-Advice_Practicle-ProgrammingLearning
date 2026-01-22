using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports
{
    public static class clsUserActivityReports_DAL
    {
        public static int InsertUserActivityReport(int UserID,string ActionKey,int? EntityID,bool Succeeded,string Metadata)
        {
            string Query = $"dbo.sp_UserActivity_Insert";
            int reportId = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                { 
                    cmd.CommandType =CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(@"UserID",UserID);
                    cmd.Parameters.AddWithValue(@"ActionKey",ActionKey);
                    cmd.Parameters.AddWithValue(@"EntityID",EntityID);
                    cmd.Parameters.AddWithValue(@"Succeeded",Succeeded);
                    cmd.Parameters.AddWithValue(@"Metadata",Metadata);
                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            reportId = Convert.ToInt32(rdr["ReportID"]);
                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: UserActivityReports.InsertUserActivityReport() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: UserActivityReports.InsertUserActivityReport() ] -> {ex.Message}");

            }
            return reportId;
        }

        public static bool FindReportByID(int ReportID,ref int UserID, ref string ActionKey,ref DateTime ReportDate ,ref int? EntityID, ref bool Succeeded, ref string Metadata)
        {
            string Query = "[dbo].[Sp_UserActivityReport_GetByID]";
            bool found = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ReportID", ReportID);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            UserID = clsGlobal.DB_SafeGet<int>(rdr, "UserID", -1);
                            ActionKey = rdr["ActionKey"].ToString() ?? string.Empty;
                            ReportDate = clsGlobal.DB_SafeGet<DateTime>(rdr, "ReportDate", DateTime.MinValue);
                            Metadata = rdr["Metadata"].ToString() ?? string.Empty;
                            Succeeded = rdr["Succeeded"] != DBNull.Value ? (bool)rdr["Succeeded"] : false;
                            EntityID = rdr["EntityID"] != DBNull.Value ? Convert.ToInt32(rdr["EntityID"]) : -1;
                            found = true;
                        }
                    }



                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: UserActivityReports.FindReportByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }                                        
            catch (Exception ex)                     
            {                                        
                clsGlobal.LogError($"[DAL: UserActivityReports.FindReportByID() ] -> {ex.Message}");

            }
            return found;
        }

        public static DataTable FilterReports(int? userId, string actionKey, bool? succeeded, DateTime? fromDate, DateTime? toDate, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UserActivity_FilterPaged", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userId.HasValue ? (object)userId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ActionKey", string.IsNullOrEmpty(actionKey) ? DBNull.Value : (object)actionKey);
                    cmd.Parameters.AddWithValue("@Succeeded", succeeded.HasValue ? (object)succeeded.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@FromDate", fromDate.HasValue ? (object)fromDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ToDate", toDate.HasValue ? (object)toDate.Value : DBNull.Value);

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
                clsGlobal.LogError($"[DAL: UserActivityReports.FilterReports() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: UserActivityReports.FilterReports() ] -> {ex.Message}");

            }
            return dt;
        }

    }
}
