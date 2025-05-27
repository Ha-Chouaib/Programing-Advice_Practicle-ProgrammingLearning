using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsTestTypes
    {

        public int TestID { get; set; }
        public string TestDescription { get; set; }
        public string TestTitle { get; set; }
        public float TestFees { get; set; }

        public enum enTestType { eVisionTest=1,eWrittenTest=2,eStreetTest=3}
        public clsTestTypes(int TestID, string TestTitle,string TestDescription, float TestFees)
        {
            this.TestID = TestID;
            this.TestTitle = TestTitle;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
        }

        public static clsTestTypes Find(int TestID)
        {
            string TestTitle = "";
            string TestDescription = "";
            float TestFees = 0;
            if (clsTestTypesDataAccess.Find(TestID, ref TestTitle, ref TestDescription,ref TestFees))
            {
                return new clsTestTypes(TestID, TestTitle, TestDescription,TestFees);
            }
            return null;
        }

        public static clsTestTypes Find(string TestTitle)
        {
            int TestID = -1;
            string TestDescription = "";
            float TestFees = 0;
            if (clsTestTypesDataAccess.Find(TestTitle,ref TestID, ref TestDescription, ref TestFees))
            {
                return new clsTestTypes(TestID, TestTitle, TestDescription, TestFees);
            }
            return null;
        }


        public bool SaveAppUpdates()
        {
            return clsTestTypesDataAccess.UpdateTest(this.TestID, this.TestTitle,this.TestDescription, this.TestFees);
        }
        public static DataTable ListAll()
        {
            return clsTestTypesDataAccess.ListAllTests();
        }


    }
}
