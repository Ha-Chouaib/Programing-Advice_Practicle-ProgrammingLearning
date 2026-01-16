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
            string Query = @"[dbo].[sp_GenerateCustomerSummaryReport]";
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
        public static bool Find(int CustomerID, ref byte TotalAccounts ,ref byte ActiveAccounts,ref double TotalBalance,ref DateTime LastActivityDate,ref bool CustomerStatus)
        {
            string Query = @"[dbo].[Sp_CustomerSummaryReports_GetByID]";
            bool found = false;
            int ReportID = _GenerateCustomerSummaryReport(CustomerID);
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
        public static DataTable ListReportsByCustomerID(int CustomerID)
        {
            DataTable dt = new DataTable();
            string Query = @"[dbo].[Sp_CustomerSummaryReports_ListByCustomerID]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports.ListReportsByCustomerID() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports.ListReportsByCustomerID() {ex.Message}");

            }
            return dt;
        }
        public static DataTable ListReports()
        {
            DataTable dt = new DataTable();
            string Query = @"[dbo].[Sp_CustomerSummaryReports_ListAll]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports.ListReports() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> CustomerSummaryReports.ListReports() {ex.Message}");

            }
            return dt;
        }


    }
}
