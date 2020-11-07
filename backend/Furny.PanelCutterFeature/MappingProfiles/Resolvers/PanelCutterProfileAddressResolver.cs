using AutoMapper;
using Furny.Model;
using Furny.Model.ServiceInterfaces;
using Furny.PanelCutterFeature.Commands;

namespace Furny.DesignerFeature.MappingProfiles.Resolvers
{
    public class PanelCutterProfileAddressResolver : IValueResolver<PanelCutterProfileCommand, PanelCutter, UserAddress>
    {
        private readonly IAddressService _addressService;

        public PanelCutterProfileAddressResolver(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public UserAddress Resolve(PanelCutterProfileCommand source, PanelCutter destination, UserAddress destMember, ResolutionContext context)
        {
            return new UserAddress()
            {
                Address = _addressService.FindByIdAsync(source.AddressId).Result,
                StreetAndHouse = source.StreetAndHouse
            };
        }
    }
}
