namespace InterviewTest
{
    public abstract class Discount
    {
        public abstract int Priority { get; }
        public abstract decimal ApplyDiscount(decimal originalAmount);
    }
}
