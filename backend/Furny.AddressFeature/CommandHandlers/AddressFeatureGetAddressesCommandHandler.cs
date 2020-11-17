using AutoMapper;
using Furny.AddressFeature.Commands;
using Furny.AddressFeature.ServiceInterfaces;
using Furny.AddressFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.AdFeature.Commands
{
    public class AddressFeatureGetAddressesCommandHandler : 
        IRequestHandler<AddressFeatureGetAddressesCommand, IList<AddressFeatureAddressViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;

        public AddressFeatureGetAddressesCommandHandler(
            IMapper mapper,
            IAddressService addressService)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        public async Task<IList<AddressFeatureAddressViewModel>> Handle(AddressFeatureGetAddressesCommand request, CancellationToken cancellationToken)
        {
            var addresses = await _addressService.Get();
            return _mapper.Map<IList<AddressFeatureAddressViewModel>>(addresses);
        }
    }
}
