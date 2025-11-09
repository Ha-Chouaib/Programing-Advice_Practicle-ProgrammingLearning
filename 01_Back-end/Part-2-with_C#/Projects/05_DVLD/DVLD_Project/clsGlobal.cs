using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using DVLD_BusinessLayer;
using Microsoft.Win32;
using System.Diagnostics;
namespace DVLD_Project
{
    public class clsGlobal
    {
        public static int CurrentUserID { get; set; }
        public static string EventLog_SourceName = "DVLD_App";

        private static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
       
        public static bool RememberUsernameAndPasssword(string UserName, string Password)
        {
            try
            {
                string ValueName_UserName = "UserName";
                string ValueName_Password = "Password";

                Registry.SetValue(KeyPath, ValueName_UserName,UserName ,RegistryValueKind.String);
                Registry.SetValue(KeyPath, ValueName_Password,clsMyLib.Encrypt(Password,clsMyLib.Key), RegistryValueKind.String);
                return true;
            }
            catch(IOException ex)
            {
                EventLog.WriteEntry(EventLog_SourceName, $"From remember user CredentialInfo: {ex.Message}", EventLogEntryType.Error);
                MessageBox.Show("Error Occured !! "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }
        
        public static bool GetUserCredential(ref string Username,ref string Password )
        {
            try
            {

                string ValueName_UserName = "UserName";
                string ValueName_Password = "Password";
                
                Username=Registry.GetValue(KeyPath, ValueName_UserName, null) as string;
                Password=clsMyLib.Decrypt(Registry.GetValue(KeyPath, ValueName_Password, null) as string,clsMyLib.Key);

                if(Username == null || Password == null)
                {
                    Username = "";
                    Password = "";
                }
                return true;
            }
            catch(IOException ex)
            {

                EventLog.WriteEntry(EventLog_SourceName, $"From remember user CredentialInfo: {ex.Message}", EventLogEntryType.Error);
                MessageBox.Show("Error Occured !! "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           

        }


        public static  void ActivateContainerControlsOneByOne(Control Container, Type ControlType )
        {
            foreach (Control ctrl in Container.Controls)
            {
                if (ctrl.GetType() ==  ControlType) ctrl.Focus();
               
                if (ctrl.HasChildren) ActivateContainerControlsOneByOne(ctrl,ControlType);
            }
        }



    }
}
