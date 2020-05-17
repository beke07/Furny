using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;
using Furny.ServiceInterfaces;
using MongoDB.Bson;
using System.Linq;

namespace Furny.MappingProfiles
{
    public class DesignerMappingProfiles : Profile
    {
        public DesignerMappingProfiles()
        {
            CreateMap<DesignerProfileDto, Designer>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<ProfileAddressResolver>())
                .ReverseMap()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<FurnitureDto, Furniture>()
                .ForMember(e => e.Moduls, opt => opt.MapFrom<ModulResolver>())
                .ReverseMap()
                .ForPath(e => e.Moduls, opt => opt.MapFrom(e => e.Moduls.Select(m => m.Id.ToString())));

            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<ComponentTableDto, Component>().ReverseMap();
            CreateMap<ComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<ClosingsDto, Closings>().ReverseMap();
            CreateMap<ModulDto, Modul>().ReverseMap();
            CreateMap<ModulTableDto, Modul>().ReverseMap();
        }
    }
}
