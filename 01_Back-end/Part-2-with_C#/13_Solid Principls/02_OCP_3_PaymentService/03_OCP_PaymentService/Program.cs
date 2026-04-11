namespace _03_OCP_PaymentService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsPaymentService paymentService = new clsPaymentService(new clsCriditCardService());
            paymentService.ProcessPayment(891.03m);
           
            paymentService = new clsPaymentService(new clsPayPalService());
            paymentService.ProcessPayment(100.50m);

            paymentService = new clsPaymentService(new clsBankTransferService());
            paymentService.ProcessPayment(10.00m);

            paymentService = new clsPaymentService(new clsBitcoinService());
            paymentService.ProcessPayment(15.00m);

            Console.ReadLine();
        }
    }
}
