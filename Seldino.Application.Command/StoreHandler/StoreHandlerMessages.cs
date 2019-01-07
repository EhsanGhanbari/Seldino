
namespace Seldino.Application.Command.StoreHandler
{
    internal sealed class StoreCommandMessage
    {

        #region Create Store
        public const string StoreCreatedSuccessfully = "ایجاد فروشگاه با موفقیت انجام شد";
        public const string StoreCreationFailed = "ایجاد فروشگاه با خطا مواجه شد";
        #endregion

        #region Edit Store
        public const string StoreEditedSuccessfully = "محتوای فروشگاه با موفقیت ویرایش گردید";
        public const string StoreEditionFailed = "ویرایش محتوای فروشگاه با خطا مواجه گردید";
        #endregion

        #region Deactive Store
        public const string StoreDeactivatedSuccessfully = "فروشگاه غیر فعال شد";
        public const string StoreDeactivationFailed = "اشکالی در روند غیر فعال نمودن فروشگاه بوجود آمد، لطفا بعدا تلاش کنید";
        #endregion

        #region Deactive Store
        public const string StoreActivatedSuccessfully = "فروشگاه فعال شد";
        public const string StoreActivationFailed = "اشکالی در روند فعال نمودن فروشگاه بوجود آمد، لطفا بعدا تلاش کنید";
        #endregion

        #region Delete Store
        public const string StoreDeletedSuccessfully = "فروشگاه حذف شد!";
        public const string StoreDeletionFailed = "اشکالی در روند حذف فروشگاه بوجود آمد، لطفا بعدا تلاش کنید";

        #endregion

        #region

        public const string CommentCreatedSuccessfully = "کامنت با موفقیت درج گردید";
        public const string CommentCreationFaild = "ایجاد کامنت با خطا مواجه شد";
        public const string CommentDeletedSuccessfully = "حذف کامنت با موفقیت انجام شد";
        public const string CommentDeletionFaild = "حذف کامنت با خطا مواجه شد";

        #endregion
    }

    internal sealed class StoreValidationMessage
    {
        public const string StoreNameIsRequired = "نام فروشگاه الزامی است";
        public const string StorePhoneIsIncorrect = "شماره تلفن با فرمت نادرست وارد شده است";
    }

    internal sealed class StoreWxceptionMessage
    {
        public const string StorePictureIsRequired = "فروشگا بایستی حداقل یک تصویر داشته باشد";
    }
}
