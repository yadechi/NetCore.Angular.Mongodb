using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCore.Angular.Mongodb.Contracts.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
