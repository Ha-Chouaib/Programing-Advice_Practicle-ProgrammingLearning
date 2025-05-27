using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Tests;

namespace DVLD_BusinessLayer.Tests
{
    public class clsTestAppointments
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LDL_AppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        enum enMode { eAddNew,eUpdate }
        enMode _Mode;

        public clsTestAppointments(int TestAppointmentID,int TestTypeID,int LDL_AppID, DateTime AppointmentDate, float PaidFees,int CreatedByUserID,bool IsLocked,int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDL_AppID = LDL_AppID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            _Mode = enMode.eUpdate;
        }

        public clsTestAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = 0;
            this.LDL_AppID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            _Mode = enMode.eAddNew;
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int TestTypeID=0;
            int LDL_AppID = -1;
            DateTime AppointmentDate=DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            if (clsTestAppointmentDataAccess.Find(TestAppointmentID,ref TestTypeID,ref LDL_AppID,ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked,ref RetakeTestApplicationID))
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LDL_AppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            else
                return null;
        }



        bool _AddNewTestApp()
        {
            this.TestAppointmentID = clsTestAppointmentDataAccess.AddNewAppointment(this.TestTypeID,this.LDL_AppID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
            return (this.TestAppointmentID > 0);
        }
        bool _UpdateTestApp()
        {
            return clsTestAppointmentDataAccess.UpdateAppointment(this.TestAppointmentID,this.AppointmentDate ,this.IsLocked);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.eAddNew:
                    if(_AddNewTestApp())
                    {
                        _Mode = enMode.eUpdate; 
                        return true;
                    }
                    return false;
                case enMode.eUpdate:
                    return _UpdateTestApp();
            }
            return false;
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentDataAccess.DeleteTestAppointment(TestAppointmentID);
        }

        public static DataTable ListTestAppointments()
        {
            return clsTestAppointmentDataAccess.ListAppointments();
        }
        public static DataTable ListTestAppointments_SchedualeInfo(int LocalDrivingLicenseApp_ID,int TestTypeID)
        {
            return clsTestAppointmentDataAccess.ListAppointments_SchedualeInfo(LocalDrivingLicenseApp_ID,TestTypeID);
        }
        

        public static bool DoesTestTypePassed(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentDataAccess.IsTestTypePassed(LocalDrivingLicenseID, TestTypeID);
        }
        public static bool HasActiveAppointment(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentDataAccess.HasActiveTestAppointment(LocalDrivingLicenseID, TestTypeID);
        }
        public static byte _GetTestTrials(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentDataAccess.TestTrials(LocalDrivingLicenseID, TestTypeID);
        }
        public static int GetCurrentAppointmetID(int LocalDrivingLicenseID, int TestTypeID)
        {
            return clsTestAppointmentDataAccess.GetCurrentTestAppointmentID(LocalDrivingLicenseID, TestTypeID);
        }
    }
}
