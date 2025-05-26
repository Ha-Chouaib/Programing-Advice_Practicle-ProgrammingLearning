using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DVLD_Project
{
    public class clsGlobal
    {
        public static int CurrentUserID { get; set; }
        public static bool IsRememberMe { get; set; }

        public static bool RememberUsernameAndPasssword(string UserName, string Password)
        {
            try
            {
                string FolderPath = System.IO.Directory.GetCurrentDirectory();

                string FilePath = FolderPath + "\\data.txt";
           
                    if (UserName == "" && File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                        return true;
                    }

                    string UserCredential = UserName + "#//#" + Password;

                    using(StreamWriter Write = new StreamWriter(FilePath))
                    {
                        Write.WriteLine(UserCredential);
                        return true;
                    }

            }catch(IOException ex)
            {
                MessageBox.Show("Error Occured !! "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        
        public static bool GetUserCredential(ref string Username,ref string Password )
        {
            try
            {
                string FolderPath = System.IO.Directory.GetCurrentDirectory();
                string FilePath = FolderPath + "\\data.txt";

                if(File.Exists(FilePath))
                {
                    string Line;
                    using(StreamReader reader= new StreamReader(FilePath))
                    {
                        while ((Line = reader.ReadLine()) != null)
                        {
                            string[] result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            Username = result[0];
                            Password = result[1];
                        }
                         return true;
                    }
                }else
                {
                    return false;
                }
            }
            catch(IOException ex)
            {

                MessageBox.Show("Error Occured !! "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           

        }
        
        public enum enApplicationStatus : byte
        {
            New = 1,
            Canceled = 2,
            Completed = 3,
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
            RetakeTest=8,
        }
        
        

           
        
    }
}
