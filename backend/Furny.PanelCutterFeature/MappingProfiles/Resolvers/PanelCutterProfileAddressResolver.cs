using AutoMapper;
using Furny.AddressFeature.ServiceInterfaces;
using Furny.Model;
using Furny.PanelCutterFeature.Data;

namespace Furny.DesignerFeature.MappingProfiles.Resolvers
{
    public class PanelCutterProfileAddressResolver : IValueResolver<PanelCutterProfileDto, PanelCutter, UserAddress>
    {
        private readonly IAddressService _addressService;

        public PanelCutterProfileAddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(PanelCutterProfileDto source, PanelCutter destination, UserAddress destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.AddressId)) return null;

            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.AddressId).Result,
                StreetAndHouse = source.StreetAndHouse
            };
        }
    }
}
