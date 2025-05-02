using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer.Applications
{
    public class clsLocalDrivingLicenseDataAccess
    {
        public static bool Find(int LDL_ID, ref short AppID,ref short LicenseClassID)
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
                    AppID = (short)Reader["ApplicationID"];
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

        public static bool AddNewLicense( short AppID,short LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Insert Into  LocalDrivingLicenseApplications SET
                                                                           (ApplicationID,LicenseClassID)
                                                                          Values
                                                                            (@AppID,@LicenseClassID);
                            Select SCOPE_IDENTITY();";

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



    }
}
