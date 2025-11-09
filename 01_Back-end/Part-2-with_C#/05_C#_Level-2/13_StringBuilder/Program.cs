using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_StringBuilder
{
    internal class Program
    {
        static void Concatenatestrings(int Iterations)
        {
            string result = "";
            for(int i=0;i< Iterations; i++)
            {
                result += "a";
            }

        }
        static void ConcatenatestringBuilders(int Iterations)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append("a");
            }

        }
        static void Main(string[] args)
        {
            int Iterations = 200000;

            Stopwatch WatchNormalStringIterationTime = Stopwatch.StartNew();
            Concatenatestrings(Iterations);
            WatchNormalStringIterationTime.Stop();
            Console.WriteLine($"String Concatenation using + took: {WatchNormalStringIterationTime.ElapsedMilliseconds} ms");

            Stopwatch WatchStringBuilderIterationTime = Stopwatch.StartNew();
            ConcatenatestringBuilders(Iterations);
            WatchStringBuilderIterationTime.Stop();
            Console.WriteLine($"String Concatenation using + took: {WatchStringBuilderIterationTime.ElapsedMilliseconds} ms");


        }
    }
}
