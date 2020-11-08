using AutoMapper;
using Furny.AuthFeature.Data;
using Furny.AuthFeature.MappingProfiles.Resolvers;
using Furny.Model;

namespace Furny.AuthFeature.MappingProfiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles()
        {
            CreateMap<AuthFeatureFirebaseUserDto, Designer>().ReverseMap();

            CreateMap<AuthFeatureFirebaseUserDto, PanelCutter>().ReverseMap();

            CreateMap<AuthFeatureAddressDto, Address>().ReverseMap();

            CreateMap<UserAddress, AuthFeatureUserAddressDto>();

            CreateMap<AuthFeatureDesignerRegisterDto, Designer>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<AddressResolver>())
                .ReverseMap();

            CreateMap<AuthFeaturePanelCutterRegisterDto, PanelCutter>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<AddressResolver>())
                .ReverseMap();
        }
    }
}
