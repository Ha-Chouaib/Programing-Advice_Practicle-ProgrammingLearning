using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank_BusinessLayer
{
    public class clsSettings
    {
        public static string EventLog_SourceName = "DVLD_App";
        public static string EncryptString_Hashing(string Str_ToEncrypt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Str_ToEncrypt));
                return BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
            }
        }
     

        public static string EncryptionKey = "1234567890123456";
        public static string Encrypt(string PlainText, string Key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(PlainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }

            }

        }
        public static string Decrypt(string cipherText, string Key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                ICryptoTransform Decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, Decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }


            }
        }


        private static string RegistryKeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        public static bool RememberUsernameAndPasssword(string UserName, string Password)
        {
            try
            {
                string ValueName_UserName = "UserName";
                string ValueName_Password = "Password";

                Registry.SetValue(RegistryKeyPath, ValueName_UserName, UserName, RegistryValueKind.String);
                Registry.SetValue(RegistryKeyPath, ValueName_Password, Encrypt(Password,EncryptionKey), RegistryValueKind.String);
                return true;
            }
            catch (IOException ex)
            {
                EventLog.WriteEntry(EventLog_SourceName, $"From remember user CredentialInfo: {ex.Message}", EventLogEntryType.Error);
                
                return false;
            }

        }
        public static bool GetUserCredential(ref string Username, ref string Password)
        {
            try
            {

                string ValueName_UserName = "UserName";
                string ValueName_Password = "Password";

                Username = Registry.GetValue(RegistryKeyPath, ValueName_UserName, null) as string;
                Password = Decrypt(Registry.GetValue(RegistryKeyPath, ValueName_Password, null) as string, EncryptionKey);

                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    Username = "";
                    Password = "";
                }
                return true;
            }
            catch (IOException ex)
            {

                EventLog.WriteEntry(EventLog_SourceName, $"From remember user CredentialInfo: {ex.Message}", EventLogEntryType.Error);

                return false;
            }


        }
    }
}
