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
        public byte TestTypeID { get; set; }
        public int LDL_AppID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public short CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        enum enMode { eAddNew,eUpdate}
        enMode _Mode;

        public clsTestAppointments(int TestAppointmentID,byte TestTypeID,int LDL_AppID, DateTime AppointmentDate, float PaidFees,short CreatedByUserID,bool IsLocked)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LDL_AppID = LDL_AppID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
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
            this.IsLocked = true;
            _Mode = enMode.eAddNew;
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {
            byte TestTypeID=0;
            int LDL_AppID = -1;
            DateTime AppointmentDate=DateTime.Now;
            float PaidFees = 0;
            short CreatedByUserID = -1;
            bool IsLocked = true;

            if (clsTestAppointmentDataAccess.Find(TestAppointmentID,ref TestTypeID,ref LDL_AppID,ref AppointmentDate,ref PaidFees,ref CreatedByUserID,ref IsLocked))
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LDL_AppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
            else
                return null;
        }



        bool _AddNewTestApp()
        {
            this.TestAppointmentID = clsTestAppointmentDataAccess.AddNewAppointment(this.TestTypeID,this.LDL_AppID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked);
            return (this.TestAppointmentID > 0);
        }
        bool _UpdateTestApp()
        {
            return clsTestAppointmentDataAccess.UpdateAppointment(this.TestAppointmentID, this.IsLocked);
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
        public static DataTable ListTestAppointments_SchedualeInfo(int LocalDrivingLicenseApp_ID,byte TestTypeID)
        {
            return clsTestAppointmentDataAccess.ListAppointments_SchedualeInfo(LocalDrivingLicenseApp_ID,TestTypeID);
        }

    }
}
