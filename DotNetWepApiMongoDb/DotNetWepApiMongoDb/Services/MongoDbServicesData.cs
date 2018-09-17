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
    public class MongoDbServicesData
    {

        private IMongoCollection<DataModel> DataCollection { get; }


        //Veritabanı Bağlantısının Kodlanması
        public MongoDbServicesData(string databasename,string colletcionname,string databaseurl)
        {
            var mongoclient = new MongoClient(databaseurl);
            var mongoDatabase = mongoclient.GetDatabase(databasename);
            DataCollection = mongoDatabase.GetCollection<DataModel>(colletcionname);
        }


        //Veritabanı İçerik ekleme
        public async Task InsertTahmin(DataModel tahmin) => await DataCollection.InsertOneAsync(tahmin);


        //Veritabanı tüm içeriği json olarak göstermek için
        public  List<DataModel> GetAllTahmin()
        {

            return DataCollection.AsQueryable<DataModel>().ToList();
        }


        //Veritabanı girilen id ye göre içerik göstermek için

        public DataModel GetOneTahmin(ObjectId id)
        {

            return DataCollection.AsQueryable<DataModel>().SingleOrDefault(a => a._id == id);
        }



        //Veritabanı girilen id ye göre içerik silme
        public async Task<bool> DeleteTahmin(ObjectId id)
        {
            
            try

            {
                DeleteResult actionResult = await DataCollection.DeleteOneAsync(Builders<DataModel>.Filter.Eq(x=>x._id, id));

               Boolean deger= actionResult.IsAcknowledged && actionResult.DeletedCount > 0;

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


        //Veritabanı id ye göre girilen veri setini güncelleme
        public async Task<bool> UpdateTahmin(ObjectId id, DataModel g)
        {
            var filter = Builders<DataModel>.Filter.Eq(x=>x._id, id);
            var update = Builders<DataModel>.Update
                            .Set(s=>s._id,id)
                            .Set(s => s.plaka, g.plaka)
                            .Set(s => s.ulke, g.ulke)
                            .Set(s => s.sehir, g.sehir)
                            .Set(s => s.temp, g.temp)
                            .Set(s => s.temp_max, g.temp_max)
                            .Set(s => s.temp_min, g.temp_min)
                            .Set(s => s.basınc, g.basınc)
                            .Set(s => s.nem, g.nem)
                            .Set(s=>s.ruzgarhiz,g.ruzgarhiz);

            try
            {
                UpdateResult actionResult = await DataCollection.UpdateOneAsync(filter, update);
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
