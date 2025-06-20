using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_Attributes
{
    [Serializable]//Attribute Tell's That This Class Able To Be Serialized
    public class Person
    {
        public string Name;

        [NonSerialized]// Will Not Be Serialized
        public int Age;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
