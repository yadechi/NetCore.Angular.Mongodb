using System;
using System.Threading.Tasks;
using NetCore.Angular.Mongodb.Contracts.Interfaces;

namespace NetCore.Angular.Mongodb.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDbContext _mongoDbContext;

        public UnitOfWork(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext ?? throw new ArgumentNullException(nameof(mongoDbContext));
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _mongoDbContext.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _mongoDbContext.Dispose();
        }
    }
}
