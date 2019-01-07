using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;
using Seldino.Infrastructure.Specification;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Seldino.Domain.ProductAggregation;
using Seldino.Repository.DataContexts;
using SqlBulkTools;

namespace Seldino.Repository
{
    /// <summary>
    /// BulkOperation https://github.com/gtaylor44/SqlBulkTools
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        private DataContext _dataContext;
        private ReadOnlyDataContext _readOnlyDataContext;

        private readonly IDbSet<TEntity> _dbset;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<TEntity>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected DataContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.GetDataContext());

        protected ReadOnlyDataContext ReadOnlyDataContext => _readOnlyDataContext ?? (_readOnlyDataContext = DatabaseFactory.GetReadOnlyDataContext());

        public void Add(TEntity entity)
        {
            var entityBase = SetEntityBaseValueForAdd(entity);
            _dbset.Add(entityBase);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            ((DbSet<TEntity>)_dbset).AddRange(entities);
        }

        public void AddBulk(IEnumerable<TEntity> entities)
        {
            var bulkOperation = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperation.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddAllColumns()
                        .BulkInsert()
                        .SetIdentityColumn(x => x.Id, ColumnDirection.Output)
                        .Commit(connection);
                }

                trans.Complete();
            }
        }

        public async void AddBulkAsync(IEnumerable<TEntity> entities)
        {
            var bulkOperation = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperation.Setup<TEntity>()
                        .ForCollection(entities)
                       .WithTable(typeof(TEntity).Name)
                        .AddAllColumns()
                        .BulkInsert()
                        .SetIdentityColumn(x => x.Id, ColumnDirection.Output)
                        .Commit(connection);
                }

                trans.Complete();
            }
        }

        public void Edit(TEntity entity)
        {
            var entityBase = SetEntityBaseValueForEdit(entity);
            _dbset.Attach(entityBase);
            _dataContext.Entry(entityBase).State = EntityState.Modified;
        }

        public void EditBulk(IEnumerable<TEntity> entities)
        {
            var bulkOperation = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperation.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddColumn(x => x.CreationDate) //ToDo
                        .BulkUpdate()
                        .MatchTargetOn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }

        public async void EditBulkAsync(IEnumerable<TEntity> entities)
        {
            var bulkOperation = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperation.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddColumn(x => x.CreationDate) //ToDo
                        .BulkUpdate()
                        .MatchTargetOn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }

        public void Remove(Guid id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
        }

        public void Remove(Func<TEntity, Guid> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            ((DbSet<TEntity>)_dbset).RemoveRange(entities);
        }

        public void RemoveBulk(IEnumerable<TEntity> entities)
        {
            var bulkOperation = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperation.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddColumn(x => x.Id)
                        .BulkDelete()
                        .MatchTargetOn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }

        public async void RemoveBulkAsync(IEnumerable<TEntity> entities)
        {
            var bulkOperation = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperation.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddColumn(x => x.Id)
                        .BulkDelete()
                        .MatchTargetOn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }

        public void MergeBulk(IEnumerable<TEntity> entities)
        {
            var bulkOperations = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperations.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddColumn(x => x.Id) //ToDo should pass the parameter
                        .BulkInsertOrUpdate()
                        .MatchTargetOn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }

        public async void MergeBulkAsync(IEnumerable<TEntity> entities)
        {
            var bulkOperations = new BulkOperations();

            using (var trans = new TransactionScope())
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Seldino"].ConnectionString))
                {
                    bulkOperations.Setup<TEntity>()
                        .ForCollection(entities)
                        .WithTable(typeof(TEntity).Name)
                        .AddColumn(x => x.Id) //ToDo should pass the parameter
                        .BulkInsertOrUpdate()
                        .MatchTargetOn(x => x.Id)
                        .Commit(conn);
                }

                trans.Complete();
            }
        }

        public int Count(TEntity entity)
        {
            return _dbset.Count();
        }

        public bool Exist(Expression<Func<TEntity, bool>> expression)
        {
            return _dbset.Where(expression).Any();
        }

        public TEntity GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault();
        }

        public IList<TEntity> ListBy(Expression<Func<TEntity, bool>> query)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> GetAll()
        {
            return _dbset.ToList();
        }

        public PagingQueryResponse<TEntity> GetAll(int pageIndex, int pageSize)
        {
            var total = _dbset.AsNoTracking().Count();

            var result = new PagingQueryResponse<TEntity>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total,
                Result = _dataContext.Set<TEntity>().OrderBy(c => c.CreationDate)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<TEntity> GetAll(int pageIndex, int pageSize, int count)
        {
            var total = _dbset.AsNoTracking().Count();

            var result = new PagingQueryResponse<TEntity>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total,
                Result = _dataContext.Set<TEntity>().OrderBy(c => c.CreationDate)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).Take(count).ToList()
            };

            return result;
        }

        public PagingQueryResponse<TEntity> GetAll(Func<TEntity, bool> expressionQuery, int pageIndex, int pageSize)
        {
            var total = _dbset.AsNoTracking().Count();

            var result = new PagingQueryResponse<TEntity>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total,
                Result = _dataContext.Set<TEntity>().OrderBy(c => c.CreationDate)
                .Where(expressionQuery).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<TEntity> GetAll(Expression<Func<TEntity, bool>> expressionQuery, int pageIndex, int pageSize)
        {
            var total = _dbset.AsNoTracking().Count();

            var result = new PagingQueryResponse<TEntity>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total,
                Result = _dataContext.Set<TEntity>()
                .Where(expressionQuery).OrderBy(c => c.CreationDate)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };

            return result;
        }

        public IList<TEntity> GetAll(ISpecification<TEntity> specification)
        {
            return _dbset.Where(specification.IsSatisfied()).ToList();
        }

        public PagingQueryResponse<TEntity> GetAll(ISpecification<TEntity> specification, int pageIndex, int pageSize)
        {
            var total = _dbset.AsNoTracking().Count();

            var result = new PagingQueryResponse<TEntity>
            {
                PageSize = pageSize,
                CurrentPage = pageIndex,
                TotalCount = total,
                Result = _dataContext.Set<TEntity>()
                .OrderBy(c => c.CreationDate).Where(specification.IsSatisfied())
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };

            return result;
        }

        private static TEntity SetEntityBaseValueForAdd(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreationDate = DateTime.Now;
            entity.LastUpdateDate = DateTime.Now;
            entity.IsDeleted = false;
            return entity;
        }

        private static TEntity SetEntityBaseValueForEdit(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            return entity;
        }
    }
}