using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountries
    {

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountries(int CountryID,string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";
            if (clsCountriesDataAccess.Find(CountryID, ref CountryName))
            {
                return new clsCountries(CountryID, CountryName);
            }
            else
                return null;

        }
        public static clsCountries Find(string CountryName)
        {
            int CountryID = -1;
            if (clsCountriesDataAccess.Find(CountryName,ref CountryID))
            {
                return new clsCountries(CountryID, CountryName);
            }
            else
                return null;

        }
    
        public static DataTable ListAll()
        {
            return clsCountriesDataAccess.ListAll();
        }
    
    }
}
