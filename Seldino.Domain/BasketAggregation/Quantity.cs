using System;

namespace Seldino.Domain.BasketAggregation
{
    public class Quantity
    {
        public Quantity()
        {
        }

        public Quantity(int value)
        {
            ValidationCheck.IsGreaterThan(-1, value, () => { throw new ArgumentOutOfRangeException(); });
            Value = value;
        }

        public int Value { get; private set; }

        public Quantity Add(Quantity quantity)
        {
            return new Quantity(Value + quantity.Value);
        }

        public bool IsZero()
        {
            return Value == 0;
        }
    }
}
