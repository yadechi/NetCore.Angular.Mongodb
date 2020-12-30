using MongoDB.Driver;
using NetCore.Angular.Mongodb.Contracts.Interfaces;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Angular.Mongodb.Data
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDbContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        public BaseRepository(IMongoDbContext mongoDbContext)
        {
            _mongoContext = mongoDbContext;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Create(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _mongoContext.AddCommand(() => _dbCollection.InsertOneAsync(obj));
        }

        public virtual void Update(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _mongoContext.AddCommand(() => _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public virtual void Delete(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            _mongoContext.AddCommand(() => _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId())));
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            var result = data.SingleOrDefault();

            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var data = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            var result = data.ToList();

            return result;
        }

        public void Dispose()
        {
            _mongoContext?.Dispose();
        }
    }
}
