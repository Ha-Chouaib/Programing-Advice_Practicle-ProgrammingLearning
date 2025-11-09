using System;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Asymmetric_Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Generate Public and Private Key Pair
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {

                    string publicKey = rsa.ToXmlString(false);
                    string privateKey = rsa.ToXmlString(true);

                    string OriginalData = "This Is A Secret";

                    string EncryptedData = Encrypt(OriginalData, publicKey);
                    string DecryptedData = Decrypt(EncryptedData, privateKey);

                    Console.WriteLine($"Public Key: {publicKey}");
                    Console.WriteLine($"\nPrivate Key: {privateKey}");
                    Console.WriteLine($"\nOriginal Data: {OriginalData}");
                    Console.WriteLine($"Encrypted Data: {EncryptedData}");
                    Console.WriteLine($"Decrypted Data: {DecryptedData}");

                }
            }
            catch(CryptographicException ex)
            {
                Console.WriteLine($"Encryption/Decryption Error: {ex.Message}");  
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An Expected Error: {ex.Message}");
            }
        }

        static string Encrypt(string PlainText, string publicKey)
        {
            try
            {
                using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);

                    byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(PlainText), false);
                    return Convert.ToBase64String(encryptedData);
                }

            }catch(CryptographicException ex)
            {
                Console.WriteLine($"Encryption Error: {ex.Message}");
                throw;
            }
        }

        static string Decrypt(string cipherText, string privateKey)
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);

                    byte[] encryptedData = Convert.FromBase64String(cipherText);
                    byte[] decryptedData= rsa.Decrypt(encryptedData,false);
                    return Encoding.UTF8.GetString(decryptedData);
                }

            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Decryption Error: {ex.Message}");
                throw;
            }
        }
    }
}
