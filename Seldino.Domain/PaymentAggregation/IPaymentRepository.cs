using System;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.PaymentAggregation
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
        Payment GetPaymentDetailById(Guid paymentId);

        PagingQueryResponse<Payment> GetPayments(PagingQueryRequest query);

        PagingQueryResponse<Payment> GetPaymentHistory(PagingQueryRequest requset);

        Invoice GetInvoiceByPaymentId(Guid paymentId);
    }
}
