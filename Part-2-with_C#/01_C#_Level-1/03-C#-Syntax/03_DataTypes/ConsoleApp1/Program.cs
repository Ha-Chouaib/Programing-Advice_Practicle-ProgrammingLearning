using System;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            //Nullable Data Type it allows you to set null to any other data type by: ( Nullable <Data Type> ...=null; )
            Nullable <int> t=null;
            Console.WriteLine("int with Nallable Data Type t= {0}",t);
            
            
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
            byte a=12;
            
            Console.WriteLine("Byte:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Byte.MaxValue, Byte.MinValue);
            //SByte......signed...............
            sbyte b= -128;
            sbyte bb=127;
            Console.WriteLine("SByte:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", SByte.MaxValue, SByte.MinValue);

            // Short......signed..............
            short sh=982;

            Console.WriteLine("Short:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Int16.MaxValue, Int16.MinValue);

            //Ushort......unsigned............
            ushort ush=13;
            Console.WriteLine("ushort:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", UInt16.MaxValue, UInt16.MinValue);

            //int.........signed..............
            int i=-1;
            int ii=1;
            Console.WriteLine("Int:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Int32.MaxValue,Int32.MinValue);

            //uint........unsigned............
            uint ui=2;
            Console.WriteLine("UInt:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", UInt32.MaxValue, UInt32.MinValue);

            //long........signed..............
            long l=3456788;
            long ll=-5678765;
            Console.WriteLine("Long:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", Int64.MaxValue, Int64.MinValue);

            //Ulong......unsigned.............
            ulong unl=98765432ul;
            Console.WriteLine("uLong:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", UInt64.MaxValue, UInt64.MinValue);

            //float.....UnSigned................
            float f=233.3f;
            Console.WriteLine("Float:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", float.MaxValue, float.MinValue);
           
            //double....UnSigned................
            double d=2307973.3d;
            Console.WriteLine("double:");
            Console.WriteLine("Max= ({0})// Min= ({1}):", double.MaxValue, double.MinValue);

            //Decimal...UnSigned................
            decimal dc=987654657890897.867m;
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