using System;
using System.Collections.Generic;
using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.BlogHandler
{
    #region BlogPost
    public interface IBlogPostCommand : ICommand
    {
        string Title { get; set; }
        string Body { get; set; }
        BlogCategoryCommand BlogCategory { get; set; }
        ICollection<BlogTagCommand> BlogTags { get; set; }
        ICollection<BlogPictureCommand> BlogPictures { get; set; }
    }

    public class BlogPostCommand : IBlogPostCommand
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public BlogCategoryCommand BlogCategory { get; set; }
        public ICollection<BlogTagCommand> BlogTags { get; set; }
        public ICollection<BlogPictureCommand> BlogPictures { get; set; }
    }

    public class CreateBlogPostCommand : BlogPostCommand
    {
    }

    public class EditBlogPostCommand : BlogPostCommand
    {
    }

    public class DeleteBlogPostCommand : ICommand
    {
        public Guid[] BlogPostIds { get; set; }
    }

    #endregion

    #region BlogTag

    public class BlogTagCommand
    {
        public string Name { get; set; }
        public bool IsNew { get; set; }
    }

    public class DeleteBlogTagCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    #endregion

    #region BlogCategory

    public class BlogCategoryCommand
    {
        public string Name { get; set; }
        public bool IsNew { get; set; }
    }

    public class DeleteBlogCategoryCommand : ICommand
    {
        public string[] Values { get; set; }
    }

    #endregion

    #region ProductPicture
    public class BlogPictureCommand
    {
        public Guid PictureId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    #endregion

    #region BlogCommand

    public interface IBlogCommandComment : ICommand
    {
        Guid BlogPostId { get; set; }
        Guid UserId { get; set; }
        string Body { get; set; }
        DateTime CreationDate { get; set; }
        DateTime LastUpdateDate { get; set; }
    }

    public class BlogCommandComment : IBlogCommandComment
    {
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }

    public class CreateBlogCommentCommand : BlogCommandComment
    {
    }

    public class EditBlogCommentCommand : BlogCommandComment
    {
        public Guid CommentId { get; set; }
    }

    public class DeleteBlogCommentCommand : ICommand
    {
        public Guid BlogId { get; set; }
    }
}
    #endregion

