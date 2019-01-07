using System;
using System.Collections.Generic;
using System.Data.Entity;
using Seldino.Domain.MembershipAggregation;
using Seldino.Repository.Infrastructure;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.MembershipAggregation.Specifications;

namespace Seldino.Repository.Repositories
{
    internal class MembershipRepository : RepositoryBase<User>, IMembershipRepository
    {
        public MembershipRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public User GetUserByEmail(string email)
        {
            var specification = new RetrievableUserSpecification(email);
            return DataContext.Users
                .Where(specification.IsSatisfied())
                .SingleOrDefault(u => u.Email == email);
        }

        public User GetUserDetailByEmail(string email)
        {
            var specification = new RetrievableUserSpecification(email);
            return DataContext.Users
                .Where(specification.IsSatisfied())
                .Include(u => u.Profile)
                .Include(u => u.Role)
                .SingleOrDefault(u => u.Email == email);
        }

        public User GetUserById(Guid userId)
        {
            var specification = new RetrievableUserSpecification(null);
            return DataContext.Users.Where(specification.IsSatisfied()).SingleOrDefault(u => u.Id == userId);
        }

        public User GetUserDetailById(Guid userId)
        {
            var specification = new RetrievableUserSpecification(null);
            return DataContext.Users
                .Where(specification.IsSatisfied())
                .Include(u => u.Profile)
                .Include(u => u.Profile.Avatar)
                .Include(u => u.Role)
                .SingleOrDefault();
        }

        public Role GetRole(string value)
        {
            return DataContext.Roles.Where(u => u.IsDeleted == false).SingleOrDefault(c => c.Name == value);
        }

        public PagingQueryResponse<User> GetUsers(PagingQueryRequest query)
        {
            var specification = new RetrievableUserSpecification(query.Keyword);
            var totalCount = ReadOnlyDataContext.Users.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<User>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = ReadOnlyDataContext.Users
                    .Where(specification.IsSatisfied())
                    .Include(c => c.Profile)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize)
                    .Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<User> GetInactiveUsers(PagingQueryRequest query)
        {
            var specification = new MatchingInInactivityUserSpecification(query.Keyword);
            var totalCount = ReadOnlyDataContext.Users.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<User>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = ReadOnlyDataContext.Users
                    .Where(specification.IsSatisfied())
                    .Include(c => c.Profile)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize)
                    .Take(query.PageSize).ToList()
            };

            return result;
        }

        public Role GetDefaultRole()
        {
            return DataContext.Roles.Where(u => u.IsDeleted == false).SingleOrDefault(c => c.IsDefault);
        }

        public IList<Role> GetRoles()
        {
            return DataContext.Roles.Where(u => u.IsDeleted == false).ToList();
        }

        public PagingQueryResponse<Favorite> GetUserFavorites(PagingQueryRequest query)
        {
            var totalCount = ReadOnlyDataContext.Favorites.Where(f => f.Users.Any(c => c.Id == query.UserId)).AsNoTracking().Count();

            var result = new PagingQueryResponse<Favorite>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Favorites.
                     Where(f => f.Users.Any(c => c.Id == query.UserId))
                    .Include(f => f.Products)
                    .Include(f => f.Stores)
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }
    }
}
