using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace DVLD_DataAccessLayer.Applications
{
    public class clsMainApplicationDataAccess
    {
        public static bool Find(int AppID, ref int ApplicantPersonID, ref DateTime AppDate, ref int AppTypeID, ref byte AppStatus,
            ref DateTime LastStatusDate, ref float PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * FROM Applications WHERE ApplicationID= @AppID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppID", AppID);

            bool ISFound = false;

            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    ISFound = true;
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    AppDate = (DateTime)Reader["ApplicationDate"];
                    AppTypeID= (int) Reader["ApplicationTypeID"];
                    AppStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (float)(decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return ISFound;
        }


        public static int AddNewApp(int ApplicantPersonID, DateTime AppDate, int AppTypeID, byte AppStatus,
            DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert INTO Applications 
                                    (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                                    Values
                                    (@ApplicantPersonID,@AppDate,@AppTypeID,@AppStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY() ;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID",ApplicantPersonID);
            command.Parameters.AddWithValue("@AppDate",AppDate);
            command.Parameters.AddWithValue("@AppTypeID",AppTypeID);
            command.Parameters.AddWithValue("@AppStatus",AppStatus);
            command.Parameters.AddWithValue("@LastStatusDate",LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees",PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);

            int AppID = -1;
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ID)) AppID = ID;


            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return AppID;
        }
        
        public static bool UpdateApp(int AppID, byte AppStatus,DateTime LastStatusDate)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Update Applications SET
                                    ApplicationStatus = @AppStatus ,LastStatusDate= @LastStatusDate
                                    WHERE ApplicationID = @AppID;";

            SqlCommand command = new SqlCommand(Query, connection);
            
            command.Parameters.AddWithValue("@AppID", AppID);
            command.Parameters.AddWithValue("@AppStatus", AppStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
           
            byte RowAffected = 0;
            try
            {
                connection.Open();
                RowAffected =(byte) command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowAffected > 0);
        }

        public static bool DeleteApplication(int AppID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Delete Applications Where ApplicationID=@AppID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);
           
            byte RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected =(byte) cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------DB Error: "+ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }

        public static DataTable ListAll()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT * From Applications";

            SqlCommand cmd = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                DT.Load(Reader);

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return DT;
        }

        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool CheckApplicationStatus(int ApplicantPersonID, int LicenseClassID, byte IsInSatus)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
           
            string Query = @"SELECT 
                            CheckAppStatus= 1 from Applications join LocalDrivingLicenseApplications 
                            On 
                            Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            Where 
                            ApplicantPersonID = @PersonID AND 
                            LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID AND 
                            Applications.ApplicationStatus = @Status ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@Status", IsInSatus);

            bool AppState = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows) AppState = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return AppState;
        }
    }
}
