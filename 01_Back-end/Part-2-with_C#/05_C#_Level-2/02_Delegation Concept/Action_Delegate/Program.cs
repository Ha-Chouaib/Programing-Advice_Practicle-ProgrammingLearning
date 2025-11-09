using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action PerformVoidProcedure = Method1LessParameters;
            Action<int> actionWithSingleParam= Method2;
            Action<string ,int> actionWithMultiParams= Method3;

            PerformVoidProcedure();
            actionWithSingleParam(2);
            actionWithMultiParams("Chouaib", 22);
        }

        static void Method1LessParameters()
        {
            Console.WriteLine("Wellcome! No Param Right Here");
        }

        static void Method2(int x)
        {
            Console.WriteLine($"Wellcome! With One Param, {x}");
        }

        static void Method3(string Name,int Age)
        {
            Console.WriteLine($"Hello! My Name Is {Name} And I am {Age} Years Old");
        }
    }
}
