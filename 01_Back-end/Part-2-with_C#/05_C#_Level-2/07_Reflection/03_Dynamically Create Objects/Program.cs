using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dynamically_Creat_Objects__InvokeMethods
{
    public class MyClass
    {
        public int Property1 { get; set; }
        public void Method1()
        {
            Console.WriteLine("Method 1 Executed");
        }
        public void Method2(int Value1, string Value2)
        {
            Console.WriteLine($"Method 2 Executed With Parameters [ {Value1} ] &&  [ {Value2} ]");
        }
    }
    internal class Program
    {
        static string GetParameterList(ParameterInfo[] Parameters)
        {
            return string.Join(", ", Parameters.Select(Parameter => $"{Parameter.ParameterType} {Parameter.Name}"));
        }
        static void Main(string[] args)
        {
            Type myClassType = typeof(MyClass);
            Console.WriteLine($"Class Name: {myClassType.Name}");
            Console.WriteLine($"Full Name: {myClassType.FullName}");

            Console.WriteLine("\n\tClass Properties:");
            foreach(var Property in myClassType.GetProperties())
            {
                Console.WriteLine($"Property Name: {Property.Name} | Type: {Property.PropertyType}");
            }

            Console.WriteLine("\n\tClass Methods:");
            foreach (var Method in myClassType.GetMethods())
            {
                Console.WriteLine($"{Method.ReturnType} | Type: {Method.Name}({GetParameterList(Method.GetParameters())})");
            }

            //Create Onbject from MyClass
            object myClassInstance = Activator.CreateInstance(myClassType);

            //Set Value To Property
            myClassType.GetProperty("Property1").SetValue(myClassInstance, 22);
            Console.WriteLine($"Set property1 To 22 Using Reflection:");

            Console.WriteLine("\n Getting Property1 Value Using Reflection\n");
            int Property1Value = (int)myClassType.GetProperty("Property1").GetValue(myClassInstance);
            Console.WriteLine($"Property1 Value=: {Property1Value}");

            Console.WriteLine("\nExecuting Methods Using Reflection\n");
            myClassType.GetMethod("Method1").Invoke(myClassInstance, null);

            object[] Parameters = { 200, "Chouaib Hadadi" };
            myClassType.GetMethod("Method2").Invoke(myClassInstance, Parameters);



        }
    }
}
