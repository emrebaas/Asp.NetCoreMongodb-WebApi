using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWepApiMongoDb.Models
{
    public class DataModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("plaka")]
        public int plaka { get; set; }

        [BsonElement("ulke")]
        public string ulke { get; set; }

        [BsonElement("sehir")]
        public string sehir { get; set; }

        [BsonElement("temp")]
        public double temp { get; set; }

        [BsonElement("temp_min")]
        public double temp_min { get; set; }

        [BsonElement("temp_max")]
        public double temp_max { get; set; }

        [BsonElement("nem")]
        public double nem { get; set; }

        [BsonElement("basınc")]
        public double basınc { get; set; }

        [BsonElement("ruzgarhiz")]
        public double ruzgarhiz { get; set; }
    }
}

