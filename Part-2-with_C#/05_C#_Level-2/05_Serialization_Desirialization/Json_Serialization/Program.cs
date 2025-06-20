using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// For Json Serialization
using System.Runtime.Serialization.Json;
using System.IO;

namespace Json_Serialization
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
            Person person = new Person { Name = "Chouaib Hadadi", Age = 22 };

            //Json Serialization
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, person);
                string JsonString = System.Text.Encoding.UTF8.GetString(stream.ToArray());

                //Save The Json String To A json File [Optional]
                File.WriteAllText("JsonPerson.json", JsonString);
            }

            //Desrialization
            using(FileStream stream= new FileStream("JsonPerson.json",FileMode.Open))
            {
                Person DeserializedPerson = (Person)serializer.ReadObject(stream);
                Console.WriteLine($"Name: {DeserializedPerson.Name} | Age: {DeserializedPerson.Age}");
            }
        }
    }
}
