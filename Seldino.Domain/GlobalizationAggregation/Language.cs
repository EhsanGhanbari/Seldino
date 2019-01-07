using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.GlobalizationAggregation
{
    public class Language : EntityBase, IAggregateRoot
    {
        public string CultureCode { get; set; }

        public string Name { get; set; }

        public bool IsRightToLeft { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
