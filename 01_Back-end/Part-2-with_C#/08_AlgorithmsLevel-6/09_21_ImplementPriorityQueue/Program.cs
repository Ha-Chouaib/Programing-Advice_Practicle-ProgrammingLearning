using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_21_ImplementPriorityQueue
{
    internal class Program
    {
        public class clsPriorityQueue
        {
            private SortedList<int, int> _ListItems= new SortedList<int, int>();
             public void Enqueue(int priority ,int Item)
            {   if(!_ListItems.ContainsKey(priority))               
                    _ListItems.Add(priority, Item);
            }

            public (int? Priority, int? value) Dequeue()
            {
                if (_ListItems.Count == 0)  return (null,null);

                var Item = _ListItems.First();
                _ListItems.Remove(Item.Key);
                return (Item.Key, Item.Value);
            }
            public int Count()
            {
                return _ListItems.Count; 
            }
            public (int priority,int value) Peek()
            {
                var item = _ListItems.First();
                return (item.Key,item.Value);
            }

            public IEnumerator<KeyValuePair<int, int>> GetEnumerator()
            {
                foreach (var item in _ListItems)
                {
                    yield return item;
                }
            }

        }
        static void Main(string[] args)
        {
            clsPriorityQueue myPriorityQueue = new clsPriorityQueue();
            myPriorityQueue.Enqueue(10, 1);
            myPriorityQueue.Enqueue(5, 2);
            myPriorityQueue.Enqueue(20, 3);
            Console.WriteLine("Peek: " + myPriorityQueue.Peek());
            while (myPriorityQueue.Count() > 0)
            {
                    var item = myPriorityQueue.Dequeue();
                    Console.WriteLine("Priority: " + item.Priority + " Item: " + item.value);
                    
              
            }
        }
    }
}
