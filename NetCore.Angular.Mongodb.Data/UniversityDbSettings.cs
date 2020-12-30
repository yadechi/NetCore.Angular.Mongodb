using NetCore.Angular.Mongodb.Contracts.Interfaces;

namespace NetCore.Angular.Mongodb.Data
{
    public class UniversityDbSettings : IUniversityDbSettings
    {
        public string StudentsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
