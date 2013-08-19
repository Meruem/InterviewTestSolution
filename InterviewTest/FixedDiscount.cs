using System;

namespace InterviewTest
{
    public class FixedDiscount : Discount
    {
        private readonly decimal _amount;

        public FixedDiscount(decimal amount)
        {
            _amount = amount;
        }

        public override int Priority
        {
            get { return 1; }
        }

        public override decimal ApplyDiscount(decimal originalAmount)
        {
            return Math.Max(0, originalAmount - _amount);
        }
    }
}
