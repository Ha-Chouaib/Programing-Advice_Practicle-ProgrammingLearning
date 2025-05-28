using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer.Applications;
using DVLD_DataAccessLayer.License;

namespace DVLD_BusinessLayer.Licenses
{
    public class clsLicenses
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public clsMainApplication ApplicationInfo;
        public int DriverID { get; set; }
        public clsDrivers DriverInfo;
        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        enum enMode { eAddNew,eUpdate}
        enMode _Mode;

        public enum enIssueReason : byte
        {
            FirstTime = 1,
            RenewLicense = 2,
            ReplaceForLost = 3,
            ReplaceFoDamage = 4,
        }


        public clsLicenses(int LicenseID,int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                                DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID         = LicenseID; 
            this.ApplicationID     = ApplicationID;
            this.DriverID          = DriverID;
            this.LicenseClassID    = LicenseClassID;
            this.IssueDate         = IssueDate;
            this.ExpirationDate    = ExpirationDate;
            this.Notes             = Notes;
            this.PaidFees          = PaidFees;
            this.IsActive          = IsActive;
            this.IssueReason       = IssueReason;
            this.CreatedByUserID   = CreatedByUserID;

            this.ApplicationInfo = clsMainApplication.FindMainApplication(this.ApplicationID);
            this.DriverInfo = clsDrivers.Find(this.DriverID);
            this.LicenseClassInfo = clsLicenseClasses.Find(this.LicenseClassID);
            _Mode = enMode.eUpdate;
        }
        public clsLicenses()
        {
            this.LicenseID      = -1;
            this.ApplicationID  = -1;
            this.DriverID       = -1;
            this.LicenseClassID = -1;
            this.IssueDate      = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes          = "";
            this.PaidFees       = 0;
            this.IsActive       = false;
            this.IssueReason    = 0;
            this.CreatedByUserID = -1;

            _Mode = enMode.eAddNew;
        }

        public static clsLicenses Find(int LicenseID )
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicensesDataAccess.Find(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate,
                               ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                                 ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }else
                return null;
              
            
            

        }

        public static clsLicenses Find_ByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            if (clsLicensesDataAccess.Find_ByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate,
                               ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate,
                                 ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
                return null;




        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicensesDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,
                                 this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason,this.CreatedByUserID);
            return (this.LicenseID >0);
        }
        private bool _Update()
        {
            return clsLicensesDataAccess.UpdateLicense(this.LicenseID,this.IsActive);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewLicense())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                        return false;
                case enMode.eUpdate:
                    return _Update();

                default:
                    return false;

            }
        }

        public static bool DeleteLicense(int LicenseID)
        {
            return clsLicensesDataAccess.DeleteLicense(LicenseID);
        }

        public static bool Exist(int LicenseID)
        {
            return clsLicensesDataAccess.Exist(LicenseID);
        }
        public static DataTable ListLicenses()
        {
            return clsLicensesDataAccess.ListLicenses();
        }
        public static DataTable List_LocalLicense_History(int DriverID)
        {
            return clsLicensesDataAccess.ListLocalLicenses_DriverHistory(DriverID);
        }
       

    }
}
