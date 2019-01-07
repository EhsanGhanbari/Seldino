using AutoMapper;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.MembershipAggregation;
using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Security;
using Seldino.Infrastructure.Logging;
using Profile = Seldino.Domain.MembershipAggregation.Profile;

namespace Seldino.Application.Query.MembershipService
{
    internal class MembershipQueryService : IMembershipQueryService
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly ILogger _logger;

        public MembershipQueryService(IMembershipRepository membershipRepository, ILogger logger)
        {
            _membershipRepository = membershipRepository;
            _logger = logger;
        }

        public GetUserQueryResponse GetUserById(GetUserQueryRequest request)
        {
            var response = new GetUserQueryResponse();

            try
            {
                var user = _membershipRepository.GetById(request.UserId);

                if (user == null)
                {
                    response.Message = MembershipQueryMessages.UserDoesNotExist;
                    return response;
                }

                response.User = Mapper.Map<User, UserDto>(user);

            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public GetUserQueryResponse GetUserByEmail(GetUserQueryRequest request)
        {
            var response = new GetUserQueryResponse();

            try
            {
                var user = _membershipRepository.GetUserByEmail(request.Email);

                if (user == null)
                {
                    response.Message = MembershipQueryMessages.UserDoesNotExist;
                    return response;
                }

                response.User = Mapper.Map<User, UserDto>(user);

            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.AuthenticationFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public GetUserQueryResponse GetUserDetailByEmail(GetUserQueryRequest request)
        {
            var response = new GetUserQueryResponse();

            try
            {
                var user = _membershipRepository.GetUserDetailByEmail(request.Email);

                if (user == null)
                {
                    response.Message = MembershipQueryMessages.UserDoesNotExist;
                    return response;
                }

                response.User = Mapper.Map<User, UserDto>(user);

            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.AuthenticationFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public GetUserProfileQueryResponse GetUserProfileById(GetUserProfileQueryRequest request)
        {
            var response = new GetUserProfileQueryResponse();

            try
            {
                var user = _membershipRepository.GetUserById(request.UserId).Profile;
                response.Profile = Mapper.Map<Profile, ProfileDto>(user);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public GetUsersQueryResponse GetUsers(GetUsersQueryRequest request)
        {
            var response = new GetUsersQueryResponse();

            try
            {
                var users = _membershipRepository.GetUsers(request);

                if (users == null)
                {
                    response.Message = MembershipQueryMessages.NoUserFound;
                    return response;
                }

                response.Users = Mapper.Map<PagingQueryResponse<User>, PagingQueryResponse<UserDto>>(users);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.LoadingUsersFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public GetUsersQueryResponse GetInactiveUsers(GetUsersQueryRequest request)
        {
            var response = new GetUsersQueryResponse();

            try
            {
                var users = _membershipRepository.GetInactiveUsers(request);

                if (users == null)
                {
                    response.Message = MembershipQueryMessages.NoUserFound;
                    return response;
                }

                response.Users = Mapper.Map<PagingQueryResponse<User>, PagingQueryResponse<UserDto>>(users);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.LoadingUsersFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public GetRoleQueryResponse GetRole(GetRoleQueryRequest request)
        {
            var response = new GetRoleQueryResponse();

            try
            {
                var role = _membershipRepository.GetRole(request.Role);

                if (role == null)
                {
                    response.Message = MembershipQueryMessages.RoleDoesNotExist;
                    return response;
                }

                response.Role = Mapper.Map<Role, RoleDto>(role);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.LoadingUsersFaild;
                _logger.Log(exception);
            }

            return response;
        }

        public GetRolesQueryResponse GetRoles(GetRolesQueryRequest request)
        {
            var response = new GetRolesQueryResponse();

            try
            {
                var roles = _membershipRepository.GetRoles();
                response.Roles = Mapper.Map<IList<Role>, IList<RoleDto>>(roles);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.NoRoleFound;
                _logger.Log(exception);
            }

            return response;
        }

        public GetUserFavoriteQueryResponse GetUserFavorites(GetUserFavoriteDtoQueryRequest request)
        {
            var response = new GetUserFavoriteQueryResponse();

            try
            {
                var favorites = _membershipRepository.GetUserFavorites(request);
                response.Favorites = Mapper.Map<PagingQueryResponse<Favorite>, PagingQueryResponse<FavoriteDto>>(favorites);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.NoRoleFound;
                _logger.Log(exception);
            }

            return response;
        }

        public AuthenticateQueryResponse Authenticate(AuthenticateQueryRequest request)
        {
            var response = new AuthenticateQueryResponse();

            try
            {
                if (request.Email == null || request.Password == null)
                {
                    throw new ArgumentNullException();
                }

                var user = _membershipRepository.GetUserByEmail(request.Email);

                if (user == null)
                {
                    response.Message = MembershipQueryMessages.UserDoesNotExist;
                    response.Failed = true;
                    return response;
                }

                if (!Cryptography.IsValidated(request.Password, user.Password))
                {
                    response.Failed = true;
                    response.Message = MembershipQueryMessages.AuthenticationFaild;
                    return response;
                }

                response.Failed = false;
                response.User = Mapper.Map<User, UserDto>(user);
                response.Message = MembershipQueryMessages.Authenticated;
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = MembershipQueryMessages.AuthenticationFaild;
                _logger.Log(exception);
            }
          
            return response;
        }
    }
}
