using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace _01_Hashing
{
    internal class Program
    {
        static string ComputeHash(string input)
        {
            using(SHA256 sha256= SHA256.Create())
            {
                byte[] hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashbytes).Replace("-", "").ToLower();
            }
        }
        static void Main(string[] args)
        {
            string Data = "Chouaib Hadadi";

            string HashedData = ComputeHash(Data);

            Console.WriteLine($"Original Data: [ {Data} ]");
            Console.WriteLine($"Hashed Data: [ {HashedData} ]");
        }
    }
}
