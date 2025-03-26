using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;


namespace _02_AccessModifiers
{
    class clsA
    {
        public int x1 = 10;
        private int _x2;
        protected int x3 = 30;
         
        //Get Set Properties
        public int x2
        {
            get
            {
                return _x2;
            }
            set 
            {
                _x2 = value;
                    
            }
        }
        //Auto Implemented Properties
        // It's Like Shortcut of the Properties above .
        //with this Way You Don't need to set a private field first then implement its properties. the sys automatically generate it.
        // So No Need To Private Field With this.    
         public int ID
        {
            get;
            set;
        }
        public int func1()
        {
            return 100;
        }
        private int func2()
        {
            return 200;
        }
        protected int func3()
        {
            return 300;
        }
    }
        class clsB : clsA
        {
            public int func4()
            {
                return x1 + x3;
            }
        }
     internal class Program
    {   
        static void Main(string[] args)
        {
            clsA A = new clsA();
            Console.WriteLine("All Public Members are Accessable");
        }
    }
}
