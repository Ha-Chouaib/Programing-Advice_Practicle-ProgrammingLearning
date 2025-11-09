using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Fro XML Serialization
using System.Xml.Serialization;

namespace XML_Serialization
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
            Person person = new Person { Name = "Chouab Hadadi", Age = 22 };

            //Xml Serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using(TextWriter Writer = new StreamWriter("XMLPerson.xml"))
            {
                serializer.Serialize(Writer, person);
            }

            // DeSerialization
            using (TextReader Reader = new StreamReader("XMLPerson.xml"))
            {
                Person deserializedPerson = (Person)serializer.Deserialize(Reader);
            }

        }
    }
}
