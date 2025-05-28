using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer.Licenses;
using DVLD_BusinessLayer.Tests;
using DVLD_DataAccessLayer.Applications;

namespace DVLD_BusinessLayer.Applications
{
    public class clsLocalDrivingLicenseApplication : clsMainApplication
    {

       
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }
        public clsLicenseClasses LicenseClassInfo;
        
        public clsLocalDrivingLicenseApplication()

        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;


            Mode = enMode.AddNew;

        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             byte ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
        this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
        this.MainApplicationID = ApplicationID;
        this.ApplicantPersonID = ApplicantPersonID;
        this.ApplicationDate = ApplicationDate;
        this.ApplicationTypeID = (int)ApplicationTypeID;
        this.ApplicationStatus = ApplicationStatus;
        this.LastStatusDate = LastStatusDate;
        this.PaidFees = PaidFees;
        this.CreatedByUserID = CreatedByUserID;
        this.LicenseClassID = LicenseClassID;
        this.LicenseClassInfo = clsLicenseClasses.Find(LicenseClassID);
        this.PersonInfo = clsPeople.Find(this.ApplicantPersonID);
        this.UserInfo = clsUsers.Find(this.CreatedByUserID);
        this.ApplicationTypeInfo = clsApplicationTypes.Find(this.ApplicationTypeID);
        Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
            {
                this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseDataAccess.AddNewLocalLicenseApplication(this.MainApplicationID, this.LicenseClassID);

                return (this.LocalDrivingLicenseApplicationID != -1);
            }

        private bool _UpdateLocalDrivingLicenseApplication()
            {

                return clsLocalDrivingLicenseDataAccess.UpdateLocalLicenseApplication
                    (
                    this.LocalDrivingLicenseApplicationID, this.MainApplicationID, this.LicenseClassID);

            }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
           
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseDataAccess.Find(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsMainApplication Application = clsMainApplication.FindMainApplication(ApplicationID);
                if (Application == null) return null;


            return new clsLocalDrivingLicenseApplication( LocalDrivingLicenseApplicationID, Application.MainApplicationID, Application.ApplicantPersonID,
                                                                Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                                                                Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;


        }

        public static clsLocalDrivingLicenseApplication FindByMainApplicationID(int MainApplicationID)
            {                
                int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

                bool IsFound = clsLocalDrivingLicenseDataAccess.FindByMainApplicationID(MainApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);


                if (IsFound)
                {
                    clsMainApplication Application = clsMainApplication.FindMainApplication(MainApplicationID);

                    return new clsLocalDrivingLicenseApplication( LocalDrivingLicenseApplicationID, Application.MainApplicationID, Application.ApplicantPersonID,
                                                                    Application.ApplicationDate, Application.ApplicationTypeID,Application.ApplicationStatus, Application.LastStatusDate,
                                                                    Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
                }
                else
                    return null;


            }

        public bool Save()
            {

                base.Mode = (clsMainApplication.enMode)this.Mode;
                if (!base.Save())
                    return false;


                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewLocalDrivingLicenseApplication())
                        {

                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateLocalDrivingLicenseApplication();
                }

                return false;
            }

        public static DataTable LocalLicenseList_View()
        {
            return clsLocalDrivingLicenseDataAccess.ListAll_View();
        }
        public static DataTable FilterBy<T>(string Column, T Term)
        {
            return clsLocalDrivingLicenseDataAccess.FilterBy<T>(Column, Term);
        }

        public static byte GetPassedTestsCount(int LDL_App)
        {
            return clsLocalDrivingLicenseDataAccess.GetPassedTestCount(LDL_App);
        }
        
        public bool Delete()
        {
           
            if (!clsLocalDrivingLicenseDataAccess.Delete(this.LocalDrivingLicenseApplicationID))
                return false;
           
            return clsMainApplication.DeleteApp(base.MainApplicationID);

        }
           

    }
}
