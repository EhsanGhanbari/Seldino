using System.Collections.Generic;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.MembershipService
{
    public class GetUserQueryResponse : QueryResponse
    {
        public UserDto User { get; set; }
    }

    public class GetUsersQueryResponse : QueryResponse
    {
        public PagingQueryResponse<UserDto> Users { get; set; }
    }

    public class GetUserProfileQueryResponse : QueryResponse
    {
        public ProfileDto Profile { get; set; }
    }

    public class GetRoleQueryResponse : QueryResponse
    {
        public RoleDto Role { get; set; }
    }

    public class GetRolesQueryResponse : QueryResponse
    {
        public IList<RoleDto> Roles { get; set; }
    }

    public class GetUserFavoriteQueryResponse : QueryResponse
    {
        public PagingQueryResponse<FavoriteDto> Favorites { get; set; }
    }

    public class AuthenticateQueryResponse : QueryResponse
    {
        public UserDto User { get; set; }
    }
}
