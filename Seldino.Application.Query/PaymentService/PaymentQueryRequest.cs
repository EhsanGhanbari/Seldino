using System;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.PaymentService
{
    public class PaymentQueryRequest : QueryRequest
    {
        public PaymentQueryRequest(Guid paymentId)
        {
            PaymentId = paymentId;
        }

        public Guid PaymentId { get; set; }
    }

    public class PaymentsQueryRequset : PagingQueryRequest
    {
        public PaymentsQueryRequset(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public PaymentsQueryRequset(int pageIndex, int pageSize, Guid userId)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            UserId = userId;
        }
    }

    public class InvoiceQueryRequest : QueryRequest
    {
        public Guid PaymentId { get; set; }

        public InvoiceQueryRequest(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}

