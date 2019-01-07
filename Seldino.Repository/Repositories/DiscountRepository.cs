using System;
using System.Data.Entity;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.DiscountAggregation.Specifications;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.QueryModels;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {
        public DiscountRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public PagingQueryResponse<Discount> GetAllDiscounts(PagingQueryRequest query, Guid storeId)
        {
            var specification = new RetrievableDiscountSpecification().And(new DiscountMatchingInStoreSpecification(storeId));
            var totalCount = ReadOnlyDataContext.Discounts.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Discount>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Discounts.
                    Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Discount> GetAllInactiveDiscounts(PagingQueryRequest query, Guid storeId)
        {
            var specification =
                new RetrievableDiscountSpecification().And(new DiscountsMatchingInInactivitySpecification()).And(new DiscountMatchingInStoreSpecification(storeId));
            var totalCount = ReadOnlyDataContext.Discounts.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Discount>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Discounts.
                    Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Discount> GetAllAactiveDiscounts(PagingQueryRequest query, Guid storeId)
        {
            var specification = new RetrievableDiscountSpecification().And(new DiscountsMatchingInActivitySpecification()).And(new DiscountMatchingInStoreSpecification(storeId));
            var totalCount = ReadOnlyDataContext.Discounts.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Discount>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Discounts.
                    Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public DiscountsCountQueryModel GetDiscountsCount(Guid storeId)
        {
            var specification = new RetrievableDiscountSpecification().And(new DiscountMatchingInStoreSpecification(storeId));

            var query = ReadOnlyDataContext.Discounts.Where(specification.IsSatisfied()).GroupBy(d => d.Stopped).Select(d => new
            {
                d.Key,
                Count = d.Count()
            });

            var model = new DiscountsCountQueryModel();

            if (query.Any())
            {
                model.Active = query.SingleOrDefault(x => x.Key == false).Count;
                model.Inactive = query.SingleOrDefault(x => x.Key).Count;

            }

            return model;
        }
    }
}
