using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;

namespace Furny.MappingProfiles.Resolvers
{
    public class ProfileAddressResolver : 
        IValueResolver<PanelCutterProfileDto, PanelCutter, UserAddress>,
        IValueResolver<DesignerProfileDto, Designer, UserAddress>
    {
        private readonly IAddressService _addressService;

        public ProfileAddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(PanelCutterProfileDto source, PanelCutter destination, UserAddress destMember, ResolutionContext context)
        {
            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.AddressId).Result,
                StreetAndHouse = source.StreetAndHouse
            };
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
