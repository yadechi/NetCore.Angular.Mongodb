using MongoDB.Bson.Serialization;
using NetCore.Angular.Mongodb.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Angular.Mongodb.Data.Persistence
{
    public class ProductMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Student>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.InternalId);

            });
        }
    }
}
