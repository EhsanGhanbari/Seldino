using System;
using System.Data.Entity;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.PaymentAggregation.Specifications;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class PayementRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PayementRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public Payment GetPaymentDetailById(Guid paymentId)
        {
            return ReadOnlyDataContext.Payments.SingleOrDefault(c => c.Id == paymentId);
        }

        public PagingQueryResponse<Payment> GetPayments(PagingQueryRequest query)
        {
            var specification = new RetrievablePaymentSpecification();
            var totalCount = ReadOnlyDataContext.Payments.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Payment>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Payments
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Payment> GetPaymentHistory(PagingQueryRequest query)
        {
            var specification = new RetrievablePaymentSpecification().And(new PaymentMatchingInOwnerSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Payments.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Payment>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Payments
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public Invoice GetInvoiceByPaymentId(Guid paymentId)
        {
            return ReadOnlyDataContext.Invoices.SingleOrDefault(c => c.PaymentId == paymentId && c.IsDeleted == false);
        }
    }
}
