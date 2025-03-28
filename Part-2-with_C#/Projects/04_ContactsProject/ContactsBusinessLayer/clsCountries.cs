using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsCountries
    {
        enum enMode { AddNew=0, Update=1}
        enMode Mode;
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }

        public clsCountries(int CountryID, string CountryName, string Code, string PhoneCode)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this.CountryName = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }

        public clsCountries()
        {
            this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";

            Mode = enMode.AddNew;
                
        }

        public static clsCountries Find(int ID)
        {
            string CountryName = "", Code = "", PhoneCode = "";
            if (clsCountriesDataAccess.Find(ID, ref CountryName, ref Code, ref PhoneCode))
                return new clsCountries(ID, CountryName, Code, PhoneCode);
            else
                return null;
        }

        public static clsCountries Find(string CountryName)
        {
            int ID = -1;
            string Code = "", PhoneCode = "";
            if (clsCountriesDataAccess.Find(CountryName, ref ID, ref Code, ref PhoneCode))
                return new clsCountries(ID, CountryName, Code, PhoneCode);
            else
                return null;
        }

         private bool _AddNewCountry()
        {
            this.CountryID = clsCountriesDataAccess.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);
            return (this.CountryID != -1);
            
        }
        private bool _UpdateCountry()
        {
            return clsCountriesDataAccess.UpdateCountry(this.CountryID,this.CountryName , this.Code, this.PhoneCode);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCountry();
                default:
                    return false;
            }
        }

        public static bool ISExist(int ID)
        {
            return clsCountriesDataAccess.ISExist(ID); 
        }

        public static  bool DeleteCountry(int ID)
        {
            return clsCountriesDataAccess.DeleteCountry(ID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }
    }
}
