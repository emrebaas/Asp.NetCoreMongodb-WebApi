using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetWepApiMongoDb.Models;
using DotNetWepApiMongoDb.Services;
using MongoDB.Bson;

namespace DotNetWepApiMongoDb.Controllers
{
    [Route("api/Sevenday")]
    [ApiController]
    public class SevendayController : Controller
    {

        // GET: api/HavaDurumu
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongodbservice = new MongoDbServicesSevenDayData("HDTest", "SevenDayData", "mongodb://127.0.0.1:27017");
            var tumtahminler = mongodbservice.GetAllTahmin();

            return Json(tumtahminler);

        }


        // GET: api/HavaDurumu/5
        [HttpGet("{id}", Name = "GetSevenday")]
        public async Task<JsonResult> GetOneTahmin(string id)
        {
            var mongodbservice = new MongoDbServicesSevenDayData("HDTest", "SevenDayData", "mongodb://127.0.0.1:27017");
            var liste = mongodbservice.GetOneTahmin(id);


            return Json(liste);

        }


        // POST: api/HavaDurumu
        [HttpPost]
        public async Task Post([FromBody] SevenDayDateModel tahmin)
        {
            var mongodbservice = new MongoDbServicesSevenDayData("HDTest", "SevenDayData", "mongodb://127.0.0.1:27017");
            await mongodbservice.InsertTahmin(tahmin);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var mongodbservice = new MongoDbServicesSevenDayData("HDTest", "SevenDayData", "mongodb://127.0.0.1:27017");
            mongodbservice.DeleteTahmin(new ObjectId(id));

        }


        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] SevenDayDateModel value)
        {
            var mongodbservice = new MongoDbServicesSevenDayData("HDTest", "SevenDayData", "mongodb://127.0.0.1:27017");
            await mongodbservice.UpdateTahmin(new ObjectId(id), value);
        }


    }
}
