﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer.License
{
    public class clsLicensesDataAccess
    {
        public static bool Find(int LicenseID,ref int ApplicationID,ref int DriverID,ref int LicenseClassID,ref DateTime IssueDate,
                                ref DateTime ExpirationDate,ref string Notes,ref float PaidFees,ref bool IsActive,ref byte IssueReason,ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Licenses WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader=cmd.ExecuteReader();
                if(Reader.Read())
                {
                    IsFound = true;

                    ApplicationID   = (int)Reader["ApplicationID"];
                    DriverID        = (int)Reader["DriverID"];
                    IssueDate       = (DateTime)Reader["IssueDate"];
                    ExpirationDate  = (DateTime)Reader["ExpirationDate"];

                    if(Reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)Reader["Notes"];

                    PaidFees = (float)(decimal)Reader["PaidFees"];
                    IsActive        = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
            }catch(Exception ex)
            {
                Console.WriteLine("------------------ DB Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                                DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INto Licenses (ApplicationID,DriverID, LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID )
                                         Values
                                            (@ApplicationID, @DriverID, @LicenseClassID,@IssueDate,@ExpirationDate,@Notes ,@PaidFees,@IsActive,@IssueReason, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int LicenseID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) LicenseID = ID;

            }
            catch (Exception ex) 
            {
                Console.WriteLine("-------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return LicenseID;
        }
        public static bool UpdateLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update Licenses SET
                                                   ApplicationID    = @ApplicationID,
                                                   DriverID         = @DriverID,
                                                   LicenseClass     = @LicenseClassID,
                                                   IssueDate        = @IssueDate,
                                                   ExpirationDate   = @ExpirationDate,
                                                   Notes            = @Notes,
                                                   PaidFees         = @PaidFees,
                                                   IsActive         = @IsActive,
                                                   IssueReason      = @IssueReason,
                                                   CreatedByUSerID  = @CreatedByUserID,
                                                    WHERE LicenseID = @LicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }
        public static bool DeleteLicense(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete Licenses Where LicenseID=@LicenseID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static DataTable ListLicenses()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Licenses ;";

            SqlCommand cmd = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DT.Load(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }



    }
}
