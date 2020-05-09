using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class BaseService
    {
        protected IMongoDatabase _database { get; set; }

        public BaseService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("FurnyDb"));
            _database = client.GetDatabase("FurnyDb");
        }
    }
}
