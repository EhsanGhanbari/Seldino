namespace Seldino.Application.Command.DiscountHandler
{

    internal sealed class DiscountCommandMessage
    {

        #region Create Discount
        public const string DiscountCreatedSuccessfully = "تخفیف با موفقیت ایجاد شد";
        public const string DiscountCreationFailed = "ایجاد تخفیف با خطا مواجه شد";

        #endregion

        #region Edit Discount
        public const string DiscountEditedSuccessfully = "تخفیف با موفقیت ویرایش شد";
        public const string DiscountEditionFailed = "ویرایش تخفیف با خطا مواجه شد";
        #endregion

        #region Start Discount

        public const string StartDiscountCreatedSuccessfully = "اعمال تخفیف با موفقیت شروع شد";
        public const string StartDiscountCreationFailed = "اعمال تخفیف با خطا مواجه شد";
        public const string DiscountAlreadyStarted = "تخفیف مورد نظر هم اکنون فعال است";
        #endregion

        #region Stop Discount

        public const string StopDiscountCreatedSuccessfully = "تخفیف مورد نظر با موفقیت خاتمه یافت";
        public const string StopDiscountCreationFailed = "پایان تخفیف مورد نظر با خطا مواجه شد";
        public const string DiscountAlreadyStoped = "تخفیف مورد نظر هم اکنون غیرفعال است";

        #endregion

        #region Delete Discount

        public const string DiscountDeletedSuccessfully = "تخفیف مورد نظر حذف گردید";
        public const string DiscountDeletionFailed = "حذف کردن تخفیف مورد نظر با خطا مواجه شد";

        #endregion
    }

    internal sealed class DiscountValidationMessage
    {
        public const string DiscountTemplateNameIsRequired = "لطفا یک نام برای قالب تخفیف خود وارد نمایید";
    }

    internal sealed class DiscountExceptionMessage
    {
    }
}
