using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObsoleteAttributes
{
    public class MyClass
    {
        [Obsolete("This Method is Marcked as Obsolete, and will be [Deprecated] in The Future")] //To Set a Warnning Message To The User That The Targeted Method Will Be 
                                                                                                //Out Of Service In The Future << Deprecated >>
        public void Method1()
        {
            Console.WriteLine("This Method Is Marked As Obsolete");
        }
        public void Method2()
        {
            Console.WriteLine("This Method Is ReCommended Method To Use Instead Of Method1");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            myClass.Method1();//Deprecated Method

            myClass.Method2();
        }
    }
}
