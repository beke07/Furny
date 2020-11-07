using AutoMapper;
using Furny.DesignerFeature.Data;
using Furny.Model;
using Furny.Model.ServiceInterfaces;

namespace Furny.DesignerFeature.MappingProfiles.Resolvers
{
    public class DesignerProfileAddressResolver : IValueResolver<DesignerUpdateProfileDto, Designer, UserAddress>
    {
        private readonly IAddressService _addressService;

        public DesignerProfileAddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(DesignerUpdateProfileDto source, Designer destination, UserAddress destMember, ResolutionContext context)
        {
            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.AddressId).Result,
                StreetAndHouse = source.StreetAndHouse
            };
        }
    }
}
