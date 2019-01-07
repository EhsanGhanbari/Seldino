using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.BlogAggregation;
using Seldino.Infrastructure.Events;
using Seldino.Infrastructure.Helpers;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.BlogHandler
{
    public partial class BlogCommandHandler :
        ICommandHandler<CreateBlogPostCommand>,
        ICommandHandler<EditBlogPostCommand>,
        ICommandHandler<DeleteBlogPostCommand>,
        ICommandHandler<DeleteBlogTagCommand>,
        ICommandHandler<DeleteBlogCategoryCommand>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public BlogCommandHandler(IBlogRepository blogRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region Post

        public ICommandResult Execute(CreateBlogPostCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var post = new BlogPost();
                AddBlogAppurtenance(command, post);
                _blogRepository.Add(post);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(BlogPostCommandMessage.BlogPostCreationFaild);
            }

            return new SuccessResult(BlogPostCommandMessage.BlogPostCreatedSuccessfully);
        }

        public ICommandResult Execute(EditBlogPostCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var post = new BlogPost();
                AddBlogAppurtenance(command, post);
                _blogRepository.Edit(post);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(BlogPostCommandMessage.BlogPostCreationFaild);
            }

            return new SuccessResult(BlogPostCommandMessage.BlogPostCreatedSuccessfully);
        }

        public ICommandResult Execute(DeleteBlogPostCommand command)
        {
            if (command.BlogPostIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var postId in command.BlogPostIds)
            {
                try
                {
                    var product = DeleteBlogPost(postId);
                    _blogRepository.Edit(product);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BlogPostCommandMessage.BlogPostDeletionFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BlogPostCommandMessage.BlogPostDeletedSuccessfully);
        }

        private void AddBlogAppurtenance(IBlogPostCommand command, BlogPost post)
        {
            AddBlogPost(command, post);
            AddBlogCategory(command, post);
            AddBlogTag(command, post);
            AddBlogPicture(command, post);
        }

        private static void AddBlogPost(IBlogPostCommand command, BlogPost post)
        {
            post.Title = command.Title;
            post.Body = command.Body;
            post.UrlSlug = command.Title.GenerateSlug();
        }

        private void AddBlogCategory(IBlogPostCommand command, BlogPost post)
        {
            if (command.BlogCategory.Name == null) return;
            post.Category = command.BlogCategory.Name;
        }

        private void AddBlogTag(IBlogPostCommand command, BlogPost post)
        {
            if (command.BlogTags == null) return;

            foreach (var item in command.BlogTags.Where(c => c.Name != null))
            {
                var tag = new BlogTag
                {
                    Name = item.Name,
                    CreationDate = DateTime.Now,
                    Creator = "sdf",
                };

                if (item.IsNew)
                {
                    post.AddTag(tag);
                   // post.BlogTags.ForEach(c => c.BlogTags.Add(tag));
                }
                else
                {
                    var productTag = _blogRepository.GetBlogTagByValue(item.Name);
                    post.BlogTags.Add(productTag);
                }
            }
        }

        private static void AddBlogPicture(IBlogPostCommand command, BlogPost blogPost)
        {
            foreach (var postPicture in command.BlogPictures.Select(item => new BlogPicture
            {
                Name = item.Name,
                Address = item.Address,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            }))
            {
                blogPost.AddPicture(postPicture);
            }
        }

        private BlogPost DeleteBlogPost(Guid postId)
        {
            var post = _blogRepository.GetById(postId);
            post.IsDeleted = true;
            return post;
        }

        #endregion

        #region Tag
        public ICommandResult Execute(DeleteBlogTagCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var tag in command.Values)
            {
                try
                {
                    _blogRepository.DeleteBlogTag(tag);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BlogPostCommandMessage.BlogTagDeletionFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BlogPostCommandMessage.BlogTagDeletedSuccessfully);
        }

        #endregion

        #region Category
        public ICommandResult Execute(DeleteBlogCategoryCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var category in command.Values)
            {
                try
                {
                    _blogRepository.DeleteBlogCategory(category);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BlogPostCommandMessage.BlogCategoryDeletionFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BlogPostCommandMessage.BlogCategoryDeletedSuccessfully);
        }

        #endregion
    }
}
