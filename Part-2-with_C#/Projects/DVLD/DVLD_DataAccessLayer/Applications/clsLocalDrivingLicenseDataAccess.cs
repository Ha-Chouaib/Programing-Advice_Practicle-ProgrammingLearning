using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer.Applications
{
    public class clsLocalDrivingLicenseDataAccess
    {
        public static bool Find(int LDL_ID, ref int AppID,ref short LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * from LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID= @LDLid";

            SqlCommand cmd =new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LDLid", LDL_ID);

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;
                    AppID = (int)Reader["ApplicationID"];
                    LicenseClassID = (short)Reader["LicenseClassID"];
                }


            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Found;
        }

        public static bool AddNewLicense( int AppID,short LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @" INSERT INTO LocalDrivingLicenseApplications 
                                          (ApplicationID,LicenseClassID)
                                          VALUES
                                          (@AppID,@LicenseClassID);
                            select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@AppID", AppID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int ldlID = -1;
            try
            {
                connection.Open();
                 object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID)) ldlID = ID;
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return (ldlID > 0);
        }



        public static DataTable ListAll_View()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From LocalDrivingLicenseApplications_View";

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

        public static DataTable FilterBy<T>(string Column,T Term)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string[] AllowedColumns = new string[] { "LocalDrivingLicenseApplicationID", "NationalNo","FullName","Status" };
            if (!AllowedColumns.Contains(Column))
            {
                throw new ArgumentException("Not Allowed Column");
            }

            string Query = $"Select * From LocalDrivingLicenseApplications_View  Where {Column} Like @Term";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@Term", "%"+ Term +"%");

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                DT.Load(Reader);
            } catch (Exception ex)
            {


            }
            finally 
            {
                connection.Close();    
            }
            return DT;
        }

        public static bool IsAppStatusNew(int ApplicantPersonID, short LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"SELECT 
                            CheckAppStatus= 1 from Applications join LocalDrivingLicenseApplications 
                            On 
                            Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            Where 
                            ApplicantPersonID = @PersonID AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID AND Applications.ApplicationStatus =1 ;";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@PersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            bool NewState=false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows) NewState = true;

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return NewState;
        }

    }
}
