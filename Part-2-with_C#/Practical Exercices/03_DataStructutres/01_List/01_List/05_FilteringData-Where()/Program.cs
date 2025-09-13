using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_FilteringData_Where__
{

    public class clsProducts 
    {
        public string Name {  get; set; } 
        public bool InStock {  get; set; }
    }
    public class clsStudents
    {
        public string Name { get; set; }
        public int Score { get; set; }
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
             1 Even numbers only
                # From a list of integers, filter only the even numbers.
             */
            List<int> Nums = new List<int> {1,2,3,4,5, 10, 20, 30, 40, 50 };
            Console.WriteLine($"[1] Initial List Items -({string.Join(" , ", Nums)})\nOnly Even Numbers: [{string.Join(" , ",Nums.Where( n => n % 2 == 0))}]");

            /*
             2 Names longer than 4 characters
               # From a list of names, return only those with length greater than 4.
             */
            List<string> Names = new List<string> { "Ali", "Sara", "John", "Omar", "Nicolas", "Mariam" };
            Console.WriteLine($"\n[2] List Items  -({string.Join(" , ", Names)}) |Only Greater Than 4 Chars => [{string.Join(" , ",Names.Where(N => N.Length > 4))}]");

            /*
             3 Positive numbers
               # From a list of integers (positive and negative), return only positive numbers.
             */
            Nums = new List<int> { 1, 3, -4, 8, -7, 0, -44, 20 };
            Console.WriteLine($"\n[3] List Items  -({string.Join(" , ", Nums)}) |Positive Numbers => [{string.Join(" , ", Nums.Where(N => N >=  0))}]");

            /*
             4 Filter by first letter
               # From a list of names, return only the ones starting with the letter "A"
             */
            Names = new List<string> { "Ali", "Sara", "Adam", "Lina", "Sam" };
            Console.WriteLine($"\n[4] List Items: {string.Join(" , ", Names)} | Only How Start With \"A\" -> {string.Join(" , ",Names.Where(n => n.StartsWith("A")))} ");

            /*
             5 Products in stock
               # Given a list of products with Name and InStock (boolean), return only products that are available.
             */
            List<clsProducts> products = new List<clsProducts>
            {
                new clsProducts{Name="Laptop",InStock=true},
                new clsProducts{Name= "Phone", InStock=true},
                new clsProducts{Name= "Tablet", InStock=false}
            };

            Console.WriteLine($"\n[5] Products List:");
            foreach (var P in products)
            {
                Console.WriteLine($"{P.Name}");

            }
            Console.WriteLine($" Products InStock :");
            foreach (var P in products.Where( p => p.InStock))
            {
                Console.WriteLine($"{P.Name}");

            }

            /*
             6 High scores
               # From a list of student scores, return only the ones greater than or equal to 80
             */
            List<clsStudents> Students = new List<clsStudents> 
            {
                new clsStudents{Name= "Chouaib",Score = 90},
                new clsStudents{Name= "Ali",Score = 80},
                new clsStudents{Name= "Omar",Score = 30},
                new clsStudents{Name= "Kamal",Score = 70},
                new clsStudents{Name= "Isma3il",Score = 83},
            };
            Console.WriteLine($"\n[6] greater than or equal to 80 Scores:");
            foreach (var Student in Students.Where(S => S.Score >= 80))
            {
                Console.WriteLine($"Student: {Student.Name}, Score: {Student.Score}");
            }

            /*
             7 Odd indexed items
             # From a list of integers, return only elements at odd indexes (hint: use .Select((value, index) => …) then Where).
             */
            Console.WriteLine($"\n[7]List Items: {string.Join(" , ",Nums)} | elements at odd indexes {string.Join(" , ",Nums.Where((N ,index) => index % 2 != 0))}");

            /*
             8 Strings containing a substring
               # From a list of sentences, return only the ones that contain the word "error".
             */
            List<string> sentences = new List<string>
                                                    {
                                                        "System started successfully.",
                                                        "Warning: Low memory.",
                                                        "Critical error: Disk not found.",
                                                        "User logged in.",
                                                        "Error: Invalid password.",
                                                        "File uploaded successfully.",
                                                        "Unexpected error occurred during execution.",
                                                        "Connection established.",
                                                        "Error: Access denied.",
                                                        "Shutdown complete."
                                                    };
            Console.WriteLine($"\n[8] List Content: \n{string.Join("\n", sentences)}");
            Console.WriteLine($"\nError Sentenses: \n#{string.Join("\n# ", sentences.Where(S => S.Contains("Error")))}");

            /*
             9 Filter by age range
               # From a list of people {Name, Age}, return only those whose age is between 18 and 30.
             */

            List<Person> people = new List<Person>
                        {
                            new Person { Name = "Ali", Age = 17 },
                            new Person { Name = "Sara", Age = 22 },
                            new Person { Name = "Omar", Age = 29 },
                            new Person { Name = "Lina", Age = 31 },
                            new Person { Name = "Adam", Age = 25 },
                            new Person { Name = "Samira", Age = 18 },
                            new Person { Name = "Khalid", Age = 35 }
                        };

            Console.WriteLine($"\n[9]Only those whose age is between 18 and 30.");
            foreach (var Person in people.Where(p => (p.Age >= 18 && p.Age <= 30)))
            {
                Console.WriteLine($"-> {Person.Name} => {Person.Age}");
            }

            /*
             10 Filter by multiple conditions
                # From a list of numbers, return only those that are divisible by 3 and greater than 10.
             */
            Nums = new List<int> { 3, 6, 9, 12, 15, 18, 5, 10, 21, 25, 30, 33, 7, 40, 45 };
            Console.WriteLine($"\n[10] Initial List Items -({string.Join(" , ", Nums)})" +
                $"\nOnly those that are divisible by 3 and greater than 10: [{string.Join(" , ", Nums.Where(n => (n % 3 == 0 && n > 10)))}]");

        }
    }
}
