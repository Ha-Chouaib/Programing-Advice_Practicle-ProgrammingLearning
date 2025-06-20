using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOrderEvent
{
    public class OrderEventArgs: EventArgs
    {
        public int OrderID { get; }
        public int OrderTotalPrice { get; }
        public string ClientEmail { get; }

        public OrderEventArgs(int OrderID, int OrderTotalPrice, string ClientEmail)
        {
            this.OrderID = OrderID;
            this.OrderTotalPrice = OrderTotalPrice;
            this.ClientEmail = ClientEmail;
        }
    }

    public class Order
    {
        public event EventHandler <OrderEventArgs> OnOrderSelected;
        
        public void Create(int OrderID, int OrderTotalPrice, string ClientEmail)
        {

            if(OnOrderSelected != null) OnOrderSelected(this,new OrderEventArgs(OrderID,OrderTotalPrice, ClientEmail));
        }
    }

    public class EmailService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderSelected += HandleNewOrder;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderSelected -= HandleNewOrder;
        }

        private void HandleNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"---------------------Email Service---------------------");
            Console.WriteLine($"Order ID:  << {e.OrderID} >>");
            Console.WriteLine($"Order Total Price:  << {e.OrderTotalPrice} >>");
            Console.WriteLine($"Clinet Email:  << {e.ClientEmail} >>");
            Console.WriteLine($"------------------------------------------\n");
        }
    }

    public class SMSService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderSelected += HandleNewOrder;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderSelected -= HandleNewOrder;
        }

        private void HandleNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"---------------------SMS Service---------------------");
            Console.WriteLine($"Order ID:  << {e.OrderID} >>");
            Console.WriteLine($"Order Total Price:  << {e.OrderTotalPrice} >>");
            Console.WriteLine($"Clinet Email:  << {e.ClientEmail} >>");
            Console.WriteLine($"------------------------------------------\n");
        }
    }

    public class ShippingService
    {
        public void Subscribe(Order order)
        {
            order.OnOrderSelected += HandleNewOrder;
        }
        public void UnSubscribe(Order order)
        {
            order.OnOrderSelected -= HandleNewOrder;
        }

        private void HandleNewOrder(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"---------------------Shipping Service---------------------");
            Console.WriteLine($"Order ID:  << {e.OrderID} >>");
            Console.WriteLine($"Order Total Price:  << {e.OrderTotalPrice} >>");
            Console.WriteLine($"Clinet Email:  << {e.ClientEmail} >>");
            Console.WriteLine($"------------------------------------------");
        }
    }



    public class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            ShippingService shippingService = new ShippingService();

            emailService.Subscribe(order);
            shippingService.Subscribe(order);

            order.Create(1, 99, "Chouaib@gmail.Com");

            smsService.Subscribe(order);
            shippingService.UnSubscribe(order);

            order.Create(2, 999, "Hanry@gmail.Com");
        }
    }
}
