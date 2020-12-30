using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using NetCore.Angular.Mongodb.Data.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Angular.Mongodb.Data
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            ProductMap.Configure();

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
