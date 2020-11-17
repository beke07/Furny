using AutoMapper;
using Furny.AddressFeature.ServiceInterfaces;
using Furny.AuthFeature.Data;
using Furny.Model;

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
                return new UserAddress();
            
            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.UserAddress.Address.Id).Result,
                StreetAndHouse = source.UserAddress.StreetAndHouse
            };
        }
    }
}
