using System;

namespace InterviewTest
{
    public class Order
    {
        public OrderCategory Category { get; private set; }
        public Decimal Price { get; private set; }
        public string ItemName { get; private set; }

        public Order(string itemName, OrderCategory category, decimal price)
        {
            Category = category;
            Price = price;
            ItemName = itemName;
        }
    }
}
