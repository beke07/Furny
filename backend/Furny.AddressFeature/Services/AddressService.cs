using Furny.AddressFeature.ServiceInterfaces;
using Furny.Common.Services;
using Furny.Model;
using Microsoft.Extensions.Configuration;

namespace Furny.AddressFeature.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        private static string collectionName = "addresses";

        public AddressService(IConfiguration configuration) : base(configuration, collectionName)
        { }
    }
}
