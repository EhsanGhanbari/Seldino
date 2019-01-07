using System.Text;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.BasketAggregation.Unauthorized;

namespace Seldino.Application.Command.BasketHandler
{
    internal class BasketCommandHandler :
        ICommandHandler<AddItemToBasketCommand>,
        ICommandHandler<RemoveItemFromBasketCommand>,
        ICommandHandler<TransferUnauthorizedBasketCommand>,
        ICommandHandler<UpdateBasketQuantityCommand>
    {

        private readonly IBasketRepository _basketRepository;
        private readonly IUnauthorizedBasketRepository _unauthorizedBasketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public BasketCommandHandler(
            IBasketRepository basketRepository,
            IUnauthorizedBasketRepository unauthorizedBasketRepository,
            IProductRepository productRepository,
            IMembershipRepository membershipRepository,
            IUnitOfWork unitOfWork,
            ILogger logger)
        {
            _basketRepository = basketRepository;
            _unauthorizedBasketRepository = unauthorizedBasketRepository;
            _productRepository = productRepository;
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(AddItemToBasketCommand command)
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
                    var userBasket = _basketRepository.GetUserBasket(command.UserId);
                    if (userBasket != null)
                    {
                        AddItemsToBasket(productId, userBasket);
                        _basketRepository.Edit(userBasket);
                    }
                    else
                    {
                        var basket = new Basket();
                        AssignToUser(command, basket);
                        AddItemsToBasket(productId, basket);
                        _basketRepository.Add(basket);
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

        public ICommandResult Execute(RemoveItemFromBasketCommand command)
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
                    var basket = _basketRepository.GetUserBasket(command.UserId);
                    var product = _productRepository.GetProductDetailById(productId);

                    if (product == null)
                    {
                        return new FailureResult(BasketCommandMessage.ProductDoesNotFound);
                    }

                    basket.Remove(product);
                    _basketRepository.Edit(basket);
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

        public ICommandResult Execute(TransferUnauthorizedBasketCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var unauthorizedBasket = _unauthorizedBasketRepository.GetBasketItems(command.CookieId);

            var exceptions = new List<Exception>();

            if (unauthorizedBasket != null)
            {
                foreach (var productItem in unauthorizedBasket.BasketItems)
                {
                    try
                    {
                        var userBasket = _basketRepository.GetUserBasket(command.UserId);
                       
                        if (userBasket != null)
                        {
                            AddItemsToBasket(productItem.ProductId, userBasket);
                            _basketRepository.Edit(userBasket);
                        }
                        else
                        {
                            var basket = new Basket();
                            AssignToUser(command, basket);
                            AddItemsToBasket(productItem.ProductId, basket);
                            _basketRepository.Add(basket);
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(exception.Message);
                        exceptions.Add(exception);
                        return new FailureResult(BasketCommandMessage.AddingItemToBasketFaild);
                    }
                }

                _unauthorizedBasketRepository.ClearUnauthorizedBasket(unauthorizedBasket.BasketItems);
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BasketCommandMessage.ItemAddedToBasketSuccessfully);
        }

        public ICommandResult Execute(UpdateBasketQuantityCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            try
            {
                var userBasket = _basketRepository.GetUserBasket(command.UserId);

                if (userBasket != null)
                {
                    var product = _productRepository.GetById(command.ProductId);

                    if (product != null)
                        userBasket.ChangeQuantityOfProduct(new Quantity(command.Quantity), product);

                    _basketRepository.Edit(userBasket);
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

        private void AssignToUser(IBasketCommand command, Basket basket)
        {
            var user = _membershipRepository.GetUserById(command.UserId);

            if (user != null)
            {
                basket.UserId = command.UserId;
            }
        }

        private void AddItemsToBasket(Guid productId, Basket basket)
        {
            var product = _productRepository.GetById(productId);

            if (product != null)
            {
                basket.AddBasketItem(product);
            }
        }
    }
}
