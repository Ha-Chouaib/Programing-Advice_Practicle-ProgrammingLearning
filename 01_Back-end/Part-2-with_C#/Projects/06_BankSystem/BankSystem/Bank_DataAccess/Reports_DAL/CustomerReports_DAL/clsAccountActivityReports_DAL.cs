using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports.CustomerReports
{
    public class clsAccountActivityReports_DAL
    {
        private static int _GenerateAccountActivityReport(int accountId,DateTime RequestedDate)
        {
            string Query = @"[dbo].[Sp_CustomerAccountActivityReports_Generate]";
            int customerReportId = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@RequestedDate",RequestedDate);


                    conn.Open();
                    customerReportId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsAccountActivityReports_DAL._GenerateAccountActivityReport() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsAccountActivityReports_DAL._GenerateAccountActivityReport() {ex.Message}");

            }
            return customerReportId;
        }
        public static bool Find( int AccountID,DateTime RequestedDate,ref int CustomerReportId, ref byte TransctionCount, ref double TotalDepit, ref double TotalCredit, ref DateTime FromDate, ref DateTime ToDate)
        {
            string Query = @"[dbo].[Sp_CustomerAccountActivityReports_GetByID]";
            bool found = false;
            CustomerReportId = _GenerateAccountActivityReport( AccountID,RequestedDate);
            try
            {
                if (CustomerReportId == -1)
                {
                    throw new ArgumentException($"Can't Generate Or Load Account Activity Report For Account[{AccountID}]");
                }

                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BalanceStatementReportID", CustomerReportId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TransctionCount = clsGlobal.DB_SafeGet<byte>(reader, "TransactionCount", 0);
                            TotalDepit = clsGlobal.DB_SafeGet<double>(reader, "TotalDepit", 0);
                            TotalCredit = clsGlobal.DB_SafeGet<double>(reader, "TotalCredit", 0);
                            FromDate = clsGlobal.DB_SafeGet<DateTime>(reader, "FromDate", DateTime.MinValue);
                            ToDate = clsGlobal.DB_SafeGet<DateTime>(reader, "ToDate", DateTime.MinValue);

                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsAccountActivityReports_DAL.Find() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsAccountActivityReports_DAL.Find() {ex.Message}");

            }
            return found;
        }
        public static DataTable FilterReports(int? CustomerID, int? AccountID, DateTime? FromDate,DateTime? ToDate, byte? MinTransactions, double? MinDebit, double? MinCredit, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_CustomerAccountActivityReports_FilterPage]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountID", AccountID.HasValue ? (object)AccountID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@FromDate", FromDate.HasValue ? (object)FromDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ToDate", ToDate.HasValue ? (object)ToDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MinTransactions", MinTransactions.HasValue ? (object)MinTransactions.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MinDebit", MinDebit.HasValue ? (object)MinDebit.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MinCredit", MinCredit.HasValue ? (object)MinCredit.Value : DBNull.Value);

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
                clsGlobal.LogError($"DAL -> clsAccountActivityReports_DAL.FilterReports() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsAccountActivityReports_DAL.FilterReports() {ex.Message}");

            }
            return dt;
        }


    }
}
