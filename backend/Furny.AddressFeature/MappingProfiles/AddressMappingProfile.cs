using AutoMapper;
using Furny.AddressFeature.Data;
using Furny.AddressFeature.ViewModels;
using Furny.Model;

namespace Furny.AddressFeature.MappingProfiles
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressFeatureAddressDto>().ReverseMap();
            CreateMap<Address, AddressFeatureAddressViewModel>().ReverseMap();
        }
    }
}
