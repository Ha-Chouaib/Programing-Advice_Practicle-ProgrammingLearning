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
        public int AppID{ get; set; }
        public short LicenseClassID{ get; set; }

        public clsLocalDrivingLicense(int LDL_id,int AppID,short LicenseClassID)
        {
            this.LDL_ID = LDL_id;
            this.AppID = AppID;
            this.LicenseClassID = LicenseClassID;

        }

        public clsLocalDrivingLicense()
        {
            this.LDL_ID = -1;
            this.AppID = -1;
            this.LicenseClassID = -1;

        }

        public static clsLocalDrivingLicense Find(int LDLid)
        {
            int AppID = -1; 
            short LicenseClassID = -1;
            if (clsLocalDrivingLicenseDataAccess.Find(LDLid, ref AppID, ref LicenseClassID))
                return new clsLocalDrivingLicense(LDLid, AppID, LicenseClassID);
            else
                return null;
        }

        private bool _AddNewLocLic()
        {
            return clsLocalDrivingLicenseDataAccess.AddNewLicense(this.AppID, this.LicenseClassID);
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
        public static bool IsAppHas_NewStatus(int ApplicanttPersonID, short LicenseClassID)
        {
            return clsLocalDrivingLicenseDataAccess.IsAppStatusNew(ApplicanttPersonID, LicenseClassID);
        }
        public static byte GetPassedTestsCount(int LDL_App)
        {
            return clsLocalDrivingLicenseDataAccess.GetPassedTestCount(LDL_App);
        }
    }
}
