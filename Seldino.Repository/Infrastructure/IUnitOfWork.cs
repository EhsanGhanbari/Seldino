using System;

namespace Seldino.Repository.Infrastructure
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}