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
    public class MongoDbServicesForcast
    {

        private IMongoCollection<ForcastModel> ForcastCollection { get; }


        //Veritabanı Bağlantısının Kodlanması
        public MongoDbServicesForcast(string databasename, string colletcionname, string databaseurl)
        {
            var mongoclient = new MongoClient(databaseurl);
            var mongoDatabase = mongoclient.GetDatabase(databasename);
            ForcastCollection = mongoDatabase.GetCollection<ForcastModel>(colletcionname);
        }


        //Veritabanı İçerik ekleme
        public async Task InsertTahmin(ForcastModel tahmin) => await ForcastCollection.InsertOneAsync(tahmin);


        //Veritabanı tüm içeriği json olarak göstermek için
        public List<ForcastModel> GetAllTahmin()
        {

            return ForcastCollection.AsQueryable<ForcastModel>().ToList();
        }



        //Veritabanı girilen id ye göre içerik silme
        public async Task<bool> DeleteTahmin(ObjectId il)
        {

            try

            {
                DeleteResult actionResult = await ForcastCollection.DeleteOneAsync(Builders<ForcastModel>.Filter.Eq(x => x._id, il));

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
        public async Task<bool> UpdateTahmin(ObjectId id, ForcastModel g)
        {
            var filter = Builders<ForcastModel>.Filter.Eq(x => x._id, id);
            var update = Builders<ForcastModel>.Update
                            .Set(s => s._id, id)
                            .Set(s => s.GenelDurum, g.GenelDurum);

            try
            {
                UpdateResult actionResult = await ForcastCollection.UpdateOneAsync(filter, update);
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
