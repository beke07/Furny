using Furny.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Furny.Seed
{
    public class DataSeeder
    {
        private const string ConnectionString = "mongodb://mongo:27017";

        public static async Task SeedAddressesAsync(string connectionString = ConnectionString)
        {
            var path = $"{System.AppDomain.CurrentDomain.BaseDirectory}Seed/adresses.json";
            var json = File.ReadAllText(path);
            var adresses = JsonConvert.DeserializeObject<IList<Address>>(json);

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnyDb");
            var collection = database.GetCollection<Address>("addresses");

            await database.DropCollectionAsync("addresses");

            if (await collection.Find(s => true).CountDocumentsAsync() == 0)
            {
                await collection.InsertManyAsync(adresses);
            }
        }

        public static async Task SeedUsersAsync(string connectionString = ConnectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("FurnyDb");

            await database.DropCollectionAsync("applicationRoles");
            await database.DropCollectionAsync("applicationUsers");

            var desginerCutterCollection = database.GetCollection<Designer>("applicationUsers");
            var panelCutterCollection = database.GetCollection<PanelCutter>("applicationUsers");
            var roleCollection = database.GetCollection<ApplicationRole>("applicationRoles");
            var addressCollection = database.GetCollection<Address>("addresses");

            await roleCollection.InsertManyAsync(new List<ApplicationRole>() {
                new ApplicationRole()
                {
                    Name = RoleNames.PanelCutter
                },
                new ApplicationRole()
                {
                    Name = RoleNames.Designer
                }
            });

            await panelCutterCollection.InsertOneAsync(new PanelCutter()
            {
                Email = "panel-cutter@furny.hu",
                Name = "Panel Cutter",
                Phone = "06306324876",
                Roles = new List<ObjectId>() { roleCollection.Find(e => e.Name == RoleNames.PanelCutter).FirstOrDefault().Id },
                UserName = "panelcutter",
                Opened = "H-P 8:00-17:00",
                Facebook = "facebook/panel-cutter.hu",
                Extras = new List<string>() { 
                  "Kiszállítást vállalok"  
                },
                UserAddress = new UserAddress()
                {
                    Address = addressCollection.Find(e => true).FirstOrDefault(),
                    StreetAndHouse = "Petőfi utca 11"
                }
            });

            await desginerCutterCollection.InsertOneAsync(new Designer()
            {
                Email = "designer@furny.hu",
                Name = "Designer",
                Phone = "06306324876",
                Roles = new List<ObjectId>() { roleCollection.Find(e => e.Name == RoleNames.Designer).FirstOrDefault().Id },
                UserName = "desginer",
                UserAddress = new UserAddress()
                {
                    Address = addressCollection.Find(e => true).FirstOrDefault(),
                    StreetAndHouse = "Petőfi utca 12"
                }
            });
        }
    }
}
