using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.DiscountAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.DiscountHandler
{
    public class DiscountCommandHandler :
        ICommandHandler<CreateDiscountCommand>,
        ICommandHandler<EditDiscountCommand>,
        ICommandHandler<StartDiscountCommand>,
        ICommandHandler<StopDiscountCommand>,
        ICommandHandler<DeleteDiscountCommand>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public DiscountCommandHandler(IDiscountRepository discountRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _discountRepository = discountRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CreateDiscountCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var discount = new Discount();
                AddDiscuont(command, discount);
                _discountRepository.Add(discount);
                _unitOfWork.Commit();
                return new SuccessResult(DiscountCommandMessage.DiscountCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(DiscountCommandMessage.DiscountCreationFailed);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(EditDiscountCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var discount = new Discount { Id = command.DiscountId, CreationDate = command.CreationDate };
                AddDiscuont(command, discount);
                _discountRepository.Edit(discount);
                _unitOfWork.Commit();
                return new SuccessResult(DiscountCommandMessage.DiscountEditedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(DiscountCommandMessage.DiscountEditionFailed);
            }
        }

        /// <summary>
        /// Start a disocunt period
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(StartDiscountCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var discountId in command.DiscountIds)
            {
                try
                {
                    var discount = StartDiscount(discountId);
                    _discountRepository.Edit(discount);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(DiscountCommandMessage.StartDiscountCreationFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(DiscountCommandMessage.StartDiscountCreatedSuccessfully);
        }

        /// <summary>
        /// end a discount perid
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(StopDiscountCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var discountId in command.DiscountIds)
            {
                try
                {
                    var discount = StopDiscount(discountId);
                    _discountRepository.Edit(discount);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(DiscountCommandMessage.StopDiscountCreationFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(DiscountCommandMessage.StopDiscountCreatedSuccessfully);
        }

        /// <summary>
        /// Delete a discount
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(DeleteDiscountCommand command)
        {
            if (command.DiscountIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var discountId in command.DiscountIds)
            {
                try
                {
                    var discount = DeleteDiscount(discountId);
                    _discountRepository.Edit(discount);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(DiscountCommandMessage.DiscountDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(DiscountCommandMessage.DiscountDeletedSuccessfully);
        }

        private static void AddDiscuont(IDiscountCommand command, Discount discount)
        {
            discount.Name = command.Name;
            discount.Amount = command.Amount;
            discount.DiscountLimitation = command.DiscountLimitation;
            discount.Percentage = command.Percentage;
            discount.StartDate = command.StartDate;
            discount.EndDate = command.EndDate;
        }

        private Discount StartDiscount(Guid discountId)
        {
            var discount = _discountRepository.GetById(discountId);

            if (discount.Stopped == false)
            {
                throw new DiscountAlreadyRunningException(DiscountCommandMessage.DiscountAlreadyStarted);
            }

            discount.Stopped = false;
            return discount;
        }

        private Discount StopDiscount(Guid discountId)
        {
            var discount = _discountRepository.GetById(discountId);

            if (discount.Stopped)
            {
                throw new DiscountAlreadyStoppedException(DiscountCommandMessage.DiscountAlreadyStoped);
            }

            discount.Stopped = true;
            return discount;
        }

        private Discount DeleteDiscount(Guid discountId)
        {
            var discount = _discountRepository.GetById(discountId);
            discount.IsDeleted = true;
            return discount;
        }
    }
}
