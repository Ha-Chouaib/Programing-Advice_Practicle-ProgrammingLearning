using System;

namespace Main
{
    internal class Program
    {
        struct stStudent
        {
            public string FirstName;
            public string LastName;
        }
        static void Main(string[] args)
        {
            
            
            
            //......................................Dynamic Types......................................
            
            // A dynamic type escapes type checking at compile-time; instead, it resolves type at run time.

            dynamic MyDynamicVar = 100;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = "Hello World!!";
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = true;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = DateTime.Now;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());
            
            
            
            
            //.......................................Struct Data Type..................................
            /*
            # struct can be used to hold small data values that do not require inheritance,
                 e.g. coordinate points, key-value pairs, and complex data structure.
            # A struct object can be created with or without the new operator, same as primitive type variables.
            # If you declare a variable of struct type without using new keyword, it does not call any constructor,
                so all the members remain unassigned. Therefore, you must assign values to each member before accessing them,
                otherwise, it will give a compile-time error.
            # using new does not mean it's allocated in heap.
            # structure is allocated in stack as long as it's not part of class.
            */
            
            //A struct object can be created with or without the new operator,
            //same as primitive type variables.

            stStudent Student ;
            stStudent Student2 = new stStudent();


            Student.FirstName = "Chouaib";
            Student.LastName = "Hadadi";

   
            Console.WriteLine(Student.FirstName);   
            Console.WriteLine(Student.LastName);

            
            Student2.FirstName = "Ali";
            Student2.LastName = "Ahmed";


            Console.WriteLine(Student2.FirstName);
            Console.WriteLine(Student2.LastName);
 
            
            //.......................Anonymous Data Type.........................

            //you dont specify any type here , automatically will be specified
            var student = new { Id = 20, FirstName = "Chouaib", LastName = "Hadadi" };

            Console.WriteLine("\nExample1:\n");
            Console.WriteLine(student.Id); //output: 20
            Console.WriteLine(student.FirstName); //output: Chouaib
            Console.WriteLine(student.LastName); //output: Hadadi
           
            //You can print like this:
            Console.WriteLine(student);

           
            //anonymous types are read-only
            //you cannot change the values of properties as they are read-only.

           // student.Id = 2;//Error: cannot chage value
           // student.FirstName = "Ali";//Error: cannot chage value


           //An anonymous type's property can include another anonymous type.
           var student2 = new
            {
                Id = 20,
                FirstName = "Chouaib",
                LastName = "Hadadi",
                Address = new { Id = 1, City = "Ca", Country = "Mo" }
            };
            
            Console.WriteLine("\nExample2:\n");
            Console.WriteLine(student2.Id);
            Console.WriteLine(student2.FirstName);
            Console.WriteLine(student2.LastName);

            Console.WriteLine(student2.Address.Id);
            Console.WriteLine(student2.Address.City);
            Console.WriteLine(student2.Address.Country);
            Console.WriteLine(student2.Address);

            
            
            
            //Nullable Data Type it allows you to set null to any other data type by: ( Nullable <Data Type> ...=null; )
            Nullable <int> t=null;
            Console.WriteLine("int with Nallable Data Type t=null {0}",t);
            
            
            /*
                                                            [ Numbers Data Type ]
                    ||                                                                                              ||
            < Intger Type >                                                                             < Floating point Type >
            --> ( byte  -08bit- )-- --(sByte).                                                     --> (float  -32bit-)
            --> ( short -16bit- -Int16-)-- --(Ushort -UInt16-).                                    --> (double  -64bit-)
            --> ( int   -32bit- )-- --(Uint).                                               --> (decimal -128bit-)
            --> ( long  -64bit- )-- --(Ulong).
            
            */
            // Byte......unsigned.............
            //Syntax ex:  byte a=12;
            
            Console.WriteLine("Byte:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Byte.MaxValue, Byte.MinValue);
            //SByte......signed...............
            //Syntax ex:  sbyte b= -128;
            //Syntax ex:  sbyte bb=127;
            Console.WriteLine("SByte:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", SByte.MaxValue, SByte.MinValue);

            // Short......signed..............
            //Syntax ex:  short sh=982;

            Console.WriteLine("Short:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Int16.MaxValue, Int16.MinValue);

            //Ushort......unsigned............
            ushort ush=13;
            Console.WriteLine("ushort:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", UInt16.MaxValue, UInt16.MinValue);

            //int.........signed..............
            //Syntax ex:  int i=-1;
            //Syntax ex:  int ii=1;
            Console.WriteLine("Int:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Int32.MaxValue,Int32.MinValue);

            //uint........unsigned............
            //Syntax ex:  uint ui=2;
            Console.WriteLine("UInt:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", UInt32.MaxValue, UInt32.MinValue);

            //long........signed..............
            //Syntax ex:  long l=3456788;
            //Syntax ex:  long ll=-5678765;
            Console.WriteLine("Long:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Int64.MaxValue, Int64.MinValue);

            //Ulong......unsigned.............
            //Syntax ex:  ulong unl=98765432ul;
            Console.WriteLine("uLong:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", UInt64.MaxValue, UInt64.MinValue);

            //float.....UnSigned................
            //Syntax ex:  float f=233.3f;
            Console.WriteLine("Float:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", float.MaxValue, float.MinValue);
           
            //double....UnSigned................
            //Syntax ex:  double d=2307973.3d;
            Console.WriteLine("double:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", double.MaxValue, double.MinValue);

            //Decimal...UnSigned................
            //Syntax ex:  decimal dc=987654657890897.867m;
            Console.WriteLine("Dicimal:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", decimal.MaxValue, decimal.MinValue);


            //Scientific Notation:  (e referse to 10 power of ...)

            double d1=0.13e2;
            Console.WriteLine(d1);

            float f1=123.43e-2f;
            Console.WriteLine(f1);

            decimal dc1=8598779.57e-3m;
            Console.WriteLine(dc1);

            //Hex & Binary:

            int hex=0x2F;
            Console.WriteLine(hex);

            int Binary= 0b_0010_1001;
            Console.WriteLine(Binary);

        }
    }
}