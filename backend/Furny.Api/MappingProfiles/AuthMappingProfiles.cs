using AutoMapper;
using Furny.Data;
using Furny.MappingProfiles.Resolvers;
using Furny.Models;
using Furny.ServiceInterfaces;
using System;

namespace Furny.MappingProfiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles()
        {
            CreateMap<FirebaseUserDto, Designer>().ReverseMap();

            CreateMap<FirebaseUserDto, PanelCutter>().ReverseMap();

            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<UserAddress, UserAddressDto>();

            CreateMap<DesignerRegisterDto, Designer>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<AddressResolver>())
                .ReverseMap();

            CreateMap<PanelCutterRegisterDto, PanelCutter>()
                .ForMember(e => e.UserAddress, opt => opt.MapFrom<AddressResolver>())
                .ReverseMap();
        }
    }
}
