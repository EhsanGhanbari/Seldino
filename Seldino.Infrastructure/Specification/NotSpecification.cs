using System;
using System.Linq.Expressions;

namespace Seldino.Infrastructure.Specification
{
    internal class NotSpecification<TEntity> : Specification<TEntity>
    {
        private readonly ISpecification<TEntity> _innerSpecification;

        public NotSpecification(ISpecification<TEntity> innerSpecification)
        {
            _innerSpecification = innerSpecification;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return !_innerSpecification.IsSatisfiedBy(candidate);
        }

        public override Expression<Func<TEntity, bool>> IsSatisfied()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(_innerSpecification.IsSatisfied()));
        }
    }
}
