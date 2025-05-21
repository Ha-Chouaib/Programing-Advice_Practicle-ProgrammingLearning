using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project
{
    public class clsGlobal
    {
        public static int CurrentUserID { get; set; }
        public static bool IsRememberMe { get; set; }

        public enum enApplicationStatus : byte
        {
            New = 1,
            Canceled = 2,
            Complete = 3,
        }
        public enum enIssueReason: byte
        {
            FirstTime = 1,
            RenewLicense = 2,
            ReplaceForLost = 3,
            ReplaceFoDamage = 4,
        }

        public enum enApplicationTypes_IDs : byte
        {
            NewLocalDrivingLicenseService=1,
            RenewDrivingLicenseService=2,
            ReplacementFor_LostDrivingLicense=3,
            ReplacementFor_DamagedDrivingLicense=4,
            ReleaseDetainedDrivingLicsense=5,
            NewInternationalLicense=6,
        }
        
        

           
        
    }
}
