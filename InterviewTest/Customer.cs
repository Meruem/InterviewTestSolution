using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace InterviewTest
{
    public class Customer : ICustomer
    {
        private readonly Dictionary<OrderCategory, IList<Discount>> _discounts;
        private readonly Dictionary<OrderCategory, IList<Order>> _orders; 

        public string Name { get; private set; }

        public Customer(string name)
        {
            _discounts = new Dictionary<OrderCategory, IList<Discount>>();
            _orders = new Dictionary<OrderCategory, IList<Order>>();
            Name = name;
        }

        public void AddDiscount(OrderCategory category, Discount discount)
        {
            Contract.Assert(discount != null);

            if (!_discounts.ContainsKey(category))
            {
                _discounts[category] = new List<Discount>();
            }

            _discounts[category].Add(discount);
        }

        public void AddOrder(Order order)
        {
            Contract.Assert(order != null);

            if (!_orders.ContainsKey(order.Category))
            {
                _orders[order.Category] = new List<Order>();
            }

            _orders[order.Category].Add(order);
        }

        public decimal GetTotalPriceByOrderCategory(OrderCategory category)
        {
            if (!_orders.ContainsKey(category)) return 0;
            return _orders[category].Sum(c => c.Price);
        }

        public decimal GetTotalPriceWithDiscountByOrderCategory(OrderCategory category)
        {
            var amount = GetTotalPriceByOrderCategory(category);
            if (!_discounts.ContainsKey(category)) return amount;
            foreach (var discount in _discounts[category].OrderBy(d => d.Priority))
            {
                amount = discount.ApplyDiscount(amount);
            }

            return amount;
        }

        public decimal GetTotalPriceWithDiscount()
        {
            return _orders.Keys.Sum(k => GetTotalPriceWithDiscountByOrderCategory(k));
        }
    }
}
