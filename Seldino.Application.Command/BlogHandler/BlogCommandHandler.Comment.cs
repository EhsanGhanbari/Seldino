using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.BlogAggregation.BlogComments;

namespace Seldino.Application.Command.BlogHandler
{
    public partial class BlogCommandHandler :
          ICommandHandler<CreateBlogCommentCommand>,
          ICommandHandler<EditBlogCommentCommand>,
          ICommandHandler<DeleteBlogCommentCommand>
    {
        private readonly IBlogCommentRepository _blogCommentRepository;

        public BlogCommandHandler(IBlogCommentRepository blogCommentRepository)
        {
            _blogCommentRepository = blogCommentRepository;
        }

        public ICommandResult Execute(CreateBlogCommentCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Execute(EditBlogCommentCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Execute(DeleteBlogCommentCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
