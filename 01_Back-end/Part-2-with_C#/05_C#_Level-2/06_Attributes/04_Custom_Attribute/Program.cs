using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true)]
    public class MyCustomAttribute: Attribute
    {
        public string Description { get; }
        public MyCustomAttribute(string Description)
        {
            this.Description = Description;
        }
    }
    [MyCustom("This is My First Custom Class attribute")]
    public class MyClass
    {
        [MyCustom("this is My First Custom Method Attribute")]
        public void MyMethod()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
