using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Angular.Mongodb.Contracts.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll();

        void Create(TEntity obj);

        void Update(TEntity obj);

        void Delete(TEntity obj);
    }
}
