using System.Security.AccessControl;

namespace Seldino.Application.Query.MembershipService
{
    internal sealed class MembershipQueryMessages
    {
        public const string UserDoesNotExist = "کابر مورد نظر یافت نشد";
        public const string LoadingUsersFaild = "بارگزاری اطلاعات کاربران با خطا مواجه شد";
        public const string NoUserFound = "هیچ کاربری در سیستم یافت نشد";
        public const string RoleDoesNotExist = "نقش مورد نظر یافت نشد";
        public const string NoRoleFound = "نقشی نظر یافت نشد";
        public const string NoFavoriteItemFoundForUser = "هیچ نوع علاقمندی برای کاربر مورد نظر یافت نشد";
        public const string AuthenticationFaild = "ورود به حساب کاربری به خطا مواجه شد، ایمیل یا رمز عبور اشتباه است";
        public const string Authenticated = "ورود به حساب کاربری با موفقیت انجام شد";
        public const string EmailIsRequired = "ایمیل اجباری می باشد!";
        public const string EmailFormatIsIncorrect = "فرمت ایمیل صحیح نمی باشد";
        public const string PasswrdIsRequired = "رمز عبوراجباری می باشد!";
        public const string PasswordLenghtIsNotInRegularForm = "رمز عبور حداقل بایستی 6 کاراکتر باشد";
    }
}
