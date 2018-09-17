using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWepApiMongoDb.Models
{
    public class ForcastModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("GenelDurum")]
        public string GenelDurum { get; set; }

    }
}
