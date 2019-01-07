using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;
using Seldino.CrossCutting.Paging;

namespace Seldino.Domain.MembershipAggregation
{
    public interface IMembershipRepository : IRepositoryBase<User>
    {
        User GetUserByEmail(string email);

        User GetUserDetailByEmail(string email);

        User GetUserById(Guid userId);

        Role GetRole(string value);

        PagingQueryResponse<User> GetUsers(PagingQueryRequest query);

        PagingQueryResponse<User> GetInactiveUsers(PagingQueryRequest query);

        Role GetDefaultRole();

        IList<Role> GetRoles();

        PagingQueryResponse<Favorite> GetUserFavorites(PagingQueryRequest query);
    }
}
