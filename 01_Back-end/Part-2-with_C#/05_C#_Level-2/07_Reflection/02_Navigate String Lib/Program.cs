using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Navigate_String_Lib
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly mscorlib = typeof(string).Assembly;

            Type strType = mscorlib.GetType("System.String");
            if(strType != null)
            {

                var strMethods= strType.GetMethods(BindingFlags.Public | BindingFlags.Instance).OrderBy(method=> method.Name);
                foreach (var method in strMethods)
                {
                    Console.WriteLine($"\t{method.ReflectedType} {method.Name}({GetParameterList(method.GetParameters())})");
                }
            }

            
        }
        static string GetParameterList(ParameterInfo[] Parameters)
        {
            return string.Join(", ", Parameters.Select(Parameter => $"{Parameter.ParameterType} {Parameter.Name}"));
        }
    }
}
