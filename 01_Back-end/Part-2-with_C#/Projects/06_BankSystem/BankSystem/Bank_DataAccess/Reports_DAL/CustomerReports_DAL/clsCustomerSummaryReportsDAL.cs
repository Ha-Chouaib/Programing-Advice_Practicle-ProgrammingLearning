using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports.CustomerReports
{
    public class clsCustomerSummaryReportsDAL
    {
        private static int _GenerateCustomerSummaryReport(int CustomerID)
        {
            int CustomerReportID = -1;
            string Query = @"[dbo].[Sp_CustomerSummaryReport_Generate]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    SqlParameter outputId = new SqlParameter("@CustomerReportID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    CustomerReportID = Convert.ToInt32(outputId.Value);

                    if (CustomerReportID == -1)
                    {
                        throw new InvalidOperationException($"No Customer exist  with ID [{CustomerID}].");
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports._GenerateCustomerSummaryReport() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports._GenerateCustomerSummaryReport() {ex.Message}");

            }
            return CustomerReportID;


        }
        public static bool Find(int CustomerID,ref int ReportID,ref byte TotalAccounts ,ref byte ActiveAccounts,ref double TotalBalance,ref DateTime LastActivityDate,ref bool CustomerStatus)
        {
            string Query = @"[dbo].[Sp_CustomerSummaryReports_GetByID]";
            bool found = false;
            ReportID = _GenerateCustomerSummaryReport(CustomerID);
            if (ReportID == -1) return false;
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerSummaryReportID",ReportID);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TotalAccounts = clsGlobal.DB_SafeGet<byte>(reader, "TotalAccounts", 0);
                            ActiveAccounts = clsGlobal.DB_SafeGet<byte>(reader, "ActiveAccounts", 0);
                            TotalBalance = clsGlobal.DB_SafeGet<double>(reader, "TotalBalance", 0);
                            LastActivityDate = clsGlobal.DB_SafeGet<DateTime>(reader, "LastActivityDate", DateTime.MinValue);
                            CustomerStatus = clsGlobal.DB_SafeGet<bool>(reader, "CustomerStatus", false);

                            found = true;
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports.Find() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports.Find() {ex.Message}");

            }
            return found;
        }
        public static DataTable FilterReports(int? CustomerID, byte? ActiveAccounts, DateTime? LastActivityFrom,DateTime? LastActivityTo, bool? CustomerStatus, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_CustomerSummaryReports_FilterPaged]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ActiveAccounts", ActiveAccounts.HasValue ? (object)ActiveAccounts.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastActivityFrom", LastActivityFrom.HasValue ? (object)LastActivityFrom.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@LastActivityTo", LastActivityTo.HasValue ? (object)LastActivityTo.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerStatus", CustomerStatus.HasValue ? (object)CustomerStatus.Value : DBNull.Value);

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
                clsGlobal.LogError($"DAL -> clsCustomerSummaryReportsDAL.FilterReports() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsCustomerSummaryReportsDAL.FilterReports() {ex.Message}");

            }
            return dt;
        }


    }
}
