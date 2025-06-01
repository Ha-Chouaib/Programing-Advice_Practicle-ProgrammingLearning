using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer.License
{
    public class clsInternationalLicensedataAccess
    {
        public static bool Find(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
                             ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------ DB Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool Find_DriverID(int DriverID, ref int InternationalLicenseID, ref int ApplicationID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
                             ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From InternationalLicenses WHERE DriverID = @DriverID AND IsActive = 1";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DriverID",DriverID );
            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    InternationalLicenseID = (int)Reader["InternationalLicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    IssuedUsingLocalLicenseID = (int)Reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    IsActive = (bool)Reader["IsActive"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------------ DB Error " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static int AddNewLicense( int ApplicationID, int IssuedUsingLocalLicenseID, int DriverID, DateTime IssueDate,
                             DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INto InternationalLicenses (ApplicationID,DriverID, IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID )
                                         Values
                                            (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate ,@IsActive, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
            cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);           
            cmd.Parameters.AddWithValue("@IsActive", IsActive);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int InternationalLicenseID = -1;
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) InternationalLicenseID = ID;

            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return InternationalLicenseID;
        }
        
        public static bool UpdateLicense(int InternationalLicenseID,bool IsActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update InternationalLicenses SET                                                  
                                                   IsActive = @IsActive,
                                                    WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

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
        public static bool DeleteLicense(int InternationalLicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete InternationalLicenses Where InternationalLicenseID=@InternationalLicenseID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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

        public static bool Exist(int DriverID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select Found=1 from InternationalLicenses Where DriverID=@DriverID ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) Found = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"-------------------------DataBase Error: {ex.Message}");
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
            string Query = @"SELECT * From InternationalLicenses ;";

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

        public static DataTable FilterBy<T>(string Column,T Term)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string[] AllowedColumns = new string[] { "IsActive","InternationalLicenseID", "IssuedUsingLocalLicenseID","DriverID" };

            DataTable DT = new DataTable();
            try
            {
                if(!AllowedColumns.Contains(Column))
                {
                    throw new ArgumentException($"Not Allowed Column {Column} < Error -> Invalide Column Name >!");
                }

                string Query = $"SELECT * From InternationalLicenses WHERE {Column} LIKE @Term ;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@Term", "%" + Term + "%");
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

        public static DataTable ListInternationalLicenses_History(int DriverID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT InternationalLicenseID, ApplicationID, 
                                    (SELECT LocalDrivingLicenseApplicationID from LocalDrivingLicenseApplications
                                            Where ApplicationID = InternationalLicenses.ApplicationID) As LocalLicenseID,
		                            IssueDate,ExpirationDate,IsActive 
                            FROM InternationalLicenses
		                    WHERE DriverID = @DriverID Order By IsActive Desc;";

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
