namespace _04_ISP_2_Solution_Payament
{
   
    public interface ICreditCardPayment
    {
        void PayWithCreditCard();
    }

    public interface IPayPalPayment
    {
        void PayWithPayPal();
    }

    public interface IBitcoinPayment 
    {
        void PayWithBitcoin();
    }

    public class CreditCardPayment : ICreditCardPayment
    {
        public void PayWithCreditCard()
        {
            Console.WriteLine("Payment with credit card.");
        }

      
    }

    public class PayPalPayment : IPayPalPayment
    {
      
        public void PayWithPayPal()
        {
            Console.WriteLine("Payment with PayPal.");
        }

     
    }

    public class BitcoinPayment : IBitcoinPayment
    {
        public void PayWithBitcoin()
        {
            Console.WriteLine("Payment with Bitcoin.");
        }

    }
    public class Program
    {
        public static void Main()
        {
            CreditCardPayment creditCardPayment = new CreditCardPayment();
            creditCardPayment.PayWithCreditCard();
           
            PayPalPayment payPalPayment = new PayPalPayment();
            payPalPayment.PayWithPayPal();
            
            BitcoinPayment bitcoinPayment = new BitcoinPayment();
            bitcoinPayment.PayWithBitcoin();

            Console.ReadKey();

        }
    }

}
