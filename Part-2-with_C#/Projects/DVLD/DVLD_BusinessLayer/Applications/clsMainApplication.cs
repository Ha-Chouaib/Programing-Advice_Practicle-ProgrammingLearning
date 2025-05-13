using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Applications;

namespace DVLD_BusinessLayer.Applications
{
    public class clsMainApplication
    {
        public int AppID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime AppDate { get; set; }
        public int AppTypeID { get; set; }
        public byte AppStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        enum enMode { eAddNew,eUpdate}
        enMode _Mode;

        public clsMainApplication(int AppID,int ApplicantPersonID,DateTime AppDate,int AppTypeID,byte AppStatus,
                                    DateTime LastStatusDate,float PaidFees,int CreatedByUserID)
        {
            this.AppID = AppID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.AppDate= AppDate;
            this.AppTypeID = AppTypeID;
            this.AppStatus = AppStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees=PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enMode.eUpdate;

        }
        public clsMainApplication()
        {
            this.AppID = -1;
            this.ApplicantPersonID = -1;
            this.AppDate = DateTime.Now;
            this.AppTypeID = -1;
            this.AppStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            _Mode = enMode.eAddNew;

        }

        public static clsMainApplication Find(int AppID)
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
                this.AppID=clsMainApplicationDataAccess.AddNewApp(this.ApplicantPersonID,this.AppDate,this.AppTypeID,this.AppStatus,
                                                            this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return (this.AppID > 0);
        }

        bool _UpdateApp()
        {
            return clsMainApplicationDataAccess.UpdateApp(this.AppID, this.AppStatus, this.LastStatusDate);
        }
        public static bool DeleteApp(int AppID)
        {
            return clsMainApplicationDataAccess.DeleteApplication(AppID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.eAddNew:
                    if(_AddNewApp())
                    {
                        _Mode = enMode.eUpdate;
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
    
    }
}
