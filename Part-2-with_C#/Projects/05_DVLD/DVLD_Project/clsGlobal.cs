using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD_Project
{
    public class clsGlobal
    {
        public static int CurrentUserID { get; set; }

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

                    string UserCredential = UserName + "#//#" + clsMyLib.EncryptString( Password);

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
                            Username = result[0] ;
                            Password = clsMyLib.DecryptString( result[1] );
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
