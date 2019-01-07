using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BannerAggregation
{
    public class BannerBusinessRule
    {
        public static readonly BusinessRule StartDate = new BusinessRule("StartDate", BusinessRuleMessage.StartDate);
    }
}
