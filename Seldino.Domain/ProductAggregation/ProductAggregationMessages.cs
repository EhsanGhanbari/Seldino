
namespace Seldino.Domain.ProductAggregation
{
    internal sealed class ProductBusinessRuleMessages
    {
        public const string EndDateMustBeGreaterThanStartDate = "تاریخ پایان بایستی جلوتر از تاریخ شروع باشد";
        public const string CategoryIsRequired = "گروه اجباری است";
        public const string Category = "گروه";
        public const string Date = "تاریخ";
        public const string Store = "فروشگاه";
        public const string StoreIsRequired = "محصول بایستی مربوط به یک فروشگاه باشد";
        public const string Picture = "تصویر";
        public const string PictureIsRequired = "محصول بایستی حداقل یک تصویر داشته باشد";
        public const string User = "کاربر ";
        public const string UserIsRequired = "محصول بایستی به یک کاربر انتساب داده شود";

    }
}
