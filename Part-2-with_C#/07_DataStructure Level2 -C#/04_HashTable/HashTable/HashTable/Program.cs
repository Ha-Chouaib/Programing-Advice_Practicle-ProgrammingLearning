using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable MyHashtable = new Hashtable();

            MyHashtable.Add("Key1","Value1");
            MyHashtable.Add("Key2","Value2");
            MyHashtable.Add("Key3","Value3");

            Console.WriteLine("Initial HashTable Contents:");
            foreach (DictionaryEntry entry in MyHashtable)
            {
                Console.WriteLine($"Key: [{entry.Key}], Value: [{entry.Value}]");
            }

            //Modifying an Element
            MyHashtable["Key1"] = "NewValue1";

            //Accessing an Element
            Console.WriteLine($"\nAccessing the [key1] Value: {MyHashtable["Key1"]}");

            //Removing Element
            MyHashtable.Remove("Key2");

            //Iterating Over Elements
            Console.WriteLine("\nCurrent HashTable Contents:");
            foreach (DictionaryEntry entry in MyHashtable)
            {
                Console.WriteLine($"Key: [{entry.Key}], Value: [{entry.Value}]");
            }

        }
    }
}
