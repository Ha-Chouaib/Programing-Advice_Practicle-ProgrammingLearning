using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ImplementingIEnumerable
{
    public class CustomCollection<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0;i < items.Count; i ++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return  GetEnumerator();
        }

        public void Add(T item)
        { 
            items.Add(item);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<int> myCollection= new CustomCollection<int>();

            myCollection.Add(1);
            myCollection.Add(2);
            myCollection.Add(3);
            myCollection.Add(4);

            foreach(int i in myCollection)
            {
                Console.WriteLine(i);
            }
        }
    }
}
