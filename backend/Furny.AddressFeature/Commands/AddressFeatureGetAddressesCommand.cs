using Furny.AddressFeature.ViewModels;
using Furny.Common.Commands;
using System.Collections.Generic;

namespace Furny.AddressFeature.Commands
{
    public class AddressFeatureGetAddressesCommand : GetCommand<IList<AddressFeatureAddressViewModel>>
    {
        public static AddressFeatureGetAddressesCommand Create()
            => new AddressFeatureGetAddressesCommand();
    }
}
