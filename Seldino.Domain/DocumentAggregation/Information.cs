using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.DocumentAggregation
{
    public class Information : EntityBase
    {
        public string Body { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
