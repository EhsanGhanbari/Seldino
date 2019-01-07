using System;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ProductAggregation.ProductRatings;

namespace Seldino.Application.Command.ProductHandler
{
    internal partial class ProductCommandHandler : ICommandHandler<RateProductCommand>
    {
        public ICommandResult Execute(RateProductCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                if (command.UserId == Guid.Empty)
                {
                    return new FailureResult(ProductCommandMessage.ProductRatingNeedToBeLoggedIn);
                }

                var product = _productRepository.GetById(command.ProductId);

                if (product == null)
                {
                    return new FailureResult(ProductCommandMessage.ProductNotFountForRating);
                }

                var user = _membershipRepository.GetById(command.UserId);
                var productRating = ChangeProductRating(product, user, command);
                _productRatingRepository.Add(productRating);
                _unitOfWork.Commit();
                return new SuccessResult(ProductCommandMessage.ProductRatedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(ProductCommandMessage.ProductRatingFaild);
            }
        }

        private static ProductRating ChangeProductRating(Product product, User user, IRateProductCommand command)
        {
            var productRating = new ProductRating
            {
                Product = product,
                User = user
            };

            productRating.Product.Id = command.ProductId;
            productRating.User.Id = command.UserId;
            productRating.Score = command.Score;

            return productRating;
        }
    }
}
