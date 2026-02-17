using Bank_BusinessLayer.Reports.CustomerReports;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Bank_BusinessLayer.clsUser;

namespace Bank_BusinessLayer
{
    public class clsUtil_BL
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
                Registry.SetValue(RegistryKeyPath, ValueName_Password, Encrypt(Password, EncryptionKey), RegistryValueKind.String);
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

        public class MappingHelper
        {
            public static Dictionary<string, string> GetOptionsFromMapping(Type targetFilterMappingClass)
            {
                var Filter_Mapping = targetFilterMappingClass.GetProperties(BindingFlags.Static | BindingFlags.Public);

                Dictionary<string, string> Options = new Dictionary<string, string>();

                foreach (var prop in Filter_Mapping)
                {
                    var option = ((string valueMember, string DisplayMember))prop.GetValue(null);

                    Options.Add(option.valueMember, option.DisplayMember);
                }

                return Options;
            }

            public static Dictionary<string, Dictionary<string, string>> FilterBy_Groups(Type targetFilterByGroupsMappingClass)
            {
                var Filter_Mapping = targetFilterByGroupsMappingClass.GetProperties(BindingFlags.Static | BindingFlags.Public);

                Dictionary<string, Dictionary<string, string>> Options = new Dictionary<string, Dictionary<string, string>>();

                foreach (var prop in Filter_Mapping)
                {
                    var option = ((string GroupName, Dictionary<string, string> GroupItems))prop.GetValue(null);

                    Options.Add(option.GroupName, option.GroupItems);
                }

                return Options;
            }
        }

        public class CallerInspector
        {
            //Stack race regular Frames 
            // Frame 0 = Frame 0: The method currently executing(GetCallerNamespace())
            // Frame 1 = The method we are inspecting (TargetMethod)
            // Frame 2 = Caller of MyMethod
            public static bool IsExternalClassCall(Type targetClass)
            {
                var caller = GetCallerType();
                return caller != null && caller != targetClass;
            }
            public static bool IsExternalNamespaceCall()
            {

                var target = GetTargetNamespace();
                var caller = GetCallerNamespace();

                if (string.IsNullOrEmpty(target)|| string.IsNullOrEmpty(caller))
                    return false;

                return target != caller;
            }
            public static string GetTargetNamespace() => GetTargetType()?.Namespace ?? "";
            public static string GetCallerNamespace() => GetCallerType()?.Namespace ?? "";
            public static Type GetTargetType()
            {
                var stack = new StackTrace();

                // First real method after our helper = target
                bool foundHelper = false;

                for (int i = 0; i < stack.FrameCount; i++)
                {
                    var type = stack.GetFrame(i)?.GetMethod()?.DeclaringType;
                    if (type == null) continue;

                    if (type == typeof(CallerInspector))
                    {
                        foundHelper = true;
                        continue;
                    }

                    if (foundHelper && IsUserType(type))
                        return type;
                }
                return null;
            }
            public static Type GetCallerType()
            {
                var stack = new StackTrace();

                bool foundTarget = false;

                for (int i = 0; i < stack.FrameCount; i++)
                {
                    var type = stack.GetFrame(i)?.GetMethod()?.DeclaringType;
                    if (type == null) continue;

                    if (type == typeof(CallerInspector))
                        continue;

                    if (!foundTarget && IsUserType(type))
                    {
                        foundTarget = true;
                        continue; // this is target
                    }

                    if (foundTarget && IsUserType(type))
                        return type; // this is caller
                }

                return null;
            }
            private static bool IsUserType(Type type)
            {
                return
                    type.Namespace != null &&
                    !type.Namespace.StartsWith("System") &&
                    !type.Namespace.StartsWith("Microsoft") &&
                    !type.FullName.Contains("ExecutionContext") &&
                    !type.FullName.Contains("AsyncTaskMethodBuilder") &&
                    !type.FullName.Contains("MoveNext");
            }
        }

        public class HandleObjectsHelper
        {
            [Serializable]
            public class LegalPropertiesSnapshot
            {
                public Type OriginalType { get; set; }

                public Dictionary<string, PropertyValue> Properties { get; set; }
            }

            [Serializable]
            public class PropertyValue
            {
                public object Value { get; set; }
                public Type Type { get; set; }
            }

            public static object GetObjectLegalPropertiesOnly<T>(T target)
            {
                if (target == null) return null;

                var legalProperties = typeof(T).GetProperties()
                    .Where(p => p.CanRead && p.CanWrite &&
                                !Attribute.IsDefined(p, typeof(AuditIgnoreAttribute)));

                var snapshot = new LegalPropertiesSnapshot
                {
                    OriginalType = typeof(T),
                    Properties = new Dictionary<string, PropertyValue>()
                };

                foreach (var prop in legalProperties)
                {
                    snapshot.Properties[prop.Name] = new PropertyValue
                    {
                        Value = prop.GetValue(target),
                        Type = prop.PropertyType
                    };
                }

                return snapshot;
            }

            public static (object Before, object After) CompareObjects<T>(T oldObj, T newObj)
            {
                var before = new LegalPropertiesSnapshot
                {
                    OriginalType = typeof(T),
                    Properties = new Dictionary<string, PropertyValue>()
                };
                var after = new LegalPropertiesSnapshot
                {
                    OriginalType = typeof(T),
                    Properties = new Dictionary<string, PropertyValue>()
                };
                var props = typeof(T).GetProperties()
                    .Where(p => p.CanRead && p.CanWrite &&
                    !Attribute.IsDefined(p, typeof(AuditIgnoreAttribute)));

                foreach (var prop in props)
                {
                    var oldValue = prop.GetValue(oldObj);
                    var newValue = prop.GetValue(newObj);

                    if (!AreEqual(oldValue, newValue))
                    {
                        before.Properties[prop.Name] = new PropertyValue
                        {
                            Value = oldValue,
                            Type = prop.PropertyType
                        };
                        after.Properties[prop.Name] = new PropertyValue
                        {
                            Value = newValue,
                            Type = prop.PropertyType
                        };
                    }
                }

                return (before, after);
            }
            private static bool AreEqual(object a, object b)
            {
                if (a == null && b == null) return true;
                if (a == null || b == null) return false;
                return a.Equals(b);
            }
        }
    }
}
