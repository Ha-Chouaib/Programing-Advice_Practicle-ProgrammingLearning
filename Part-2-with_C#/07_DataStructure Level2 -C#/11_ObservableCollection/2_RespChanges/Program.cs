using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_RespChanges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> Items = new ObservableCollection<string>();

            Items.CollectionChanged += Item_CollectionChanged;

            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");

            Items.RemoveAt(1);
            Items.Insert(0, "New Item In Beginning");
            Items[1] = "Replaced Item";
            Items.Move(0, 2);

            Console.WriteLine("\nFinal Collection:");
            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }


        }

        static void Item_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Added:");
                    foreach (var newItem in e.NewItems)
                    {
                        Console.WriteLine($"-  {newItem}");
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Removed:");
                    foreach (var OldItem in e.OldItems)
                    {
                        Console.WriteLine($"-  {OldItem}");
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Replaced:");
                    foreach (var OldItem in e.OldItems)
                    {
                        Console.WriteLine($"-  {OldItem}");
                    }
                    Console.WriteLine("With:");
                    foreach (var newItem in e.NewItems)
                    {
                        Console.WriteLine($"-  {newItem}");
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    Console.WriteLine("Moved:");
                    Console.WriteLine($"From index: {e.OldStartingIndex} TO: {e.NewStartingIndex}");
                    break;


            }
        }
    }
}
