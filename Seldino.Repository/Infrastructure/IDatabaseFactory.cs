using System;
using Seldino.Repository.DataContexts;

namespace Seldino.Repository.Infrastructure
{
    internal interface IDatabaseFactory : IDisposable
    {
        DataContext GetDataContext();

        ReadOnlyDataContext GetReadOnlyDataContext();
    }
}