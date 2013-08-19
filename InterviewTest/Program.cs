using System;

namespace InterviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("John Black");

            customer.AddOrder(new Order("LCD", OrderCategory.Hardware, 220));
            customer.AddOrder(new Order("Mouse", OrderCategory.Hardware, 30));
            customer.AddOrder(new Order("Keyboard", OrderCategory.Hardware, 45));
            customer.AddOrder(new Order("OS", OrderCategory.Software, 90));
            customer.AddOrder(new Order("Minesweeper deluxe", OrderCategory.Software, 1200));
            customer.AddOrder(new Order("Delivery", OrderCategory.Services, 25));
            customer.AddOrder(new Order("Installation", OrderCategory.Services, 60));

            customer.AddDiscount(OrderCategory.Hardware, new PercentDiscount(10));
            customer.AddDiscount(OrderCategory.Hardware, new FixedDiscount(15));
            customer.AddDiscount(OrderCategory.Software, new PercentDiscount(20));

            var hardwareTotal = customer.GetTotalPriceByOrderCategory(OrderCategory.Hardware);
            var hardwareTotalWithDiscount = customer.GetTotalPriceWithDiscountByOrderCategory(OrderCategory.Hardware);
            var total = customer.GetTotalPriceWithDiscount();

            Console.WriteLine("Expected hardware total: {0}, actual {1}", 220 + 30 + 45, hardwareTotal);
            Console.WriteLine("Expected hardware total with discount: {0}, actual {1}", (220 + 30 + 45 - 15) * (100 - 10) / 100, hardwareTotalWithDiscount);
            Console.WriteLine("Expected total with discount: {0}, actual {1}", (220 + 30 + 45 - 15) * (100 - 10) / 100 + (90 + 1200) * (100 - 20) / 100 + 25 + 60, total);

            Console.ReadKey();
        }
    }
}
