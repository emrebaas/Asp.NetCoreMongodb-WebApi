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
    [Route("api/Forcast")]
    [ApiController]
    public class ForcastController : Controller
    {

        // GET: api/HavaDurumu
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongodbservice = new MongoDbServicesForcast("HDTest", "Forcast", "mongodb://127.0.0.1:27017");
            var tumtahminler = mongodbservice.GetAllTahmin();

            return Json(tumtahminler);

        }




        // POST: api/HavaDurumu
        [HttpPost]
        public async Task Post([FromBody] ForcastModel tahmin)
        {
            var mongodbservice = new MongoDbServicesForcast("HDTest", "Forcast", "mongodb://127.0.0.1:27017");
            await mongodbservice.InsertTahmin(tahmin);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var mongodbservice = new MongoDbServicesForcast("HDTest", "Forcast", "mongodb://127.0.0.1:27017");
            mongodbservice.DeleteTahmin(new ObjectId(id));

        }


        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] ForcastModel value)
        {
            var mongodbservice = new MongoDbServicesForcast("HDTest", "Forcast", "mongodb://127.0.0.1:27017");
            await mongodbservice.UpdateTahmin(new ObjectId(id), value);
        }


    }
}
