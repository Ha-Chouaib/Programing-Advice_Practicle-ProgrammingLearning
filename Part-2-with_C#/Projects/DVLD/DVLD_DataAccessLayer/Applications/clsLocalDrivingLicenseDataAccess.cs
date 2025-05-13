using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DVLD_DataAccessLayer.Applications
{
    public class clsLocalDrivingLicenseDataAccess
    {
        public static bool Find(int LDL_ID, ref int AppID,ref byte LicenseClassID)
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
                    LicenseClassID = Convert.ToByte( Reader["LicenseClassID"] );
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

       

        public static byte GetPassedTestCount(int LDL_AppID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = $"Select PassedTestCount From LocalDrivingLicenseApplications_View  Where LocalDrivingLicenseApplicationID = @LDL_AppID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LDL_AppID", LDL_AppID );

            byte TestsCount = 40;
            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null && byte.TryParse(Result.ToString(), out byte PassedCountTests)) TestsCount = PassedCountTests;
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }
            return TestsCount;
        }

        public static bool Delete(int LocalDrivinglicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @" Delete LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID= @LocalDrivinglicenseID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@LocalDrivinglicenseID", LocalDrivinglicenseID);

            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------DB Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }


    }
}
