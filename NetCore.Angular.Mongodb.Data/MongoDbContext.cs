using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NetCore.Angular.Mongodb.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Angular.Mongodb.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly List<Func<Task>> _commands;

        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }


        public MongoDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            // Every command will be stored and it will be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            ConfigureMongo();

            var data = Database.GetCollection<T>(name);

            return data;
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient(_configuration["UniversityDatabaseSettings:Connection"]);
            Database = MongoClient.GetDatabase(_configuration["UniversityDatabaseSettings:DatabaseName"]);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
