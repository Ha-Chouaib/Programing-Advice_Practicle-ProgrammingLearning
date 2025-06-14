using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsMyLib
    {
        public static string EncryptString(string Str_ToEncrypt)
        {
            char[] chars = Str_ToEncrypt.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] ^ 6);
            } 
         
            return new string(chars);
        }

        public static string DecryptString(string Str_ToDecrypt)
        {
            char[] chars = Str_ToDecrypt.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] ^ 6);
            }

            return new string(chars);
        }
    }
}
