using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClasses
    {
        public short LicenseClassID { get; set; }
        public string LicenseClassName { get; set; }
        public string LicenseDescription { get; set; }
        public byte MinAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float LicenseFees { get; set; }

        public clsLicenseClasses(short LicenseClassID, string LicenseClassName, string LicenseDescription, byte MinAllowedAge, byte DefaultValidityLength, float LicenseFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassName = LicenseClassName;
            this.LicenseDescription = LicenseDescription;
            this.MinAllowedAge = MinAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.LicenseFees = LicenseFees;
        } 

        public static clsLicenseClasses Find(short LicenseClassID)
        {
            string LicenseClassName = "", LicenseDescription = "";
            byte MinAllowedAge = 0, DefaultValidityLength = 0;
            float LicenseFees = 0;
            if (clsLicenseClassesDataAccess.Find(LicenseClassID, ref LicenseClassName, ref LicenseDescription, ref MinAllowedAge, ref DefaultValidityLength, ref LicenseFees))
            {
                return new clsLicenseClasses(LicenseClassID, LicenseClassName, LicenseDescription, MinAllowedAge, DefaultValidityLength, LicenseFees);
            }
            else
                return null;
        }

        public static clsLicenseClasses Find(string LicenseClassName)
        {
            string  LicenseDescription = "";
            short LicenseClassID = -1;
            byte MinAllowedAge = 0, DefaultValidityLength = 0;
            float LicenseFees = 0;
            if (clsLicenseClassesDataAccess.Find(LicenseClassName,ref LicenseClassID, ref LicenseDescription, ref MinAllowedAge, ref DefaultValidityLength, ref LicenseFees))
            {
                return new clsLicenseClasses(LicenseClassID, LicenseClassName, LicenseDescription, MinAllowedAge, DefaultValidityLength, LicenseFees);
            }
            else
                return null;
        }

        public static DataTable LicenseClassesList()
        {
            return clsLicenseClassesDataAccess.LicenseClassesList();
        }
    }
}
