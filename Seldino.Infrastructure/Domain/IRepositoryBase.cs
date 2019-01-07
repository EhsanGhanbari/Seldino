using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seldino.Infrastructure.Domain
{
    public interface IRepositoryBase<TEntity> where TEntity : IAggregateRoot
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void AddBulk(IEnumerable<TEntity> entities);

        void AddBulkAsync(IEnumerable<TEntity> entities);

        void Edit(TEntity entity);

        void EditBulk(IEnumerable<TEntity> entities);

        void EditBulkAsync(IEnumerable<TEntity> entities);

        void Remove(Guid id);

        void Remove(Func<TEntity, Guid> predicate);

        void RemoveRange(IEnumerable<TEntity> entities);

        void RemoveBulk(IEnumerable<TEntity> entities);

        void RemoveBulkAsync(IEnumerable<TEntity> entities);

        void MergeBulk(IEnumerable<TEntity> entities);

        void MergeBulkAsync(IEnumerable<TEntity> entities);

        int Count(TEntity entity);

        bool Exist(Expression<Func<TEntity, bool>> expression);

        TEntity GetById(Guid id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> ListBy(Expression<Func<TEntity, bool>> query);

        IList<TEntity> GetAll();

        PagingQueryResponse<TEntity> GetAll(int pageIndex, int pageSize);

        PagingQueryResponse<TEntity> GetAll(int pageIndex, int pageSize, int count);

        PagingQueryResponse<TEntity> GetAll(Func<TEntity, bool> expressionQuery, int pageIndex, int pageSize);

        PagingQueryResponse<TEntity> GetAll(Expression<Func<TEntity, bool>> expressionQuery, int pageIndex, int pageSize);

        IList<TEntity> GetAll(ISpecification<TEntity> specification);

        PagingQueryResponse<TEntity> GetAll(ISpecification<TEntity> specification, int pageIndex, int pageSize);
    }
}
