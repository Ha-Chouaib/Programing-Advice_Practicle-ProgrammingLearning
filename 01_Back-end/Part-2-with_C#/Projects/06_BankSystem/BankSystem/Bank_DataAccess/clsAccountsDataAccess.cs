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
            string Query = "dbo.Sp_AddNewAccount";
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
                            AccountID = clsGlobal.SafeGet<int>(rdr, "AccountID",-1);
                            AccountNumber = clsGlobal.SafeGet<string>(rdr, "AccountNumber", "");
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
            string Query = "dbo.Sp_GetAccountByID";
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
                           

                            CustomerID = clsGlobal.SafeGet<int>(rdr, "CustomerID", -1);
                            AccountNumber = clsGlobal.SafeGet<string>(rdr, "AccountNumber",string.Empty);
                            AccountType = clsGlobal.SafeGet<byte>(rdr, "AccountType",0);
                            Balance = clsGlobal.SafeGet<double>(rdr, "Balance",0);
                            IsActive = clsGlobal.SafeGet<bool>(rdr, "IsActive",false);
                            CreatedDate = clsGlobal.SafeGet<DateTime>(rdr, "CreatedAt",DateTime.MinValue);
                            CreatedByUserID = clsGlobal.SafeGet<int>(rdr, "CreatedByUserID", -1);

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
            string Query = "dbo.GetAccountByAccountNumber";
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
                           

                            CustomerID = clsGlobal.SafeGet<int>(rdr, "CustomerID", -1);
                            AccountID = clsGlobal.SafeGet<int>(rdr, "AccountID", -1);
                            AccountType = clsGlobal.SafeGet<byte>(rdr, "AccountType", 0);
                            Balance = clsGlobal.SafeGet<double>(rdr, "Balance", 0);
                            IsActive = clsGlobal.SafeGet<bool>(rdr, "IsActive", false);
                            CreatedDate = clsGlobal.SafeGet<DateTime>(rdr, "CreatedAt",DateTime.MinValue);
                            CreatedByUserID = clsGlobal.SafeGet<int>(rdr, "CreatedByUserID", -1);

                            found = clsGlobal.SafeGet<bool>(rdr, "Success", false);
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
                            success = clsGlobal.SafeGet<bool>(reader, "Success",false);

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

            string Query = "Sp_UpdateBalanceByAccountID";
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
                            success = clsGlobal.SafeGet<bool>(reader, "Success", false);

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

            string Query = "Sp_UpdateAccountStatusByID";
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
                            success = clsGlobal.SafeGet<bool>(reader, "Success", false);

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

            string Query = "Sp_UpdateAccountType";
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
                            success =clsGlobal.SafeGet<bool>(reader,"Success", false);

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
            string Query = "Sp_Trans_DepositWithdraw";
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
                        Success = clsGlobal.SafeGet<bool>(rdr, "Success", false);

                        if (!Success)
                            throw new InvalidOperationException(clsGlobal.SafeGet<string>(rdr, "ErrorMSG", ""));

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
            string Query = "Sp_TransferMoney";
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
                        Success = clsGlobal.SafeGet<bool>(rdr, "Success", false);

                        if (!Success)
                            throw new InvalidOperationException(clsGlobal.SafeGet<string>(rdr, "Message", ""));

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
            string Query = "Sp_DeleteAccount";
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

        public static DataTable ListAccounts()
        {

            string Query = "Sp_GetAccounts";
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
                clsGlobal.LogError($"[DAL: Account.ListAccounts() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: Account.ListAccounts() ] -> {ex.Message}");

            }
            return dt;
        }

        public static DataTable FilterAccounts(string Column, string Term)
        {
            string Query = "Sp_FilterAccountsList";
            DataTable FilteredList = new DataTable();
            string[] AllowedColumn = new string[] { "All", "ID", "CustomerID", "IsActive", "AccountType","AccountNumber" };
            try
            {
                if (!AllowedColumn.Contains(Column))
                {
                    throw new ArgumentException($"Invalid Column Name: {Column}");
                }
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Column", Column);
                    cmd.Parameters.AddWithValue("@FilterBy", Term);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        FilteredList.Load(reader);
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: Accounts.FilterAccounts() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL:  Accounts.FilterAccounts() ] -> {ex.Message}");

            }
            return FilteredList;
        }

    }
}
