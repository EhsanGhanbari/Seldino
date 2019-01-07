using Seldino.CrossCutting.Paging;
using Seldino.Domain.BannerAggregation;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Seldino.Domain.BannerAggregation.Specifications;
using Seldino.Repository.QueryModels;

namespace Seldino.Repository.Repositories
{
    internal class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public Banner GetBannerById(Guid bannerId)
        {
            return DataContext.Banners.Include(p => p.Picture).SingleOrDefault(c => c.Id == bannerId);
        }

        public BannersCountQueryModel GetBannerCount(Guid userId)
        {
            var specification = new RetrievableBannerSpecificaion().And(new BannerMatchingInOwnerSpecification(userId));
            var query = ReadOnlyDataContext.Banners.Where(specification.IsSatisfied()).GroupBy(d => d.IsActive).Select(d => new
            {
                d.Key,
                Count = d.Count()
            });

            var model = new BannersCountQueryModel();

            if (!query.Any()) return model;

            var activeBanners = query.SingleOrDefault(x => x.Key == false);
            if (activeBanners != null)
                model.Active = activeBanners.Count;

            var inactiveBanners = query.SingleOrDefault(x => x.Key);
            if (inactiveBanners != null) model.Inactive = inactiveBanners.Count;

            return model;
        }

        public PagingQueryResponse<Banner> GetBanners(PagingQueryRequest query)
        {
            var specification = new RetrievableBannerSpecificaion().And(new BannerMatchingInOwnerSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Banners.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Banner>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Banners
                  .Where(specification.IsSatisfied())
                  .Include(c => c.Picture)
                  .OrderByDescending(c => c.CreationDate)
                  .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Banner> GetInactiveBanners(PagingQueryRequest query)
        {
            var specification = new RetrievableBannerSpecificaion().And(new BannersMatchingInInactivitySpecification()).And(new BannerMatchingInOwnerSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Banners.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Banner>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Banners
                    .Where(specification.IsSatisfied())
                    .Include(c => c.Picture)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Banner> GetActiveBanners(PagingQueryRequest query)
        {
            var specification = new RetrievableBannerSpecificaion().And(new BannersMatchingInActivitySpecification()).And(new BannersMatchingInConfirmedSpecification());
            var totalCount = ReadOnlyDataContext.Banners.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Banner>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Banners.Where(specification.IsSatisfied())
                   .Include(p => p.Picture).OrderByDescending(f => f.CreationDate)
                   .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public IList<Banner> GetActiveAdvBanners(int count)
        {
            return ReadOnlyDataContext.Banners
                .Where(c => c.IsConfirmed && c.IsDeleted == false)
                .Include(d => d.Picture)
                .Take(count)
                .ToList();
        }

        public PagingQueryResponse<Banner> GetUnConfirmedBanners(PagingQueryRequest query)
        {
            var specification = new RetrievableBannerSpecificaion().And(new BannersMatchingInUnconfirmedSpecification()).And(new BannerMatchingInOwnerSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Banners.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Banner>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Banners
                    .Where(specification.IsSatisfied())
                    .Include(p => p.Picture)
                    .OrderByDescending(f => f.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }
    }
}
