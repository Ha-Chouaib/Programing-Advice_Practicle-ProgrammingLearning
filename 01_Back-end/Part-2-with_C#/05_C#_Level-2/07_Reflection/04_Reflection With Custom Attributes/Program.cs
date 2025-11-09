using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_With_Custom_Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method ,AllowMultiple =true)]
    public class MyCustomAttribute:Attribute
    {
        public string Description { get; }
        public MyCustomAttribute(string Description)
        {
            this.Description = Description;
        }
    }

    [MyCustom("This is a Class Attribute")]
    public class MyClass
    {
        [MyCustom("this is a Method Attribue")]
        public void MyMethod()
        {
            Console.WriteLine("MyClass Method");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);

            object[] classAttributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach(MyCustomAttribute attribute in classAttributes )
            {
                Console.WriteLine("Class Attribute: " + attribute.Description);
            }

            MethodInfo methodInfo = type.GetMethod("MyMethod");
            object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach (MyCustomAttribute attribute in methodAttributes)
            {
                Console.WriteLine("Method Attribute: " + attribute.Description);
            }
        }
    }
}
