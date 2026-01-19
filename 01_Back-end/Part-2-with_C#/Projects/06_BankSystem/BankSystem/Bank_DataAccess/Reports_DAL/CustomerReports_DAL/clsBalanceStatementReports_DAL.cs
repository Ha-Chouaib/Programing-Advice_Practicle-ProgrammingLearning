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
            string Query = @"dbo.Sp_BalanceStatementReports_Generate";
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
            string Query = @"[dbo].[Sp_BalanceStatementReports_GetByID]";
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
    }
}
