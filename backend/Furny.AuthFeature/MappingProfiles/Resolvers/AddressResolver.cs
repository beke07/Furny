using AutoMapper;
using Furny.AuthFeature.Data;
using Furny.Model;
using Furny.Model.ServiceInterfaces;
using System;

namespace Furny.AuthFeature.MappingProfiles.Resolvers
{
    public class AddressResolver : IValueResolver<AuthFeatureRegisterBaseDto, ApplicationUser, UserAddress>
    {
        private readonly IAddressService _addressService;

        public AddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(AuthFeatureRegisterBaseDto source, ApplicationUser destination, UserAddress destMember, ResolutionContext context)
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
