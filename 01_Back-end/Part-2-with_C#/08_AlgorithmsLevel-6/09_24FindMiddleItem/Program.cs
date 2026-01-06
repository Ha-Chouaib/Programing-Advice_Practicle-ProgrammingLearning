using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_24FindMiddleItem
{
    internal class Program
    {
        int GetMiddleItem(Queue<int> inputQueue)
        {
            List<int> list = new List<int>(inputQueue);
            return list[list.Count / 2];
        }
        static void Main(string[] args)
        {
            Queue<int> inputQueue = new Queue<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
            Console.WriteLine("Input Queue: " + string.Join(", ", inputQueue));
            Console.WriteLine("Middle Item: " + new Program().GetMiddleItem(inputQueue));
        }
    }
}
