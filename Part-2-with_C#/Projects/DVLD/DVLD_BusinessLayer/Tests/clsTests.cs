using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer.Tests;

namespace DVLD_BusinessLayer.Tests
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult_IsPassed { get; set; }
        public string Notes { get; set; }
        public short CreatedByUserID { get; set; }


        public clsTests(int TestID, int TestAppointmentID,bool TestResult,string Notes, short CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult_IsPassed = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }
        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID= -1;
            this.TestResult_IsPassed = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
        }


        public static clsTests Find(int TestAppointmentID)
        {
            int TestID = -1;
            bool TestResult = false; 
            string Notes = "";
            short CreatedByUserID = -1;

            if (clsTestsDataAccess.Find(TestAppointmentID,ref TestID ,ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;

        }

        bool _AddNewTest()
        {
            this.TestID = clsTestsDataAccess.AddNewTest(this.TestAppointmentID, this.TestResult_IsPassed, this.Notes, this.CreatedByUserID);
            return (this.TestID > 0);
        }

        public bool Save()
        {
            return _AddNewTest();
        }

        public static bool DeleteTest(int TestID)
        {
            return clsTestsDataAccess.DeleteTest(TestID);
        }

        public static DataTable ListTests()
        {
            return clsTestsDataAccess.ListTests();
        }

    }
}
