using System;
using System.Collections.Generic;
using System.Text;

namespace Seldino.Infrastructure.Domain
{
    public abstract class ValueObjectBase 
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public DateTime CreationDate { get; set; }
        public string Creator { get; set; }
        public bool IsDeleted { get; set; }

        protected static bool EqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();

            if (_brokenRules.Count <= 0) return;
            var issues = new StringBuilder();
            foreach(var businessRule in _brokenRules)
            {
                issues.AppendLine(businessRule.Rule);
            }
            throw new ValueObjectIsInvalidException(issues.ToString());
        }
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}
