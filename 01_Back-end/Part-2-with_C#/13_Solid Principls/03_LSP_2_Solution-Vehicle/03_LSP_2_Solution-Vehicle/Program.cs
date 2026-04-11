namespace _03_LSP_2_Solution_Vehicle
{
    public class Vehicle
    {
        public virtual void Drive()
        {
            Console.WriteLine("Driving...");
        }

    }

    public class EngineVehivle : Vehicle
    {
        public virtual void StartEngine()
        {
            Console.WriteLine("Starting engine...");
        }
    }
    public class Car : EngineVehivle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started...");
        }

        public override void Drive()
        {
            Console.WriteLine("Car is driving...");
        }
    }

    public class Bicycle : Vehicle
    {
      
        public override void Drive()
        {
            Console.WriteLine("Bicycle is riding...");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            EngineVehivle vehicle1 = new Car();
            vehicle1.StartEngine();
            vehicle1.Drive();

            Vehicle vehicle2 = new Bicycle();
          
            vehicle2.Drive();        // Behaves as expected for a bicycle.
        }
    }

}
