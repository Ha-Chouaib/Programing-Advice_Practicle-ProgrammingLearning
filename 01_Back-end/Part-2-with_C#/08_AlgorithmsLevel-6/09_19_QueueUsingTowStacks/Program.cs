using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_19_QueueUsingTowStacks
{
    internal class Program
    {
        class MySimpleQueue<T>
        {
            Stack<T> EnqueueStack = new Stack<T>();
            Stack<T> DequeueStack = new Stack<T>();

            public void Enqueue(T item)
            {
                EnqueueStack.Push(item);
            }
            public T Dequeue()
            {
                if (DequeueStack.Count == 0)
                {
                    while (EnqueueStack.Count > 0)
                        DequeueStack.Push(EnqueueStack.Pop());
                }

                return DequeueStack.Pop();
            }
            public T Peek()
            {
                if (DequeueStack.Count == 0)
                {
                    while (EnqueueStack.Count > 0)
                        DequeueStack.Push(EnqueueStack.Pop());
                }
                return DequeueStack.Peek();
            }
            public int Count => EnqueueStack.Count + DequeueStack.Count;

            public IEnumerator<T> GetEnumerator()
            {
                // Return all items in current queue order
                // First: elements in outbox (top → bottom)
                foreach (var item in DequeueStack)
                    yield return item;

                // Then: elements in inbox (bottom → top)
                foreach (var item in EnqueueStack.Reverse())
                    yield return item;
            }

            
        }
        static void Main(string[] args)
        {
            MySimpleQueue<int> myqueue = new MySimpleQueue<int>();
            myqueue.Enqueue(1);
            myqueue.Enqueue(2);
            myqueue.Enqueue(3);
            myqueue.Enqueue(4);

            while (myqueue.Count > 0)
            {
                Console.WriteLine(myqueue.Dequeue());
            }
        }
    }
}
