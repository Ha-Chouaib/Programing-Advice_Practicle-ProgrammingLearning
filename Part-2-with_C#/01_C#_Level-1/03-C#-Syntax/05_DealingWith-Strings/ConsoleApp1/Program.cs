using System;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string S1="Hello! Good Morning ";
            Console.WriteLine(S1);//Hello! Good Morning 
            Console.WriteLine(S1.Substring(0,4));//Hell
            Console.WriteLine(S1.ToLower());//hello! good morning
            Console.WriteLine(S1.ToUpper());//HELLO! GOOD MORNING
            Console.WriteLine(S1[4]);// o
            Console.WriteLine(S1.Insert(0,"Well"));//WellHello! Good Morning
            Console.WriteLine(S1.Replace('G','D'));//Hello! Dood Morning
            Console.WriteLine(S1.IndexOf('M'));//12
            Console.WriteLine(S1.Contains('Z'));//False
            Console.WriteLine(S1.Contains('n'));//True
            Console.WriteLine(S1.LastIndexOf('o'));//13

            string S2="Chouaib,Mohammed,Kamal";
            string [] ListStr=S2.Split(',');
            Console.WriteLine(ListStr[0]);//Chouoib
            Console.WriteLine(ListStr[1]);//Mohammed
            Console.WriteLine(ListStr[2]);//Kamal

            string S3="    Hadadi     ";
            Console.WriteLine(S3.Trim());//Hadadi
            Console.WriteLine(S3.TrimStart());//Hadadi.....
            Console.WriteLine(S3.TrimEnd());//.....Hadadi

        }
    }
}