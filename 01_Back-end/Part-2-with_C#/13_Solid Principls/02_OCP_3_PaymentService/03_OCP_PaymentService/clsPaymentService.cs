using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OCP_PaymentService
{
    public  class clsPaymentService
    {
        IPaymentService paymentService;
        public clsPaymentService(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        public void ProcessPayment(decimal amount)
        {
            paymentService.Pay(amount);
        }
    }
}
