using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation_Example
{
    [AttributeUsage(AttributeTargets.Property ,AllowMultiple =true)]
    public class RangeAttribute:Attribute
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public string ErorMessage { get; set; }

        public RangeAttribute(int Min, int Max)
        {
            this.Min = Min;
            this.Max = Max;
        }
    }

    public class Person
    {
        [Range(18,99,ErorMessage ="Age Must Be Between 18 and 99")]
        public int Age { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Age = 17, Name = "Chouaib Hadadi" };

            if(PersonValidation(person))
            {
                Console.WriteLine("Valid Person");            }
        }

        static bool PersonValidation(Person person)
        {
            Type type = typeof(Person);

            foreach(var property in type.GetProperties())
            {
                if(Attribute.IsDefined(property,typeof(RangeAttribute)))
                {
                    var rangeAttribute= (RangeAttribute)Attribute.GetCustomAttribute(property,typeof(RangeAttribute));  
                    int Value=(int)property.GetValue(person);

                    if (Value < rangeAttribute.Min || Value > rangeAttribute.Max)
                    {
                        Console.WriteLine($"Validation Failed for Property '{property.Name}' : {rangeAttribute.ErorMessage}");
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
