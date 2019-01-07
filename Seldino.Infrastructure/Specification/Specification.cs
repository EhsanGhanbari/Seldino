using System;
using System.Linq.Expressions;

namespace Seldino.Infrastructure.Specification
{
    public abstract class Specification<TEntity> : ISpecification<TEntity>
    {
        public abstract bool IsSatisfiedBy(TEntity candidate);

        public abstract Expression<Func<TEntity, bool>> IsSatisfied();

        public ISpecification<TEntity> And(ISpecification<TEntity> other)
        {
            return new AndSpecification<TEntity>(this, other);
        }

        public ISpecification<TEntity> Or(ISpecification<TEntity> other)
        {
            return new OrSpecification<TEntity>(this, other);
        }

        public ISpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        public ISpecification<TEntity> OrderBy(ISpecification<TEntity> other)
        {
           return new OrderBySpecification<TEntity>(this);
        }

        public ISpecification<TEntity> Take(int amount)
        {
            throw new NotImplementedException();
        }

        public ISpecification<TEntity> Skip(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
