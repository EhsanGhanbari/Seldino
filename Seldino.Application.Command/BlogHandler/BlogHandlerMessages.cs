namespace Seldino.Application.Command.BlogHandler
{
    internal sealed class BlogPostCommandMessage
    {
        #region BlogPost

        public const string BlogPostCreationFaild = "ایجاد پست با خطا مواجه شد";
        public const string BlogPostCreatedSuccessfully = "ایجاد پست با موفقیت انجام شد";
        public const string BlogPostDeletionFaild = "حذف پست با خطا مواجه شد";
        public const string BlogPostDeletedSuccessfully = "حذف پست با موفقیت انجام شد";
        #endregion 

        #region BlogCategory
        public const string BlogCategoryDeletionFaild = "حذف دسته پست با خطا مواجه شد";
        public const string BlogCategoryDeletedSuccessfully = "حذف دسته پست با موفقیت انجام شد";
        #endregion

        #region BlogTag
        public const string BlogTagDeletionFaild = "حذف برچسب پست به خطا مواجه شد ";
        public const string BlogTagDeletedSuccessfully = "حذف برچسب پست با موفقیت انجام شد ";
        #endregion
    }
}
