using System;
using System.Collections.Generic;

namespace Seldino.Infrastructure.Domain
{
    public abstract class EntityBase
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool IsDeleted { get; set; }

        protected abstract void Validate();

        public virtual IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}
