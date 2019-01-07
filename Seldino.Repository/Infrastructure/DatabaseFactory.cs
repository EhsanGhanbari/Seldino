using Seldino.Repository.DataContexts;

namespace Seldino.Repository.Infrastructure
{
    internal class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DataContext _dataContext;
        private ReadOnlyDataContext _readOnlyDataContext;

        public DataContext GetDataContext()
        {
            return _dataContext ?? (_dataContext = new DataContext());
        }

        public ReadOnlyDataContext GetReadOnlyDataContext()
        {
            return _readOnlyDataContext ?? (_readOnlyDataContext = new ReadOnlyDataContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}