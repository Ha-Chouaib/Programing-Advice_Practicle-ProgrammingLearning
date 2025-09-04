using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_ListOfCustomObjects
{
    public class People
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        public People(string name, byte age)
        {
            Name = name;
            Age = age;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<People> people = new List<People>
            {
                new People("Chouaib",23),
                new People("Omar",24),
                new People("Ali",26),
                new People("Mohammed",41),
                new People("Nour",20),
                new People("Salma",23)
            };

            Console.WriteLine("The Current State of the people List");
            foreach(People person in people)
            {
                Console.WriteLine($"Name: [{person.Name}] , Age: [{person.Age}]");
            }

            People FoundPerson = people.Find(p => p.Name == "Chouaib");
            if(FoundPerson != null) Console.WriteLine($"\nName: [{FoundPerson.Name}] , Age: [{FoundPerson.Age}]");
            
            //Like Find => List Property || FirstOrDeafault => Linq Property
            People searchresult = people.FirstOrDefault(p => p.Name == "Ali");
            if (searchresult != null)
            {
                searchresult.Age = 27;
                Console.WriteLine($"Update [{searchresult.Name}'s] Age To [{searchresult.Age}]");
            }

            List<People> PeopleOver25 = people.FindAll(p => p.Age >= 25);
            Console.WriteLine("\nPeople Over 25:");
            foreach (People person in PeopleOver25)
            {
                Console.WriteLine($"Name: [{person.Name}] , Age: [{person.Age}]");
            }

            bool ContainsPersonWithName = people.Any(p => p.Name == "Omar");
            Console.WriteLine($"\nIs List Contains a Person Named [Omar]?: {ContainsPersonWithName}");

            bool ExistOver30 = people.Exists(p=> p.Age > 30);
            Console.WriteLine($"Exists Person Over [30]?: {ExistOver30}");


            people.RemoveAll(p => p.Age < 23);
            Console.WriteLine("\nRemoved All People Under Than 23");

            foreach (People person in people)
            {
                Console.WriteLine($"Name: [{person.Name}] , Age: [{person.Age}]");
            }





        }
    }
}
