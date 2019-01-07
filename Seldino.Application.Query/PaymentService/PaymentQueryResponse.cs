using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.PaymentService
{
    public class PaymentQueryResponse : QueryResponse
    {
        public PaymentDto Payment { get; set; }
    }


    public class PaymentsQueryResponse : QueryResponse
    {
        public PagingQueryResponse<PaymentDto> Payments { get; set; } 
    }

    public class InvoiceQueryResponse : QueryResponse
    {
        public InvoiceDto Invoice { get; set; }
    }

}
