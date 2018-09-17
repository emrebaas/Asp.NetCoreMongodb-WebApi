using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver;
using DotNetWepApiMongoDb.Models;
using System.Linq.Expressions;

namespace DotNetWepApiMongoDb.Services
{
    public class MongoDbServicesSevenDayData
    {

        private IMongoCollection<SevenDayDateModel> SevenDayCollection { get; }


        //Veritabanı Bağlantısının Kodlanması
        public MongoDbServicesSevenDayData(string databasename, string colletcionname, string databaseurl)
        {
            var mongoclient = new MongoClient(databaseurl);
            var mongoDatabase = mongoclient.GetDatabase(databasename);
            SevenDayCollection = mongoDatabase.GetCollection<SevenDayDateModel>(colletcionname);
        }


        //Veritabanı İçerik ekleme
        public async Task InsertTahmin(SevenDayDateModel tahmin) => await SevenDayCollection.InsertOneAsync(tahmin);


        //Veritabanı tüm içeriği json olarak göstermek için
        public List<SevenDayDateModel> GetAllTahmin()
        {

            return SevenDayCollection.AsQueryable<SevenDayDateModel>().ToList();
        }


        //Veritabanı girilen id ye göre içerik göstermek için
        public SevenDayDateModel GetOneTahmin(String id)
        {
            return SevenDayCollection.AsQueryable<SevenDayDateModel>().Single(x => x.sehir == id);
        }


        //Veritabanı girilen id ye göre içerik silme
        public async Task<bool> DeleteTahmin(ObjectId il)
        {

            try

            {
                DeleteResult actionResult = await SevenDayCollection.DeleteOneAsync(Builders<SevenDayDateModel>.Filter.Eq(x => x._id, il));

                Boolean deger = actionResult.IsAcknowledged && actionResult.DeletedCount > 0;

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        //Veritabanı id ye göre girilen veri setini güncelleme
        public async Task<bool> UpdateTahmin(ObjectId id, SevenDayDateModel g)
        {
            var filter = Builders<SevenDayDateModel>.Filter.Eq(x => x._id, id);
            var update = Builders<SevenDayDateModel>.Update
                            .Set(s => s._id, id)
                            .Set(s => s.plaka, g.plaka)
                            .Set(s => s.sehir, g.sehir)
                            .Set(s => s.g1d, g.g1d)
                            .Set(s => s.g1des, g.g1des)
                            .Set(s => s.g1r, g.g1r)
                            .Set(s => s.g1temp, g.g1temp)

                            .Set(s => s.g2d, g.g2d)
                            .Set(s => s.g2des, g.g2des)
                            .Set(s => s.g2r, g.g2r)
                            .Set(s => s.g2temp, g.g2temp)

                            .Set(s => s.g3d, g.g3d)
                            .Set(s => s.g3des, g.g3des)
                            .Set(s => s.g3r, g.g3r)
                            .Set(s => s.g3temp, g.g3temp)

                            .Set(s => s.g4d, g.g4d)
                            .Set(s => s.g4des, g.g4des)
                            .Set(s => s.g4r, g.g4r)
                            .Set(s => s.g4temp, g.g4temp)

                            .Set(s => s.g5d, g.g5d)
                            .Set(s => s.g5des, g.g5des)
                            .Set(s => s.g5r, g.g5r)
                            .Set(s => s.g5temp, g.g5temp);

            try
            {
                UpdateResult actionResult = await SevenDayCollection.UpdateOneAsync(filter, update);
                Boolean upd = actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }




    }
}
