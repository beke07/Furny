using Furny.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Furny.Seed
{
    public class DataSeeder
    {
        private const string ConnectionString = "mongodb://mongo:27017";

        public static async Task SeedAddressesAsync()
        {
            var path = $"{System.AppDomain.CurrentDomain.BaseDirectory}Seed/adresses.json";
            var json = File.ReadAllText(path);
            var adresses = JsonConvert.DeserializeObject<IList<Address>>(json);

            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase("FurnyDb");
            var collection = database.GetCollection<Address>("addresses");

            if(await collection.Find(s => true).CountDocumentsAsync() == 0)
            {
                await collection.InsertManyAsync(adresses);
            }
        }
    }
}
