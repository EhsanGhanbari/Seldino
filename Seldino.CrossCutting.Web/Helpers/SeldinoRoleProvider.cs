using System;
using System.Linq;
using System.Web.Security;
using Seldino.Application.Query.MembershipService;

namespace Seldino.CrossCutting.Web.Helpers
{
    /// <summary>
    /// http://www.codeproject.com/Articles/607392/Custom-Role-Providers
    /// </summary>
    public class SeldinoRoleProvider : RoleProvider
    {
        private readonly IMembershipQueryService _membershipQueryService;

        public SeldinoRoleProvider(IMembershipQueryService membershipQueryService)
        {
            _membershipQueryService = membershipQueryService;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var response = _membershipQueryService.GetUserByEmail(new GetUserQueryRequest());//ToDo
            if (response.Failed)
                return false;
            return response.User.Role.ToString() == roleName;
        }

        public override string[] GetRolesForUser(string username)
        {
            //var user = _membershipQueryService.GetUserByEmail(username);
            //if (user == null)
            //    return new string[] { };
            //return user.Role == null ? new string[] { } :
            //  user.Role.Name).ToArray();
            return null;
        }


        public override string[] GetAllRoles()
        {
            return _membershipQueryService.GetRoles(new GetRolesQueryRequest()).Roles.Select(c => c.Name).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
