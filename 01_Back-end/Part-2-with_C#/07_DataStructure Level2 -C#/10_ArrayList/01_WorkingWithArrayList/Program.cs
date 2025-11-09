using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WorkingWithArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrList=new ArrayList();

            arrList.Add(1);
            arrList.Add(2);
            arrList.Add(3);
            arrList.Add("Hi!");
            arrList.Add(true);

            Console.WriteLine($"Elements in ArrayList: ");
            foreach (var i in arrList)
            { 
                Console.WriteLine(i);
            }

            arrList.Remove(true);
            Console.WriteLine($"\nAfter Remove [true] Element: ");
            foreach (var i in arrList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"\nGet Elements By Index: ");
            for (int i = 0; i < arrList.Count; i++)
            {
                Console.WriteLine($"Index[{i}]: < {arrList[i]} >");
            }
        }
    }
}
