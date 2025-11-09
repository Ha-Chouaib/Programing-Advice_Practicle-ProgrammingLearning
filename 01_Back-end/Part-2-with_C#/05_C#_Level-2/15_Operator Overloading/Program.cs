using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Operator_Overloading
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point( int x ,int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point P1,Point P2)
        {
            return new Point(P1.X + P2.X, P1.Y + P2.Y);
        }

        public static Point operator -(Point P1, Point P2)
        {
            return new Point(P1.X - P2.X, P1.Y - P2.Y);
        }

        public static bool operator == (Point P1, Point P2)
        {
            return (P1.X == P2.X) && (P1.Y == P2.Y);
        }
        public static bool operator !=(Point P1, Point P2)
        {
            return (P1.X != P2.X) || (P1.Y != P2.Y);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 2);
            Point point2 = new Point(3, 4);

            Point point3 = point1 + point2; //Using The Overload '+' operator for point Addition
            Point point4 = point1 - point2; //Using The Overload '-' operator for point Substraction

            Console.WriteLine($"Point1: {point1.ToString()}");
            Console.WriteLine($"Point2: {point2.ToString()}");

            Console.WriteLine($"Point3 = Point1 + Point2: {point3.ToString()}");
            Console.WriteLine($"Point4 = Point1 - Point2: {point4.ToString()}");

            if (point1 == point2)
                Console.WriteLine("Using ==: Yes, Point1 = point2");
            else
                Console.WriteLine("Using ==: No, Point1 Does not equal point2");

            if (point1 != point2)
                Console.WriteLine("Using !=: No, Point1 Does not equal point2");
            else
                Console.WriteLine("Using !=: Yes, Point1 = point2");
        }
    }
}
