using System;

namespace Main
    {
        internal class Program
        {

        static void Main(string[] args)
            {
            /*
                C# Exceptions - Try..Catch
                C# Exceptions
                When executing C# code, different errors can occur: coding errors made by the programmer, errors due to wrong input, or other unforeseeable things.
                When an error occurs, C# will normally stop and generate an error message. The technical term for this is: C# will throw an exception (throw an error).
                C# try and catch
                The try statement allows you to define a block of code to be tested for errors while it is being executed.
                The catch statement allows you to define a block of code to be executed, if an error occurs in the try block.
                The try and catch keywords come in pairs
            
            */

            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (Exception e)
            {   
                //error Message
                Console.WriteLine(e.Message);
            }
           
        }
        }
    }

