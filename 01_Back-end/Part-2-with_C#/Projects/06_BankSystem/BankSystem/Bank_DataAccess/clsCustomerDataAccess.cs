using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsCustomerDataAccess
    {
        public static int AddNewCustomer(int PersonID,string Occupation,byte CustomerType ,DateTime CreatedDate, int CreatedByUserID,bool IsActive)
        {
            string Query = "[dbo].[Sp_Customer_AddNew]";
            int CustomerID = -1;

            try
            {
                using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using( SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID",PersonID);
                    cmd.Parameters.AddWithValue("@Occupation",Occupation);
                    cmd.Parameters.AddWithValue("@CustomerType",CustomerType);
                    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            if (CustomerID == -1)
                                throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.AddNewCustomer() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.AddNewCustomer() ] -> {ex.Message}");
            }
            return CustomerID;
        }
    
        public static bool FindCustomerByID(int CustomerID, ref int PersonID, ref string Occupation,ref byte CustomerType, ref DateTime CreatedDate, ref int CreatedByUserID, ref bool IsActive)
        {
            string Query = "[dbo].[Sp_Customer_GetByID]";
            bool Found = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            PersonID = Convert.ToInt32(rdr["PersonID"]);
                            Occupation = rdr["Occupation"].ToString() ?? string.Empty;
                            CustomerType = Convert.ToByte(rdr["CustomerType"]);
                            CreatedDate = (DateTime)rdr["CreatedDate"];
                            CreatedByUserID = Convert.ToInt32(rdr["CreatedByUserID"]);
                            IsActive = Convert.ToBoolean(rdr["IsActive"]);

                            Found = true;

                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.FindCustomerByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.FindCustomerByID() ] -> {ex.Message}");
            }
            return Found;


        }

        public static bool FindCustomerByPersonID(int PersonID, ref int CustomerID, ref string Occupation, ref byte CustomerType, ref DateTime CreatedDate, ref int CreatedByUserID,ref bool IsActive)
        {
            string Query = "[dbo].[Sp_Customer_GetByPersonID]";
            bool Found = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                            Occupation = rdr["Occupation"].ToString() ?? string.Empty;
                            CustomerType = Convert.ToByte(rdr["CustomerType"]);
                            CreatedDate = (DateTime)rdr["CreatedDate"];
                            CreatedByUserID = Convert.ToInt32(rdr["CreatedByUserID"]);
                            IsActive = Convert.ToBoolean(rdr["IsActive"]);

                            Found = true;

                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.FindCustomerByPersonID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.FindCustomerByPersonID() ] -> {ex.Message}");
            }
            return Found;


        }

        public static bool Update(int CustomerID, string Occupation, byte CustomerType, bool IsActive)
        {
            string Query = "[dbo].[Sp_Customer_Update]";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@Occupation", Occupation);
                    cmd.Parameters.AddWithValue("@CustomerType", CustomerType);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);


                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.Update() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.Update() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateCustomerStatus(int CustomerID, bool IsActive)
        {
            string Query = "[dbo].[Sp_Customer_UpdateStatus]";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = Convert.ToBoolean(reader["Success"]);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.UpdateCustomerStatus() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.UpdateCustomerStatus() ] -> {ex.Message}");

            }

            return success;
        }

        public static bool IsCustomerExistsByID(int CustomerID)
        {
            string Query = @" SELECT dbo.Fn_IsCustomerExistsByID(@CustomerID)";
            bool Exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.IsCustomerExistsByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.IsCustomerExistsByID() ] -> {ex.Message}");
            }
            return Exists;
        }
        public static bool IsCustomerExistsByPersonID(int PersonID)
        {
            string Query = @" SELECT dbo.Fn_IsCustomerExistsByPersonID(@PersonID)";
            bool Exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.IsCustomerExistsByPersonID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.IsCustomerExistsByPersonID() ] -> {ex.Message}");
            }
            return Exists;
        }
        public static bool IsActive(int CustomerID)
        {
            string Query = @" SELECT dbo.Fn_IsCustomerActive(@CustomerID)";
            bool Active = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool active)) Active = active;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.IsActive() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.IsActive() ] -> {ex.Message}");
            }
            return Active;
        }        
        public static bool Delete(int CustomerID, int DeletedByUserID)
        {

            string Query = "[dbo].[Sp_Customer_Delete]";
            bool Deleted = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@DeletedByUserID", DeletedByUserID);

                    connection.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        Deleted = Convert.ToBoolean(rdr["Success"]);
                        if (!Deleted)
                        {
                            throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.Delete() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {   
                clsGlobal.LogError($"[DAL: Customer.Delete() ] -> {ex.Message}");

            }

            return Deleted;
        }
      
        public static DataTable FilterCustomers
        (int? CustomerID, int? PersonID, int? CreatedByUserID, bool? IsActive, byte? CustomerType, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(" [dbo].[Sp_Customers_FilterPaged]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@PersonID", PersonID.HasValue ? (object)PersonID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive.HasValue ? (object)IsActive.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID.HasValue ? (object)CreatedByUserID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerType", CustomerType.HasValue? (object)CustomerType.Value : DBNull.Value);

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
                clsGlobal.LogError($"DAL -> Customers.FilterCustomers() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> Customers.FilterCustomers() {ex.Message}");

            }
            return dt;
        }

        public static DataTable GetCustomerAccounts(int CustomerID)
        {

            string Query = "[dbo].[Sp_Customer_GetAccounts]";
            DataTable accounts = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        accounts.Load(rdr);
                    }
                }

            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.GetCustomerAccounts() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.GetCustomerAccounts() ] -> {ex.Message}");
            }

            return accounts;
        }
        public static bool HasAccountType(int CustomerID, byte AccountType)
        {
            string Query = @" SELECT dbo.Fn_HasAccountType(@CustomerID,@AccountType)";
            bool HasType = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@AccountType", AccountType);
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool hasType)) HasType = hasType;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.HasAccountType() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.HasAccountType() ] -> {ex.Message}");
            }
            return HasType; 
        }


    }
}
