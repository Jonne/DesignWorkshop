using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Coupling
{
    class Program
    {
        public class LineItem
        {
            public decimal Price { get; set; }
            public decimal Amount { get; set; }
        }

        public class Order
        {
            public IEnumerable<LineItem> Items { get; set; }
        }
        
        public class OrderTotalCalculator
        {
            public decimal Calculate(Order order)
            {
                decimal total = 0;

                foreach(LineItem item in order.Items)
                {
                    decimal itemTotal = item.Price * item.Amount;

                    total += itemTotal;
                }

                return total;
            }
        }

        static void Main(string[] args)
        {
            var order = new Order
            {
                Items = new List<LineItem>{
                    new LineItem{
                        Price = 2.44m,
                        Amount = 11
                    },
                    new LineItem{
                        Price = 444m,
                        Amount = 11
                    },
                    new LineItem{
                        Price = 0.99m,
                        Amount = 4
                    }
                }
            };
            
            var calculator = new OrderTotalCalculator();
            decimal total = calculator.Calculate(order);

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }
}
