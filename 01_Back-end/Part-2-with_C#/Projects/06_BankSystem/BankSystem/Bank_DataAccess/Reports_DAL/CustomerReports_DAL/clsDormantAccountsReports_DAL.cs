using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports.CustomerReports
{
    public class clsDormantAccountsReports_DAL
    {
        public static int _GenerateCustomerDormantAccountsReport()
        {
            int CustomerReportID = -1;
            string Query = @"[dbo].[Sp_CustomerDormantAccountReports_Generate]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter outputId = new SqlParameter("@CustomerReportID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outputId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    CustomerReportID = Convert.ToInt32(outputId.Value);

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsDormantAccountsReports_DAL._GenerateCustomerDormantAccountsReport() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsDormantAccountsReports_DAL._GenerateCustomerDormantAccountsReport() {ex.Message}");

            }
            return CustomerReportID;


        }
        public static bool Find(int ReportID, ref int AccountID, ref int TransactionID, ref DateTime LastTransactionDate, ref byte DormantMonths)
        {
            string Query = @"[dbo].[Sp_CustomerDormantAccountReports_GetByID]";
            bool found = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AccountID = clsGlobal.DB_SafeGet<int>(reader, "AccountID", -1);
                            DormantMonths = clsGlobal.DB_SafeGet<byte>(reader, "DormantMonths", 0);
                            TransactionID = clsGlobal.DB_SafeGet<int>(reader, "TransactionID", -1);
                            LastTransactionDate = clsGlobal.DB_SafeGet<DateTime>(reader, "LastTransactionDate", DateTime.MinValue);
                          
                            found = true;
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> clsDormantAccountsReports_DAL.Find() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsDormantAccountsReports_DAL.Find() {ex.Message}");

            }
            return found;
        }
        public static DataTable FilterReports(int? AccountID, int? CustomerID, DateTime? ReportDate, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_CustomerDormantAccountReports_FilterPage]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountID", AccountID.HasValue ? (object)AccountID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReportDate", ReportDate.HasValue ? (object)ReportDate.Value : DBNull.Value);


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
                clsGlobal.LogError($"DAL -> clsDormantAccountsReports_DAL.FilterReports() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> clsDormantAccountsReports_DAL.FilterReports() {ex.Message}");

            }
            return dt;
        }

    }
}
