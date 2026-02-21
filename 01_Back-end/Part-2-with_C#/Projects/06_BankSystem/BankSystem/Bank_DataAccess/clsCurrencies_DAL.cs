using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsCurrencies_DAL
    {
        public static bool FindByID(int ID , ref string Code, ref string Country, ref string Name, ref float Rate)
        {
            string Query = "[dbo].[Sp_CurrenciesGetByID]";
            bool found = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            Code = rdr["ID"].ToString() ?? string.Empty;
                            Country = rdr["Country"].ToString() ?? string.Empty;
                            Name = rdr["Name"].ToString() ?? string.Empty;
                            Rate = rdr["Rate"] != DBNull.Value ? Convert.ToSingle(rdr["Rate"]) : 0;
                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.FindByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.FindByID() ] -> {ex.Message}");
            }

            return found;
        }

        public static bool FindByCode(string Code, ref int ID, ref string Country, ref string Name, ref float Rate)
        {
            string Query = "[dbo].[Sp_CurrenciesGetByCode]";
            bool found = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Code);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ID = rdr["ID"] != DBNull.Value ? Convert.ToInt32(rdr["ID"]) : -1;
                            Country = rdr["Country"].ToString() ?? string.Empty;
                            Name = rdr["Name"].ToString() ?? string.Empty;
                            Rate = rdr["Rate"] != DBNull.Value ? Convert.ToSingle(rdr["Rate"]) : 0;
                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.FindByCode() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.FindByCode() ] -> {ex.Message}");
            }

            return found;
        }

        public static bool FindByName(string Name, ref int ID, ref string Country, ref string Code, ref float Rate)
        {
            string Query = "[dbo].[Sp_CurrenciesGetByName]";
            bool found = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", Name);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ID = rdr["ID"] != DBNull.Value ? Convert.ToInt32(rdr["ID"]) : -1;
                            Country = rdr["Country"].ToString() ?? string.Empty;
                            Code = rdr["ID"].ToString() ?? string.Empty;
                            Rate = rdr["Rate"] != DBNull.Value ? Convert.ToSingle(rdr["Rate"]) : 0;
                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.FindByName() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.FindByName() ] -> {ex.Message}");
            }

            return found;
        }
        public static bool UpdateRateByCode(string Code, float Rate)
        {
            string Query = "[dbo].[Sp_CurrenciesUpdateRateByCode]";
            bool success = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", Code);
                    cmd.Parameters.AddWithValue("@Rate", Rate);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                            success = Convert.ToBoolean(rdr["success"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.UpdateRateByCode() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.UpdateRateByCode() ] -> {ex.Message}");
            }

            return success;
        }
        public static bool UpdateRateByID(int ID, float Rate)
        {
            string Query = "[dbo].[Sp_CurrenciesUpdateRateByID]";
            bool success = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Rate", Rate);

                    conn.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                            success = Convert.ToBoolean(rdr["success"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.UpdateRateByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.UpdateRateByID() ] -> {ex.Message}");
            }

            return success;
        }

        public static float GetRateByID(int ID)
        {
            float rate = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.Fn_CurrenciesGetRateByID(@ID)", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    conn.Open();
                    rate = Convert.ToSingle(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.GetRateByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.GetRateByID() ] -> {ex.Message}");
            }

            return rate;
        }
        public static float GetRateByCode(string Code)
        {
            float rate = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.Fn_CurrenciesGetRateByCode(@ID)", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", Code);
                    conn.Open();
                    rate = Convert.ToSingle(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.GetRateByCode() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.GetRateByCode() ] -> {ex.Message}");
            }

            return rate;
        }

        public static DataTable Filter(string country, string name, string code, short pageNumber, short pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_CurrenciesList_Filter]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country", (object)country ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", (object)name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Code", (object)code ?? DBNull.Value);

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
                clsGlobal.LogError($"[DAL: Currencies.Filter() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Currencies.Filter() ] -> {ex.Message}");
            }

            return dt;
        }
    }

}

