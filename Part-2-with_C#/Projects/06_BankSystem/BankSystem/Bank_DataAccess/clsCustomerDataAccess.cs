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
            string Query = "dbo.Sp_AddNewCustomer";
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
            string Query = "Sp_GetCustomerByID";
            bool Found = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

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
            string Query = "Sp_GetCustomerByPersonID";
            bool Found = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PersonID", PersonID);

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
            string Query = "Sp_UpdateCustomer";
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
            string Query = "Sp_UpdateCustomerStatus";
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
        public static bool Delete(int CustomerID)
        {

            string Query = "Sp_DeleteUser";
            bool Deleted = false;
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
        public static DataTable GetAllCustomers()
        {
            string Query = "Sp_GetAllCustomers";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.GetAllCustomers() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.GetAllCustomers() ] -> {ex.Message}");

            }
            return dt;
        }


    }
}
