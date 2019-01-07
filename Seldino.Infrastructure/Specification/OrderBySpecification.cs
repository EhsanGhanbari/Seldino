using System;
using System.Linq;
using System.Linq.Expressions;

namespace Seldino.Infrastructure.Specification
{
    /// <summary>
    /// http://stackoverflow.com/questions/25244030/specification-pattern-with-entity-framework-and-using-orderby-and-skip-take
    /// http://iswwwup.com/t/1e10c3e71af7/c-specification-pattern-with-entity-framework-and-using-orderby-and-skip.html
    /// http://iswwwup.com/t/1bd125b534cf/specification-pattern-and-entity-framework.html
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class OrderBySpecification<TEntity> : Specification<TEntity>
    {
        private ISpecification<TEntity> _innerSpecification;
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Sort { get; protected set; }
        public Func<IQueryable<TEntity>, IQueryable<TEntity>> PostProcess { get; protected set; }

        public OrderBySpecification(ISpecification<TEntity> innerSpecification)
        {
            _innerSpecification = innerSpecification;
        }

        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return !_innerSpecification.IsSatisfiedBy(candidate);
        }

        public override Expression<Func<TEntity, bool>> IsSatisfied()
        {
            //return Expression.Lambda<Func<TEntity, bool>>(Expression.(_innerSpecification.IsSatisfied()));
            throw new NotImplementedException();
        }
    }
}
