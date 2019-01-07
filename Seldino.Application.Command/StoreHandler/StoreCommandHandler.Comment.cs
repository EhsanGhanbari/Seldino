using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.StoreAggregation.StoreComments;

namespace Seldino.Application.Command.StoreHandler
{
    internal partial class StoreCommandHandler :
       ICommandHandler<CreateStoreCommentCommand>,
       ICommandHandler<DeleteStoreCommentCommand>
    {
        public ICommandResult Execute(CreateStoreCommentCommand command)
        {
            try
            {
                var comment = new StoreComment();
                AddStoreComment(command, comment);
                _storeCommentRepository.Add(comment);
                _unitOfWork.Commit();
                return new SuccessResult(StoreCommandMessage.CommentCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(StoreCommandMessage.CommentCreationFaild);
            }
        }

        public ICommandResult Execute(DeleteStoreCommentCommand command)
        {
            if (command.CommentIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var commentId in command.CommentIds)
            {
                try
                {
                    var comment = DeleteComment(commentId);
                    _storeCommentRepository.Edit(comment);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(StoreCommandMessage.CommentDeletionFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(StoreCommandMessage.CommentDeletedSuccessfully);
        }

        private StoreComment DeleteComment(Guid commentId)
        {
            var comment = _storeCommentRepository.GetById(commentId);
            comment.IsDeleted = false;
            return comment;
        }

        private void AddStoreComment(IStoreCommentCommand command, StoreComment comment)
        {
            comment.Body = command.Body;
            AssigneCommentToStore(command, comment);
            AssigneCommentToUser(command, comment);
        }

        private void AssigneCommentToUser(IStoreCommentCommand command, StoreComment comment)
        {
            var user = _membershipRepository.GetUserById(command.UserId);
            comment.Users.Add(user);
        }

        private void AssigneCommentToStore(IStoreCommentCommand command, StoreComment comment)
        {
            var store = _storeRepository.GetById(command.StoreId);
            comment.Stores.Add(store);
        }
    }
}
