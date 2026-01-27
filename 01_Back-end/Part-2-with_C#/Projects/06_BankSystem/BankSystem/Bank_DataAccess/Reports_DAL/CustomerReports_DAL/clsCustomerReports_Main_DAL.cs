using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess.Reports.CustomerReports
{
    public class clsCustomerReports_Main_DAL
    {
        public static bool Find(int CustomerreportID, ref int CustomerID, ref short ReportTypeID, ref DateTime ReportDate)
        {
            string Query = @"[dbo].[Sp_CustomerReports_GetByID]";
            bool found = false;
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerReportID", CustomerreportID);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CustomerID = clsGlobal.DB_SafeGet<int>(reader, "CustomerID", -1);
                                ReportTypeID = clsGlobal.DB_SafeGet<short>(reader, "ReportTypeID", -1);
                                ReportDate = clsGlobal.DB_SafeGet<DateTime>(reader, "ReportDate", DateTime.MinValue);
                                found = true;
                            }
                        }
                    }
                }
            }catch(SqlException sqlEx)
            {
                clsGlobal.LogError("SQL Error in clsCustomerReports_Main_DAL.Find: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                clsGlobal.LogError("Error in clsCustomerReports_Main_DAL.Find: " + ex.Message);
            }
            return found;
        }
    }
}
