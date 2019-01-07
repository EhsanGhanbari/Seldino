using System;
using System.Data.Entity;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.StoreAggregation;
using Seldino.Repository.Infrastructure;
using System.Linq;
using Seldino.Domain.StoreAggregation.Specifications;
using Seldino.Domain.StoreAggregation.StoreComments;

namespace Seldino.Repository.Repositories
{
    internal class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public Store GetStoreDetailById(Guid storeId)
        {
            return DataContext.Stores
                .Include(s => s.Location)
                .Include(s => s.Location.Address)
                .Include(s => s.Location.Country)
                .Include(s => s.Location.State)
                .Include(s => s.Document)
                .Include(s => s.Products)
                .Include(s => s.StoreComments)
                .SingleOrDefault(s => s.Id == storeId);
        }

        public PagingQueryResponse<Store> GetBestSellingStores(PagingQueryRequest query)
        {
            //ToDo Busines
            var specificaion = new RetrievableStoreSpecification();
            var totalCount = ReadOnlyDataContext.Stores.Where(specificaion.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Store>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Stores
                    .Where(specificaion.IsSatisfied())
                    .Include(c => c.Location)
                    .Include(c => c.Pictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Store> GetDiscountedStores(PagingQueryRequest query)
        {
            //ToDo Scnerio should be completed
            var specificaion = new RetrievableStoreSpecification();
            var totalCount = ReadOnlyDataContext.Stores.Where(specificaion.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Store>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Stores
                    .Where(specificaion.IsSatisfied())
                    .Include(c => c.Location)
                    .Include(c => c.Pictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Store> GetStores(PagingQueryRequest query)
        {
            var specificaion = new RetrievableStoreSpecification().And(new StoreMatchingInOwnerSpecificaion(query.UserId));
            var totalCount = ReadOnlyDataContext.Stores.Where(specificaion.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Store>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Stores
                    .Where(specificaion.IsSatisfied())
                    .Include(c => c.Location)
                    .Include(c => c.Pictures)
                    .Include(c => c.Users)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Store> GetInactiveStores(PagingQueryRequest query)
        {
            var specificaion = new StoreMatchingInInactivitySpecification().And(new StoreMatchingInOwnerSpecificaion(query.UserId));
            var totalCount = DataContext.Stores.AsNoTracking().Count(specificaion.IsSatisfied());

            var result = new PagingQueryResponse<Store>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Stores
                    .Where(specificaion.IsSatisfied())
                    .Include(c => c.Location)
                    .Include(c => c.Pictures)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }
    }

    internal class StoreCommentRepository : RepositoryBase<StoreComment>, IStoreCommentRepository
    {
        public StoreCommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
