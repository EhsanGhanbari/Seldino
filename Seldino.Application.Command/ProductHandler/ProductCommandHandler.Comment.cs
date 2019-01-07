using System;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.ProductAggregation.ProductComments;

namespace Seldino.Application.Command.ProductHandler
{
    internal partial class ProductCommandHandler :
        ICommandHandler<CreateProductCommentCommand>,
        ICommandHandler<EditProductCommentCommand>,
        ICommandHandler<DeleteProductCommentCommand>,
        ICommandHandler<ReplyToProductCommentCommand>
    {

        public ICommandResult Execute(CreateProductCommentCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var comment = new ProductComment();
                AddProductComment(comment, command);
                _productCommentRepository.Add(comment);
                _unitOfWork.Commit();
                return new SuccessResult(ProductCommandMessage.ProductCommentCreatedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductCommentCreationFailed);
            }
        }

        public ICommandResult Execute(EditProductCommentCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var productComment = _productCommentRepository.GetById(command.CommentId);

                //if (productComment.Users.Id != command.UserId)
                //    throw new ProductCommentOwnerIsWrongException(ProductExceptionMessage.ProductCommentOwnerIsWrong);

                ReplyToProductComment(productComment, command);
                _productCommentRepository.Edit(productComment);
                _unitOfWork.Commit();
                return new SuccessResult(ProductCommandMessage.ProductCommentCreatedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductBrandDeletedSuccessufully);
            }
        }
       
        public ICommandResult Execute(DeleteProductCommentCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var comment = _productCommentRepository.GetById(command.CommentId);
                comment.IsDeleted = true;
                _productCommentRepository.Edit(comment);
                _unitOfWork.Commit();

                return new SuccessResult(ProductCommandMessage.ProductCommentDeletedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductCommentDeletionFailed);
            }
        }

        public ICommandResult Execute(ReplyToProductCommentCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var comment = _productCommentRepository.GetById(command.CommentId);
                comment.ParentId = command.ProductId; //ToDo
                comment.Body = command.Body;
                _productCommentRepository.Edit(comment);
                _unitOfWork.Commit();

                return new SuccessResult(ProductCommandMessage.ProductCommentCreatedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductCommentCreationFailed);
            }
        }

        private void AddProductComment(ProductComment comment, IProductCommentCommand command)
        {
            comment.Body = command.Body;
            comment.UserId = command.UserId;
            AssigneCommentToProduct(comment, command);
        }

        private void ReplyToProductComment(ProductComment productComment, IProductCommentCommand command)
        {
            var comment = _productCommentRepository.GetById(command.CommentId);
            productComment.ParentId = command.CommentId;
            AssigneCommentToProduct(comment, command);
        }

        private void AssigneCommentToProduct(ProductComment comment, IProductCommentCommand command)
        {
            var product = _productRepository.GetProductDetailById(command.ProductId);
            comment.Products.Add(product);
        }
    }
}
