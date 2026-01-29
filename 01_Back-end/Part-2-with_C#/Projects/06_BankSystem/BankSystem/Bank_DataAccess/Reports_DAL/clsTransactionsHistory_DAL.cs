using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    public class clsTransactionHistory
    {
        public static int AddNewTransaction(byte TransactionType, DateTime TransactionDate, int AccountFromID, int? AccountToID,
            double Amount, double OldBalance, double NewBalance, string Notes, int PerformedByUserID , bool IsPerformedByAccountOwner)
        {
            string Query = "[dbo].[Sp_Transaction_AddNew]";
            int ID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TransactionType", TransactionType);
                    cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate);
                    cmd.Parameters.AddWithValue("@AccountFromID", AccountFromID);
                    cmd.Parameters.AddWithValue("@AccountToID", AccountToID);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@OldBalance", OldBalance);
                    cmd.Parameters.AddWithValue("@NewBalance", NewBalance);
                    cmd.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? DBNull.Value : (object)Notes);
                    cmd.Parameters.AddWithValue("@PerformedByUserID", PerformedByUserID);
                    cmd.Parameters.AddWithValue("@PerformedByCustomer", IsPerformedByAccountOwner);


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        ID = clsGlobal.DB_SafeGet<int>(rdr, "TransactionID", -1);
                        if (ID == -1)
                            throw new InvalidOperationException(clsGlobal.DB_SafeGet(rdr, "ErrorMSG", ""));
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: LogsDataAccess.AddNewTransaction() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: LogsDataAccess.AddNewTransaction() ] -> {ex.Message}");
            }
            return ID;
        }

        public static bool Find(int TransactionID ,ref byte transactionType,ref DateTime transactionDate,ref int accountFromID,ref int? accountToID,ref double amount,ref double oldBalance,ref double newBalance,ref string notes,ref int performedByUserID, ref bool IsPerformedByAccountOwner)
        {
            bool found = false;
            string Query = "[dbo].[Sp_Transaction_GetByID]";
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                    connection.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            transactionType = clsGlobal.DB_SafeGet<byte>(rdr, "TransactionType", 0);
                            transactionDate = clsGlobal.DB_SafeGet<DateTime>(rdr, "TransactionDate", DateTime.MinValue);
                            accountFromID = clsGlobal.DB_SafeGet<int>(rdr, "AccountFromID", -1);
                            accountToID = clsGlobal.DB_SafeGet<int?>(rdr, "AccountToID", null);
                            amount = clsGlobal.DB_SafeGet<double>(rdr, "Amount", 0);
                            oldBalance = clsGlobal.DB_SafeGet<double>(rdr, "OldBalance", 0);
                            newBalance = clsGlobal.DB_SafeGet<double>(rdr, "NewBalance", 0);
                            notes = clsGlobal.DB_SafeGet<string>(rdr, "Notes", "");
                            performedByUserID = clsGlobal.DB_SafeGet<int>(rdr, "PerformedByUserID", -1);
                            IsPerformedByAccountOwner = clsGlobal.DB_SafeGet<bool>(rdr, "PerformedByCustomer", false);
                            found = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: LogsDataAccess.Find() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: LogsDataAccess.Find() ] -> {ex.Message}");
            }
            return found;
        }
        public static DataTable FilterTransactions
        (int? TransactionID, int? AccountFromID, int? AccountToID, int? AccountOwnerID,bool? IsPerformedByCustomer,int? PerformedByUserID,DateTime? TransactionDate, byte pageNumber, byte pageSize, out int totalRows)
        {
            totalRows = 0;
            DataTable dt = new DataTable();
            try
            {


                using (SqlConnection conn = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[Sp_TransactionsList_FilterPaged]", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TransactionID", TransactionID.HasValue ? (object)TransactionID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountFromID", AccountFromID.HasValue ? (object)AccountFromID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountToID", AccountToID.HasValue ? (object)AccountToID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccountOwnerID", AccountOwnerID.HasValue ? (object)AccountOwnerID.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@PerformedByCustomer", IsPerformedByCustomer.HasValue ? (object)IsPerformedByCustomer.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TransactionDate", TransactionDate.HasValue ? (object)TransactionDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@PerformedByUserID", PerformedByUserID.HasValue ? (object)PerformedByUserID.Value : DBNull.Value);

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
                clsGlobal.LogError($"DAL -> TransactionsHistory.FilterTransactions() ,SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"DAL -> TransactionsHistory.FilterTransactions() {ex.Message}");

            }
            return dt;
        }
    }

}
