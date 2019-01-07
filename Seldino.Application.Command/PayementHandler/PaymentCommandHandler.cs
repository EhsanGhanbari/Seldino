using System;
using System.Collections.Generic;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.PaymentAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.PayementHandler
{
    internal class PaymentCommandHandler :
        ICommandHandler<ChargeAccountCommand>,
        ICommandHandler<SetOrderPaymentCommand>,
        ICommandHandler<DeletePaymentCommand>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public PaymentCommandHandler(
            IPaymentRepository paymentRepository,
            IUnitOfWork unitOfWork,
            ILogger logger)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(ChargeAccountCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var payment = new Payment(DateTime.Now, "TransactionId", "Merchant", command.Amount);//ToDo
                _paymentRepository.Add(payment);
                _unitOfWork.Commit();
                return new SuccessResult(PaymentCommandMessage.PaymentOperationSucceded);
            }
            catch (PayementCommandException exception)
            {
                _logger.Error(exception);
                return new FailureResult(PaymentCommandMessage.PaymentOpertaionFaild);
            }
        }

        public ICommandResult Execute(SetOrderPaymentCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                return new SuccessResult(PaymentCommandMessage.PaymentOperationSucceded);
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                return new FailureResult(PaymentCommandMessage.PaymentOpertaionFaild);
            }
        }

        public ICommandResult Execute(DeletePaymentCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var orderId in command.PaymentIds)
            {
                try
                {
                    var payment = DeletePayment(orderId);
                    _paymentRepository.Edit(payment);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(PaymentCommandMessage.PaymentDeletionFailed);
                }
            }

            _unitOfWork.Commit();
            return new SuccessResult(PaymentCommandMessage.PaymentDeletedSuccessfully);
        }

        private Payment DeletePayment(Guid orderId)
        {
            var payment = _paymentRepository.GetById(orderId);
            payment.IsDeleted = true;
            return payment;
        }
    }
}
