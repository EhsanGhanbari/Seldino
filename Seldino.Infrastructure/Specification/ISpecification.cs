using System;
using System.Linq.Expressions;

namespace Seldino.Infrastructure.Specification
{
    /// <summary>
    /// More info about Specification pattern
    /// http://lostechies.com/chrismissal/2009/09/11/using-the-specification-pattern-for-querying/
    /// http://en.wikipedia.org/wiki/Specification_pattern#C.23
    /// https://architectbetter.wordpress.com/2011/05/11/understanding-specification-pattern-with-linq-part-2/
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity candidate);
        Expression<Func<TEntity, bool>> IsSatisfied();
        ISpecification<TEntity> And(ISpecification<TEntity> other);
        ISpecification<TEntity> Or(ISpecification<TEntity> other);
        ISpecification<TEntity> Not();
        ISpecification<TEntity> OrderBy(ISpecification<TEntity> other);
        ISpecification<TEntity> Take(int amount);
        ISpecification<TEntity> Skip(int amount);
    }
}
