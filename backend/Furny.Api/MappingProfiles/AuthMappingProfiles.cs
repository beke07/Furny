using AutoMapper;
using Furny.Data;
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

    public class AddressResolver : IValueResolver<RegisterBaseDto, ApplicationUser, UserAddress>
    {
        private readonly IAddressService _addressService;

        public AddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(RegisterBaseDto source, ApplicationUser destination, UserAddress destMember, ResolutionContext context)
        {
            if (source?.UserAddress == null)
            {
                throw new Exception("Mappelés nem sikerült, mert a megadott tulajdonság üres!");
            }

            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.UserAddress.Address._id).Result,
                StreetAndHouse = source.UserAddress.StreetAndHouse
            };
        }
    }
}
