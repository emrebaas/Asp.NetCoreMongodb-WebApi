using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWepApiMongoDb.Models
{
    public class SevenDayDateModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("plaka")]
        public int plaka { get; set; }

        [BsonElement("sehir")]
        public string sehir { get; set; }

        [BsonElement("g1d")]
        public string g1d { get; set; }

        [BsonElement("g1temp")]
        public double g1temp { get; set; }

        [BsonElement("g1des")]
        public string g1des { get; set; }

        [BsonElement("g1r")]
        public double g1r { get; set; }



        [BsonElement("g2d")]
        public string g2d { get; set; }

        [BsonElement("g2temp")]
        public double g2temp { get; set; }

        [BsonElement("g2des")]
        public string g2des { get; set; }

        [BsonElement("g2r")]
        public double g2r { get; set; }




        [BsonElement("g3d")]
        public string g3d { get; set; }

        [BsonElement("g3temp")]
        public double g3temp { get; set; }

        [BsonElement("g3des")]
        public string g3des { get; set; }

        [BsonElement("g3r")]
        public double g3r { get; set; }


        [BsonElement("g4d")]
        public string g4d { get; set; }

        [BsonElement("g4temp")]
        public double g4temp { get; set; }

        [BsonElement("g4des")]
        public string g4des { get; set; }

        [BsonElement("g4r")]
        public double g4r { get; set; }


        [BsonElement("g5d")]
        public string g5d { get; set; }

        [BsonElement("g5temp")]
        public double g5temp { get; set; }

        [BsonElement("g5des")]
        public string g5des { get; set; }

        [BsonElement("g5r")]
        public double g5r { get; set; }
    }
}
