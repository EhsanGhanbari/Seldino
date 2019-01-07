namespace Seldino.Application.Command.MembershipHandler
{
    internal sealed class MembershipCommandMessage 
    {
        public const string UserCreatedSuccessfully = "ایحاد حساب کاربری با موفقیت انجام شد";
        public const string UserCreationFailed = "ایجاد حساب کاربری با خطا مواجه شد";

        public const string UserEditedSuccessfully = "ویرایش حساب کاربری با موفقیت انجام شد";
        public const string UserEditionFailed = "ویرایش حساب کاربری با حطا مواجه شد";

        public const string UserDeletedSuccessfully = "حساب کاربری با موفقیت حذف گردید";
        public const string UserDeletionFailed = "حذف حساب کاربری با خطا مواجه گردید";

        public const string UserDeactivatedSuccessfully = "حساب کاربری غیر فعال گردید";
        public const string UserDeactivationFailed = "حساب کاربری با خطا مواجه گردید";

        public const string UserActivatedSuccessfully = "حساب کاربری با موفقیت فعال شد ";
        public const string UserActivationFaild = "با خطا مواجه شد";

        public const string AuthenticatedSuccessfully = "ورود به حساب کاربری با موفقیت انجام شد";
      
        public const string PasswordResetSuccessfully = "بازیابی کلمه عبور با موفقیت انجام شد، یک ایمیل حاوی کد فعال سازی برای شما ارسال خواهد شد";
        public const string PasswordResetFaild = "بازیابی کلمه عبور با خطا مواجه شد";

        public const string PasswordChangedSuccessfully = "رمز عبور با موفقیت تغییر یافت";
        public const string PasswordChandingFaild = "تغییر رمز عبور با خطا مواجه شد";

        public const string ForgotPasswordOperationFaild = "ارسال لینک فراموشی رمز عبور با خطا مواجه شد";
        public const string ForgotPasswordOperationSucceded = "لینک بازیابی رمز عبور به ایملتان ارسال شد";
    }

    internal sealed class MembershipValidationMessages
    {
        public const string EmailFormatIsIncorrect = "فرمت ایمیل صحیح نمی باشد";
        public const string EmailIsRequired = "ایمیل اجباری می باشد!";

        public const string PasswrdIsRequired = "رمز عبوراجباری می باشد!";
        public const string PasswordLenghtIsNotInRegularForm = "رمز عبور حداقل بایستی 6 کاراکتر باشد";
        public const string ConfirmPasswrdIsRequired = "تکرار رمز عبوراجباری می باشد!";
        public const string ConfirmPasswordIsNotMatchWithPassword = " تکرار رمز عبور با رمز عبور یکی نیستند";

        public const string NameIsNotInReguarLenght = "نام وارد شده طولانی است!";
        public const string LastNameIsNotInRegularLenght = "نام خانوادگی وارد شده طولانی است";

        public const string PhoneNumerIsNotInCorrectFormat = "شماره تلفن اشتباه می باشد";
        public const string CellPhoneNumerIsNotInCorrectFormat = "شماره موبایل اشتباه می باشد";

        public const string RoleNameIsRequired = "عنوان سمت اجباری است";
    }

    internal sealed class MembershipExceptionMessage
    {
        public const string EmailIsTaken = "!ایمیل مورد نظر قبلا در سیستم ثبت شده است";
        public const string UserIsInactive = "حساب کاربری مورد نظر مسدود میباشد";
        public const string IncorrectOldPassword = "رمز عبور قبلی اشتباه می باشد";
    }
}
