using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.MembershipAggregation
{
    public class Profile : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CellPhone { get; set; }

        public DateTime? BirthDate { get; set; }

        public Guid? AvatarId { get; set; }

        public virtual ProfileAvatar Avatar { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
