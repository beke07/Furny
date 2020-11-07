using AutoMapper;
using Furny.Data;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;

namespace Furny.MappingProfiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles()
        {
            CreateMap<FirebaseUserCommand, Designer>().ReverseMap();

            CreateMap<FirebaseUserCommand, PanelCutter>().ReverseMap();

            CreateMap<AddressCommand, Address>().ReverseMap();

            CreateMap<UserAddress, UserAddressCommand>();

            CreateMap<DesignerRegisterCommand, Designer>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<AddressResolver>())
                .ReverseMap();

            CreateMap<PanelCutterRegisterCommand, PanelCutter>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<AddressResolver>())
                .ReverseMap();
        }
    }
}
