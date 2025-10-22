﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_DataAccess
{
    internal class clsLogsDataAccess
    {
        public static int AddNewTransaction(byte TransactionType, DateTime TransactionDate, int AccountFromID, int? AccountToID,
            double Amount, double OldBalance, double NewBalance, string Notes, int PerformedByUserID)
        {
            string Query = "Sp_AddNewTransaction";
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

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        ID = clsGlobal.SafeGet<int>(rdr, "TransactionID", -1);
                        if (ID == -1)
                            throw new InvalidOperationException(clsGlobal.SafeGet(rdr, "ErrorMSG", ""));
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

        public static DataTable GetFilteredTransactions(string Column, string FilterBy)
        {
            string Query = "Sp_GetFilteredTransactions";
            DataTable dt = new DataTable();
            List<string> ValidColumns = new List<string> { "All", "TransactionType", "TransactionDate", "AccountFromID", "PerformedByUerID" };
            try
            {
                if (!ValidColumns.Contains(Column))
                    throw new ArgumentException($"{FilterBy} is not valid.");

                using (SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString))
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Column", Column);
                    cmd.Parameters.AddWithValue("@FilterBySql", FilterBy ?? (object)DBNull.Value);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        dt.Load(rdr);
                    }

                }
            }
            catch (SqlException ex)
            {
                clsGlobal.LogError($"[DAL: LogsDataAccess.GetFilteredTransactions() ] -> SqlServer Error({ex.Number}): {ex.Message}");
            }
            catch (Exception ex)
            {
                clsGlobal.LogError($"[DAL: LogsDataAccess.GetFilteredTransactions() ] -> {ex.Message}");
            }
            return dt;
            }
        
    
    
    
    
    }   

        

}
