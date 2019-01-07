namespace Seldino.Application.Command.OrderHandler
{
    #region OrderCommand
    internal sealed class OrderCommandMessage 
    {
        #region General
        public const string InvalidDataEntered = "اطلاعات وارد شده صحیح نیست";
        #endregion

        #region Create Oreder

        public const string OrderCreatedSuccessfully = "ایجاد سفارش با موفقیت انجام شد";
        public const string OrderCreationFailed = "ایجاد سفارش  با خطا مواجه شد";

        #endregion

        #region Cancel Order

        public const string OrderCanceledSuccessfully = "سفارش شما با موفقیت لغو شد";
        public const string OrderCancellationFailed = "لغو سقارش با خطا مواجه شد";

        #endregion

        #region Edit Order

        public const string OrderEditedSuccessfully = "ویرایش محتوای سفارش با موفقیت انجام شد";
        public const string OrderEditionFailed = "ویرایش محتوای سفارش  با خطا مواجه شد";

        #endregion

        #region Delete Order

        public const string OrderDeletedSuccessfully = "حذف سفارش با موفقیت صورت گرفت";
        public const string OrderDeletionFailed = "حذف سفارش با با خطا مواجه شد، لطفا لحظاتی بعد دوباره تلاش کنید";

        #endregion

    }
    #endregion

    #region OrderException
    internal sealed class OrderExceptionMessage 
    {
        public const string OrderOperationHasBeenCompleted = "عملیات مریوط به تهیه سفارش این محصول انجام شده و امکان لغو یا حذف آن وجود ندارد";
    }
    #endregion
}
