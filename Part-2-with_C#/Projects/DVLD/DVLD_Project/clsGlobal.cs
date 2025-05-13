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

        public static byte ApplicationStatus_New = 1;
        public static byte ApplicationStatus_Canceled = 2;
        public static byte ApplicationStatus_Complete = 3;
    }
}
