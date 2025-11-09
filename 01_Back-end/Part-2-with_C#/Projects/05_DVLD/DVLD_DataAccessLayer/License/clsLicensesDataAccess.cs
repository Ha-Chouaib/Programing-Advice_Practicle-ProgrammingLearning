using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

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
                    LicenseClassID    = (int)Reader["LicenseClass"];
                    IssueReason    = Convert.ToByte(Reader["IssueReason"]);
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
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ Find() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool Find_ByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
                                ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Licenses WHERE ApplicationID = @ApplicationID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    LicenseID = (int)Reader["LicenseID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClassID    = (int)Reader["LicensClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    if (Reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)Reader["Notes"];

                    IssueReason    = Convert.ToByte(Reader["IssueReason"]);
                    PaidFees = (float)(decimal)Reader["PaidFees"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ FindBy_ApplicationID() ]: {ex.Message}", EventLogEntryType.Error);
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
            if(Notes == string.Empty)
                cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
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
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ AddNewLicense() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return LicenseID;
        }
        public static bool UpdateLicense(int LicenseID, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update Licenses SET
                                                   IsActive = @IsActive Where LicenseID= @LicenseID;";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            int RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ UpdateLicense() ]: {ex.Message}", EventLogEntryType.Error);
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
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ DeleteLicense() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static bool Exist(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select Found=1 from Licenses Where LicenseID=@LicenseID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) Found = true;

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ Exist() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static bool HasActiveLicenseClass(int DriverID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT Top 1 Found = 1 From Licenses Where DriverID = @DriverID AND LicenseClass = @LicenseClassID AND IsActive = 1; ;";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) Found = true;

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ HasActiveLicenseClass() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return Found;
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
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ ListLicenses() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

        public static DataTable ListLocalLicenses_DriverHistory(int DriverID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"
                            SELECT LicenseID,ApplicationID, 
		                    (Select LicenseClasses.ClassName from LicenseClasses Where LicenseClassID = Licenses.LicenseClass) As ClassName,
		                    IssueDate,ExpirationDate,IsActive FROM Licenses
		                    WHERE DriverID = @DriverID 
                            Order By IsActive Desc;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                DT.Load(reader);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"Licenses DataAccess: [ ListLocalLicnese_DriverHistory() ]: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

       

    }
}
