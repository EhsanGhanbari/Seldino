namespace Seldino.Application.Command.BasketHandler
{
    internal sealed class BasketCommandMessage
    {
        public const string ItemAddedToBasketSuccessfully = "محصول مورد نظر به سبد خرید اضافه شد";
        public const string AddingItemToBasketFaild = "مشکلی در اضافه نمودن محصول به سبد خرید وجود دارد";

        public const string ItemRemovedFromBasketSuccessfully = "محصول مورد نظر از سبد خرید حذف گردید";
        public const string RemovingItemFromBasketFaild = "حذف محصول از سبد خرید با خطا مواجه شد";
        
        public const string ProductDoesNotFound = "محصول مورد نظر یافت نشد";
    }

    internal sealed class BasketExceptionMessage
    {
    }
}
