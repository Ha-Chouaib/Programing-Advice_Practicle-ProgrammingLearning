using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using DVLD_BusinessLayer.Licenses;
using DVLD_DataAccessLayer.License;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsDetainLicenses
    {

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public float FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }


        enum enMode { DetainMode, ReleaseMode }
        enMode _Mode;

        public clsDetainLicenses(int DetainID,int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
                    DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;

            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            _Mode = enMode.ReleaseMode;
        }
        public clsDetainLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = true;

            _Mode = enMode.DetainMode;
        }

        public static clsDetainLicenses Find(int DetainID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.Now;
            float FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = true;

            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (clsDetainLicenseDataAccess.Find(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
                               ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                               ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;

        }

        public static clsDetainLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.Now;
            float FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = true;

            DateTime ReleaseDate = DateTime.Now;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            if (clsDetainLicenseDataAccess.FindByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased,
                               ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                               ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;

        }

        private bool _DetainLicense()
        {
            this.DetainID = clsDetainLicenseDataAccess.DetainLicense(this.LicenseID,  this.DetainDate, this.FineFees,  this.CreatedByUserID, this.IsReleased);
            return (this.DetainID > 0);
        }
        private bool _ReleaseLicense()
        {
            return clsDetainLicenseDataAccess.ReleaseLicense(this.DetainID,this.IsReleased,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.DetainMode:
                    if (_DetainLicense())
                    {
                        _Mode = enMode.ReleaseMode;
                        return true;
                    }
                    else
                        return false;
                case enMode.ReleaseMode:
                    return _ReleaseLicense();

                default:
                    return false;

            }
        }

        public static bool Delete(int DetainID)
        {
            return clsDetainLicenseDataAccess.Delete(DetainID);
        }

        public static bool IsDetained(int DetainID)
        {
            return clsDetainLicenseDataAccess.IsDetained(DetainID);
        }
        public static bool IsDetainedByLicenseID(int LicenseID)
        {
            return clsDetainLicenseDataAccess.IsDetained_ByLicenseID(LicenseID);
        }
        public static DataTable ListAll()
        {
            return clsDetainLicenseDataAccess.ListAll();
        }

        public static DataTable FilterBy<T>(string Column, T Term)
        {
            return clsDetainLicenseDataAccess.FilterBy<T>(Column,Term);
        }
    }
}
