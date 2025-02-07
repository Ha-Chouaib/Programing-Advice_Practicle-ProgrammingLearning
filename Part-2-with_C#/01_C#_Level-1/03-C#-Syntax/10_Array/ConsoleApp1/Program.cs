using System;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creat Array
            int[] nums={1,2,3};

            //Access Elements
            Console.WriteLine(nums[0]);
            Console.WriteLine(nums[1]);
            Console.WriteLine(nums[2]);

            // You Can Not Access out of Range Value like:
            //nums[4] or even append one like: nums[4]=3;

            // You can also declare array ether by:
            //int[] arr1;
            //or int[] arr2=new int[set a Length]
            //or arr1=new int[Length];

            //--------- Initialization----------//
            int[] arr={1,2,3,4,4};
            int[] arr1=new int[3];
            arr1[0]=1;
            arr1[1]=2;
            arr1[2]=3;
            //--------- Tow Dimensional array-----//
            // You can Do
            int[,] Matrix={{1,2,3},{4,5,6}};
            //or
            int [,] Mat=new int[2,3];
            Mat[0,0]=1;
            Mat[0,1]=2;
            Mat[0,2]=3;
            Mat[1,0]=4;
            Mat[1,1]=5;
            Mat[1,2]=6;

            //----------------For Each loop---------//
            foreach (int a in  arr)
            {
                Console.WriteLine(a);
            }

            

        }
    }
}