using AutoMapper;
using Furny.MappingProfiles;
using Furny.Seed;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Furny.Test
{
    public class MongoDbTest
    {
        protected readonly IConfiguration _configuration;
        protected readonly IMapper _mapper;

        public MongoDbTest()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() {
                    new CommonMappingProfiles(),
                    new AuthMappingProfiles(),
                    new DesignerMappingProfiles(),
                    new PanelCutterMappingProfiles(),
                    new OfferMappingProfiles()
                });

            });

            _mapper = new Mapper(mapperConfiguration);

            DataSeeder.SeedAddressesAsync(_configuration.GetConnectionString("FurnyDb"))
                .GetAwaiter()
                .GetResult();

            DataSeeder.SeedUsersAsync(_configuration.GetConnectionString("FurnyDb"))
                .GetAwaiter()
                .GetResult();
        }
    }
}
