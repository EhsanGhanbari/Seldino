using Seldino.Application.Command.CommandHandler;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.OrderAggregation;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.ShippingAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.PayementHandler;

namespace Seldino.Application.Command.OrderHandler
{
    internal class OrderCommandHandler :
        ICommandHandler<CreateOrderCommand>,
        ICommandHandler<UpdateOrderCommand>,
        ICommandHandler<CancelOrderCommand>,
        ICommandHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public OrderCommandHandler(IOrderRepository orderRepository,
            IBasketRepository basketRepository,
            IMembershipRepository membershipRepository,
            IDeliveryOptionRepository deliveryOptionRepository,
            IUnitOfWork unitOfWork,
            ILogger logger)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _membershipRepository = membershipRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Create order by registed members
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CreateOrderCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var basket = _basketRepository.GetById(command.BasketId);
                var user = _membershipRepository.GetUserById(command.UserId);
                var deliveryAddress = user.Locations.FirstOrDefault(d => d.Id == command.DeliveryId);

                var order = ConvertToOrder(basket);
                order.User = user;
                order.Location = deliveryAddress;
                _orderRepository.Add(order);
                _basketRepository.Remove(basket.Id);

                _unitOfWork.Commit();
                return new SuccessResult(OrderCommandMessage.OrderCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(OrderCommandMessage.OrderCreationFailed);
            }
        }

        private static Order ConvertToOrder(Basket basket)
        {
            var order = new Order();
            //{
            //    ShippingCharge = basket.DeliveryCost(),
            //    ShippingService = basket.DeliveryOption.ShippingService
            //};

            foreach (var item in basket.Items())
            {
                order.AddItem(item.Product, item.Quantity.Value);
            }

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(UpdateOrderCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var order = new Order { Id = command.OrderId };//, Status = OrderStatus.Processing };
                _orderRepository.Edit(order);
                _unitOfWork.Commit();
                return new SuccessResult(OrderCommandMessage.OrderEditedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(OrderCommandMessage.OrderEditionFailed);
            }
        }

        /// <summary>
        /// Canceling an order identity
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CancelOrderCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var orderId in command.OrderIds)
            {
                try
                {
                    var order = CancelOrder(orderId);
                    _orderRepository.Edit(order);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(OrderCommandMessage.OrderCancellationFailed);
                }
            }

            _unitOfWork.Commit();
            return new SuccessResult(OrderCommandMessage.OrderCanceledSuccessfully);
        }

        /// <summary>
        /// Delete an order 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(DeleteOrderCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var orderId in command.OrderIds)
            {
                try
                {
                    var order = DeleteOrder(orderId);
                    _orderRepository.Edit(order);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(OrderCommandMessage.OrderDeletionFailed);
                }
            }

            _unitOfWork.Commit();
            return new SuccessResult(OrderCommandMessage.OrderDeletedSuccessfully);
        }

        private Order CancelOrder(Guid orderId)
        {
            var order = CheckOrderStatus(orderId);
            // order.Status = OrderStatus.Cancelled;
            return order;
        }

        private Order DeleteOrder(Guid orderId)
        {
            var order = CheckOrderStatus(orderId);
            order.IsDeleted = true;
            return order;
        }

        private DeliveryOption GetCheapestDeliveryOption()
        {
            return _deliveryOptionRepository.GetAll().OrderBy(d => d.Cost).FirstOrDefault();
        }

        private Order CheckOrderStatus(Guid orderId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order.Status == OrderStatus.Completed)
                throw new OrderHasBeenCompletedException(OrderExceptionMessage.OrderOperationHasBeenCompleted);

            return order;
        }
    }
}
