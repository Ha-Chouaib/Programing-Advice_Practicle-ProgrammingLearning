using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationTypesDataAccessLayer
    {
        public static bool Find(int AppID,ref string AppTitle,ref float AppFees )
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From ApplicationTypes Where ApplicationTypeID = @AppID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppID", AppID);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.Read())
                {
                    IsFound = true;
                    AppTitle = (string)Reader["ApplicationTypeTitle"];
                    AppFees = (float)(decimal)Reader["ApplicationFees"];
                }

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool Find(string AppTitle, ref int AppID, ref float AppFees)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From ApplicationTypes Where ApplicationTypeTitle = @AppTitle";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppTitle", AppTitle);

            bool IsFound = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    AppID = (short)Reader["ApplicationTypeID"];
                    AppFees = (float)(decimal)Reader["ApplicationFees"];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool UpdateApp(int AppID,string AppTitle,double AppFees)
        {
            SqlConnection connection = new SqlConnection(   DataAccessSettings.connectionString);
            string Query = @"Update ApplicationTypes
                                                    Set
                                                        ApplicationTypeTitle=@AppTitle,
                                                        ApplicationFees=@AppFees
                                                    WHERE ApplicationTypeID=@AppID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@AppID",AppID);
            command.Parameters.AddWithValue("@AppTitle",AppTitle);
            command.Parameters.AddWithValue("@AppFees",AppFees);

            byte RowsAffected = 0;
            try
            {
                connection.Open();
                RowsAffected = (byte)command.ExecuteNonQuery();
                
            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (RowsAffected > 0);
        }
        public static DataTable ListAllApps()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * from ApplicationTypes";

            SqlCommand command = new SqlCommand(Query, connection);
            DataTable Dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                Dt.Load(Reader);

            }catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Dt;
        }

    }
}
