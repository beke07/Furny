using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;

namespace Furny.MappingProfiles
{
    public class PanelCutterMappingProfiles : Profile
    {
        public PanelCutterMappingProfiles()
        {
            CreateMap<PanelCutterProfileCommand, PanelCutter>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<ProfileAddressResolver>())
                .ReverseMap()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<Ad, DesignerAdCommand>()
                .ForMember(e => e.HourAgo, opt => opt.MapFrom<DesignerAdResolver>());

            CreateMap<MaterialCommand, Material>().ReverseMap();
            CreateMap<MaterialTableCommand, Material>().ReverseMap();
            CreateMap<ClosingTableCommand, Closing>().ReverseMap();
            CreateMap<ClosingCommand, Closing>().ReverseMap();
            CreateMap<AdCommand, Ad>().ReverseMap();
            CreateMap<AdTableCommand, Ad>().ReverseMap();
        }
    }
}
