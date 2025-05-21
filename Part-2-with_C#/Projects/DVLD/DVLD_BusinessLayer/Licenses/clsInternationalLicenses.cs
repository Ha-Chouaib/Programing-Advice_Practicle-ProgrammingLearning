using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.License;

namespace DVLD_BusinessLayer.Licenses
{
    public class clsInternationalLicenses
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }       
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        enum enMode { eAddNew, eUpdate }
        enMode _Mode;

        public clsInternationalLicenses(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
                                 DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;          
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.eUpdate;
        }
        public clsInternationalLicenses()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;           
            this.IsActive = false;
            this.CreatedByUserID = -1;

            _Mode = enMode.eAddNew;
        }

        public static clsInternationalLicenses Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsInternationalLicensedataAccess.Find(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate,
                               ref ExpirationDate,  ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate,
                                 ExpirationDate,IsActive,  CreatedByUserID);
            }
            else
                return null;

        }

        public static clsInternationalLicenses Find_DriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;

            bool IsActive = false;
            int CreatedByUserID = -1;


            if (clsInternationalLicensedataAccess.Find_DriverID(DriverID ,ref InternationalLicenseID, ref ApplicationID, ref IssuedUsingLocalLicenseID, ref IssueDate,
                               ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicenses(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate,
                                 ExpirationDate, IsActive, CreatedByUserID);
            }
            else
                return null;




        }

        private bool _AddNewLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensedataAccess.AddNewLicense( this.ApplicationID, this.IssuedUsingLocalLicenseID, this.DriverID, this.IssueDate,
                                                 this.ExpirationDate,  this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID > 0);
        }
        private bool _Update()
        {
            return clsInternationalLicensedataAccess.UpdateLicense(this.InternationalLicenseID,this.IsActive);
        }

        public bool Save()
        {
            switch (_Mode)
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

        public static bool DeleteLicense(int InternationalLicenseID)
        {
            return clsInternationalLicensedataAccess.DeleteLicense(InternationalLicenseID);
        }

        public static bool Exist(int DriverID)
        {
            return clsInternationalLicensedataAccess.Exist(DriverID);
        }
        public static DataTable ListInternationalLicenses()
        {
            return clsInternationalLicensedataAccess.ListLicenses();
        }

        public static DataTable FilterBy<T>(string FilterByColumn, T Term)
        {
            return clsInternationalLicensedataAccess.FilterBy<T>(FilterByColumn,Term);
        }

        public static DataTable List_InternationalLicenses_History(int DriverID)
        {
            return clsInternationalLicensedataAccess.ListInternationalLicenses_History(DriverID);
        }
    }
}
