
namespace Seldino.Application.Query.MembershipService
{
    public interface IMembershipQueryService
    {
        GetUserQueryResponse GetUserById(GetUserQueryRequest request);

        GetUserQueryResponse GetUserByEmail(GetUserQueryRequest request);

        GetUserQueryResponse GetUserDetailByEmail(GetUserQueryRequest request);

        GetUserProfileQueryResponse GetUserProfileById(GetUserProfileQueryRequest request);

        GetUsersQueryResponse GetUsers(GetUsersQueryRequest request);

        GetUsersQueryResponse GetInactiveUsers(GetUsersQueryRequest request);

        GetRoleQueryResponse GetRole(GetRoleQueryRequest request);

        GetRolesQueryResponse GetRoles(GetRolesQueryRequest request);

        GetUserFavoriteQueryResponse GetUserFavorites(GetUserFavoriteDtoQueryRequest request);

        AuthenticateQueryResponse Authenticate(AuthenticateQueryRequest request);
    }
}
