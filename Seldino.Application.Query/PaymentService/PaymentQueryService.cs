using System;
using AutoMapper;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.PaymentAggregation;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.PaymentService
{
    internal class PaymentQueryService : IPaymentQueryService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger _logger;

        public PaymentQueryService(IPaymentRepository paymentRepository, ILogger logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public PaymentQueryResponse GetPaymentById(PaymentQueryRequest request)
        {
            var response = new PaymentQueryResponse();

            try
            {
                var payment = _paymentRepository.GetById(request.PaymentId);
                response.Payment = Mapper.Map<Payment, PaymentDto>(payment);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }

        public PaymentQueryResponse GetPaymentDetailById(PaymentQueryRequest request)
        {
            var response = new PaymentQueryResponse();

            try
            {
                var payment = _paymentRepository.GetPaymentDetailById(request.PaymentId);
                response.Payment = Mapper.Map<Payment, PaymentDto>(payment);

            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }

        public PaymentsQueryResponse GetPayments(PaymentsQueryRequset requset)
        {
            var response = new PaymentsQueryResponse();

            try
            {
                var payments = _paymentRepository.GetPayments(requset);
                response.Payments = Mapper.Map<PagingQueryResponse<Payment>, PagingQueryResponse<PaymentDto>>(payments);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }

        public PaymentsQueryResponse GetPaymentHistory(PaymentsQueryRequset requset)
        {
            var response = new PaymentsQueryResponse();

            try
            {
                var payments = _paymentRepository.GetPaymentHistory(requset);
                response.Payments = Mapper.Map<PagingQueryResponse<Payment>, PagingQueryResponse<PaymentDto>>(payments);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }

        public InvoiceQueryResponse GetInvoiceByPaymentId(InvoiceQueryRequest request)
        {
            var response = new InvoiceQueryResponse();

            try
            {
                var invoice = _paymentRepository.GetInvoiceByPaymentId(request.PaymentId);
                response.Invoice = Mapper.Map<Invoice, InvoiceDto>(invoice);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = PaymentQueryMessage.LoadingInvoiceFaild;
                _logger.Log(exception);
            }

            return response;
        }
    }
}
