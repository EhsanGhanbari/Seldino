using System;
using System.Linq.Expressions;

namespace Seldino.Infrastructure.Specification
{
    internal class AndSpecification<TEntity> : Specification<TEntity> 
    {
        private readonly ISpecification<TEntity> _leftSpecification;
        private readonly ISpecification<TEntity> _rightSpecification;

        public AndSpecification(ISpecification<TEntity> leftSpecification, ISpecification<TEntity> rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return _leftSpecification.IsSatisfiedBy(candidate) || _rightSpecification.IsSatisfiedBy(candidate);
        }

        public override Expression<Func<TEntity, bool>> IsSatisfied()
        {
            return _leftSpecification.IsSatisfied().And(_rightSpecification.IsSatisfied());
        }
    }
}
