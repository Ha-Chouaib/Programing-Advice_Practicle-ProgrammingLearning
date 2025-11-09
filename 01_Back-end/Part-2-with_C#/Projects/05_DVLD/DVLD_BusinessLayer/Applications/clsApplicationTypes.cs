
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsApplicationTypes
    {

        public int AppID { get; set; }
        public string AppTitle { get; set; }
        public  float AppFees { get; set; }
        public clsApplicationTypes(int AppID,string AppTitle,float AppFees) 
        {
            this.AppID = AppID;
            this.AppTitle= AppTitle;
            this.AppFees= AppFees;
        }

        public static clsApplicationTypes Find(int AppID)
        {
            string AppTitle = "";
            float AppFees = 0;
            if(clsApplicationTypesDataAccessLayer.Find(AppID,ref AppTitle,ref AppFees))
            {
                return new clsApplicationTypes(AppID,AppTitle,AppFees);
            }
            return null;
        }
        public static clsApplicationTypes Find(string AppTitle)
        {
            int AppID = -1;
            float AppFees = 0;
            if (clsApplicationTypesDataAccessLayer.Find(AppTitle,ref AppID, ref AppFees))
            {
                return new clsApplicationTypes(AppID, AppTitle, AppFees);
            }
            return null;
        }
        
        public bool SaveAppUpdates()
        {
            return clsApplicationTypesDataAccessLayer.UpdateApp(this.AppID, this.AppTitle, this.AppFees);
        }
        public static DataTable ListAll()
        {
            return clsApplicationTypesDataAccessLayer.ListAllApps();
        }

        
    
    }
}
