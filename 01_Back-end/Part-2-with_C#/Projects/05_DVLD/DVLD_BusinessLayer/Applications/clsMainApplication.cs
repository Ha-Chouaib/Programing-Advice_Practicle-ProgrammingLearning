using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer.Licenses;
using DVLD_DataAccessLayer.Applications;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer.Applications
{
    public class clsMainApplication
    {
        public int MainApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPeople PersonInfo;
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo;
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers UserInfo;

        public enum enMode { eAddNew,eUpdate}
        public  enMode Mode;

        public enum enApplicationStatus : byte
        {
            New = 1,
            Cancelled = 2,
            Completed = 3,
        }

        public enum enApplicationTypes_IDs 
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementFor_LostDrivingLicense = 3,
            ReplacementFor_DamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 8,
        }

        public clsMainApplication(int AppID,int ApplicantPersonID,DateTime AppDate,int AppTypeID,byte AppStatus,
                                    DateTime LastStatusDate,float PaidFees,int CreatedByUserID)
        {
            this.MainApplicationID = AppID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate= AppDate;
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationStatus = AppStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees=PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.PersonInfo = clsPeople.Find(this.ApplicantPersonID);
            this.UserInfo=clsUsers.Find(this.CreatedByUserID);
            this.ApplicationTypeInfo = clsApplicationTypes.Find(this.ApplicationTypeID);

            Mode = enMode.eUpdate;

        }
        public clsMainApplication()
        {
            this.MainApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.eAddNew;

        }

        public static clsMainApplication FindMainApplication(int AppID)
        {
            int ApplicantPersonID = -1;
            int CreatedByUserID=-1;
            DateTime AppDate=DateTime.Now, LastStatusDate=DateTime.Now;
            int AppTypeID=-1;
            byte AppStatus=0;
            float PaidFees=0;
            if (clsMainApplicationDataAccess.Find(AppID, ref ApplicantPersonID, ref AppDate, ref AppTypeID, ref AppStatus,
                                    ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
                return new clsMainApplication(AppID, ApplicantPersonID, AppDate, AppTypeID, AppStatus, LastStatusDate, PaidFees, CreatedByUserID);
            else
                return null;
        }

        bool _AddNewApp()
        {
                this.MainApplicationID=clsMainApplicationDataAccess.AddNewApp(this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID,this.ApplicationStatus,
                                                            this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return (this.MainApplicationID > 0);
        }

        bool _UpdateApp()
        {
            return clsMainApplicationDataAccess.UpdateApp(this.MainApplicationID, this.ApplicationStatus, this.LastStatusDate);
        }
        public static bool DeleteApp(int AppID)
        {
            return clsMainApplicationDataAccess.DeleteApplication(AppID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.eAddNew:
                    if(_AddNewApp())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.eUpdate:
                    return _UpdateApp();
                default:
                    return false;
            }
        }

        public static  DataTable ListAll()
        {
            return clsMainApplicationDataAccess.ListAll();
        }
    
        public static bool CheckApplicationStatus(int ApplicantPersonID,int LicenseClassID,byte IsInStatus)
        {
            return clsMainApplicationDataAccess.CheckApplicationStatus(ApplicantPersonID, LicenseClassID, IsInStatus);
        }

       
        public static bool UpdateApplicationStatus(int ApplicationID, clsMainApplication.enApplicationStatus SetStatus)
        {
            return clsMainApplicationDataAccess.UpdateStatus(ApplicationID,(short) SetStatus);
        }
    }
}
