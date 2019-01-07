using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.PaymentService
{
    public interface IPaymentQueryService
    {
        PaymentQueryResponse GetPaymentById(PaymentQueryRequest request);

        PaymentQueryResponse GetPaymentDetailById(PaymentQueryRequest request);

        PaymentsQueryResponse GetPayments(PaymentsQueryRequset requset);

        PaymentsQueryResponse GetPaymentHistory(PaymentsQueryRequset requset);

        InvoiceQueryResponse GetInvoiceByPaymentId(InvoiceQueryRequest request);
    }
}
