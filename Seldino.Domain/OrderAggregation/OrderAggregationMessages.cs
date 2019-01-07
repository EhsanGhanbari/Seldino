namespace Seldino.Domain.OrderAggregation
{
    internal sealed class OrderBusinessRulesMessages
    {
        public const string ProductHasBeenDeleted = "این محصول حذف شده است و امکان سفارش آن وجود ندارد";
        public const string OrderHasBeeenSubmited = "این سفارش قبلا ثبت شده است و امکان ثبت دوباره آن مقدور نیست";
        public const string PaymentIsNotValid = " ({2}) پرداخت معتبر نیست. جمع مبلغ پرداخت ({0}) برای معادل است با ({1}). شناسه پرداخت";
        public const string PaymentHasBeenPaid = " ({2}) پرداخت قبلا انجام شده است. مبلغ ({0}) در تاریخ ({1}) با شناسه پرداخت";
        public const string CanNotAddItemToOrder = "افزودن محصول به سفارش در حالت ({0}) وجود ندارد";
        public const string ShippingServiceIsRequiredForOrder = "سفارش بایستی سرویس ارسال داشته باشد";
        public const string OrderMustHaveAnItem = "سفارش بایستی یک محصول داشته باشد";
        public const string OrderMustHaveDeliveryAddress = "سفارش بایستی یک آدرس معتبر داشته باشد";
        public const string OrderMustAssociatedWithCustomer = "سفارش بایستی متعلق به یک مشتری باشد";
        public const string OrderMustAssociatedWithProduct = "سفارش بایستی یک محصول داشته باشد";
        public const string OrderMustHaveACreationDate = "سفارش بایستی تاریخ دقیق داشته باشد";
        public const string OrderMustHaveNonNegativePrice = "سفارش بایستی دارای مقداری مثبت برای سفارش داشته باشد";
    }

    internal sealed class OrderEventMessages
    {

    }
}
