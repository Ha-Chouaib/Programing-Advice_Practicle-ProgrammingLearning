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
        private int _LDL_ID{ get; set; }
        private short _AppID{ get; set; }
        private short _LicenseClassID{ get; set; }

        public clsLocalDrivingLicense(int LDL_id,short AppID,short LicenseClassID)
        {
            this._LDL_ID = LDL_id;
            this._AppID = AppID;
            this._LicenseClassID = LicenseClassID;

        }

        public clsLocalDrivingLicense()
        {
            this._LDL_ID = -1;
            this._AppID = -1;
            this._LicenseClassID = -1;

        }

        public static clsLocalDrivingLicense Find(int LDLid)
        {
            short AppID = -1, LicenseClassID = -1;
            if (clsLocalDrivingLicenseDataAccess.Find(LDLid, ref AppID, ref LicenseClassID))
                return new clsLocalDrivingLicense(LDLid, AppID, LicenseClassID);
            else
                return null;
        }

        private bool _AddNewLocLic()
        {
            return clsLocalDrivingLicenseDataAccess.AddNewLicense(this._AppID, this._LicenseClassID);
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
    }
}
