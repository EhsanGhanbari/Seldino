using System;
using System.ComponentModel.DataAnnotations;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.MembershipService
{
    public class GetUserQueryRequest : QueryRequest
    {
        public GetUserQueryRequest()
        {            
        }

        public GetUserQueryRequest(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }

    public class GetUsersQueryRequest : PagingQueryRequest
    {
        public GetUsersQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public GetUsersQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class GetUserProfileQueryRequest : QueryRequest
    {
        public GetUserProfileQueryRequest(Guid userId)
        {
            UserId = userId;
        }
    }

    public class GetRoleQueryRequest : QueryRequest
    {
        public string Role { get; set; }
    }

    public class GetRolesQueryRequest : QueryRequest
    {
    }

    public class GetUserFavoriteDtoQueryRequest : PagingQueryRequest
    {
    }

    public class AuthenticateQueryRequest : QueryRequest
    {
        [Required(ErrorMessage = MembershipQueryMessages.EmailIsRequired)]
        [EmailAddress(ErrorMessage = MembershipQueryMessages.EmailFormatIsIncorrect)]
        public string Email { get; set; }

        [Required(ErrorMessage = MembershipQueryMessages.PasswrdIsRequired), MinLength(6), MaxLength(16)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
