using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Searching_Functions
{
    public class clsStudents
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    public class clsProducts
    {
        public string Name { get; set; }
        public bool InStock { get; set; }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
             1 Contains – Check if a number exists
               # From a list of integers, check if the number 25 exists.
             */
            List <int>Nums = new List<int> { 3, 6, 9, 12, 15, 18, 5, 10, 21, 25, 30, 33, 7, 40, 45 };
            Console.WriteLine($"[1] List Items: {string.Join(" , ",Nums)}");
            Console.WriteLine($"Check If [25] Exists On The List -[ {Nums.Contains(25)} ]-");

            /*
             2 Contains – Check for a name
              # From a list of names, check if "Sara" is in the list.
             */
            List<string>Names = new List<string> { "Ali", "Sara", "Adam", "Lina", "Sam","Chouaib" };
            Console.WriteLine($"\n[2] List Items: {string.Join(" , ", Names)}");
            Console.WriteLine($"Check If [Sara] Exists On The List -[ {Names.Contains("Sara")} ]-");

            /*
             3 Find – First even number
               # From a list of integers, find the first even number.
             */
            Console.WriteLine($"\n[3] List Items: {string.Join(" , ", Nums)}");
            Console.WriteLine($"First Even Number -[ {Nums.Find(n => n % 2 == 0)} ]-");

            /*
             4 Find – First name longer than 5 chars
               # From a list of names, find the first one with more than 5 letters.
             */
            Console.WriteLine($"\n[4] List Items: {string.Join(" , ", Names)}");
            Console.WriteLine($"the first one with more than 5 letters. -[ {Names.Find(N => N.Length > 5)} ]-");

            /*
             5 FindAll – All odd numbers
               # From a list of integers, return all odd numbers.
             */
            Console.WriteLine($"\n[5] List Items: {string.Join(" , ", Nums)}");
            Console.WriteLine($"All Odd Numbers -[ {string.Join(" , ",Nums.FindAll(n => n % 2 != 0))} ]-");

            /*
             6 FindAll – Names starting with 'A'
               # From a list of names, return all names that start with 'A'.
             */
            Console.WriteLine($"\n[6] List Items: {string.Join(" , ", Names)}");
            Console.WriteLine($"Names starting with 'A' -[ {string.Join(" , ", Names.FindAll(n => n.StartsWith("A")))} ]-");

            /*
             7 Exists – Product in stock
               # From a list of products { Name, InStock }, check if at least one product is available (InStock == true).
             */
            List<clsProducts> products = new List<clsProducts>
            {
                new clsProducts{Name="Laptop",InStock=true},
                new clsProducts{Name= "Phone", InStock=true},
                new clsProducts{Name= "Tablet", InStock=false}
            };
            Console.WriteLine($"\n[7] Products List:");
            foreach (var P in products)
            {
                Console.WriteLine($"{P.Name}");

            }
            Console.WriteLine($" Products InStock :");
            foreach (var P in products.FindAll(p => p.InStock))
            {
                Console.WriteLine($"{P.Name}");

            }
            /*
             8 Exists – Person under 18
               # From a list of people { Name, Age }, check if there exists any person under 18.
             */
            List<Person> people = new List<Person>
                        {
                            new Person { Name = "Ali", Age = 17 },
                            new Person { Name = "Sara", Age = 22 },
                            new Person { Name = "Omar", Age = 29 },
                            new Person { Name = "Lina", Age = 13 },
                            new Person { Name = "Adam", Age = 25 },
                            new Person { Name = "Samira", Age = 18 },
                            new Person { Name = "Khalid", Age = 35 }
                        };
            Console.WriteLine($"\n[8] People List:");
            foreach (var P in people)
            {
                Console.WriteLine($"{P.Name}");

            }

            Console.WriteLine($"---------- Person under 18.\n");
            foreach (var Person in people.FindAll(p => p.Age <= 18))
            {
                Console.WriteLine($"-> {Person.Name} => {Person.Age}");
            }

            /*
             9 Any – Scores greater than 90
               # From a list of scores, check if any score is greater than 90.
             */
            List<clsStudents> Students = new List<clsStudents>
            {
                new clsStudents{Name= "Chouaib",Score = 90},
                new clsStudents{Name= "Ali",Score = 80},
                new clsStudents{Name= "Omar",Score = 30},
                new clsStudents{Name= "Kamal",Score = 70},
                new clsStudents{Name= "Isma3il",Score = 83},
            };
            Console.WriteLine($"\n[9]List Content:");
            foreach (var Student in Students)
            {
                Console.WriteLine($"Student: {Student.Name}, Score: {Student.Score}");
            }
            Console.WriteLine($"Are There Any Score Greater Than 90 --> [{Students.Any(s => s.Score > 90)}]");

            /*
             10 Any – Names with specific substring
               # From a list of names, check if any name contains the substring "am".
             */
            List<string> names = new List<string>
                                {
                                    "Sam",
                                    "Lina",
                                    "Adam",
                                    "Omar",
                                    "Khalid",
                                    "Amira",
                                    "Sara",
                                    "Hatem",
                                    "Salma",
                                    "Nour"
                                };

            Console.WriteLine($"\n[10] List Items: {string.Join(" , ", names)}");
            Console.WriteLine($"Are there any name contains the substring \"am\"-[ {names.Any(n => n.Contains("am"))} ]-");
        }
    }
}
