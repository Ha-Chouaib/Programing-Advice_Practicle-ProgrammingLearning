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

        public static bool FindReportByID(int ReportID, ref string ActionKey, ref int EntityID, ref bool Succeeded, ref string Metadata)
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

                            ActionKey = rdr["ActionKey"].ToString() ?? string.Empty;
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
    
        public static DataTable ListUserReports()
        {

            string Query = "";
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
                clsGlobal.LogError($"[DAL: UserActivityReports.ListUserReports() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: UserActivityReports.ListUserReports() ] -> {ex.Message}");

            }
            return dtRoles;
        }
    }
}
