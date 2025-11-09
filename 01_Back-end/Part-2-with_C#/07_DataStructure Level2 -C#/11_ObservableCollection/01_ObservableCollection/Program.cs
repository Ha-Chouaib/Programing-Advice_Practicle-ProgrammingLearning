using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ObservableCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> names=new ObservableCollection<string>();
            names.Add("Chouaib");
            names.Add("Ali");
            names.Add("Omar");
            names.Add("Ayoub");
        }
    }
}
