using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OCP_PaymentService
{
    internal class clsPayPalService : IPaymentService
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paying {amount}$ using PayPal.");
        }
    }
}
