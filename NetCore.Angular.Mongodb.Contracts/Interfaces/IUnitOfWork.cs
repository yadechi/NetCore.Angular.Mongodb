using System;
using System.Threading.Tasks;

namespace NetCore.Angular.Mongodb.Contracts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
