using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.BasketAggregation.Unauthorized;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.BasketHandler.Unauthorized
{
    internal class UnauthorizedBasketCommandHandler :
          ICommandHandler<AddItemToUnauthorizedBasketCommand>,
          ICommandHandler<RemoveItemFromUnauthorizedBasketCommand>,
          ICommandHandler<UpdateUnAuthorizedBasketQuantityCommand>
    {

        private readonly IUnauthorizedBasketRepository _unauthorizedBasketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UnauthorizedBasketCommandHandler(
            IUnauthorizedBasketRepository unauthorizedBasketRepository,
            IUnitOfWork unitOfWork,
            ILogger logger,
            IProductRepository productRepository)
        {
            _unauthorizedBasketRepository = unauthorizedBasketRepository;
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(AddItemToUnauthorizedBasketCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var product = _productRepository.GetById(productId);

                    if (product == null)
                    {
                        return new FailureResult(BasketCommandMessage.ProductDoesNotFound);
                    }

                    var unauthorizedBasket = _unauthorizedBasketRepository.GetBasketItems(command.CookieId);

                    if (unauthorizedBasket != null)
                    {
                        unauthorizedBasket.AddBasketItem(product);
                        _unauthorizedBasketRepository.Edit(unauthorizedBasket);
                    }
                    else
                    {
                        var basket = new UnauthorizedBasket { CookieId = command.CookieId };
                        basket.AddBasketItem(product);
                        _unauthorizedBasketRepository.Add(basket);
                    }
                }
                catch (Exception exception)
                {
                    _logger.Error(exception.Message);
                    exceptions.Add(exception);
                    return new FailureResult(BasketCommandMessage.AddingItemToBasketFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BasketCommandMessage.ItemAddedToBasketSuccessfully);
        }

        public ICommandResult Execute(RemoveItemFromUnauthorizedBasketCommand command)
        {
            if (command.ProductIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var productId in command.ProductIds)
            {
                try
                {
                    var basket = _unauthorizedBasketRepository.GetBasketItems(command.CookieId);
                    var product = _productRepository.GetProductDetailById(productId);

                    if (product == null)
                    {
                        return new FailureResult(BasketCommandMessage.ProductDoesNotFound);
                    }

                    basket.Remove(product);
                    _unauthorizedBasketRepository.Edit(basket);
                }
                catch (Exception exception)
                {
                    _logger.Error(exception.Message);
                    exceptions.Add(exception);
                    return new FailureResult(BasketCommandMessage.RemovingItemFromBasketFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BasketCommandMessage.ItemRemovedFromBasketSuccessfully);
        }

        public ICommandResult Execute(UpdateUnAuthorizedBasketQuantityCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var basket = _unauthorizedBasketRepository.GetBasketItems(command.CookieId);

                if (basket != null)
                {
                    var product = _productRepository.GetById(command.ProductId);

                    if (product != null)
                        basket.ChangeQuantityOfProduct(new Quantity(command.Quantity), product);

                    _unauthorizedBasketRepository.Edit(basket);
                    _unitOfWork.Commit();
                }

                return new SuccessResult("");
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult("");
            }
        }
    }
}
