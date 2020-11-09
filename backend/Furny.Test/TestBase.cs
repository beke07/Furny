using Furny.Seed;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Furny.Test
{
    public class TestBase
    {
        private const string _dbName = "FurnyTestDb";
        private readonly IConfiguration _configuration;
        protected readonly IMongoDatabase _database;
        protected readonly ServiceProvider serviceProvider;

        public TestBase()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = _configuration.GetConnectionString(_dbName);

            _database = new MongoClient(connectionString)
                .GetDatabase(_dbName);

            serviceProvider = new ServiceCollection()
                .AddMediatR()
                .AddStartupAutoMapper()
                .AddServices()
                .AddMongoIdentity(_configuration)
                .AddSingleton(_configuration)
                .BuildServiceProvider();

            DataSeeder.SeedAddressesAsync(connectionString, _dbName)
                .GetAwaiter()
                .GetResult();

            DataSeeder.SeedUsersAsync(connectionString, _dbName)
                .GetAwaiter()
                .GetResult();
        }
    }
}
