using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductSpecialState : EntityBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }


        protected override void Validate()
        {
            if (StartDate >= EndDate)
                AddBrokenRule(ProductBusinessRule.EndDateMustBeGreaterThanStartDate);
        }
    }
}
