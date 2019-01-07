namespace Seldino.Application.Command.BannerHandler
{
    internal sealed class BannerCommandMessage
    {
        public const string BannerCreatedSuccessfully = "بنر با موفقیت درج گردید";
        public const string BannerCreationFaild = "ایجاد بنر با خطا مواجه شد";

        public const string BannerEditedSuccessfully = "بنر با موفقیت ویرایش گردید";
        public const string BannerEditionFaild = "ویرایش بنر با خطا مواجه شد";

        public const string BannerDeletedSuccessfully = "حذف بنر با موفقیت انجام شد";
        public const string BannerDeletionFailed = "حذف بنر با خطا مواجه شد";

        public const string BannerActivatedSuccssfully = "بنر با موفقیت فعال شد ";
        public const string BannerActivationFaild = "فعال سازی بنر با خطا مواجه شد";

        public const string BannerDeactivatedSuccssfully = "بنر با موفقیت غیرفعال شد ";
        public const string BannerDeactivationFaild = "غیر فعال کردن بنر با خطا مواجه شد";

        public const string BannerConfirmedSuccessfully = "بنر با موفقیت تایید شد";
        public const string BannerConfirmationFaild = "تایید بنر با خطلا مواجه شد";
    }

    internal sealed class BannerValidationMessage
    {
        public const string StartDateIsRequired = "تاریخ شروع بنر الزامی است";
        public const string EndDateIsRequired = "تاریخ خاتمه بنر الزامی است";
        public const string FeeDateIsRequired = "هزینه مربوط به بنر الزامی است";
        public const string BannerDateIsRequired = "انتخاب نوع بنر الزامی است";
    }
}
