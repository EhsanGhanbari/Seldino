using System.Data.Entity;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.GiftDeskAggregation;
using Seldino.Domain.GiftDeskAggregation.Specifications;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class GiftDeskRepository : RepositoryBase<GiftDesk>, IGiftDeskRepository
    {
        public GiftDeskRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public PagingQueryResponse<GiftDesk> GetGiftDesks(PagingQueryRequest query)
        {
            var specification = new RetrievableGiftDeskSpecification();
            var totalCount = ReadOnlyDataContext.GiftDesks.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<GiftDesk>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.GiftDesks
                    .Where(specification.IsSatisfied())                 
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }
    }
}
