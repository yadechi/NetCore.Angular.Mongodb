using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Angular.Mongodb.Contracts.Interfaces
{
    public interface IUniversityDbSettings
    {
        public string StudentsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
