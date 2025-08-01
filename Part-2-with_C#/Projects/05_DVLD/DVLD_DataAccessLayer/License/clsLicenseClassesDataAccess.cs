﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassesDataAccess
    {
        public static bool Find(int LicenseCalassID,ref string ClassName,ref string LicenseDescription,
            ref byte MinAllowedAge,ref byte DefaultValidityLength,ref float ClassFees )
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From LicenseClasses Where LicenseClassID= @ClassID";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ClassID",LicenseCalassID);
            

            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if(Reader.Read())
                {
                    Found = true;
                    ClassName = (string)Reader["ClassName"];
                    LicenseDescription = (string)Reader["ClassDescription"];
                    MinAllowedAge =Convert.ToByte( Reader["MinimumAllowedAge"] );
                    DefaultValidityLength = Convert.ToByte( Reader["DefaultValidityLength"] );
                    ClassFees = (float)(decimal)Reader["ClassFees"];
                }
                
            }catch(Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LicenseClasses DataAccess: [ Find() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }

        public static bool Find(string ClassName,ref int LicenseCalassID, ref string LicenseDescription,
           ref byte MinAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From LicenseClasses Where ClassName = @ClassName";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);


            bool Found = false;
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;
                    LicenseCalassID = (int)Reader["LicenseClassID"];
                    LicenseDescription = (string)Reader["ClassDescription"];
                    MinAllowedAge =Convert.ToByte( Reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToByte(Reader["DefaultValidityLength"]);
                    ClassFees = (float)(decimal)Reader["ClassFees"];
                }

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LicenseClasses DataAccess: [ Find() By ClassName ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return Found;
        }


        public static DataTable LicenseClassesList()
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string Query = @"Select * From LicenseClasses";

            SqlCommand cmd = new SqlCommand(Query, connection);

            DataTable DT = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                DT.Load(Reader);
            }catch(Exception ex)
            {
                EventLog.WriteEntry(DataAccessSettings.EventLog_SourceName, $"LicenseClasses DataAccess: [ LicenseClassesList() ]: {ex.Message}", EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return DT;
        }
    }
}
