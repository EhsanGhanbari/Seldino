
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation
{
    public class ProductBusinessRule
    {
        public static readonly BusinessRule EndDateMustBeGreaterThanStartDate = new BusinessRule(ProductBusinessRuleMessages.Date, ProductBusinessRuleMessages.EndDateMustBeGreaterThanStartDate);
        public static readonly BusinessRule CategoryIsRequired = new BusinessRule(ProductBusinessRuleMessages.Category, ProductBusinessRuleMessages.CategoryIsRequired);
        public static readonly BusinessRule StoreIsRequired = new BusinessRule(ProductBusinessRuleMessages.Store, ProductBusinessRuleMessages.CategoryIsRequired);
        public static readonly BusinessRule PictureIsRequired = new BusinessRule(ProductBusinessRuleMessages.Picture, ProductBusinessRuleMessages.PictureIsRequired);
        public static readonly BusinessRule UserIsRequired = new BusinessRule(ProductBusinessRuleMessages.User, ProductBusinessRuleMessages.UserIsRequired);
    }
}
