using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsAccountsDataAccess
    {
       
        public static (int AccountID,string AccountNumber) AddNewAccount(int CustomerID, byte AccountType, double Balance, bool IsActive, DateTime CreatedDate, int CreatedByUserID)
        {
            string Query = "[dbo].[Sp_Accounts_AddNew]";
            int AccountID = -1;
            string AccountNumber = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@AccountType", AccountType);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@CreatedAt", CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    connection.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            AccountID = clsGlobal.DB_SafeGet<int>(rdr, "AccountID",-1);
                            AccountNumber = clsGlobal.DB_SafeGet<string>(rdr, "AccountNumber", "");
                            if (AccountID == -1)
                                throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.AddNewAccount() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.AddNewAccount() ] -> {ex.Message}");
            }

            return (AccountID,AccountNumber);
        }
    
        public static bool FindByID(int AccountID,ref int CustomerID,ref string AccountNumber,ref byte AccountType,
            ref double Balance,ref bool IsActive,ref DateTime CreatedDate,ref int CreatedByUserID)
        {
            string Query = "[dbo].[Sp_Account_GetByID]";
            bool found=false;
            try
            {
                using(SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    connection.Open();
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                           

                            CustomerID = clsGlobal.DB_SafeGet<int>(rdr, "CustomerID", -1);
                            AccountNumber = clsGlobal.DB_SafeGet<string>(rdr, "AccountNumber",string.Empty);
                            AccountType = clsGlobal.DB_SafeGet<byte>(rdr, "AccountType",0);
                            Balance = clsGlobal.DB_SafeGet<double>(rdr, "Balance",0);
                            IsActive = clsGlobal.DB_SafeGet<bool>(rdr, "IsActive",false);
                            CreatedDate = clsGlobal.DB_SafeGet<DateTime>(rdr, "CreatedAt",DateTime.MinValue);
                            CreatedByUserID = clsGlobal.DB_SafeGet<int>(rdr, "CreatedByUserID", -1);

                            found = true;
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.FindAccountByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.FindAccountByID() ] -> {ex.Message}");
            }

            return found;
        }
        public static bool FindByAccountNumber(string AccountNumber, ref int AccountID, ref int CustomerID,  ref byte AccountType,
           ref double Balance, ref bool IsActive, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            string Query = "[dbo].[Sp_AccountGet_ByAccountNumber]";
            bool found = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                           

                            CustomerID = clsGlobal.DB_SafeGet<int>(rdr, "CustomerID", -1);
                            AccountID = clsGlobal.DB_SafeGet<int>(rdr, "AccountID", -1);
                            AccountType = clsGlobal.DB_SafeGet<byte>(rdr, "AccountType", 0);
                            Balance = clsGlobal.DB_SafeGet<double>(rdr, "Balance", 0);
                            IsActive = clsGlobal.DB_SafeGet<bool>(rdr, "IsActive", false);
                            CreatedDate = clsGlobal.DB_SafeGet<DateTime>(rdr, "CreatedAt",DateTime.MinValue);
                            CreatedByUserID = clsGlobal.DB_SafeGet<int>(rdr, "CreatedByUserID", -1);

                            found = clsGlobal.DB_SafeGet<bool>(rdr, "Success", false);
                            if (!found)
                                throw new InvalidOperationException(rdr["ErrorMSG"].ToString());
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.FindByAccountNumber() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.FindByAccountNumber() ] -> {ex.Message}");
            }

            return found;
        }
       
        public static bool ExistsByAccountNumber(string AccountNumber)
        {
            string Query = @" SELECT dbo.Fn_IsAccountExistsByAccountNumber(@AccountNumber)";
            bool Exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.ExistsByAccountNumber() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.ExistsByAccountNumber() ] -> {ex.Message}");
            }
            return Exists;

        }
        public static bool ExistsByID(int AccountID)
        {
            string Query = @" SELECT dbo.Fn_IsAccountExistsByID(@AccountID)";
            bool Exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AccountID", AccountID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool exists)) Exists = exists;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.ExistsByID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.ExistsByID() ] -> {ex.Message}");
            }
            return Exists;

        }
        public static bool ExistsByCustomerID(int CustomerID)
        {
            string Query = @" SELECT dbo.Fn_IsAccountExistsByCustomerID(@CustomerID)";
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
                clsGlobal.LogError($"[DAL: Account.ExistsByCustomerID() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.ExistsByCustomerID() ] -> {ex.Message}");
            }
            return Exists;

        }
        
        public static bool Update(int AccountID,byte AccountType,double Balance,  bool IsActive)
        {

            string Query = "Sp_UpdateAccount";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@AccountType", AccountType);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);


                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = clsGlobal.DB_SafeGet<bool>(reader, "Success",false);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.Update() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.Update() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateBalance(int AccountID,  double Balance)
        {

            string Query = "[dbo].[Sp_Account_UpdateBalanceByID]";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@Balance", Balance);
 


                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = clsGlobal.DB_SafeGet<bool>(reader, "Success", false);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.UpdateBalance() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.UpdateBalance() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateStatus(int AccountID, bool IsActive)
        {

            string Query = "[dbo].[Sp_Account_UpdateStatusByID]";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);



                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success = clsGlobal.DB_SafeGet<bool>(reader, "Success", false);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.UpdateBalance() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }   
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.UpdateBalance() ] -> {ex.Message}");

            }

            return success;
        }
        public static bool UpdateAccountType(int AccountID, byte AccountType)
        {

            string Query = "[dbo].[Sp_Account_UpdateType]";
            bool success = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@AccountType", AccountType);



                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            success =clsGlobal.DB_SafeGet<bool>(reader,"Success", false);

                            if (!success) throw new InvalidOperationException(reader["ErrorMSG"].ToString());
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.UpdateAccountType() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.UpdateAccountType() ] -> {ex.Message}");

            }

            return success;
        }

        public static bool DepositWithdraw(int AccountID, double Amount)
        {
            string Query = "[dbo].[Sp_Account_DepositWithdraw]";
            bool Success = false;
            try
            {


                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);

                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        Success = clsGlobal.DB_SafeGet<bool>(rdr, "Success", false);

                        if (!Success)
                            throw new InvalidOperationException(clsGlobal.DB_SafeGet<string>(rdr, "ErrorMSG", ""));

                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.DepositWithdraw() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.DepositWithdraw() ] -> {ex.Message}");

            }
            return Success;

        }

        public static bool TransferMoney(int AccountFromID, int AccountToID, double Amount)
        {
            string Query = "[dbo].[Sp_Account_TransferMoney]";
            bool Success = false;
            try
            {


                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountFromID", AccountFromID);
                    cmd.Parameters.AddWithValue("@AccountToID", AccountToID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);

                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        Success = clsGlobal.DB_SafeGet<bool>(rdr, "Success", false);

                        if (!Success)
                            throw new InvalidOperationException(clsGlobal.DB_SafeGet<string>(rdr, "Message", ""));

                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Customer.TransferMoney() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Customer.TransferMoney() ] -> {ex.Message}");

            }
            return Success;
        }

        public static bool IsActive(int AccountID)
        {

            string Query = @" SELECT dbo.Fn_GetAccountStatus(@AccountID)";
            bool Active = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@AccountID", AccountID);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && bool.TryParse(result.ToString(), out bool active)) Active = active;
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Account.IsActive() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.IsActive() ] -> {ex.Message}");
            }
            return Active;
        }

        public static bool Delete(int AccountID,int DeletedByUserID)
        {
            string Query = "[dbo].[Sp_Account_Delete]";
            bool Deleted = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
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
                clsGlobal.LogError($"[DAL: Account.Delete() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.Delete() ] -> {ex.Message}");

            }

            return Deleted;
        }

        public static DataTable FilterAccounts
        (int? AccountID,string AccountNumber, int? CustomerID, int? CreatedByUserID, bool? IsActive, byte? AccountType, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(" [dbo].[Sp_Accounts_FilterPaged]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID.HasValue ? (object)CustomerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountID", AccountID.HasValue ? (object)AccountID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive.HasValue ? (object)IsActive.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID.HasValue ? (object)CreatedByUserID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountType", AccountType.HasValue ? (object)AccountType.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountNumber", !string.IsNullOrEmpty(AccountNumber) ? (object)AccountNumber : DBNull.Value);

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
                clsGlobal.LogError($"DAL -> Accounts.FilterAccounts() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> Accounts.FilterAccounts() {ex.Message}");

            }
            return dt;
        }

    }
}
