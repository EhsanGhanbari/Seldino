namespace Seldino.Application.Command.ProductHandler
{
    #region ProductCommand
    internal sealed class ProductCommandMessage
    {

        #region Create Product

        public const string ProductCreatedSuccessfully = "ایجاد محصول با موفقیت انجام شد";
        public const string ProductCreationFailed = "ایجاد محصول با خطا مواجه شد";

        #endregion

        #region Delete Product

        public const string ProductDeletedSuccessufully = "حذف محصول با موفقیت انجام شد";
        public const string ProductDeletionFailed = "حذف محصول با خطا مواجه شد";
        public const string ProductsDeletedSuccessufully = "حذف محصولات با موفقیت انجام شد";
        public const string ProductsDeletionFailed = "حذف محصولات با خطا مواجه شد";

        #endregion

        #region Edit Product

        public const string ProductEditedSuccessfully = "ویرایش محصول با موفقیت انجام شد";
        public const string ProductEditionFailed = "ویرایش محصول با خطا مواجه شد";


        #endregion

        #region Deactive Product

        public const string ProductDeactivatedSuccessfully = "محصول با موفقیت غیر فعال شد";
        public const string ProductDeactivationFailed = "غیر فعال کردن محصول با خطا مواجه شد";

        #endregion

        #region Activate Product

        public const string ProductActivatedSuccessfully = "محصول با موفقیت فعال شد";
        public const string ProductActivationFailed = "فعال سازی محصول با خطا مواجه شد";

        #endregion

        #region Delete ProductCategory

        public const string ProductCategoryDeletedSuccessufully = "حذف گروه محصول با موفقیت انجام شد";
        public const string ProductCategoryDeletionFailed = "حذف گروه محصول با خطا مواجه شد";
        public const string ProductCategoryCreationFailed = "ایجاد گروه محصول  با خطا مواجه گردید";

        #endregion

        #region Delete ProductBrand

        public const string ProductBrandDeletedSuccessufully = "حذف برند محصول با موفقیت انجام پذیرفت";
        public const string ProductBrandDeletionFailed = "حذف برند محصول با خطا مواجه شد";
        public const string ProductBrandCreationFailed = "ایجاد برند محصول با خطا مواجه گردید";

        #endregion

        #region Delete ProductTag

        public const string ProductTagDeletedSuccessufully = "حذف برچسب محصول با موفقیت انجام پذیرفت";
        public const string ProductTagDeletionFailed = "حذف برچسب محصول با خطا مواجه شد";
        public const string ProductTagCreationFailed = "ایجاد تگ محصول جدید با خطا مواجه گردید";

        #endregion

        #region Delete ProductColor

        public const string ProductColorDeletedSuccessfully = "حذف رنگ محصول با موفقیت انجام شد ";
        public const string ProductColorDeletionFaild = "حذف رنگ محصول با خطا مواجه شد";

        #endregion

        #region Delete ProductSize

        public const string ProductSizeDeletedSuccessfully = "حذف سایز محصول با موفقیت انجام شد";
        public const string ProductSizeDeletionFaild = "حذف سایز محصول با خطا مواجه شد ";
        #endregion

        #region Create ProductComment

        public const string ProductCommentCreatedSuccessufully = "کامنت با موفقیت درج گردید";
        public const string ProductCommentCreationFailed = " درج کامنت با خطا مواجه شد";

        #endregion

        #region Delete ProductComment

        public const string ProductCommentDeletedSuccessufully = "حذف کامنت با موفقیت انجام پذیرفت";
        public const string ProductCommentDeletionFailed = "حذف کامنت با خطا مواجه شد";
        public const string ProductCommentsDeletionFailed = "حذف کامنت با خطا مواجه شد";

        #endregion

        #region  ProductRating
        public const string ProductRatedSuccessufully = "محصول با موفقیت امتیاز دهی شد";
        public const string ProductRatingFaild = "امتیاز دهی محصول با خطا مواجه شد";
        public const string ProductRatingNeedToBeLoggedIn = "برای امتیاز دهی به محصول بایستی وارد سیستم شوید";
        public const string ProductNotFountForRating = "محسول مورد نظر برای امتیاز دهی یافت نشد!";
        #endregion

    }

    #endregion

    #region  ProductValidation
    internal sealed class ProductValidationMessage
    {
        public const string ProductNameIsRequired = "نام محصول اجباری است";
        public const string ProductNameIsTooLong = "عنوان محصول حداقل شامل 2 و حداکثر شامل 80 کاراکتر می تواند باشد";

        public const string ProductPriceIsRequired = "قیمت محصول اجباری است";

        public const string ProductDescriptionIsNotInRegularLenght = "توضیحات محصول حداقل بایستی شامل 10 و حداکثر شامل 200 کاراکتر باشد";

        public const string ProductPictureIsRequired = "حداکثر بایستی یک تصویر برای محصول انتخاب کنید";

        public const string ProductColorIsRequired = "رنگ های موجود برای محصول را انتخاب نمایید";
        public const string ProductColorIsNotInRegularLenght = "عنوان رنگ محصول حداقل شامل 2 و حداکثر شامل 50 کاراکتر می تواند باشد";

        public const string ProductManufacturerIsNotInRegularLenght = "نام کارخانه محصول حداقل شامل 2 و حداکثر شامل 50 کاراکتر می تواند باشد";

        public const string ProductBrandIsNotInRegularLenght = "نام برند حداقل شامل 2 کاراکتر و حداکثر شامل 50 کاراکتر می تواند باشد";

        public const string ProductTagIsNotInRegularLenght = "نام برچسب محصول حداقل شامل 2 و حداکثر شامل 50 کاراکتر می تواند باشد";
        public const string ProductTagIsRequired = "محصول بایستی حداقل زیر مجموعه یک برچسب باشد";

        public const string ProductCategoryIsNotInRegularLenght = "نام گروه محصول حداقل شامل 2 و حداکثر شامل 50 کاراکتر می تواند باشد";
        public const string ProductCategoryIsRequired = "محصول بایستی زیر مجموعه یک گروه باشد";
      
        public const string ProductSizeIsNotInRegularLenght = "نام اندازه محصول حداقل شامل 2 و حداکثر شامل 50 کاراکتر می تواند باشد";
        public const string ProductSizeIsRequired = "سایزهای موجود برای محصول را انتخاب نمایید";

        public const string ProductPriceHasIncorrectFormat = "قیمت محصول با فرمت درست وارد نشده است ";

        public const string ProductCommentBodyIsRequired = "متن کامنت اجباری است";
        public const string ProductCommentBodyIsTooLong = "متن کامنت حداکثر بایستی 150 کاراکتر باشد";
    }

    #endregion

    #region ProductException
    internal sealed class ProductExceptionMessage
    {
        public const string ProductPictureisNullOrEmpty = "محصول بایستی حداقل یک تصویر داشته باشد!";
        public const string ProductCommentOwnerIsWrong = "کاربر جاری دارنده این کامنت نیست";
        public const string ProductStoreIsNotDeterminded = "فروشگاه مورد نطر برای محصول انتخاب نشده است";
    }

    #endregion
}
