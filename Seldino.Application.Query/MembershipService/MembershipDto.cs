using Seldino.Application.Query.ProductService;
using Seldino.Application.Query.StoreService;
using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.MembershipService
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public RoleDto Role { get; set; }

        public string Password { get; set; }

        public ProfileDto Profile { get; set; }
    }

    public class ProfileDto
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CellPhone { get; set; }

        public DateTime BirthDate { get; set; }

        public ProfileAvatarDto Avatar { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }

    public class RoleDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class ProfileAvatarDto
    {
        public Guid AvatarId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }

    public class FavoriteDto
    {
        public int Number { get; set; }

        public string Description { get; set; }

        public IList<ProductDto> Product { get; set; }

        public IList<StoreDto> Store { get; set; }
    }
}
