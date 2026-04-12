namespace _04_ISP_1_Solution_Printer
{
    public interface IPrint
    {
        void Print(string content);
    }
    public interface IScanner
    {
        void Scan();
    }
    public interface IFax
    {
        void Fax();
    }
    public class BasicPrinter : IPrint
    {
        public void Print(string content)
        {
            Console.WriteLine($"Printing: {content}");
        }

      
    }


    public class AdvancedPrinter : IPrint, IScanner, IFax
    {
        public void Print(string content)
        {
            Console.WriteLine($"Printing: {content}");
        }

        public void Scan()
        {
            Console.WriteLine($"Scanning..");
        }

        public void Fax()
        {
            Console.WriteLine($"Faxing...");
        }
    }

    public class Program
    {
        public static void Main()
        {
            IPrint basicPrinter = new BasicPrinter();
            basicPrinter.Print("Hi, My Name is Hadadi");
          

            AdvancedPrinter advancedPrinter = new AdvancedPrinter();
            advancedPrinter.Print("Hi, My Name is Hadadi");
            advancedPrinter.Scan();
            advancedPrinter.Fax();

            Console.ReadKey();

        }
    }

}
