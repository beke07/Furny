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
            CreateMap<PanelCutterProfileDto, PanelCutter>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<ProfileAddressResolver>())
                .ReverseMap()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<Ad, DesignerAdDto>()
                .ForMember(e => e.HourAgo, opt => opt.MapFrom<DesignerAdResolver>());

            CreateMap<MaterialDto, Material>().ReverseMap();
            CreateMap<MaterialTableDto, Material>().ReverseMap();
            CreateMap<ClosingTableDto, Closing>().ReverseMap();
            CreateMap<ClosingDto, Closing>().ReverseMap();
            CreateMap<AdDto, Ad>().ReverseMap();
            CreateMap<AdTableDto, Ad>().ReverseMap();
        }
    }
}
