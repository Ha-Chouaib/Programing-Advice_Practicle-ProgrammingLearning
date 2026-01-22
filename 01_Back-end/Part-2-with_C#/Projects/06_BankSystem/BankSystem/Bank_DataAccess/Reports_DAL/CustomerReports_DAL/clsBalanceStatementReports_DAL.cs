using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports.CustomerReports
{
    public class clsBalanceStatementReports_DAL
    {
        private static int _GenerateBalanceStatementReport( int customerId, int accountId)
        {
            string Query = @"dbo.Sp_CustomerBalanceStatementReports_Generate";
            int customerReportId = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@RequestDate", DateTime.Today);
                   

                    conn.Open();
                    customerReportId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsBalanceStatementReports_DAL.GenerateBalanceStatementReport() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsBalanceStatementReports_DAL.GenerateBalanceStatementReport() {ex.Message}");

            }
            return customerReportId;
        }
        public static bool Find(int CustomerID,int AccountID,ref double OpeningBalance,ref double CloseingBalance,ref DateTime FromDate,ref DateTime ToDate)
        {
            string Query = @"[dbo].[Sp_CustomerBalanceStatementReports_GetByID]";
            bool found = false;
            int CustomerReportId = _GenerateBalanceStatementReport(CustomerID,AccountID);
            try
            {
                if (CustomerReportId == -1)
                {
                    throw new ArgumentException($"Can't Generate Or Load Balance Statment Report For Customert[{CustomerID}].Account[{AccountID}]");
                }

                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand( Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BalanceStatementReportID",CustomerReportId);
                    conn.Open() ;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            OpeningBalance = clsGlobal.DB_SafeGet<double>(reader, "OpeningBalance", 0);
                            CloseingBalance = clsGlobal.DB_SafeGet<double>(reader, "ClosingBalance", 0);
                            FromDate = clsGlobal.DB_SafeGet<DateTime>(reader, "FromDate", DateTime.MinValue);
                            ToDate = clsGlobal.DB_SafeGet<DateTime>(reader, "ToDate", DateTime.MinValue);

                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsBalanceStatementReports_DAL.GenerateBalanceStatementReport() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsBalanceStatementReports_DAL.GenerateBalanceStatementReport() {ex.Message}");

            }
            return found;
        }

        public static DataTable FilterReports(int? CustomerID, int? AccountID, DateTime? fromDate, DateTime? toDate, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_CustomerBalanceStatementReports_FilterPaged]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerD", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountID", AccountID.HasValue ? (object)AccountID.Value : DBNull.Value);
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
                clsGlobal.LogError($"DAL -> clsBalanceStatementReports_DAL.FilterReports() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsBalanceStatementReports_DAL.FilterReports() {ex.Message}");

            }
            return dt;
        }
    }


}

