using System;
using Seldino.Repository.DataContexts;

namespace Seldino.Repository.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private DataContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected DataContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.GetDataContext()); }
        }

        public void Commit()
        {
            using (var dbContextTransaction = DataContext.Database.BeginTransaction())
            {
                try
                {
                    DataContext.Commit();
                    dbContextTransaction.Commit();
                }
                catch (Exception exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DataContext != null)
                {
                    DataContext.Dispose();
                }
            }
        }
    }
}