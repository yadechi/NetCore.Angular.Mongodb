using NetCore.Angular.Mongodb.Contracts.Interfaces;
using NetCore.Angular.Mongodb.Contracts.Models;
using NetCore.Angular.Mongodb.Data;

namespace NetCore.Angular.Mongodb.Database.Repositories.Students
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {

        public StudentRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext)
        {

        }
    }
}
