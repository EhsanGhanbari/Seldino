using System;
using Seldino.CrossCutting.Enums;

namespace Seldino.Application.Query.DiscountService
{
    public class DiscountDto
    {
        public Guid DiscountId { get; set; }

        public string Name { get; set; }

        public decimal Percentage { get; set; }

        public decimal Amount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool Stopped { get; set; }

        public DiscountLimitation DiscountLimitation { get; set; }

        public DiscountType DiscountType { get; set; }
    }
}
