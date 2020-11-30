using AutoMapper;
using Furny.DesignerFeature.Data;
using Furny.DesignerFeature.MappingProfiles.Resolvers;
using Furny.DesignerFeature.ViewModels;
using Furny.Model;

namespace Furny.DesignerFeature.MappingProfiles
{
    public class DesignerMappingProfile : Profile
    {
        public DesignerMappingProfile()
        {
            CreateMap<DesignerProfileDto, Designer>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<DesignerProfileAddressResolver>())
                .ReverseMap()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<Designer, DesignerProfileViewModel>()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(e => e.UserAddress.Address.Id))
                .ForMember(e => e.StreetAndHouse, opt => opt.MapFrom(e => e.UserAddress.StreetAndHouse));

            CreateMap<PanelCutter, DesignerFavoriteViewModel>();
        }
    }
}
