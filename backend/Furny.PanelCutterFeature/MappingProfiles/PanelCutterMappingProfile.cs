using AutoMapper;
using Furny.DesignerFeature.MappingProfiles.Resolvers;
using Furny.Model;
using Furny.PanelCutterFeature.Commands;
using Furny.PanelCutterFeature.Data;
using Furny.PanelCutterFeature.ViewModels;

namespace Furny.PanelCutterFeature.MappingProfiles
{
    public class PanelCutterMappingProfile : Profile
    {
        public PanelCutterMappingProfile()
        {
            CreateMap<PanelCutterProfileDto, PanelCutter>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<PanelCutterProfileAddressResolver>())
                .ReverseMap()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<PanelCutter, PanelCutterProfileViewModel>()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));
        }
    }
}
