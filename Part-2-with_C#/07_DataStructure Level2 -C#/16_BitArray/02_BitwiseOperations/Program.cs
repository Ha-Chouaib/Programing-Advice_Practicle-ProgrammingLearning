﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BitwiseOperations
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

            // Create two BitArrays
            BitArray bits1 = new BitArray(new bool[] { true, false, true, false });
            BitArray bits2 = new BitArray(new bool[] { true, true, true, false });


            Console.WriteLine("bits1 : " + BitArrayToString(bits1));
            Console.WriteLine("bits2 : " + BitArrayToString(bits2));
            Console.WriteLine("BitWise Operators:");


            // Bitwise AND operation
            BitArray resultAnd = new BitArray(bits1);
            resultAnd.And(bits2);


            Console.WriteLine("\nBitwise AND result: ");
            Console.WriteLine(BitArrayToString(bits1));
            Console.WriteLine(BitArrayToString(bits2));
            Console.WriteLine("------------");
            Console.WriteLine(BitArrayToString(resultAnd));

            // Bitwise Or operation

            BitArray resultOr = new BitArray(bits1);
            resultOr.Or(bits2);


            Console.WriteLine("\nBitwise Or result: ");
            Console.WriteLine(BitArrayToString(bits1));
            Console.WriteLine(BitArrayToString(bits2));
            Console.WriteLine("------------");
            Console.WriteLine(BitArrayToString(resultOr));

            // Bitwise Not operation
            BitArray resultNot = new BitArray(bits1);
            resultNot.Not();

            Console.WriteLine("\nBitwise Not result: ");
            Console.WriteLine(BitArrayToString(bits1));
            Console.WriteLine("------------");
            Console.WriteLine(BitArrayToString(resultNot));

            // Bitwise Xor operation
            /*
             Explaining the XOR:
             XOR Table: returns true of the two bits are diffrent, otherwise returns false.

                | A | B | A XOR B |
                |---|---|---------|
                | 0 | 0 |    0    |
                | 0 | 1 |    1    |
                | 1 | 0 |    1    |
                | 1 | 1 |    0    |
             */
            BitArray resultXor = new BitArray(bits1);
            resultXor.Xor(bits2);


            Console.WriteLine("\nBitwise Xor result: ");
            Console.WriteLine(BitArrayToString(bits1));
            Console.WriteLine(BitArrayToString(bits2));
            Console.WriteLine("------------");
            Console.WriteLine(BitArrayToString(resultXor));

            Console.ReadKey();
        }
    }
}
