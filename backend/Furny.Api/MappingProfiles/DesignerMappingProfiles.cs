using AutoMapper;
using Furny.Data;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;
using System.Linq;

namespace Furny.MappingProfiles
{
    public class DesignerMappingProfiles : Profile
    {
        public DesignerMappingProfiles()
        {
            CreateMap<DesignerProfileCommand, Designer>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<ProfileAddressResolver>())
                .ReverseMap()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<FurnitureCommand, Furniture>()
                .ForMember(e => e.Moduls, opt => opt.MapFrom<ModulResolver>())
                .ReverseMap()
                .ForPath(e => e.Moduls, opt => opt.MapFrom(e => e.Moduls.Select(m => m.Id.ToString())));

            CreateMap<ComponentCommand, Component>().ReverseMap();
            CreateMap<ComponentTableCommand, Component>().ReverseMap();
            CreateMap<ComponentClosingDto, ComponentClosing>().ReverseMap();
            CreateMap<ClosingsDto, Closings>().ReverseMap();
            CreateMap<ModulCommand, Modul>().ReverseMap();
            CreateMap<ModulTableCommand, Modul>().ReverseMap();
        }
    }
}
