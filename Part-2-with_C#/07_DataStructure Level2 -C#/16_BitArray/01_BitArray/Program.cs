using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_BitArray
{
    internal class Program
    {
        static string BitArrayToString(BitArray bitArr)
        {
            char[] chars = new char[bitArr.Length];
            for (int i = 0; i < bitArr.Length; i++)
            {
                chars[i] = bitArr[i] ? '1' : '0';

            }
            return new string(chars);
        }
        static void Main(string[] args)
        {
            BitArray bits1= new BitArray(10);
            Console.WriteLine($"Bits 1 Content: { BitArrayToString(bits1)}");

            for (int i = 0; i < bits1.Length; i++)          
                Console.WriteLine($"Bits at Index[{i}] => {(bool)bits1[i]}");

            //--------------
            bool[] boolVal = { true, true, false ,true,false};
            BitArray bits2= new BitArray(boolVal);
            Console.WriteLine("\nbits2 content: " + BitArrayToString(bits2));

            for (int i = 0; i < bits2.Count; i++)
                Console.WriteLine($"Bit at index {i}: {(bool)bits2[i]}");
            
            //----------------
            byte[] byteArray = { 0xAA, 0x55 }; // 10101010, 01010101
            BitArray bits3= new BitArray(byteArray);

            Console.WriteLine("\nbits3 content: " + BitArrayToString(bits3));
            for (int i = 0; i < bits3.Count; i++)
                Console.WriteLine($"Bit at index {i}: {(bool)bits3[i]}");

            //----------------
            BitArray bits4 = new BitArray(8); // 00000000

            bits4.Set(2, true);
            bits4.Set(4, true);
            bits4[6]=true;
            bits4[7]=true;

            Console.WriteLine("\nbits4 content: " + BitArrayToString(bits4));
            for (int i = 0; i < bits4.Count; i++)
                Console.WriteLine($"Bit at index {i}: {(bool)bits4[i]}");


            bits4.SetAll(true); // Set all bits to true
            Console.WriteLine("\nbits4 content after setting all to true: " + BitArrayToString(bits4));
            for (int i = 0; i < bits4.Count; i++)
                Console.WriteLine($"Bit at index {i}: {(bool)bits4[i]}");


            bits4.SetAll(false); // Set all bits to false
            Console.WriteLine("\nbits4 content after setting all to false:" + BitArrayToString(bits4));
            for (int i = 0; i < bits4.Count; i++)
                Console.WriteLine($"Bit at index {i}: {(bool)bits4[i]}");

            bool bitValue = bits4[3]; // Get the value of the bit at index 3
            int length = bits4.Length; // Get the number of bits in the BitArray

            //---------------
            // Iterating Through a BitArray
            BitArray bits5 = new BitArray(8);
            bits5.SetAll(true);

            Console.WriteLine("\nbits5 content: " + BitArrayToString(bits5));
            for (int i = 0; i < bits5.Count; i++)
                Console.WriteLine($"Bit at index {i}: {(bool)bits5[i]}");






        }
    }
}
