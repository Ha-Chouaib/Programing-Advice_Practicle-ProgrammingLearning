namespace _04_ISP_3_Solution_Device
{
   
    public interface ICallDevice
    {
        void MakeCall();
    }
    public interface IPhotoDevice
    {
        void TakePhoto();
    }
    public interface IEmailDevice
    {
        void SendEmail();
    }
    public interface IGPSDevice
    {
        void UseGPS();
    }
    public interface ISmartPhoneDevice : ICallDevice, IPhotoDevice, IEmailDevice, IGPSDevice{}
    public class Smartphone : ISmartPhoneDevice
    {
        public void MakeCall()
        {
            Console.WriteLine("Making a call.");
        }

        public void TakePhoto()
        {
            Console.WriteLine("Taking Photo.");
        }

        public void SendEmail()
        {
            Console.WriteLine("Sending an email.");
        }

        public void UseGPS()
        {
            Console.WriteLine("Using GPS.");
        }
    }

    public class Computer : IEmailDevice
    {
       
        public void SendEmail()
        {
            Console.WriteLine("Sending an email.");
        }

    }

    public class Program
    {
        public static void Main()
        {
            Smartphone smartphone = new Smartphone();
            Console.WriteLine("SmartPhone:");
            smartphone.MakeCall();
            smartphone.TakePhoto();
            smartphone.SendEmail();
            smartphone.UseGPS();

            IEmailDevice computer = new Computer();
            Console.WriteLine("\nComputer:");
            computer.SendEmail();
            

            Console.ReadKey();


        }
    }

}
