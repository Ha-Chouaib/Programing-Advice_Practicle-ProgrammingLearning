using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsDrivers
    {
        public int _DriverID { get; set; }
        public int _PersonID { get; set; }
        public int _CreatedByUserID { get; set; }
        public clsPeople PersonInfo;
        public clsUsers UserInfo;
        public DateTime _CreatedDate { get; set; }

        enum enMode {eAddNew,eUpdate}
        enMode _Mode;
        public clsDrivers(int DriverID,int PersonID, int CreatedByUserID,DateTime CreatedDate)
        {
            this._DriverID = DriverID;
            this._PersonID = PersonID;
            this._CreatedByUserID = CreatedByUserID;
            this._CreatedDate = CreatedDate;

            this.PersonInfo = clsPeople.Find(_PersonID);
            this.UserInfo = clsUsers.Find(this._CreatedByUserID);

            _Mode = enMode.eUpdate;
        }
        public clsDrivers()
        {
            this._DriverID = -1;
            this._PersonID = -1;
            this._CreatedByUserID = -1;
            this._CreatedDate = DateTime.Now;
            _Mode = enMode.eAddNew;
        }

        public static clsDrivers Find(int DriverID)
        {

            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverDataAccess.Find(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
                return null;
        }

        public static clsDrivers FindByPersonID(int PersonID)
        {
            
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriverDataAccess.FindByPersonID( PersonID,ref DriverID ,ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
                return null; 
        }
        private bool _AddNewDriver()
        {
            this._DriverID= clsDriverDataAccess.AddNewDriver(this._PersonID,this._CreatedByUserID,this._CreatedDate);

            return (this._DriverID > 0);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewDriver())
                    {
                        _Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                        return false;
                case enMode.eUpdate:
                    return false;

                default:
                    return false;

            }
        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriverDataAccess.DeleteDriver(DriverID);
        }
        public static bool Exist(int PersonID)
        {
            return clsDriverDataAccess.Exist(PersonID);
        }

        public static DataTable ListDrivers()
        {
            return clsDriverDataAccess.ListDrivers();
        }
        public static DataTable FilterBy<T>(string FilterByColumn, T FilterTerm)
        {
            return clsDriverDataAccess.FilterBy<T>(FilterByColumn,FilterTerm);
        }

    }
}
