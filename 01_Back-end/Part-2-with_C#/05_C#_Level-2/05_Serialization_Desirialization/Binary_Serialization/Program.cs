using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//For Binary Serialization
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Binary_Serialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = " Chouaib Hadadi", Age = 22 };

            //Serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream= new FileStream("BinaryPerson.bin",FileMode.Create))
            {
                formatter.Serialize(stream, person);
            }

            //Deserialization
            using(FileStream stream=new FileStream("BinaryPerson.bin",FileMode.Open))
            {
                Person Desrializedperson= (Person) formatter.Deserialize(stream);
                Console.WriteLine($"Name: {Desrializedperson.Name} | Age: {Desrializedperson.Age}");
            }
        }
    }
}
