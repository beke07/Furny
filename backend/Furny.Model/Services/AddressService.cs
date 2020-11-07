using Furny.Common.Services;
using Furny.Model.ServiceInterfaces;
using Microsoft.Extensions.Configuration;

namespace Furny.Model.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        private static string collectionName = "addresses";

        public AddressService(IConfiguration configuration) : base(configuration, collectionName)
        { }
    }
}
