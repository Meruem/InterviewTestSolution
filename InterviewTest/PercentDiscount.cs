using System.Diagnostics.Contracts;

namespace InterviewTest
{
    public class PercentDiscount : Discount
    {
        private readonly decimal _value;

        public PercentDiscount(decimal percentValue)
        {
            Contract.Requires(percentValue >= 0 && percentValue < 100);
            _value = percentValue;
        }

        public override int Priority
        {
            get { return 5; }
        }

        public override decimal ApplyDiscount(decimal originalAmount)
        {
            return originalAmount*(1 - _value/100);
        }
    }
}
