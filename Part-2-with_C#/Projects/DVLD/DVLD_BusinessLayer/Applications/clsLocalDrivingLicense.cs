using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Applications;

namespace DVLD_BusinessLayer.Applications
{
    public class clsLocalDrivingLicense
    {
        public int LDL_ID{ get; set; }
        public int MainApplicationID{ get; set; }
        public byte LicenseClassID{ get; set; }

        public clsLocalDrivingLicense(int LDL_id,int AppID,byte LicenseClassID)
        {
            this.LDL_ID = LDL_id;
            this.MainApplicationID = AppID;
            this.LicenseClassID = LicenseClassID;

        }

        public clsLocalDrivingLicense()
        {
            this.LDL_ID = -1;
            this.MainApplicationID = -1;
            this.LicenseClassID = 0;

        }

        public static clsLocalDrivingLicense Find(int LDLid)
        {
            int AppID = -1; 
            byte LicenseID = 0;
            if (clsLocalDrivingLicenseDataAccess.Find(LDLid, ref AppID, ref LicenseID))
                return new clsLocalDrivingLicense(LDLid, AppID, LicenseID);
            else
                return null;
        }

        private bool _AddNewLocLic()
        {
            return clsLocalDrivingLicenseDataAccess.AddNewLicense(this.MainApplicationID, this.LicenseClassID);
        }
        public bool Save()
        {
            return _AddNewLocLic();
        }

        public static DataTable LocalLicenseList_View()
        {
            return clsLocalDrivingLicenseDataAccess.ListAll_View();
        }
        public static DataTable FilterBy<T>(string Column,T Term)
        {
            return clsLocalDrivingLicenseDataAccess.FilterBy<T>(Column, Term);
        }
      
        public static byte GetPassedTestsCount(int LDL_App)
        {
            return clsLocalDrivingLicenseDataAccess.GetPassedTestCount(LDL_App);
        }
        public static bool Delete(int LocalLicensAppID)
        {
            return clsLocalDrivingLicenseDataAccess.Delete(LocalLicensAppID);
        }
    }
}
