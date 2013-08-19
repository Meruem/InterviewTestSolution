namespace InterviewTest
{
    public interface ICustomer
    {
        void AddDiscount(OrderCategory category, Discount discount);
        void AddOrder(Order order);
        decimal GetTotalPriceByOrderCategory(OrderCategory category);
        decimal GetTotalPriceWithDiscountByOrderCategory(OrderCategory category);
        decimal GetTotalPriceWithDiscount();
    }
}
