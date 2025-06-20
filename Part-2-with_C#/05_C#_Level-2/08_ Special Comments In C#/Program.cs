using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08__Special_Comments_In_C_
{
    /// <summary>
    /// This class represent a simple calculator
    /// </summary>

    public class Calculator
    {
        /// <summary>
        /// Adds Two Numbers and returns The Result
        /// </summary>
        /// <param name="a">The First Number to be Added.</param>
        /// <param name="b">The Second Number to be Added.</param>
        /// <returns>the Sum Of Two Numbers.</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Substructs The Second number from The first Number and returns the result
        /// </summary>
        /// <param name="a">The Number which to substruct.</param>
        /// <param name="b">The Number To Substruct.</param>
        /// <returns>The Result Of Substructing The Second number from the First one</returns>
        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Add(1, 2); // put the Mouse Over The Function to See Its Description
            calculator.Sub(1, 2); // put the Mouse Over The Function to See Its Description
        }
    }
}
