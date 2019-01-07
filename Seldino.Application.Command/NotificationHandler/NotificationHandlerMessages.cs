namespace Seldino.Application.Command.NotificationHandler
{
    #region Notification Command
    internal sealed class NotificationCommandMessage
    {
        #region Notification

        public const string NotificationCreatedSuccessfully = "ایجاد اعلان با موفقیت انجام شد";
        public const string NotifactionCreationFaild = "ایجاد اعلان با خطا مواجه شد";
        public const string NotifcationEditedSuccessfully = "اعلان با موفقیت ویرایش گردید";
        public const string NotificationEditionFaild = "ویرایش اعلان با خطا مواجه گردید";
        public const string NotificationDeletionFailed = "حذف اعلان با خطا مواجه شد";
        public const string NotificationDeletedSuccessufully = "حذف پیغام با موفقیت انجام شد";
        public const string NotificationTerminatedSuccessfully = "اعلان با موفقیت خاتمه یافت";
        public const string NotificationTerminationFaild = "خاتمه اعلان با خطا مواجه شد";

        #endregion

        #region Message
        public const string MessageCreatedSuccessfully = "پیغام با موفقیت ارسال شد";
        public const string MessageCreationFailed = "ارسال پیغام با خطا مواجه شد";
        public const string MessageDeletedSuccessufully = "حذف پیغام با موفقیت انجام شد";
        public const string MessageDeletionFailed = "حذف پیغام با خطا مواجه شد";
        public const string MessagesDeletedSuccessufully = "حذف پیغام با موفقیت انجام شد";
        public const string MessagesDeletionFailed = "حذف پیغام ها با خطا مواجه شد";
        public const string MessageResponseCreatedSuccessfully = "پیغام با موفقیت ارسال شد";
        public const string MessageResponseCreationFailed = "ارسال پیغام با خطا مواجه شد";
        public const string MessageResponseDeletedSuccessufully = "حذف پیغام با موفقیت انجام شد";
        public const string MessageResponseDeletionFailed = "حذف پیغام با خطا مواجه شد";
        public const string MessageRsponsesDeletedSuccessufully = "حذف پیغام با موفقیت انجام شد";
        public const string MessageResponsesDeletionFailed = "حذف پیغام با خطا مواجه شد";
        #endregion

        #region Newsletter

        public const string EmailAddedToNewslettersuccessfully = "ایمیل شما با موفقیت در خبرنامه وارد شد";
        public const string AddingEmailToNewsletterFaild = "وارد شدن ایمیل شما در خبرنامه با خطا مواجه شد";
        public const string EmailRemovedFromNewslettersuccessfully = "ایمیل شما از لیست خبر نامه حذف شد";
        public const string RemovingEmailFromNewsletterFaild = "حذف ایمیل از خبرنامه با خطا مواجه شد";

        #endregion
    }
    #endregion

    #region Notification Validation

    internal sealed class NotificationValidationMessage
    {
        public const string MesssageTitleIsEmpty = "عنوان متن خالی می باشد";
        public const string MesssageIsNotInRegularLenght = "عنوان متن حداکثر می تواند 100 کاراکتر داشته باشد";

        public const string NameIsNotInRegularForm = "نام وارد شده طولانی است!";
        public const string EmailIsRequired = "ایمیل اجباری است";
        public const string EmailFormatIsIncorrect = "فرمت ایمیل صحیح نمی باشد";

        public const string MessageBodyIsRquired = "متن پیغام خالی است";
        public const string MessageBodyIsNotInReqularLenght = "متن پیغام حداکثر می تواند 500 کاراکتر داشته باشد";
    }
    #endregion

    #region Notification Exception

    internal sealed class NotificationExceptionMessage
    {
        public const string EmailIsAlreadyInNewsletter = "ایمیل مورد نظر شما در لیست خبر نامه موجود است";
        public const string EmailIsNotExist = "ایمیل مورد نظر شما در خبر نامه موجود نیست";
    }
    #endregion
}
