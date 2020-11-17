using AutoMapper;
using Furny.AddressFeature.ServiceInterfaces;
using Furny.DesignerFeature.Data;
using Furny.Model;

namespace Furny.DesignerFeature.MappingProfiles.Resolvers
{
    public class DesignerProfileAddressResolver : IValueResolver<DesignerProfileDto, Designer, UserAddress>
    {
        private readonly IAddressService _addressService;

        public DesignerProfileAddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(DesignerProfileDto source, Designer destination, UserAddress destMember, ResolutionContext context)
        {
            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.AddressId).Result,
                StreetAndHouse = source.StreetAndHouse
            };
        }
    }
}
