using AutoMapper;
using Furny.Data;
using Furny.MappingProfiles;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;
using Furny.Seed;
using Furny.ServiceInterfaces;
using Furny.Services;
using Furny.Test.Helper;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Furny.Test
{
    public class MongoDbTest
    {
        protected readonly IConfiguration _configuration;
        protected readonly IMapper _mapper;
        protected readonly IAddressService _addressService;
        protected readonly IMongoDatabase _database;

        public MongoDbTest()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _database = new MongoClient(_configuration.GetConnectionString("FurnyDb"))
                .GetDatabase("FurnyDb");

            _addressService = new AddressService(_configuration);

            var panelCutterService = new PanelCutterService(_mapper, _configuration);
            var designerService = new DesignerService(_mapper, panelCutterService, _configuration);

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>() {
                    new CommonMappingProfiles(),
                    new AuthMappingProfiles(),
                    new TestDesignerMappingProfiles(),
                    new TestPanelCutterMappingProfiles(),
                    new TestOfferMappingProfiles()
                });

                cfg.CreateMap<OfferComponentDto, OfferComponent>()
                    .ForMember(e => e.Component, opt => opt.MapFrom(new ComponentResolver(designerService)))
                    .ForMember(e => e.Closing, opt => opt.MapFrom(new ClosingResolver(panelCutterService)))
                    .ForMember(e => e.Material, opt => opt.MapFrom(new MaterialResolver(panelCutterService)))
                    .ReverseMap();

                cfg.CreateMap<PanelCutterProfileDto, PanelCutter>()
                    .ForMember(e => e.UserAddress, opt => opt.MapFrom(new ProfileAddressResolver(_addressService)))
                    .ReverseMap()
                    .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                    .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

                cfg.CreateMap<DesignerProfileDto, Designer>()
                    .ForMember(e => e.UserAddress, opt => opt.MapFrom(new ProfileAddressResolver(_addressService)))
                    .ReverseMap()
                    .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                    .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

                cfg.CreateMap<FurnitureDto, Furniture>()
                    .ForMember(e => e.Moduls, opt => opt.MapFrom(new ModulResolver(designerService)))
                    .ReverseMap()
                    .ForPath(e => e.Moduls, opt => opt.MapFrom(e => e.Moduls.Select(m => m.Id.ToString())));
            }));

            DataSeeder.SeedAddressesAsync(_configuration.GetConnectionString("FurnyDb"))
                .GetAwaiter()
                .GetResult();

            DataSeeder.SeedUsersAsync(_configuration.GetConnectionString("FurnyDb"))
                .GetAwaiter()
                .GetResult();
        }
    }
}
